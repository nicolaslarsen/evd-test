using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace evd_test
{
    public class EvalueLSB : Evalue
    {
        private DateTime HandelSkoedeDato;
        private int HandelMatch;
        private int VurderingsAar;
        private DateTime VurderingsDato;
        private long Ejendomsvaerdi;
        private long Grundvaerdi;
  
        public override void Init(string dataLine)
        {
            Header = "LeveranceNummer" + ";" +
            "LeveranceDato" + ";" +
            "EjdNr" + ";" +
            "KomNr" + ";" +
            "ModelVaerdi" + ";" +
            "ModelDato" + ";" +
            "HandelPris" + ";" +
            "HandelDato" + ";" +
            "HandelSkoedeDato" + ";" +
            "HandelMatch" + ";" +
            "ErIUdbud" + ";" +
            "FoersteUdbudsDato" + ";" +
            "SenesteUdbudsDato" + ";" +
            "FoersteUdsbudsPris" + ";" +
            "SenesteUdbudsPris" + ";" +
            "Vurderingsaar" + ";" +
            "Vurderingsdato" + ";" +
            "Ejendomsvaerdi" + ";" +
            "Grundvaerdi" + "\n";

            string[] fields = dataLine.Split(';');

            Int32.TryParse(fields[0], out LeveranceID);
            DateTime.TryParse(fields[1], out LeveranceDato);
            Int32.TryParse(fields[2], out EjdNr);
            Int32.TryParse(fields[3], out KomNr);
            Int64.TryParse(fields[4], out ModelVaerdi);
            DateTime.TryParse(fields[5], out ModelDato);
            Int64.TryParse(fields[6], out HandelsPris);
            DateTime.TryParse(fields[7], out HandelsDato);
            DateTime.TryParse(fields[8], out HandelSkoedeDato);
            Int32.TryParse(fields[9], out HandelMatch);
            Int32.TryParse(fields[10], out ErIUdbud);
            DateTime.TryParse(fields[11], out FoersteUdbudsdato);
            DateTime.TryParse(fields[12], out SenesteUdbudsDato);
            Int64.TryParse(fields[13], out FoersteUdbudsPris);
            Int64.TryParse(fields[14], out SenesteUdsbudsPris);
            Int32.TryParse(fields[15], out VurderingsAar);
            DateTime.TryParse(fields[16], out VurderingsDato);
            Int64.TryParse(fields[17], out Ejendomsvaerdi);
            Int64.TryParse(fields[18], out Grundvaerdi);
        }

        public override string ToCsv()
        {
            string output = "" +
            LeveranceID + ";" +
            DateCsv(LeveranceDato) + ";" +
            EjdNr + ";" +
            KomNr + ";" +
            ModelVaerdi + ";" +
            DateCsv(ModelDato) + ";" +
            HandelsPris + ";" +
            DateCsv(HandelsDato) + ";" +
            DateCsv(HandelSkoedeDato) + ";" +
            HandelMatch + ";" +
            ErIUdbud + ";" +
            DateCsv(FoersteUdbudsdato) + ";" +
            DateCsv(SenesteUdbudsDato) + ";" +
            FoersteUdbudsPris + ";" +
            SenesteUdsbudsPris + ";" +
            VurderingsAar + ";" +
            DateCsv(VurderingsDato) + ";" +
            Ejendomsvaerdi + ";" +
            Grundvaerdi + "\n";
            return output;
        }

        public override string ToString()
        {
            string output = "" +
            "LeveranceID: " + LeveranceID + "\n" +
            "LeveranceDato: " + DateCsv(LeveranceDato) + "\n" +
            "EjdNr: " + EjdNr + "\n" +
            "KomNr: " + KomNr + "\n" +
            "ModelVaerdi: " + ModelVaerdi + "\n" +
            "DateCsv(ModelDato: )" + DateCsv(ModelDato) + "\n" +
            "HandelsPris: " + HandelsPris + "\n" +
            "HandelsDato: " + DateCsv(HandelsDato) + "\n" +
            "HandelSkoedeDato: " + DateCsv(HandelSkoedeDato) + "\n" +
            "HandelMatch: " + HandelMatch + "\n" +
            "ErIUdbud: " + ErIUdbud + "\n" +
            "FoersteUdbudsdato: " + DateCsv(FoersteUdbudsdato) + "\n" +
            "SenesteUdbudsDato: " + DateCsv(SenesteUdbudsDato) + "\n" +
            "FoersteUdbudsPris: " + FoersteUdbudsPris + "\n" +
            "SenesteUdsbudsPris: " + SenesteUdsbudsPris + "\n" +
            "VurderingsAar: " + VurderingsAar + "\n" +
            "DateCsv(VurderingsDato: )" + DateCsv(VurderingsDato) + "\n" +
            "Ejendomsvaerdi: " + Ejendomsvaerdi + "\n" +
            "Grundvaerdi: " + Grundvaerdi + "\n";
            return output;
        }
    }
}
