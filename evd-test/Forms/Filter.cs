using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace evd_test
{
    public class Filter
    {
        // Everything
        public int YearFrom;
        public int YearTo;
        public bool YearChecked;
        public int KomNr;
        public int EjdNr;
        public long HandelsprisFrom;
        public long HandelsprisTo;
        public bool ErIUdbud;
        public long EvalueFrom;
        public long EvalueTo;
        
        //Statistics
        public Decimal EvalueCompHandelsprisFrom;
        public Decimal EvalueCompHandelsprisTo;
        public Decimal EvalueNewCompOldFrom;
        public Decimal EvalueNewCompOldTo;



        public Filter()
        {
            YearFrom        = 0;
            YearTo          = 0;
            YearChecked     = false;
            KomNr           = 0;
            EjdNr           = 0;
            HandelsprisFrom = -1;
            HandelsprisTo   = -1;
            ErIUdbud        = false;
            EvalueFrom      = -1;
            EvalueTo        = -1;

            // Stats
            EvalueCompHandelsprisFrom   = -1m;
            EvalueCompHandelsprisTo     = -1m;
            EvalueNewCompOldFrom        = -1m;
            EvalueNewCompOldTo          = -1m;

        }

        public int IntFilter(string input, out int param, int defaultValue, 
            int errorNum)
        {
            if (!Int32.TryParse(input, out param))
            {
                param = defaultValue;
                if (input != "")
                {
                    return errorNum;
                }
            }
            return 0;
        }

        public int LongFilter(string input, out long param, long defaultValue, 
            int errorNum)
        {
            if (!Int64.TryParse(input, out param))
            {
                param = defaultValue;
                if (input != "")
                {
                    return errorNum;
                }
            }
            return 0;
        }

        public int DecimalFilter(string input, out Decimal param, Decimal defaultValue, 
            int errorNum)
        {
            if (!Decimal.TryParse(input, out param))
            {
                param = defaultValue;
                if (input != "")
                {
                    return errorNum;
                }
            }
            return 0;
        }

        public int SetFilters(string yearFrom, string yearTo, bool yearChecked,
            string komNr, string ejdNr, string handelsPrisFrom, string handelsPrisTo, bool erIUdbud,
            string evalueFrom, string evalueTo, string evalueCompHandelsprisFrom,
            string evalueCompHandelsprisTo, string evalueNewCompOldFrom, string evalueNewCompOldTo)
        {
            int retVal = 0;
            retVal += IntFilter(yearFrom, out YearFrom, 0, -1);
            retVal += IntFilter(yearTo, out YearTo, 0, -2); 
            YearChecked = yearChecked;
            retVal += IntFilter(komNr, out KomNr, 0, -3);
            retVal += IntFilter(ejdNr, out EjdNr, 0, -4);
            retVal += LongFilter(handelsPrisFrom, out HandelsprisFrom, -1, -5);
            retVal += LongFilter(handelsPrisTo, out HandelsprisTo, -1, -6);
            ErIUdbud = erIUdbud;
            retVal += LongFilter(evalueFrom, out EvalueFrom, -1, -7);
            retVal += LongFilter(evalueTo, out EvalueTo, -1, -8);
            retVal += DecimalFilter(evalueCompHandelsprisFrom,
                out EvalueCompHandelsprisFrom, -1m, -9);
            retVal += DecimalFilter(evalueCompHandelsprisTo,
                out EvalueCompHandelsprisTo, -1m, -10);
            retVal += DecimalFilter(evalueNewCompOldFrom,
                out EvalueNewCompOldFrom, -1m, -11);
            retVal += DecimalFilter(evalueNewCompOldTo,
                out EvalueNewCompOldTo, -1m, -12);

            return retVal;
        }

        public IEnumerable<Evalue> YearFilter(IEnumerable<Evalue> evalueList)
        {
            if (YearFrom > 0)
            {
                // If interval isn't checked or if the YearTo has no value (or 0)
                if (YearTo == 0 || !YearChecked)
                {
                    return evalueList.Where(prop =>
                        prop.HandelsDato.Year == YearFrom
                    );
                }
                else
                {
                    if (YearTo > 0)
                    {
                        // Where handelsdato.year is contained within
                        // YearFrom and YearTo
                        return evalueList.Where(prop =>
                            prop.HandelsDato.Year >= YearFrom &&
                            prop.HandelsDato.Year <= YearTo
                        );
                    }
                }
            }
            else
            {
                // If interval is checked, yearfrom has no value (or 0), 
                // but yearto has a value
                if (YearChecked && YearTo > 0)
                {
                    return evalueList.Where(prop =>
                        prop.HandelsDato.Year <= YearTo
                    );
                }
            }

            return evalueList;
        }

        public IEnumerable<Evalue> KomNrFilter(IEnumerable<Evalue> evalueList)
        {
            if (KomNr > 0)
            {
                return evalueList.Where(prop =>
                    prop.KomNr == KomNr
                );
            }
            return evalueList; 
        }

        public IEnumerable<Evalue> EjdNrFilter(IEnumerable<Evalue> evalueList)
        {
            if (EjdNr > 0)
            {
                return evalueList.Where(prop =>
                    prop.EjdNr == EjdNr
                );
            }
            return evalueList;
        }

        public IEnumerable<Evalue> HandelsprisFilter(IEnumerable<Evalue> evalueList)
        {
            if (HandelsprisFrom > -1)
            {
                if (HandelsprisTo > 0)
                {
                    return evalueList.Where(prop =>
                        prop.HandelsPris >= HandelsprisFrom &&
                        prop.HandelsPris <= HandelsprisTo
                    );
                }
                else
                {
                    return evalueList.Where(prop =>
                        prop.HandelsPris == HandelsprisFrom
                    );
                }
            }
            else
            {
                if (HandelsprisTo > -1)
                {
                    return evalueList.Where(prop =>
                        prop.HandelsPris <= HandelsprisTo
                    );
                }
            }

            return evalueList;
        }

        public IEnumerable<Evalue> ErIUdbudFilter(IEnumerable<Evalue> evalueList)
        {
            if (ErIUdbud)
            {
                return evalueList.Where(prop =>
                    prop.ErIUdbud == 1
                );
            }
            return evalueList;
        } 

        public IEnumerable<Evalue> EvalueFilter(IEnumerable<Evalue> evalueList)
        {
            if (EvalueFrom > -1)
            {
                if (EvalueTo > 0)
                {
                    return evalueList.Where(prop =>
                        prop.ModelVaerdi >= EvalueFrom &&
                        prop.ModelVaerdi <= EvalueTo
                    );
                }
                else
                {
                    return evalueList.Where(prop =>
                        prop.ModelVaerdi == EvalueFrom
                    );
                }
            }
            else
            {
                if (EvalueTo > -1)
                {
                    return evalueList.Where(prop =>
                        prop.ModelVaerdi <= EvalueTo
                    );
                }
            }

            return evalueList;
        }

        public IEnumerable<StatisticProperty> EvalueCompHandelsprisFilter(
            IEnumerable<StatisticProperty> statList)
        {
            if (EvalueCompHandelsprisFrom >= 0)
            {
                if (EvalueCompHandelsprisTo > 0)
                {
                    return statList.Where(prop =>
                        prop.EvalueNewCompHandelspris >= EvalueCompHandelsprisFrom
                        && prop.EvalueNewCompHandelspris <= EvalueCompHandelsprisTo
                    );
                }
                else
                {
                    return statList.Where(prop =>
                        prop.EvalueNewCompHandelspris == EvalueCompHandelsprisFrom
                    );
                }
            }
            else
            {
                if (EvalueCompHandelsprisTo > 0)
                {
                    return statList.Where(prop =>
                        prop.EvalueNewCompHandelspris <= EvalueCompHandelsprisTo
                    );
                }
            }
            return statList; 
        }

        public IEnumerable<StatisticProperty> EvalueNewCompOldFilter(
            IEnumerable<StatisticProperty> statList)
        {
            if (EvalueNewCompOldFrom >= 0)
            {
                if (EvalueNewCompOldTo > 0)
                {
                    return statList.Where(prop =>
                        prop.EvalueNewCompOld >= EvalueNewCompOldFrom
                        && prop.EvalueNewCompOld <= EvalueNewCompOldTo
                    );
                }
                else
                {
                    return statList.Where(prop =>
                        prop.EvalueNewCompOld == EvalueNewCompOldFrom
                    );
                }
            }
            else
            {
                if (EvalueNewCompOldTo > 0)
                {
                    return statList.Where(prop =>
                        prop.EvalueNewCompOld <= EvalueNewCompOldTo
                    );
                }
            }
            return statList; 
        }


        // Apply filters for a regular file 
        public EvalueStorage ApplyFilters(List<Evalue> evalueList)
        {
            IEnumerable<Evalue> filteredList = evalueList;

            filteredList = YearFilter(filteredList);
            filteredList = KomNrFilter(filteredList);
            filteredList = EjdNrFilter(filteredList);
            filteredList = HandelsprisFilter(filteredList);
            filteredList = ErIUdbudFilter(filteredList);
            filteredList = EvalueFilter(filteredList);

            // Create the storage class
            EvalueStorage filteredStorage = new EvalueStorage();

            // Fill it
            foreach (Evalue prop in filteredList)
            {
                filteredStorage.PutProperty(prop);
            }
            return filteredStorage;
        }

        // Apply filters for statistics
        public List<StatisticProperty> ApplyFilters(
            List<StatisticProperty> statList)
        {
            IEnumerable<StatisticProperty> filteredList = statList;

            return filteredList.ToList();
        }
    }
}
