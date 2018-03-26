using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace evd_test
{
    public class EvalueStorage<T> where T: Evalue, new()
    {
        public List<T> Evalues;
        private StoreProperty<T> PropStore;


        public EvalueStorage()
        {
            // Just init list
            Evalues = new List<T>();
            PropStore = new StoreProperty<T>();
        }

        public int PutProperty(T evalue)
        {
            Evalues.Add(evalue);
            // The index to be added must be the last index of Evalues
            PropStore.AddIndex(evalue.KomNr, evalue.EjdNr, Evalues.Count() - 1);

            return 0;
        }

        public T GetProperty(int komKode, int ejdNr)
        {
            return PropStore.GetEjendom(komKode, ejdNr, Evalues);
        }

        // Number of properties in the EvalueStorage
        public int Length()
        {
            int length = Evalues.Count();

            if (PropStore.Length() == length)
            {
                return length;
            }

            // Just a check, there should always be an index for each evalue
            return -1;
        }
    }
}
