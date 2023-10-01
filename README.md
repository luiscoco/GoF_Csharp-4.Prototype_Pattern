# GoF_Csharp-Prototype_Pattern (Creational Patterns)

https://refactoring.guru/design-patterns/prototype

https://www.dotnettricks.com/learn/designpatterns/prototype-design-pattern-dotnet

https://refactoring.guru/design-patterns/examples

Prototype is a creational design pattern that lets you copy existing objects without making your code dependent on their classes.

![image](https://github.com/luiscoco/GoF_Csharp-4.Prototype_Pattern/assets/32194879/048e3aad-2c54-41a9-a1e5-594d6c9eda84)

## Prototype Pattern - Example

![image](https://github.com/luiscoco/GoF_Csharp-4.Prototype_Pattern/assets/32194879/b88a4cad-5038-4046-af5b-1b1036c2dbee)

```csharp
/// <summary>
/// Prototype Pattern Demo
/// </summary>

class Program
{
 static void Main(string[] args)
 {
 Developer dev = new Developer();
 dev.Name = "Rahul";
 dev.Role = "Team Leader";
 dev.PreferredLanguage = "C#";

 Developer devCopy = (Developer)dev.Clone();
 devCopy.Name = "Arif"; //Not mention Role and PreferredLanguage, it will copy above

 Console.WriteLine(dev.GetDetails());
 Console.WriteLine(devCopy.GetDetails());

 Typist typist = new Typist();
 typist.Name = "Monu";
 typist.Role = "Typist";
 typist.WordsPerMinute = 120;

 Typist typistCopy = (Typist)typist.Clone();
 typistCopy.Name = "Sahil";
 typistCopy.WordsPerMinute = 115;//Not mention Role, it will copy above

 Console.WriteLine(typist.GetDetails());
 Console.WriteLine(typistCopy.GetDetails());

 Console.ReadKey();

 }
}
```

```csharp
/// <summary>
/// The 'Prototype' interface
/// </summary>
public interface IEmployee
{
 IEmployee Clone();
 string GetDetails();
}

/// <summary>
/// A 'ConcretePrototype' class
/// </summary>
public class Developer : IEmployee
{
 public int WordsPerMinute { get; set; }
 public string Name { get; set; }
 public string Role { get; set; }
 public string PreferredLanguage { get; set; }

 public IEmployee Clone()
 {
 // Shallow Copy: only top-level objects are duplicated
 return (IEmployee)MemberwiseClone();

 // Deep Copy: all objects are duplicated
 //return (IEmployee)this.Clone();
 }

 public string GetDetails()
 {
 return string.Format("{0} - {1} - {2}", Name, Role, PreferredLanguage);
 }
}

/// <summary>
/// A 'ConcretePrototype' class
/// </summary>
public class Typist : IEmployee
{
 public int WordsPerMinute { get; set; }
 public string Name { get; set; }
 public string Role { get; set; }

 public IEmployee Clone()
 {
 // Shallow Copy: only top-level objects are duplicated
 return (IEmployee)MemberwiseClone();

 // Deep Copy: all objects are duplicated
 //return (IEmployee)this.Clone();
 }

 public string GetDetails()
 {
 return string.Format("{0} - {1} - {2}wpm", Name, Role, WordsPerMinute);
 }
}
```

## Prototype Pattern

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

## How to setup Github actions

![Csharp Github actions](https://github.com/luiscoco/GoF_Csharp-4.Prototype_Pattern/assets/32194879/806e630e-e7a0-45bd-a958-cc293c22bf7f)
























