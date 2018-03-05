using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace evd_test
{
    public class EvalueTest<T> where T: Evalue, new()
    {
        public static List<T> CollectData(string filename, StoreProperty<T> propStore)
        {
            List<T> Evalues = new List<T>();

            string[] dataLines;
            try
            {
                dataLines = File.ReadAllLines(filename);
            }
            catch (IOException e)
            {
                throw e;
            }

            for (int i = 0; i < dataLines.Count(); i++)
            {
                string dataLine = dataLines[i];

                try
                {
                    T Evalue = new T();
                    Evalue.Init(dataLine);
                    Evalues.Add(Evalue);
                    propStore.AddIndex(Evalue.KomNr, Evalue.EjdNr, i);
                }
                catch (IndexOutOfRangeException e)
                {
                    throw e;
                }
            }
            return Evalues;
        }

        // Returns a negative number on error
        public static int TryCollectData(string filename, ref List<T> Evalue, int fileNum, StoreProperty<T> propStore)
        {
            try
            {
                Evalue = EvalueTest<T>.CollectData(filename, propStore);
            }
            catch (IndexOutOfRangeException)
            {
                MessageBox.Show("Fil: " + fileNum + " er ikke i det korekte format", 
                    "File " + fileNum + " format error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -fileNum;
            }
            catch (IOException)
            {
                MessageBox.Show("Fil: " + fileNum + " er i brug af et andet program", 
                    "File " + fileNum + " IO error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -fileNum;
            }

            return 0;
        }

        public static string BuildOutputString(List<T> firstFile, List<T> secondFile, StoreProperty<T> propStore)
        {
            string output = firstFile[0].Header;
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
                T firstEjendom = firstFile[randIndex];

                T secondEjendom = propStore.GetEjendom
                    (firstEjendom.KomNr, firstEjendom.EjdNr, secondFile); 

                output += firstEjendom.ToCsv() + secondEjendom.ToCsv() + "\n";

                randoms.Add(randIndex);
                i++;
            }

            // Only get properties that are "i udbud"
            List<T> ScndIUdbud = secondFile.Where(ejd => ejd.ErIUdbud == 1).ToList();

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
                T Ejendom = ScndIUdbud[randIndex];

                output += Ejendom.ToCsv() + "\n";

                randoms.Add(randIndex);
                i++;
            }
            return output;
        }
    }
}
