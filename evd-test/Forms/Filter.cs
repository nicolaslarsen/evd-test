using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace evd_test
{
    public class Filter<T> where T: Evalue, new()
    {
        public int YearFrom;
        public int YearTo;
        public bool YearChecked;
        public int KomNr;
        public int EjdNr;
        public int HandelsprisFrom;
        public int HandelsprisTo;
        public bool ErIUdbud;

        public Filter()
        {
            YearFrom    = 0;
            YearTo      = 0;
            YearChecked = false;
            KomNr       = 0;
            EjdNr       = 0;
            HandelsprisFrom = -1;
            HandelsprisTo = 0;
            ErIUdbud    = false;
        }

        public int SetFilters(string yearFrom, string yearTo, bool yearChecked,
            string komNr, string ejdNr, string handelsPrisFrom, string handelsPrisTo, bool erIUdbud)
        {
            int retVal = 0;
            if (!Int32.TryParse(yearFrom, out YearFrom))
            {
                YearFrom = 0;
                if (yearFrom != "")
                {
                    retVal -= 1;
                }
            }

            if (!Int32.TryParse(yearTo, out YearTo))
            {
                YearTo = 0;
                if (yearTo != "")
                {
                    retVal -= 2;
                }
            }

            YearChecked = yearChecked;

            if (!Int32.TryParse(komNr, out KomNr))
            {
                KomNr = 0;
                if (komNr != "")
                {
                    retVal -= 3;
                }
            }

            if (!Int32.TryParse(ejdNr, out EjdNr))
            {
                EjdNr = 0;
                if (ejdNr != "")
                {
                    retVal -= 4;
                }
            }

            if (!Int32.TryParse(handelsPrisFrom, out HandelsprisFrom))
            {
                HandelsprisFrom = -1;
                if (handelsPrisFrom != "")
                {
                    retVal -= 5;
                }
            }

            if (!Int32.TryParse(handelsPrisTo, out HandelsprisTo))
            {
                HandelsprisTo = 0;
                if (handelsPrisTo != "")
                {
                    retVal -= 6;
                }
            }

            ErIUdbud = erIUdbud;

            return retVal;
        }

        public IEnumerable<T> YearFilter(IEnumerable<T> evalueList)
        {
            if (YearFrom > 0)
            {
                Console.WriteLine("YearFrom > 0");

                // If interval isn't checked or if the YearTo has no value (or 0)
                if (YearTo == 0 || !YearChecked)
                {
                    Console.WriteLine("!YearCheck || YearTo == 0");
                    Console.WriteLine("YearTo: {0}", YearTo);
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

        public IEnumerable<T> KomNrFilter(IEnumerable<T> evalueList)
        {
            if (KomNr > 0)
            {
                return evalueList.Where(prop =>
                    prop.KomNr == KomNr
                );
            }
            return evalueList; 
        }

        public IEnumerable<T> EjdNrFilter(IEnumerable<T> evalueList)
        {
            if (EjdNr > 0)
            {
                return evalueList.Where(prop =>
                    prop.EjdNr == EjdNr
                );
            }
            return evalueList;
        }

        public IEnumerable<T> HandelsprisFilter(IEnumerable<T> evalueList)
        {
            if (HandelsprisFrom >= 0)
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

            return evalueList;
        }

        public IEnumerable<T> ErIUdbudFilter(IEnumerable<T> evalueList)
        {
            if (ErIUdbud)
            {
                return evalueList.Where(prop =>
                    prop.ErIUdbud == 1
                );
            }
            return evalueList;
        } 

        // TODO: 
        public EvalueStorage<T> ApplyFilters(List<T> evalueList)
        {
            IEnumerable<T> filteredList = evalueList;

            filteredList = YearFilter(filteredList);
            filteredList = KomNrFilter(filteredList);
            filteredList = EjdNrFilter(filteredList);
            filteredList = HandelsprisFilter(filteredList);
            filteredList = ErIUdbudFilter(filteredList);

            // Create the storage class
            EvalueStorage<T> filteredStorage = new EvalueStorage<T>();

            // Fill it
            foreach (T prop in filteredList)
            {
                filteredStorage.PutProperty(prop);
            }
            return filteredStorage;
        }
    }
}
