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
        // Stores the komkode and ejdnr in dictionaries, 
        // contains the indexes for an ejendom in the "file" arrays
        private StoreProperty<T> PropStore;

        public Statistic(List<T> firstFile, List<T> secondFile, StoreProperty<T> propStore)
        {
            FirstFile = firstFile;
            SecondFile = secondFile;
            PropStore = propStore;
        } 

        public StatisticProperty CompareProperties(T first, T scnd)
        {
            int komNr = first.KomNr;
            int ejdNr = first.EjdNr;
            long evalueOld = first.ModelVaerdi;
            long evalueNew = scnd.ModelVaerdi;
            long handelspris = scnd.HandelsPris;
            DateTime handelsDato = scnd.HandelsDato;

            Decimal evalueNewCompOld = 0;
            Decimal evalueNewCompHandelspris = 0;

            if (evalueNew != 0)
            {
                if (evalueOld != 0)
                {
                    evalueNewCompOld = (Decimal) evalueNew / (Decimal) evalueOld;
                }
                
                if (handelspris != 0)
                {
                    evalueNewCompHandelspris = (Decimal) evalueNew / (Decimal) handelspris;
                }
            }


            StatisticProperty statProp = new StatisticProperty(komNr, ejdNr, 
                evalueOld, evalueNew, handelspris, handelsDato, evalueNewCompOld,
                evalueNewCompHandelspris);

            return statProp;
        }

        public List<string> BuildStats()
        {
            List<string> output = new List<string>();

            foreach(T Ejendom in FirstFile)
            {
                T scndEjd = PropStore.GetEjendom(Ejendom.KomNr, Ejendom.EjdNr, SecondFile);

                StatisticProperty statProp = CompareProperties(Ejendom, scndEjd);

                output.Add(statProp.ToCsv());
            }

            return output;
        }
    }
}