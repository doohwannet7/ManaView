using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manaview
{
    public class ManaviewHost : IDisposable
    {
        private static object syncRoot = new object();
        //volatile : 동시에 실행되는 여러 스레드에 의해 필드가 수정될 수 있음
        //컴파일러가 반드시 메모리를 읽도록 하는 용도
        //cpu는 최적화를 위해 이미 캐싱한 변수에 대해서는 메모리까지 다녀오지 않음
        //멀티스레드의 경우 A스레드에서 값이 변경되었다면 B스레드가 올바른 값을 받기 위해서는 반드시 메모리까지 다녀와야 한다
        //이때 메모리에서 값을 읽어올 것을 명시하는 키워드
        private static volatile ManaviewHost instance;

        public static ManaviewHost Inst
        {
            get
            {
                if(instance == null)
                {
                    lock(syncRoot)
                    {
                        if(instance == null)
                        {
                            instance = new ManaviewHost();
                        }
                    }
                }

                return instance;
            }
        }

        public VersionData VersionInfo { get; set; }

        public ManaviewHost()
        {
            InitializeHost();
        }

        private void InitializeHost()
        {
            VersionInfo = new VersionData();
        }

        public void Dispose()
        {
            //throw new NotImplementedException();
        }
    }
}
