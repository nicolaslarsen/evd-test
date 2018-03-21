using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace evd_test.Test
{
    class EvalueBECTest
    {
        public EvalueBECTest() { }

        public int Init()
        {
            EvalueBEC ejendomBECOld = new EvalueBEC();
            EvalueBEC ejendomBECNew = new EvalueBEC();

            bool oldHasEvalue = ejendomBECOld.ModelVaerdi > 0;
            bool newHasEvalue = ejendomBECNew.ModelVaerdi > 0;

            Console.WriteLine("Unitiated Old has evalue where evalue <= 0: " + ejendomBECOld.ModelVaerdi + ": " + !oldHasEvalue);
            Console.WriteLine("Unitiated New has evalue where evalue <= 0: " + ejendomBECNew.ModelVaerdi + ": " + !newHasEvalue);

            string dataLineOld = "69;69;2018-02-09T16:30:30.033;2012-05-29;1;26510;253;3117000;2018-02-01;2600000;2010-02-12;0;;;0;0;2532179017";
            string dataLineNew = "70;70;2018-03-09T16:30:32.333;2012-05-29;1;26510;253;3280000;2018-03-01;2600000;2010-02-12;0;;;0;0;2532179017";

            ejendomBECOld.Init(dataLineOld);
            ejendomBECNew.Init(dataLineNew);

            oldHasEvalue = ejendomBECOld.ModelVaerdi > 0;
            newHasEvalue = ejendomBECNew.ModelVaerdi > 0;

            Console.WriteLine("Old has evalue " + ejendomBECOld.ModelVaerdi + ": " + oldHasEvalue);
            Console.WriteLine("New has evalue " + ejendomBECNew.ModelVaerdi + ": " + newHasEvalue);

            return 0;
        }

        public int TestEvalueBEC() {
            Init();

            return 0;
        }
    }
}
