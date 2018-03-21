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
        private StoreProperty<EvalueBEC> localPropStore = new StoreProperty<EvalueBEC>();

        private List<EvalueBEC> localOldFile = new List<EvalueBEC>();
        private List<EvalueBEC> localNewFile = new List<EvalueBEC>();

        private Statistic<EvalueBEC> stat = new Statistic<EvalueBEC>();

        public int GetEjendom()
        {
            EvalueTest<EvalueBEC>.TryCollectData(testPathOld, ref localOldFile, 1, localPropStore);


            return 0;
        }

        public int TestStoreProperty()
        {
            

            return 0;
        }
    }
}
