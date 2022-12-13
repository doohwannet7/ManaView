using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Manaview
{
    public class VersionData
    {
       


    }

    public class Etc
    {
        private string _programTitle = "ManaView 1.0";
        public string ProgramTtitle
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
