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
            PropStore.AddIndex(evalue.KomNr, evalue.EjdNr, Evalues.Count() - 1);

            return 0;
        }

        public T GetProperty(int komKode, int ejdNr)
        {
            if (Evalues.ContainsKey(komKode))
            {
                if (Evalues[komKode].ContainsKey(ejdNr))
                {
                    return Evalues[komKode][ejdNr]; 
                }
            }

            return default;
        }

        // Number of properties in the EvalueStorage
        public int Length()
        {
            return Evalues.Values.Sum(x => x.Count());
        }
    }
}
