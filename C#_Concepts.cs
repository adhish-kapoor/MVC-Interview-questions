===== IEnumerable and IEnumerator
IEnumerable and IEnumerator are implementation of the iterator pattern in .NET.
In C#, all collections (eg lists, dictionaries, stacks, queues, etc) are enumerable because they implement the IEnumerable interface. 
So are strings. 
You can iterate over a string using a foreach block to get every character in the string.

==== Iterator Pattern
public class List
{
    public object[] Objects;
 
    public List()
    {
        Objects = new object[100];
    }
 
    public void Add(object obj)
    {
        Objects[Objects.Count] = obj;
    }
}

The problem with this implementation is that the List class is exposing its internal structure (object[]) for storing data. 
This violates the information hiding principle of object-oriented programming. 
It gives the outside world intimate knowledge of the design of this class.

So, objects should not expose their internal structure. 
This means we need to modify our List class and make the Objects array private:

public class List
{
    private object[] _objects;
 
    public List()
    {
        _objects = new object[100];
    }
 
    public void Add(object obj)
    {
        _objects[_objects.Count] = obj;
    }
}

But this leads to a new different problem: how are we going to iterate over this list? 
We no longer have access to the Objects array, and we cannot use it in a loop.

Iterator pattern provides a mechanism to traverse an object, irrespective of how it is internally represented.

=====Boxing and unboxing
Boxing is the process of converting a value type to the type object or to any interface type implemented by this value type.
 Unboxing extracts the value type from the object. 
 Boxing is implicit; unboxing is explicit.
 The concept of boxing and unboxing underlies the C# unified view of the type system in which a value of any type can be treated as an object.

 int i = 123;
// The following line boxes i.
object o = i;

o = 123;
i = (int)o;  // unboxing

BOXING
Boxing is used to store value types in the garbage-collected heap.
Boxing a value type allocates an object instance on the heap and copies the value into the new object.
    
UNBOXING
Unboxing is used to get value from object type.
    
=======Singleton Design Pattern

The Singleton design pattern is one of the simplest design patterns.
This pattern ensures that the class has only one instance and provides a global point of access to it. 
The pattern ensures that only one object of a specific class is ever created. 
All further references to objects of the singleton class refer to the same underlying instance.

There are situations in a project where we want only one instance of the object to be created and shared among the clients. 
No client can create an instance from outside.
It is more appropriate than creating a global variable since this may be copied and leads to multiple access points. 

=======Delegates
A delegate is like a pointer to a function. It is a reference type data type and it holds the reference of a method.
All the delegates are implicitly derived from System.Delegate class.
class Program
{
    // declare delegate
    public delegate void Print(int value);

    static void Main(string[] args)
    {
        // Print delegate points to PrintNumber
        Print printDel = PrintNumber;
        
        // or
        // Print printDel = new Print(PrintNumber);
            
        printDel(100000);
        printDel(200);

        // Print delegate points to PrintMoney
        printDel = PrintMoney;

        printDel(10000);
        printDel(200);
    }

    public static void PrintNumber(int num)
    {
        Console.WriteLine("Number: {0,-12:N0}",num);                            //Number: 100,000     
    }                                                                           //Number: 200         
                                                                                //Money: $10,000.00
                                                                                //Money: $200.00 
    public static void PrintMoney(int money)
    {
        Console.WriteLine("Money: {0:C}", money);
    }
}
=========MultiCast Delegate
The delegate can point to multiple methods. A delegate that points multiple methods is called a multicast delegate. 
The "+" operator adds a function to the delegate object and the "-" operator removes an existing function from a delegate object.
    
public delegate void Print(int value);

static void Main(string[] args)
{       
    Print printDel = PrintNumber;
    printDel += PrintHexadecimal;
    printDel += PrintMoney;

    printDel(1000);

    printDel -=PrintHexadecimal;
    printDel(2000);
}

public static void PrintNumber(int num)
{
    Console.WriteLine("Number: {0,-12:N0}",num);                                //Number: 1,000       
                                                                                //Hexadecimal: 3E8
                                                                                //Money: $1,000.00
                                                                                //Number: 2,000       
                                                                                //Money: $2,000.00
}

public static void PrintMoney(int money)
{
    Console.WriteLine("Money: {0:C}", money);
}

public static void PrintHexadecimal(int dec)
{
    Console.WriteLine("Hexadecimal: {0:X}", dec);
}
