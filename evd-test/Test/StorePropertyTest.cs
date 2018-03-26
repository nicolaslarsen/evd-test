using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace evd_test.Test
{
    class StorePropertyTest
    {
        private string testPathOld = "c:/users/nr/desktop/e-quality/bec-realview-boligprismodel-v1_old.csv";
        private string testPathNew = "c:/users/nr/desktop/e-quality/bec-realview-boligprismodel-v1.csv";

        private EvalueStorage<EvalueBEC> localOldFile = new EvalueStorage<EvalueBEC>();
        private EvalueStorage<EvalueBEC> localNewFile = new EvalueStorage<EvalueBEC>();

        private Statistic<EvalueBEC> stat = new Statistic<EvalueBEC>();

        public int GetEjendom()
        {
            EvalueTest<EvalueBEC>.TryCollectData(testPathOld, ref localOldFile, 1);

            return 0;
        }

        public int TestStoreProperty()
        {
            

            return 0;
        }
    }
}
