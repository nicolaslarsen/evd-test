using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace evd_test.Test
{
    class StatisticsTest
    {
        public int TestStatistics()
        {
            EvalueBEC ejendomBECOld = new EvalueBEC();
            EvalueBEC ejendomBECNew = new EvalueBEC();

            string dataLine_old = "69;69;2018-02-09T16:30:30.033;2012-05-29;1;26510;253;3117000;2018-02-01;2600000;2010-02-12;0;;;0;0;2532179017";
            string dataLine_new = "70;70;2018-03-09T16:30:32.333;2012-05-29;1;26510;253;3280000;2018-03-01;2600000;2010-02-12;0;;;0;0;2532179017";

            ejendomBECOld.Init(dataLine_old);
            ejendomBECNew.Init(dataLine_new);

            return 0;
        }
    }
}
