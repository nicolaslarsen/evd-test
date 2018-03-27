using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace evd_test.Test
{
    public class GraphTest
    {
        private string testPathOld = "c:/users/nr/desktop/e-quality/bec-realview-boligprismodel-v1_old.csv";
        private string testPathNew = "c:/users/nr/desktop/e-quality/bec-realview-boligprismodel-v1.csv";

        private EvalueStorage<EvalueBEC> localOldFile = new EvalueStorage<EvalueBEC>();
        private EvalueStorage<EvalueBEC> localNewFile = new EvalueStorage<EvalueBEC>();

        private Statistic<EvalueBEC> stat = new Statistic<EvalueBEC>();
       
        public int Categorize()
        {
            Console.WriteLine("\nCategorize() Test:\n---------------------------------------------");

            Graph graph = new Graph();
            // Categorize takes a evalueDifference. So 1 means there's no difference
            int zeroGroup = graph.Categorize(1m);

            Console.WriteLine("Group {0} is in the 0 group : {1}", 
                zeroGroup, zeroGroup == 0);

            // 1 1-1.05, 1.05-1.1, 1.1-1.15, 1.15-1.2, 1.2-1.25
            // 0   1        2        3          4         5 
            // So 1.25 should be in the 5th group.
            // Apart from the 0 group, all other groups contain the top value as well (e.g. 1.25)
            int fiveGroup = graph.Categorize(1.25m);

            Console.WriteLine("Group {0} is in the 5 group : {1}", 
                fiveGroup, fiveGroup == 5);

            // Over 100% difference
            int overHundred = graph.Categorize(2.1m);
            Console.WriteLine("Group {0} is in the 21 group : {1}", 
                overHundred, overHundred == 21);
            
            Console.WriteLine("---------------------------------------------\n");
            return 0;
        }
        
        public int FillGraph()
        {
            Console.WriteLine("\nFillGraph() Test:\n---------------------------------------------");

            int TryOld = EvalueTest<EvalueBEC>.TryCollectData(testPathOld, ref localOldFile, 1);
            int TryNew = EvalueTest<EvalueBEC>.TryCollectData(testPathNew, ref localNewFile, 2);

            stat = new Statistic<EvalueBEC>(localOldFile, localNewFile);
            List<StatisticProperty> statList = stat.BuildStats();

            Graph graph = new Graph(statList);

            graph.FillGraph();

            List<string> graphString = graph.BuildOutputString();
            foreach(string line in graphString)
            {
                Console.WriteLine(line);
            }

            Console.WriteLine("---------------------------------------------\n");
            return 0;
        }

        public int TestGraph()
        {
            Categorize();

            FillGraph();

            return 0;
        }
    }
}
