using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace evd_test 
{
    // Class is used to store indexes for properties somewhat efficiently
    public class StoreProperty<T> 
    {
        // Uses komkode and ejdnr to find index in the original array
        Dictionary<int, Dictionary<int, int>> Indexes;

        public StoreProperty()
        {
            // Just init List
            Indexes = new Dictionary<int, Dictionary<int, int>>();
        }

        public int AddIndex(int komKode, int ejdNr, int index)
        {
            if (Indexes.ContainsKey(komKode))
            {
                Indexes[komKode][ejdNr] = index;
            }
            else
            {
                Indexes.Add(komKode, new Dictionary<int, int>());
                Indexes[komKode][ejdNr] = index;
            }
            return 0;
        }

        public int FindIndex(int komKode, int ejdNr)
        {
            if (Indexes.ContainsKey(komKode)) {
                if (Indexes[komKode].ContainsKey(ejdNr)){
                    return Indexes[komKode][ejdNr];
                }
            }

            return -1;
        }

        public T GetEjendom(int komKode, int ejdNr, List<T> properties)
        {
            int index = this.FindIndex(komKode, ejdNr);
            if (index < 0)
            {
                return default; 
            }

            return properties[index];
        }

        public int Length()
        {
            return Indexes.Values.Sum(x => x.Count());
        }
    }
}
