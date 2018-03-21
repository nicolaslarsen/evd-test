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
            try
            {
                return Indexes[komKode][ejdNr];
            }
            catch (KeyNotFoundException)
            {
                Console.WriteLine("KeyNotFound: KomNr: " + komKode + " EjdNr: " + ejdNr);
            }
            return -1;
        }

        public int counter = 0;
        public T GetEjendom(int komKode, int ejdNr, List<T> properties)
        {
            int index = this.FindIndex(komKode, ejdNr);
            if (index < 0)
            {
                Console.WriteLine(counter);
                counter++;
                return default; 
            }

            return properties[index];
        }
    }
}
