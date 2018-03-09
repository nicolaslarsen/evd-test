using evd_test.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace evd_test
{
    public class StatisticProperty
    {
        public int KomNr;
        public int EjdNr;
        public long EvalueOld;
        public long EvalueNew;
        public long Handelspris;
        public DateTime HandelsDato;
        // New evalue in regards to the old
        public Decimal EvalueNewCompOld;
        public Decimal EvalueNewCompHandelspris;

        public StatisticProperty()
        { 
        }

        public StatisticProperty(int komNr, int ejdNr, long evalueOld, long evalueNew, 
            long handelspris, DateTime handelsDato, Decimal evalueNewCompOld, 
            Decimal evalueNewCompHandelspris)
        {
            KomNr = komNr;
            EjdNr = ejdNr;
            EvalueOld = evalueOld;
            EvalueNew = evalueNew;
            Handelspris = handelspris;
            HandelsDato = handelsDato;
            EvalueNewCompOld = evalueNewCompOld;
            EvalueNewCompHandelspris = evalueNewCompHandelspris;
        }

        public string ToCsv()
        {
            string output = "";

            // Just need the CommonFunc.DateCsv function.
            EvalueBEC dummy = new EvalueBEC();
            CommonFunc lel = new CommonFunc();

            output = KomNr + ";" + EjdNr + ";" + EvalueOld + ";" + EvalueNew + ";"
                + Handelspris + ";" + CommonFunc.DateCsv(HandelsDato) + ";" + EvalueNewCompOld + ";" 
                + EvalueNewCompHandelspris; 

            return output; 
        }
    }
}