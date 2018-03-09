using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace evd_test.Common
{
    public class CommonFunc
    {
        public static string DateCsv(DateTime dt)
        {
            if (dt == DateTime.MinValue)
            {
                return "";
            }
            if (dt.TimeOfDay.TotalSeconds == 0)
            {
                return dt.Date.ToString("yyyy-MM-dd");
            }
            return dt.ToString();
        }

    }
}
