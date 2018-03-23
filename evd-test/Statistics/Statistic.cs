using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace evd_test
{
    public class Statistic<T> where T: Evalue, new()
    {
        private EvalueStorage<T> FirstFile;
        private EvalueStorage<T> SecondFile;

        private string Header = "KomNr;EjdNr;Gammel e-value;Ny e-value;Handelspris;Handelsdato;Ny e-value i forhold til gammel; Ny e-value i forhold til handelspris";

        public Statistic() { }
        public Statistic(EvalueStorage<T> firstFile, EvalueStorage<T> secondFile) 
        {
            FirstFile = firstFile;
            SecondFile = secondFile;
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
            else
            {
                Console.WriteLine(komNr + ";" + ejdNr + ";" + evalueOld + ";" + evalueNew + ";" + evalueNewCompOld);
            }

            StatisticProperty statProp = new StatisticProperty(komNr, ejdNr, 
                evalueOld, evalueNew, handelspris, handelsDato, evalueNewCompOld,
                evalueNewCompHandelspris);

            return statProp;
        }

        public List<StatisticProperty> BuildStats()
        {
            List<StatisticProperty> statList = new List<StatisticProperty>();


            foreach (T Ejendom in FirstFile)
            {
                T scndEjd = PropStore.GetEjendom(Ejendom.KomNr, Ejendom.EjdNr, SecondFile);

                StatisticProperty statProp = CompareProperties(Ejendom, scndEjd);
                // TO DELETE
                if (statProp.EvalueNew == 0)
                {
                    Console.WriteLine(
                        "EvalueOld: " + statProp.EvalueOld + "\n" +
                        "EvalueNew: " + statProp.EvalueNew + "\n" +
                        "Comparison: " + statProp.EvalueNewCompOld + "\n"
                    );
                }

                statList.Add(statProp);
            }

            return statList;
        }

        public List<string> BuildStatString(List<StatisticProperty> statList)
        {
            // New list, just add the header
            List<string> output = new List<string>
            {
                Header
            };

            foreach (StatisticProperty statProp in statList)
            {
                output.Add(statProp.ToCsv());
            }

            return output;
        }

        public List<string> BuildStatStringDirectly()
        {
            // New list, just add the header
            List<string> output = new List<string>
            {
                Header
            };

            foreach (T Ejendom in FirstFile)
            {
                T scndEjd = PropStore.GetEjendom(Ejendom.KomNr, Ejendom.EjdNr, SecondFile);

                StatisticProperty statProp = CompareProperties(Ejendom, scndEjd);

                output.Add(statProp.ToCsv());
            }
            return output;
        }
    }
}