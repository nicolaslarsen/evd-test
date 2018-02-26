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

        public int CompareProperties(T first, T scnd)
        {
            return 0;
        }

        public int BuildStats()
        {
            string output = "";

            foreach(T Ejendom in FirstFile)
            {
                // TODO: Think about making this faster, could be very costly
                T ScndEjendom = SecondFile.Single(scnd => scnd.KomNr == Ejendom.KomNr
                    && scnd.EjdNr == Ejendom.EjdNr);
                output += ""; 
            }

            return 0;
        }
    }
}
