using evd_test.Test;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace evd_test
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());

            //EvalueBECTest becTest = new EvalueBECTest();
            //becTest.TestEvalueBEC();

            //EvalueStorageTest evalStoreTest = new EvalueStorageTest();
            //evalStoreTest.TestEvalueStorage();

            //StatisticsTest statTest = new StatisticsTest();
            //statTest.TestStatistics();

            //StorePropertyTest storePropTest = new StorePropertyTest();
            //storePropTest.TestStoreProperty();

        }
    }
}
