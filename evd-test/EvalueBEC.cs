using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace evd_test
{
    public class EvalueBEC : Evalue {
        public int LeveranceGruppe;
        public DateTime ModelAendrDato;
        public int FormatID;
        public string KVHX;

        public override void Init(string dataLine)
        {
            string[] fields = dataLine.Split(';');

            Header = "LeveranceID" + ";" +
                "LeveranceGruppe" + ";" +
                "LeveranceDato" + ";" +
                "ModelAendrDato" + ";" +
                "FormatID" + ";" +
                "EjdNr" + ";" +
                "KomNr" + ";" +
                "ModelVaerdi" + ";" +
                "ModelDato" + ";" +
                "HandelsPris" + ";" +
                "HandelsDato" + ";" +
                "ErIUdbud" + ";" +
                "FoersteUdbudsdato" + ";" +
                "SenesteUdbudsDato" + ";" +
                "FoersteUdbudsPris" + ";" +
                "SenesteUdsbudsPris" + ";" +
                "KVHX" + "\n";
            Int32.TryParse(fields[0], out LeveranceID);
            Int32.TryParse(fields[1], out LeveranceGruppe);
            DateTime.TryParse(fields[2], out LeveranceDato);
            DateTime.TryParse(fields[3], out ModelAendrDato);
            Int32.TryParse(fields[4], out FormatID);
            Int32.TryParse(fields[5], out EjdNr);
            Int32.TryParse(fields[6], out KomNr);
            Int64.TryParse(fields[7], out ModelVaerdi);
            DateTime.TryParse(fields[8], out ModelDato);
            Int64.TryParse(fields[9], out HandelsPris);
            DateTime.TryParse(fields[10], out HandelsDato);
            Int32.TryParse(fields[11], out ErIUdbud);
            DateTime.TryParse(fields[12], out FoersteUdbudsdato);
            DateTime.TryParse(fields[13], out SenesteUdbudsDato);
            Int64.TryParse(fields[14], out FoersteUdbudsPris);
            Int64.TryParse(fields[15], out SenesteUdsbudsPris);
            KVHX = fields[16];
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
