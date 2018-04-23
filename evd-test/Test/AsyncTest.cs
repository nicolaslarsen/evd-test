using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace evd_test.Test
{
    class AsyncTest
    {
        public AsyncTest() {}

        private int Fib(int n)
        {
            if (n < 2)
            {
                return n;
            }

            return Fib(n - 2) + Fib(n - 1);
        }

        private int Slow()
        {
            int ret = Fib(10);
            Console.WriteLine("Slow");
            return ret; 
        }

        private int Fast()
        {
            int ret = Fib(1);
            Console.WriteLine("Fast");
            return ret; 
        }

        public async Task<int> CallFuncsAsync()
        {
            Console.WriteLine("Start");

            var hej = Task.Run(() => Slow());

            var memes = Task.Run(() => Fast());

            Console.WriteLine("test");


            var test = await hej;
            var fest = await memes;

            Console.WriteLine("test: {0} fest: {1}", test, fest);
            return test + fest;
        }

        public void Test()
        {
            Console.WriteLine(CallFuncsAsync().Result);
        }
    }
}
