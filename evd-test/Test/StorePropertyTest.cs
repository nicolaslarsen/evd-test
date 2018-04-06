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

        private EvalueStorage localOldFile = new EvalueStorage();
        private EvalueStorage localNewFile = new EvalueStorage();

        private Statistic stat = new Statistic();

        public int GetEjendom()
        {
            Console.WriteLine("\n GetEjendom() test:\n---------------------------------------------");
            
            EvalueTest<EvalueBEC>.TryCollectData(testPathOld, ref localOldFile, 1);

            // It just uses the storeproperty on its own List anyway,
            // might as well use the EvalueStorage class.
            // Right now we're checking for a KeyNotFound.
            Evalue fest = localNewFile.GetProperty(localOldFile.Evalues[0].KomNr,
                localOldFile.Evalues[0].EjdNr);
            Console.WriteLine("Fest == null: {0}\n", fest == null);

            // Fill the actual table
            EvalueTest<EvalueBEC>.TryCollectData(testPathNew, ref localNewFile, 2);

            fest = localNewFile.GetProperty(localOldFile.Evalues[0].KomNr,
                localOldFile.Evalues[0].EjdNr);

            Console.WriteLine(fest);

            Console.WriteLine("---------------------------------------------\n");

            return 0;
        }

        public int TestStoreProperty()
        {
            GetEjendom();

            return 0;
        }
    }
}
