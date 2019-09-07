using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQSample
{
    class Program
    {
        static void Main(string[] args)
        {
            /////Query syntax

            //DataSource
            List<int> list = new List<int>() { 1, 2, 3, 4, 5, 6, 7, 8 };

            //Query
            var query = from obj in list
                        where obj > 3
                        select obj;

            //Execution
            foreach(var i in query)
            {
                Console.WriteLine(i); // 4 5 6 7 8
            }

            Console.WriteLine("===============");

            /////Method syntax
            query = list.Where(obj => obj > 4);

            foreach(var i in query)
            {
                Console.WriteLine(i); // 5 6 7 8
            }

            Console.WriteLine("===============");

            /////Mixed syntax

            var mixedSyntax = (from obj in list
                              select obj).Max();

            Console.WriteLine("Max value is " + mixedSyntax); // 8
        }
    }
}
