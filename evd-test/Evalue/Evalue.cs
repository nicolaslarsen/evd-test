using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace evd_test
{
    public abstract class Evalue
    {
        public string Header { get; set; }

        public int LeveranceID;
        public DateTime LeveranceDato;
        public int EjdNr;
        public int KomNr;
        public long ModelVaerdi;
        public DateTime ModelDato;
        public long HandelsPris;
        public DateTime HandelsDato; 
        public int ErIUdbud;
        public DateTime FoersteUdbudsdato;
        public DateTime SenesteUdbudsDato;
        public long FoersteUdbudsPris;
        public long SenesteUdsbudsPris;

        // Just a null constructor
        public Evalue(){}

        public Evalue(int leveranceID, DateTime leveranceDato, 
            int ejdNr, int komNr, long modelVaerdi, DateTime modelDato, 
            long handelsPris, DateTime handelsDato, int erIUdbud, 
            DateTime foersteUdbudsdato, DateTime senesteUdbudsDato, 
            long foersteUdbudsPris, long senesteUdsbudsPris)
        {
            LeveranceID = leveranceID;
            LeveranceDato = leveranceDato;
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
        }

        // TODO: Move this function to somewhere more accessible 
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

        public abstract void Init(string dataLine);
        public abstract string ToCsv();
        public abstract override string ToString();
    }
}
