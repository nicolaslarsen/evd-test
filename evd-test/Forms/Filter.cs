using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace evd_test
{
    public class Filter
    {
        public int YearFrom;
        public int YearTo;
        public bool YearChecked;

        public Filter()
        {
            YearFrom    = -1;
            YearTo      = -1;
            YearChecked = false;
        }
    }
}
