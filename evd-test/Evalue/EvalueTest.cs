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
        public static EvalueStorage CollectData(string filename)
        {
            EvalueStorage EvalueStore = new EvalueStorage(filename);

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
        public static int TryCollectData(string filename, ref EvalueStorage Evalue, int fileNum, bool freshRun)
        {
            // If we already have the file cached, we don't neeed to recollect the data
            if (!freshRun)
            {
                return 0;
            }

            try
            {
                Evalue = CollectData(filename);
            }
            catch (IndexOutOfRangeException)
            {
                MessageBox.Show("Fil: " + filename + " er ikke i det korekte format", 
                    "File " + filename + " format error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -fileNum;
            }
            catch (IOException)
            {
                MessageBox.Show("Fil: " + filename + " er i brug af et andet program", 
                    "File " + filename + " IO error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -fileNum;
            }

            return 0;
        }

        public static async Task<int> TryCollectAsyncFiles(string firstFilename, EvalueStorage firstFile,
                string secondFilename, EvalueStorage secondFile, bool freshRun)
        {
            var firstTask = Task.Run(() => TryCollectData(firstFilename, ref firstFile, 1, freshRun));
            var secondTask = Task.Run(() => TryCollectData(secondFilename, ref secondFile, 1, freshRun));

            await Task.WhenAll(firstTask, secondTask);
            Console.WriteLine(firstTask);
            return 0;
        }

        public static string BuildOutputString(EvalueStorage firstFile, EvalueStorage secondFile)
        {
            // Just get the header from a new instance
            string output = new T().Header();

            Random rand = new Random();
            List<int> randoms = new List<int>();

            int i = 0;
            // randoms < firstFile and secondFile to make sure we have enough properties to test.
            while(i < 5 && randoms.Count() < firstFile.Length() &&
                randoms.Count() < secondFile.Length())
            {
                int randIndex = rand.Next(firstFile.Length());

                // If we already used this property
                if (randoms.Contains(randIndex))
                {
                    continue;
                }
                Evalue firstEjendom = firstFile.Evalues[randIndex];

                Evalue secondEjendom = secondFile.GetProperty(
                    firstEjendom.KomNr, firstEjendom.EjdNr); 

                // If secondFile did not contain the property
                if (secondEjendom == null)
                {
                    continue;
                }
                output += firstEjendom.ToCsv() + "\n" + secondEjendom.ToCsv() + "\n\n";

                randoms.Add(randIndex);
                i++;
            }

            // Only get properties that are "i udbud"
            List<Evalue> ScndIUdbud = secondFile.Evalues.Where(ejd => ejd.ErIUdbud == 1).ToList();

            // Just force it to 5, so we only get 5 where ErIUdbud == 1 
            if (i != 5)
            {
                i = 5;
            }

            // i should be 5 at this point, so we get 5 more properties here
            while (i < 10 && randoms.Count() < ScndIUdbud.Count())
            {
                int randIndex = rand.Next(ScndIUdbud.Count);

                // If we already used this property we skip it
                // (we haven't necessarily used it, but chances are, 
                // that this case won't be hit a lot anyway)
                if (randoms.Contains(randIndex))
                {
                    continue;
                }
                Evalue Ejendom = ScndIUdbud[randIndex];

                output += Ejendom.ToCsv() + "\n";

                randoms.Add(randIndex);
                i++;
            }
            return output;
        }
    }
}
