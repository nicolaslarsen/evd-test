using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace evd_test
{
    public class Statistic
    {
        private EvalueStorage FirstFile;
        private EvalueStorage SecondFile;

        private string Header = "KomNr;EjdNr;Gammel e-value;Ny e-value;Handelspris;Handelsdato;Ny e-value i forhold til gammel; Ny e-value i forhold til handelspris";

        public Statistic() { }

        public Statistic(EvalueStorage firstFile, EvalueStorage secondFile) 
        {
            FirstFile = firstFile;
            SecondFile = secondFile;
        } 

        public StatisticProperty CompareProperties(Evalue first, Evalue scnd)
        {
            // This can be removed if we decide to include nulls. 
            // first should never be null. Just a sanity check.
            if (scnd == null || first == null)
            {
                return null;
            }
            int komNr = first.KomNr;
            int ejdNr = first.EjdNr;
            long evalueOld = first.ModelVaerdi;
            long evalueNew = 0;
            long handelspris = 0;
            DateTime handelsDato = new DateTime();
            // We already checked for this, but if we decide to include these in the stats,
            // we can just remove the null check above. 
            if (scnd != null) 
            {
                evalueNew = scnd.ModelVaerdi;
                handelspris = scnd.HandelsPris;
                handelsDato = scnd.HandelsDato;
            }
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

        public List<StatisticProperty> BuildStats()
        {
            List<StatisticProperty> statList = new List<StatisticProperty>();


            foreach (Evalue Ejendom in FirstFile.Evalues)
            {
                Evalue scndEjd = SecondFile.GetProperty(Ejendom.KomNr, Ejendom.EjdNr);
                StatisticProperty statProp = CompareProperties(Ejendom, scndEjd);
                if (statProp != null)
                {
                    statList.Add(statProp);
                }
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

        // Without saving it in a statList basically
        public List<string> BuildStatStringDirectly()
        {
            // New list, just add the header
            List<string> output = new List<string>
            {
                Header
            };

            foreach (Evalue Ejendom in FirstFile.Evalues)
            {
                Evalue scndEjd = SecondFile.GetProperty(Ejendom.KomNr, Ejendom.EjdNr);
                StatisticProperty statProp = CompareProperties(Ejendom, scndEjd);
                if (statProp != null)
                {
                    output.Add(statProp.ToCsv());
                }
            }
            return output;
        }
    }
}