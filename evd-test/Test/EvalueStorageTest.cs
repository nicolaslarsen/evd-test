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

            int ret = evalStore.PutProperty(253,26510, null);
            Console.WriteLine("Put-test. Return == 0: {0}", ret == 0);

            EvalueBEC test = evalStore.GetProperty(253, 26510);
            Console.WriteLine("Get-test. Return == null: {0}", test == null);

            Console.WriteLine("\nWith an actual value...");

            test = new EvalueBEC();
            test.Init("69;69;2018-02-09T16:30:30.033;2012-05-29;1;26510;253;3117000;2018-02-01;2600000;2010-02-12;0;;;0;0;2532179017");

            ret = evalStore.PutProperty(253, 26510, test);
            Console.WriteLine("Put-test. Return == 0: {0}", ret == 0);

            EvalueBEC testGet = evalStore.GetProperty(253, 26510);
            Console.WriteLine("Get-test. Return == test value: {0}", testGet == test);
            Console.WriteLine("\nDouble-check:\n{0}\n{1}", test.ToCsv(), testGet.ToCsv());

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

            evalStore.PutProperty(253, 26510, null);
            evalStore.PutProperty(253, 26511, null);
            evalStore.PutProperty(250, 26510, null);

            Console.WriteLine("Length = 3: {0}", evalStore.Length() == 3);
            Console.WriteLine("Double-check: {0}",evalStore.Length());

            Console.WriteLine("---------------------------------------------\n");
            return -1;
        }
        public int TestEvalueStorage(){
            PutGetProperty();

            Length();

            return 0;
        }
    }
}
