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
