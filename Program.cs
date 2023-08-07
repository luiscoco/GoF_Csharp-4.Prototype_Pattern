using System;

class Program
{
    static void Main(string[] args)
    {
        // Create an original prototype
        var originalPrototype = new ConcretePrototype(1);

        // Shallow copy using ICloneable (MemberwiseClone)
        var shallowCopy = (ConcretePrototype)originalPrototype.Clone();

        // Deep copy using custom Clone method
        var deepCopy = originalPrototype.ClonePrototype();

        // Modify the cloned objects
        shallowCopy.Id = 2;
        deepCopy.Id = 3;

        // Output the results
        Console.WriteLine($"Original Prototype ID: {originalPrototype.Id}");
        Console.WriteLine($"Shallow Copy ID: {(shallowCopy as ConcretePrototype).Id}");
        Console.WriteLine($"Deep Copy ID: {(deepCopy as ConcretePrototype).Id}");

    }
}

// The prototype interface
public interface IPrototype
{
    int Id { get; set; }
    IPrototype ClonePrototype();
}

// A concrete prototype class
public class ConcretePrototype : IPrototype, ICloneable
{
    public int Id { get; set; }

    public ConcretePrototype(int id)
    {
        Id = id;
    }

    // Shallow copy implementation using ICloneable
    public object Clone()
    {
        return this.MemberwiseClone();
    }

    // Deep copy implementation using custom ClonePrototype method
    public IPrototype ClonePrototype()
    {
        return new ConcretePrototype(this.Id);
    }
}
