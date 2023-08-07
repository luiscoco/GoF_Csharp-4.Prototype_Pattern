# GoF_Csharp-Prototype_Pattern

Creates new objects by copying existing ones, thus avoiding the need for complex initialization.

The Prototype Pattern is a creational design pattern in software development that allows you to create new objects by copying existing ones, thus avoiding the need for complex initialization. The key idea is to clone an existing object and customize it as needed rather than creating a new object from scratch.

In C#, you can implement the Prototype Pattern by using the ICloneable interface, which defines a method called Clone(). This interface allows you to create a copy of an object.

```csharp
﻿using System;

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
```























