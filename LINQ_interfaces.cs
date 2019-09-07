using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQSample
{
    class LINQInterface
    {
        public static void Main(String[] args)
        {

            List<Employee> employees = new List<Employee>()
        {
            new Employee() {Id=1,Name="Adi"},
            new Employee() {Id=2,Name="Raku"}
        };

            IEnumerable<Employee> query = from emp in employees
                                          where emp.Id == 1
                                          select emp;

            IQueryable<Employee> query1 = employees.AsQueryable().Where(x => x.Id == 1);

            foreach (var i in query)
            {
                Console.WriteLine("Id is " + i.Id + " and " + "Name is " + i.Name);
            }

        }
     class Employee
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }

    }
    }
   
