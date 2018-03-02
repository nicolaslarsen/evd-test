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
        private StoreProperty<T> PropStore;

        public Statistic(List<T> firstFile, List<T> secondFile, StoreProperty<T> propStore)
        {
            FirstFile = firstFile;
            SecondFile = secondFile;
            PropStore = propStore;
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
                PropStore.GetEjendom(Ejendom.KomNr, Ejendom.EjdNr, SecondFile);

                output += ""; 
            }

            return 0;
        }
    }
}
