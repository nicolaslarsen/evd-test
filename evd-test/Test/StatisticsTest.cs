using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace evd_test.Test
{
    class StatisticsTest
    {
        private string testPathOld = "c:/users/nr/desktop/e-quality/bec-realview-boligprismodel-v1_old.csv";
        private string testPathNew = "c:/users/nr/desktop/e-quality/bec-realview-boligprismodel-v1.csv";
        private StoreProperty<EvalueBEC> localPropStoreOld = new StoreProperty<EvalueBEC>();
        private StoreProperty<EvalueBEC> localPropStoreNew = new StoreProperty<EvalueBEC>();

        private List<EvalueBEC> localOldFile = new List<EvalueBEC>();
        private List<EvalueBEC> localNewFile = new List<EvalueBEC>();

        private Statistic<EvalueBEC> stat = new Statistic<EvalueBEC>();
       
        public StatisticsTest() { }

        public int CompareProperties()
        {
            EvalueBEC Old = new EvalueBEC();
            EvalueBEC New = new EvalueBEC();

            string dataLineOld = "69;69;2018-02-09T16:30:30.033;2012-05-29;1;26510;253;3117000;2018-02-01;2600000;2010-02-12;0;;;0;0;2532179017";
            string dataLineNew = "70;70;2018-03-09T16:30:32.333;2012-05-29;1;26510;253;3280000;2018-03-01;2600000;2010-02-12;0;;;0;0;2532179017";

            Old.Init(dataLineOld);
            New.Init(dataLineNew);

            StatisticProperty statProp;

            Console.WriteLine("\nCompareProperties() Test:\n---------------------------------------------");
            statProp = stat.CompareProperties(new EvalueBEC(), new EvalueBEC());
            Console.WriteLine("With both values as new EvalueBEC(): {0}", statProp.ToCsv());

            statProp = stat.CompareProperties(new EvalueBEC(), New);
            Console.WriteLine("With first value as new EvalueBEC(): {0}", statProp.ToCsv());

            statProp = stat.CompareProperties(Old, new EvalueBEC());
            Console.WriteLine("With second value as new EvalueBEC(): {0}", statProp.ToCsv());

            statProp = stat.CompareProperties(Old, New);
            Console.WriteLine("With both values as actual values: {0}", statProp.ToCsv());
            Console.WriteLine("---------------------------------------------\n");

            return 0;
        }

        public int BuildStats()
        {
            int TryOld = EvalueTest<EvalueBEC>.TryCollectData(testPathOld, ref localOldFile, 1, localPropStoreOld);
            int TryNew = EvalueTest<EvalueBEC>.TryCollectData(testPathNew, ref localNewFile, 2, localPropStoreNew);

            EvalueBEC uniqueEjd = new EvalueBEC();
            uniqueEjd.Init("69;69;2018-02-09T16:30:30.033;2012-05-29;1;26510;253;3117000;2018-02-01;2600000;2010-02-12;0;;;0;0;2532179017");

            localOldFile.Add(uniqueEjd);
            stat = new Statistic<EvalueBEC>(localOldFile, localNewFile, localPropStoreNew);

            List<StatisticProperty> statList = stat.BuildStats();

            Console.WriteLine("\nBuildStats() Test:\n---------------------------------------------");

            // Test for evaluenew = 0
            IEnumerable<StatisticProperty> NoEvalueNews = statList.Where(ejd => ejd.EvalueNew == 0);
            foreach (StatisticProperty sp in NoEvalueNews)
            {
                Console.WriteLine(sp.ToCsv());
            } 

            Console.WriteLine("---------------------------------------------\n");
            return 0;
        }

        public int TestStatistics()
        {
            CompareProperties();

            BuildStats();

            return 0;
        }
    }
}
