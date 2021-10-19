using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Simple_Mutex_Demo
{
    class Program
    {
        static void Main(string[] args)
        {

            Mutex mutex = new Mutex();

            for(int i = 0; i < 10; i++)
            {
                Task.Factory.StartNew(() =>
                {
                    if (mutex.WaitOne())
                    {
                        try
                        {
                            Console.WriteLine(File.ReadAllText(@"C:\MutexTest.txt"));
                            File.AppendAllText(@"C:\MutexTest.txt", "Be Different.");
                        }
                        finally
                        {
                            mutex.ReleaseMutex();
                        }
                    }

                });
            }

            Console.ReadKey();

        }
    }
}
