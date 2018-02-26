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
        public static List<T> CollectData(string filename)
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


            foreach (string dataLine in dataLines)
            {
                try
                {
                    T Evalue = new T();
                    Evalue.Init(dataLine);
                    Evalues.Add(Evalue);
                }
                catch (IndexOutOfRangeException e)
                {
                    throw e;
                }
            }
            return Evalues;
        }

        // Returns a negative number on error
        public static int TryCollectData(string filename, ref List<T> Evalue, int fileNum)
        {
            try
            {
                Evalue = EvalueTest<T>.CollectData(filename);
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

        public static string BuildOutputString(List<T> firstFile, List<T> secondFile)
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

                T secondEjendom = secondFile.Find(scndEjd =>
                    firstEjendom.GetKomNr() == scndEjd.GetKomNr() &&
                    firstEjendom.GetEjdNr() == scndEjd.GetEjdNr()
                );

                output += firstEjendom.ToCsv() + secondEjendom.ToCsv() + "\n";

                randoms.Add(randIndex);
                i++;
            }

            // Only get properties that are "i udbud"
            List<T> ScndIUdbud = secondFile.Where(ejd => ejd.GetErIUdbud() == 1).ToList();

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
