using evd_test.Common;
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

        public override string Header()
        {

            return "LeveranceID" + ";" +
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
        }

        public override void Init(string dataLine)
        {
                        string[] fields = dataLine.Split(';');
           
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
            CommonFunc.DateCsv(LeveranceDato) + ";" +
            CommonFunc.DateCsv(ModelAendrDato) + ";" +
            FormatID + ";" +
            EjdNr + ";" +
            KomNr + ";" +
            ModelVaerdi + ";" +
            CommonFunc.DateCsv(ModelDato) + ";" +
            HandelsPris + ";" +
            CommonFunc.DateCsv(HandelsDato) + ";" +
            ErIUdbud + ";" +
            CommonFunc.DateCsv(FoersteUdbudsdato) + ";" +
            CommonFunc.DateCsv(SenesteUdbudsDato) + ";" +
            FoersteUdbudsPris + ";" +
            SenesteUdsbudsPris + ";" +
            KVHX;
            return output; 
        }

        public override string ToString()
        { 
            string output = "" +
            "LeveranceID : " + LeveranceID + "\n" +
            "LeveranceGruppe : " + LeveranceGruppe + "\n" +
            "LeveranceDato : " + CommonFunc.DateCsv(LeveranceDato) + "\n" +
            "ModelAendrDato : " + CommonFunc.DateCsv(ModelAendrDato) + "\n" +
            "FormatID : " + FormatID + "\n" +
            "EjdNr : " + EjdNr + "\n" +
            "KomNr : " + KomNr + "\n" +
            "ModelVaerdi : " + ModelVaerdi + "\n" +
            "ModelDato : " + CommonFunc.DateCsv(ModelDato) + "\n" +
            "HandelsPris : " + HandelsPris + "\n" +
            "HandelsDato : " + CommonFunc.DateCsv(HandelsDato) + "\n" +
            "ErIUdbud : " + ErIUdbud + "\n" +
            "FoersteUdbudsdato : " + CommonFunc.DateCsv(FoersteUdbudsdato) + "\n" +
            "SenesteUdbudsDato : " + CommonFunc.DateCsv(SenesteUdbudsDato) + "\n" +
            "FoersteUdbudsPris : " + FoersteUdbudsPris + "\n" +
            "SenesteUdsbudsPris : " + SenesteUdsbudsPris + "\n" +
            KVHX + "\n";
            return output; 
 
        }
    }
}
