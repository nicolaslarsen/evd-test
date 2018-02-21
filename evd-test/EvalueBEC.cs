using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace evd_test
{
    public class EvalueBEC : Evalue
    {
        public EvalueBEC(string dataLine) : base(dataLine)
        {
        }

        public static List<EvalueBEC> CollectData(string filename)
        {
            List<EvalueBEC> Evalues = new List<EvalueBEC>();
            string[] dataLines = File.ReadAllLines(filename);

            foreach (string dataLine in dataLines)
            {
                try
                {
                    Evalues.Add(new EvalueBEC(dataLine));
                }
                catch (IndexOutOfRangeException e)
                {
                    throw e;
                }
            }
            return Evalues;
        }

        public override string ToCsv()
        {
            string output = "" +
            LeveranceID + ";" +
            LeveranceGruppe + ";" +
            DateCsv(LeveranceDato) + ";" +
            DateCsv(ModelAendrDato) + ";" +
            FormatID + ";" +
            EjdNr + ";" +
            KomNr + ";" +
            ModelVaerdi + ";" +
            DateCsv(ModelDato) + ";" +
            HandelsPris + ";" +
            DateCsv(HandelsDato) + ";" +
            ErIUdbud + ";" +
            DateCsv(FoersteUdbudsdato) + ";" +
            DateCsv(SenesteUdbudsDato) + ";" +
            FoersteUdbudsPris + ";" +
            SenesteUdsbudsPris + ";" +
            KVHX + "\n";
            return output; 
        }
    }
}
