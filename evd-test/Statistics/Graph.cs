using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace evd_test
{
    public class Graph
    {
        // 1 for every 5% up to 100% and two extra for 0 and 100+% 
        public int[] GraphPoints = new int[22];
        public List<StatisticProperty> StatList;

        public Graph(){}

        public Graph(List<StatisticProperty> statList)
        {
            StatList = statList;
        }

        public int Categorize(Decimal evalueDiff)
        {
            // The smallest group aside from 0
            int group = 0;

            // Just an extra check, even though we will probably check before calling the function
            if (evalueDiff == 0)
            {
                return -1;
            }

            Decimal evalueDiffGroup = (evalueDiff * 100) - 100;

            // Get the absolute value
            if (evalueDiffGroup < 0)
            {
                evalueDiffGroup *= -1; 
            }

            while (group <= 100)
            {
                if (evalueDiffGroup <= group)
                {
                    return group / 5;
                }
                group += 5;
            }

            return 21;
        }

        public int FillGraph()
        {
            foreach (StatisticProperty statProp in StatList)
            {
                int group = Categorize(statProp.EvalueNewCompOld);
                if (group >= 0)
                {
                    GraphPoints[group]++;
                }
            }
            
            return 0;
        }

        public List<string> BuildOutputString()
        {
            List<string> GraphStrings = new List<string>();

            for (int i = 0; i < GraphPoints.Length; i++){
                int group = i * 5;
                string graphPointStr = "";
                
                switch (group)
                {
                    case 0:
                        graphPointStr = "0%;" + GraphPoints[i];
                        break;
                    case 105:
                        graphPointStr = "Over 100%;" + GraphPoints[i];
                        break;
                    default:
                        graphPointStr = group - 5 + "-" + group + "%;" + GraphPoints[i];
                        break;
                }

                GraphStrings.Add(graphPointStr);
            }
            
            return GraphStrings;
        }
    }
}