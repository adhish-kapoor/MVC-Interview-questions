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

