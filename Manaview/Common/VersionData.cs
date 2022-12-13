using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manaview
{
    public class VersionData
    {
        private Etc _etc = null;
        public Etc Etc
        {
            get
            {
                if(_etc == null)
                {
                    _etc = new Etc();
                }
                return _etc;
            }
            set
            {
                _etc = value;
            }
        }
    }

    public class Etc
    {
        private string _programTitle = "ManaView 1.0";
        public string ProgramTitle
        {
            get
            {
                return _programTitle;
            }
            set
            {
                _programTitle = value;
            }
        }
    }
}
