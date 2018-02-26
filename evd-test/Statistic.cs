using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace evd_test
{
    public class Statistic<T> where T: Evalue, new()
    {
        private List<T> FirstFile;
        private List<T> SecondFile;
        
        public Statistic(List<T> firstFile, List<T> secondFile)
        {
            FirstFile = firstFile;
            SecondFile = secondFile;
        } 

        public int BuildStats()
        {
            string output = "";

            foreach(T Ejendom in FirstFile)
            {
                
            }

            return 0;
        }
    }
}
