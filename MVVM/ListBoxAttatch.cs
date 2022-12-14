using System;
using System.Windows;
using System.Windows.Controls;
using System.Collections.Generic;


namespace ManaView.MVVM
{
    /// <summary>
    /// MultiDragListBox의 ScrollToView, SelectAll, UnSelectAll
    /// ViewModel에서 View 컨트롤의 Method를 호출하는 방법 제공 
    /// 출처: http://stackoverflow.com/questions/2596757/mvvm-how-can-i-select-text-in-a-textbox
    /// </summary>
    public static class ListBoxAttatch
    {
        public static readonly DependencyProperty ListBoxControllerProperty = DependencyProperty.RegisterAttached(
            "ListBoxController", typeof(IListBoxController), typeof(ListBoxAttatch),
            new FrameworkPropertyMetadata(null, OnListBoxControllerChanged));
        public static void SetListBoxController(UIElement element, IListBoxController value)
        {
            element.SetValue(ListBoxControllerProperty, value);
        }
        public static IListBoxController GetListBoxController(UIElement element)
        {
            return (IListBoxController)element.GetValue(ListBoxControllerProperty);
        }

        private static readonly Dictionary<IListBoxController, List<ListBox>> elements = new Dictionary<IListBoxController, List<ListBox>>();
        private static void OnListBoxControllerChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var element = d as ListBox;
            if (element == null)
                throw new ArgumentNullException("d");

            var oldController = e.OldValue as IListBoxController;
            if (oldController != null)
            {
                elements.Remove(oldController);
                oldController.ScrollToView -= ScrollToView;
                oldController.SelectAll -= SelectAll;
                oldController.UnSelectAll -= UnSelectAll;

            }

            var newController = e.NewValue as IListBoxController;
            if (newController != null)
            {
                List<ListBox> ListBoxs = null;

                if (elements.ContainsKey(newController) == true)
                {
                    bool IsValueExists = elements.TryGetValue(newController, out ListBoxs);
                    if (IsValueExists == true)
                    {
                        if (ListBoxs != null)
                        {
                            ListBoxs.Add(element);
                        }
                        else
                        {
                            List<ListBox> newList = new List<ListBox>();
                            newList.Add(element);

                            elements[newController] = newList;
                        }
                    }                    
                    else
                    {
                        List<ListBox> newList = new List<ListBox>();
                        newList.Add(element);

                        elements[newController] = newList;
                    }
                }
                else
                {
                    List<ListBox> newList = new List<ListBox>();
                    newList.Add(element);

                    elements.Add(newController, newList);
                }
                                
                newController.ScrollToView += ScrollToView;
                newController.SelectAll += SelectAll;
                newController.UnSelectAll += UnSelectAll;
            }
        }
        private static void DoFunc(IListBoxController sender, Action<ListBox> func)
        {
            List<ListBox> elementList;
            if (!elements.TryGetValue(sender, out elementList))
                throw new ArgumentException("sender");

            foreach (ListBox element in elementList)
            {
                if (element.Visibility == Visibility.Visible)
                {
                    element.Focus();
                    func(element);                    
                }
            }           
        }
        private static void ScrollToView(IListBoxController sender, object item)
        {
            DoFunc(sender, p => { p.ScrollIntoView(item); });            
        }
        private static void SelectAll(IListBoxController sender)
        {
            DoFunc(sender, p => { p.SelectAll(); });                        
        }
        private static void UnSelectAll(IListBoxController sender)
        {
            DoFunc(sender, p => { p.UnselectAll(); });                        
        } 
    }

    public interface IListBoxController
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

    public delegate void ScrollToViewEventHandler(IListBoxController sender, object ScrollItem); 
    public delegate void SelectAllEventHandler(IListBoxController sender); 
    public delegate void UnSelectAllEventHandler(IListBoxController sender); 
    

}
