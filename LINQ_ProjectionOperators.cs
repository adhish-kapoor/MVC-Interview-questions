//Select and SelectMany
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LINQSample
{
    public class Program
    {
        public static void Main(string[] args)
        {
            List<Employee> employees = new List<Employee>()
            {
                new Employee() { Id=1,Name="Adi",Email="adi@gmail.com" },
                new Employee() { Id=2,Name="Bdi",Email="bdi@gmail.com" },
                new Employee() { Id=3,Name="Cdi",Email="cdi@gmail.com"},
                new Employee() { Id=4,Name="Ddi",Email="ddi@gmail.com"},
                new Employee() { Id=5,Name="Edi",Email="edi@gmail.com"}
            };

            var basicQuery = (from emp in employees
                              select emp).ToList();

           
            var basicMethod = employees.ToList();

            //operations applied on emp.Id
            var basicPropQuery = (from emp in employees
                                  select emp.Id + 1).ToList();    //to show only Id in output 2 3 4 5 6

            var basicPropMethod = employees.Select(emp => emp.Id).ToList();

            //to select only Id and Name 
            var selectQuery = (from emp in employees
                               select new Employee
                               {
                                   Id = emp.Id,
                                   Name = emp.Name

                               }).ToList();
                               
            //to select data using index                   
            var query = employees.Select((emp, index) => new { Index = index, name = emp.Name }).ToList();   //query will contain:-
                                                                                                             //{Index=0, name="Adi"}
                                                                                                             //{Index=1, name="Bdi"}
                                                                                                             //similar for all indexes
            
            //SelectMany is used to get multiple records from a sequence and converting it into a single sequence
            List<string> strList = new List<string>() { "Adhish", "Kapoor" };
            
            var methodResult = strList.SelectMany(x => x).ToList(); //count 12, each char with ASCII code 

            var queryResult = (from str in strList
                               from ch in str
                               select ch).ToList(); //count 12, each char with ASCII code 
            
            foreach (var i in selectQuery)
            {
                Console.WriteLine($"Id is {i.Id}, Name is {i.Name}, Email is {i.Email}"); //Email is null 
            }

            //SelectMany for list within a list
             var dataSource = new List<Employee>()
            {
                new Employee() {Id =1,Name = "A",Programming=new List<string>() { "C#","Python"} },
                new Employee() {Id =2,Name = "B",Programming=new List<string>() { "C++","Java"} },
                new Employee() {Id =3,Name = "C",Programming=new List<string>() { "C#","JS"} }
            };

            var methodSyntax = dataSource.SelectMany(x => x.Programming).ToList();  //count 6 (list of programming languages)
            
            
            var querySyntax = (from emp in dataSource
                               from pr in emp.Programming
                               select pr).ToList();                                  //count 6 (list of programming languages)

            foreach(var i in methodSyntax)
            {
                Console.WriteLine("Programming - " + i);
            }
            
            Console.ReadKey();
        }
    }
}
