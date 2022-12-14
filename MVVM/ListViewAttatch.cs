using System;
using System.Windows;
using System.Windows.Controls;
using System.Collections.Generic;


namespace NewHmi.MVVM
{
    /// <summary>
    /// MultiDragListView의 ScrollToView, SelectAll, UnSelectAll
    /// ViewModel에서 View 컨트롤의 Method를 호출하는 방법 제공 
    /// 출처: http://stackoverflow.com/questions/2596757/mvvm-how-can-i-select-text-in-a-textbox
    /// </summary>
    public static class ListViewAttatch
    {
        public static readonly DependencyProperty ListViewControllerProperty = DependencyProperty.RegisterAttached(
            "ListViewController", typeof(IListViewController), typeof(ListViewAttatch),
            new FrameworkPropertyMetadata(null, OnListViewControllerChanged));
        public static void SetListViewController(UIElement element, IListViewController value)
        {
            element.SetValue(ListViewControllerProperty, value);
        }
        public static IListViewController GetListViewController(UIElement element)
        {
            return (IListViewController)element.GetValue(ListViewControllerProperty);
        }

        private static readonly Dictionary<IListViewController, List<ListView>> elements = new Dictionary<IListViewController, List<ListView>>();
        private static void OnListViewControllerChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var element = d as ListView;
            if (element == null)
                throw new ArgumentNullException("d");

            var oldController = e.OldValue as IListViewController;
            if (oldController != null)
            {
                elements.Remove(oldController);
                oldController.ScrollToView -= ScrollToView;
                oldController.SelectAll -= SelectAll;
                oldController.UnSelectAll -= UnSelectAll;

            }

            var newController = e.NewValue as IListViewController;
            if (newController != null)
            {
                List<ListView> listViews = null;

                if (elements.ContainsKey(newController) == true)
                {
                    bool IsValueExists = elements.TryGetValue(newController, out listViews);
                    if (IsValueExists == true)
                    {
                        if (listViews != null)
                        {
                            listViews.Add(element);
                        }
                        else
                        {
                            List<ListView> newList = new List<ListView>();
                            newList.Add(element);

                            elements[newController] = newList;
                        }
                    }                    
                    else
                    {
                        List<ListView> newList = new List<ListView>();
                        newList.Add(element);

                        elements[newController] = newList;
                    }
                }
                else
                {
                    List<ListView> newList = new List<ListView>();
                    newList.Add(element);

                    elements.Add(newController, newList);
                }
                                
                newController.ScrollToView += ScrollToView;
                newController.SelectAll += SelectAll;
                newController.UnSelectAll += UnSelectAll;
            }
        }
        private static void DoFunc(IListViewController sender, Action<ListView> func)
        {
            List<ListView> elementList;
            if (!elements.TryGetValue(sender, out elementList))
                throw new ArgumentException("sender");

            foreach (ListView element in elementList)
            {
                if (element.Visibility == Visibility.Visible)
                {
                    element.Focus();
                    func(element);                    
                }
            }           
        }
        private static void ScrollToView(IListViewController sender, object item)
        {
            DoFunc(sender, p => { p.ScrollIntoView(item); });            
        }
        private static void SelectAll(IListViewController sender)
        {
            DoFunc(sender, p => { p.SelectAll(); });                        
        }
        private static void UnSelectAll(IListViewController sender)
        {
            DoFunc(sender, p => { p.UnselectAll(); });                        
        } 
    }

    public interface IListViewController
    {
        /// <summary>
        /// 해당 View로 스크롤 
        /// </summary>
        event ScrollToViewEventHandler ScrollToView;

        /// <summary>
        /// 전체 선택 
        /// </summary>
        event SelectAllEventHandler SelectAll;

        /// <summary>
        /// 전체 해제 
        /// </summary>
        event UnSelectAllEventHandler UnSelectAll;
    }

    public delegate void ScrollToViewEventHandler(IListViewController sender, object ScrollItem); 
    public delegate void SelectAllEventHandler(IListViewController sender); 
    public delegate void UnSelectAllEventHandler(IListViewController sender); 
    

}
