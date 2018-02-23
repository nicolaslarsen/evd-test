using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace evd_test
{
    public class EvalueLSB : Evalue
    {
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
            throw new NotImplementedException();
        }

        public override string ToCsv()
        {
            throw new NotImplementedException();
        }
    }
}
