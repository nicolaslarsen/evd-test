using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace evd_test
{
    public class EvalueStorage
    {
        public List<Evalue> Evalues;
        public string Filename;
        private StoreProperty<Evalue> PropStore;


        public EvalueStorage()
        {
            // Just init list
            Evalues = new List<Evalue>();
            PropStore = new StoreProperty<Evalue>();
        }

        public EvalueStorage(string filename)
        {
            // Just init list
            Evalues = new List<Evalue>();
            PropStore = new StoreProperty<Evalue>();
            Filename = filename;
        }

        public int PutProperty(Evalue evalue)
        {
            Evalues.Add(evalue);
            // The index to be added must be the last index of Evalues
            PropStore.AddIndex(evalue.KomNr, evalue.EjdNr, Evalues.Count() - 1);

            return 0;
        }

        public Evalue GetProperty(int komKode, int ejdNr)
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
