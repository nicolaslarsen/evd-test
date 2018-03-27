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

        private EvalueStorage<EvalueBEC> localOldFile = new EvalueStorage<EvalueBEC>();
        private EvalueStorage<EvalueBEC> localNewFile = new EvalueStorage<EvalueBEC>();

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
            Console.WriteLine("\nBuildStats() Test:\n---------------------------------------------");

            int TryOld = EvalueTest<EvalueBEC>.TryCollectData(testPathOld, ref localOldFile, 1);
            int TryNew = EvalueTest<EvalueBEC>.TryCollectData(testPathNew, ref localNewFile, 2);

            stat = new Statistic<EvalueBEC>(localOldFile, localNewFile);
            List<StatisticProperty> statList = stat.BuildStats();

            // Test for evaluenew = 0. By new rules, this should be empty
            IEnumerable<StatisticProperty> NoEvalueNews = statList.Where(ejd => ejd.EvalueNew == 0);
            foreach (StatisticProperty sp in NoEvalueNews)
            {
                Console.WriteLine(sp.ToCsv());
            }

            Console.WriteLine("---------------------------------------------\n");
            return 0;
        }

        // We want to see if each property has a distinct KomNr and EjdNr
        public int UniqueTest()
        {
            int TryOld = EvalueTest<EvalueBEC>.TryCollectData(testPathOld, ref localOldFile, 1);

            Console.WriteLine("\nUniqueTest() Test:\n---------------------------------------------");

            Console.WriteLine("Test if lengths match: {0}: {1}",
                localOldFile.Length(), 0 < localOldFile.Length());

            Console.WriteLine("---------------------------------------------\n");
            return 0;
        }

        public int TestStatistics()
        {
            CompareProperties();

            BuildStats();

            UniqueTest();

            return 0;
        }
    }
}
