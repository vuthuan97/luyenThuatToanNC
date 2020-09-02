using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Threadl
{
    class Program
    {
        static void Main()
        {
            Thread t1 = new Thread(MethodA);
            Thread t2 = new Thread(MethodB);
            Thread t3 = new Thread(MethodC);

            t1.Start();
            t2.Start();

            t2.Join();

            t3.Start();
            Console.ReadKey();
        }

        static void MethodA()
        {
            for (int i = 0; i < 500; i++)
            {
               Console.Write("0");
            }
        }
        static void MethodB()
        {

            for (int i = 0; i < 100; i++) {
            
                Console.Write("1"); }
        }
        static void MethodC()
        {
            for (int i = 0; i < 100; i++) Console.Write("2");
        }

    }
  
    public class Student
    {
        public string  name { get; set; }
        public DateTime NS { get; set; }
    }
}
