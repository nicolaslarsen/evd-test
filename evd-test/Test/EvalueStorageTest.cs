using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace evd_test.Test
{
    class EvalueStorageTest
    {
        public EvalueStorageTest() { }

        public int PutGetProperty()
        {
            Console.WriteLine("\nPutProperty() and GetProperty() Test:\n---------------------------------------------");

            EvalueStorage<EvalueBEC> evalStore = new EvalueStorage<EvalueBEC>();

            EvalueBEC testProp = new EvalueBEC
            {
                KomNr = 253,
                EjdNr = 26510
            };


            int ret = evalStore.PutProperty(testProp);
            Console.WriteLine("Put-test. Return == 0: {0}", ret == 0);

            EvalueBEC test = evalStore.GetProperty(253, 26510);
            Console.WriteLine("Get-test. Return == testProp: {0}", test == testProp);

            int length = evalStore.Length();
            Console.WriteLine("Length() test. Return == 1: {0}", length == 1);

            Console.WriteLine("\nWith an actual value...");

            test = new EvalueBEC();
            test.Init("69;69;2018-02-09T16:30:30.033;2012-05-29;1;26510;253;3117000;2018-02-01;2600000;2010-02-12;0;;;0;0;2532179017");

            ret = evalStore.PutProperty(test);
            Console.WriteLine("Put-test. Return == 0: {0}", ret == 0);

            EvalueBEC testGet = evalStore.GetProperty(253, 26510);
            Console.WriteLine("Get-test. Return == test value: {0}", testGet == test);
            Console.WriteLine("\nDouble-check:\n{0}\n{1}", test.ToCsv(), testGet.ToCsv());

            length = evalStore.Length();
            // We expect this to return -1, since we now have one element in the StoreProperty
            // and two in the Evalues list of evalStore. Need to investigate how to handle this.
            // Can there be two properties with the same komnr and ejdnr?
            Console.WriteLine("\nLength() error test. Return == -1: {0}", length == -1);
            Console.WriteLine("Double-check: Length = {0}", length);

            Console.WriteLine("\nActual null-test Get...");
            Console.WriteLine("Get-test with no result: {0}",
                evalStore.GetProperty(100,100) == null);

            Console.WriteLine("---------------------------------------------\n");

            return 0;
        }

        public int Length()
        {
            EvalueStorage<EvalueBEC> evalStore = new EvalueStorage<EvalueBEC>();

            Console.WriteLine("\nLength() Test:\n---------------------------------------------");

            EvalueBEC test = new EvalueBEC()
            {
                KomNr = 253,
                EjdNr = 26510
            };
            EvalueBEC testTwo = new EvalueBEC()
            {
                KomNr = 250,
                EjdNr = 26510
            };

            evalStore.PutProperty(test);
            evalStore.PutProperty(testTwo);

            Console.WriteLine("Length = 2: {0}", evalStore.Length() == 2);
            Console.WriteLine("Double-check: {0}", evalStore.Length());

            Console.WriteLine("---------------------------------------------\n");
            return 0;
        }
        public int TestEvalueStorage()
        {
            PutGetProperty();

            Length();

            return 0;
        }
    }
}
