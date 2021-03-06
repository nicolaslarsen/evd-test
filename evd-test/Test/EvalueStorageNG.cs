﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace evd_test.Test
{
    class EvalueStorageNG 
    {
        public List<Evalue> Evalues;
        private StoreProperty<Evalue> PropStore;


        public EvalueStorageNG()
        {
            // Just init list
            Evalues = new List<Evalue>();
            PropStore = new StoreProperty<Evalue>();
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

        public void Test()
        {
            Console.WriteLine("\nPutProperty() and GetProperty() Test:\n---------------------------------------------");

            EvalueStorageNG evalStore = new EvalueStorageNG();

            EvalueBEC testProp = new EvalueBEC
            {
                KomNr = 253,
                EjdNr = 26510
            };


            int ret = evalStore.PutProperty(testProp);
            Console.WriteLine("Put-test. Return == 0: {0}", ret == 0);

            //EvalueBEC test = evalStore.GetProperty(253, 26510);
            //Console.WriteLine("Get-test. Return == testProp: {0}", test == testProp);

            //int length = evalStore.Length();
            //Console.WriteLine("Length() test. Return == 1: {0}", length == 1);

            //Console.WriteLine("\nWith an actual value...");

            //test = new EvalueBEC();
            //test.Init("69;69;2018-02-09T16:30:30.033;2012-05-29;1;26510;253;3117000;2018-02-01;2600000;2010-02-12;0;;;0;0;2532179017");

            //ret = evalStore.PutProperty(test);
            //Console.WriteLine("Put-test. Return == 0: {0}", ret == 0);

            //EvalueBEC testGet = evalStore.GetProperty(253, 26510);
            //Console.WriteLine("Get-test. Return == test value: {0}", testGet == test);
            //Console.WriteLine("\nDouble-check:\n{0}\n{1}", test.ToCsv(), testGet.ToCsv());

            //length = evalStore.Length();
            //// We expect this to return -1, since we now have one element in the StoreProperty
            //// and two in the Evalues list of evalStore. Need to investigate how to handle this.
            //// Can there be two properties with the same komnr and ejdnr?
            //Console.WriteLine("\nLength() error test. Return == -1: {0}", length == -1);
            //Console.WriteLine("Double-check: Length = {0}", length);

            //Console.WriteLine("\nActual null-test Get...");
            //Console.WriteLine("Get-test with no result: {0}",
            //    evalStore.GetProperty(100,100) == null);

            Console.WriteLine("---------------------------------------------\n");
        }
    }
}
