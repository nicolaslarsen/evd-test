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
        public static EvalueStorage<T> CollectData(string filename)
        {
            EvalueStorage<T> EvalueStore = new EvalueStorage<T>();

            string[] dataLines;

            dataLines = File.ReadAllLines(filename);

            for (int i = 0; i < dataLines.Count(); i++)
            {
                string dataLine = dataLines[i];

                T Evalue = new T();
                Evalue.Init(dataLine);
                EvalueStore.PutProperty(Evalue);
            }
            return EvalueStore;
        }

        // Returns a negative number on error
        public static int TryCollectData(string filename, ref EvalueStorage<T> Evalue, int fileNum)
        {
            try
            {
                Evalue = CollectData(filename);
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

        public static string BuildOutputString(EvalueStorage<T> firstFile, EvalueStorage<T> secondFile)
        {
            // Just get the header from a new instance
            string output = new T().Header();

            Random rand = new Random();
            List<int> randoms = new List<int>();

            int i = 0;
            while(i < 5)
            {
                int randIndex = rand.Next(firstFile.Length());

                // If we already used this property
                if (randoms.Contains(randIndex))
                {
                    continue;
                }
                T firstEjendom = firstFile.Evalues[randIndex];

                T secondEjendom = secondFile.GetProperty(
                    firstEjendom.KomNr, firstEjendom.EjdNr); 

                output += firstEjendom.ToCsv() + "\n" + secondEjendom.ToCsv() + "\n";

                randoms.Add(randIndex);
                i++;
            }

            // Only get properties that are "i udbud"
            List<T> ScndIUdbud = secondFile.Evalues.Where(ejd => ejd.ErIUdbud == 1).ToList();

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
