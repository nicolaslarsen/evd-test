using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace evd_test
{
    class Evalue
    {
        private int LeveranceID;
        private int LeveranceGruppe;
        private DateTime LeveranceDato;
        private DateTime ModelAendrDato;
        private int FormatID;
        private int EjdNr;
        private int KomNr;
        private long ModelVaerdi;
        private DateTime ModelDato;
        private long HandelsPris;
        private DateTime HandelsDato;
        private int ErIUdbud;
        private DateTime FoersteUdbudsdato;
        private DateTime SenesteUdbudsDato;
        private long FoersteUdbudsPris;
        private long SenesteUdsbudsPris;
        private string KVHX;

        public int GetEjdNr() => EjdNr;
        public int GetKomNr() => KomNr;
        public int GetErIUdbud() => ErIUdbud;

        public static string BECHeader =             
            "LeveranceID" + ";" +
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

        public static string LSBHeader =
            "LeveranceNummer" + ";" +
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

        // Just a null constructor
        public Evalue(){}

        public Evalue(int leveranceID, int leveranceGruppe, DateTime leveranceDato, 
            DateTime modelAendrDato, int formatID, int ejdNr, int komNr, long modelVaerdi,
            DateTime modelDato, long handelsPris, DateTime handelsDato, int erIUdbud, 
            DateTime foersteUdbudsdato, DateTime senesteUdbudsDato, long foersteUdbudsPris, 
            long senesteUdsbudsPris, string kVHX)
        {
            LeveranceID = leveranceID;
            LeveranceGruppe = leveranceGruppe;
            LeveranceDato = leveranceDato;
            ModelAendrDato = modelAendrDato;
            FormatID = formatID;
            EjdNr = ejdNr;
            KomNr = komNr;
            ModelVaerdi = modelVaerdi;
            ModelDato = modelDato;
            HandelsPris = handelsPris;
            HandelsDato = handelsDato;
            ErIUdbud = erIUdbud;
            FoersteUdbudsdato = foersteUdbudsdato;
            SenesteUdbudsDato = senesteUdbudsDato;
            FoersteUdbudsPris = foersteUdbudsPris;
            SenesteUdsbudsPris = senesteUdsbudsPris;
            KVHX = kVHX;
        }

        public Evalue(string dataLine)
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

        public static List<Evalue> CollectData(string filename)
        {
            List<Evalue> Evalues = new List<Evalue>();
            string[] dataLines = File.ReadAllLines(filename);

            foreach(string dataLine in dataLines)
            {
                try
                {
                    Evalues.Add(new Evalue(dataLine));
                }
                catch (IndexOutOfRangeException e)
                {
                    throw e;
                }
            }
            return Evalues;
        }

        public static string BuildOutputString(List<Evalue> firstFile, List<Evalue> secondFile)
        {
            string output = BECHeader;
            Random rand = new Random();
            List<int> randoms = new List<int>();

            int i = 0;
            while(i < 5)
            {
                int randIndex = rand.Next(firstFile.Count);

                // If we already used this property
                if (randoms.Contains(randIndex))
                {
                    continue;
                }
                Evalue firstEjendom = firstFile[randIndex];

                Evalue secondEjendom = secondFile.Find(scndEjd =>
                    firstEjendom.GetKomNr() == scndEjd.GetKomNr() &&
                    firstEjendom.GetEjdNr() == scndEjd.GetEjdNr()
                );

                output += firstEjendom.ToCsv() + secondEjendom.ToCsv() + "\n";

                randoms.Add(randIndex);
                i++;
            }

            // Only get properties that are "i udbud"
            List<Evalue> ScndIUdbud = secondFile.Where(ejd => ejd.GetErIUdbud() == 1).ToList();

            // i should be 5 at this point, so we get 5 more properties here
            while (i < 10)
            {
                int randIndex = rand.Next(ScndIUdbud.Count);

                // If we already used this property we skip it
                // (we haven't necessarily used it, but chances are, 
                // that this case won't be hit a lot anyway)
                if (randoms.Contains(randIndex))
                {
                    continue;
                }
                Evalue Ejendom = ScndIUdbud[randIndex];

                output += Ejendom.ToCsv() + "\n";

                randoms.Add(randIndex);
                i++;
            }
            return output;
        }

        public string DateCsv(DateTime dt)
        {
            if (dt == DateTime.MinValue)
            {
                return "";
            }
            if (dt.TimeOfDay.TotalSeconds == 0)
            {
                return dt.Date.ToString("yyyy-MM-dd");
            }
            return dt.ToString();
        }

        public string ToCsv()
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
        public override string ToString()
        {
            string output = "" +
            "LeveranceID: " + LeveranceID + "\n" +
            "LeveranceGruppe: " + LeveranceGruppe + "\n" +
            "LeveranceDato: " + LeveranceDato + "\n" +
            "ModelAendrDato: " + ModelAendrDato + "\n" +
            "FormatID: " + FormatID + "\n" +
            "EjdNr: " + EjdNr + "\n" +
            "KomNr: " + KomNr + "\n" +
            "ModelVaerdi: " + ModelVaerdi + "\n" +
            "ModelDato: " + ModelDato + "\n" +
            "HandelsPris: " + HandelsPris + "\n" +
            "HandelsDato: " + HandelsDato + "\n" +
            "ErIUdbud: " + ErIUdbud + "\n" +
            "FoersteUdbudsdato: " + FoersteUdbudsdato + "\n" +
            "SenesteUdbudsDato: " + SenesteUdbudsDato + "\n" +
            "FoersteUdbudsPris: " + FoersteUdbudsPris + "\n" +
            "SenesteUdsbudsPris: " + SenesteUdsbudsPris + "\n" +
            "KVHX: " + KVHX + "\n";
            return output;
        }
    }
}
