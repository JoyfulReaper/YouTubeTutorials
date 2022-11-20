using System;

/*
 * Benefits of records:
 * - Simple to setup
 * - Thread safe
 * - Easy/safe to share (immutable)
 * 
 * When to use Records:
 * - Capturing external data that doesnt change (from an API)
 * - API Calls -> Data from DB then send it out the API
 * - Processing data -> Not changing the data
 * - Read only data
 * 
 * When not to use Records
 * - When you need to change the data (Entity Framework)
 */

public class Program
{
    private static void Main(string[] args)
    {
        Record1 r1a = new("Tim", "Coery");
        Record1 r1b = new("Tim", "Coery");
        Record1 r1c = new("Sue", "Storm");

        Class1 c1a = new("Tim", "Corey");
        Class1 c1b = new("Tim", "Corey");
        Class1 c1c = new("Sue", "Storm");

        Console.WriteLine("Record Type");
        Console.WriteLine($"To String {r1a}");
        Console.WriteLine($"Are the two objects equal: {Equals(r1a, r1b)}");
        Console.WriteLine($"Are the two objects reference equal: {ReferenceEquals(r1a, r1b)}");
        Console.WriteLine($"Are the two objects ==: {r1a == r1b}");
        Console.WriteLine($"Are the two objects ==: {r1a != r1c}");
        Console.WriteLine($"Hashcode of object A: {r1a.GetHashCode()}");
        Console.WriteLine($"Hashcode of object B: {r1b.GetHashCode()}");
        Console.WriteLine($"Hashcode of object C: {r1c.GetHashCode()}");

        Console.WriteLine();
        Console.WriteLine("***************************************");
        Console.WriteLine();


        Console.WriteLine("Class type");
        Console.WriteLine($"To String {c1a}");
        Console.WriteLine($"Are the two objects equal: {Equals(c1a, c1b)}");
        Console.WriteLine($"Are the two objects reference equal: {ReferenceEquals(c1a, c1b)}");
        Console.WriteLine($"Are the two objects ==: {c1a == c1b}");
        Console.WriteLine($"Are the two objects ==: {c1a != c1c}");
        Console.WriteLine($"Hashcode of object A: {c1a.GetHashCode()}");
        Console.WriteLine($"Hashcode of object B: {c1b.GetHashCode()}");
        Console.WriteLine($"Hashcode of object C: {c1c.GetHashCode()}");


        Console.WriteLine();
        var (fn, ln) = r1a;
        Console.WriteLine($"The value of fn is {fn} and the value of ln in {ln}");

        // Change just the values you need to change when making a record copy (Shallow copy)
        Record1 r1d = r1a with
        {
            FirstName = "Jon"
        };

        Console.WriteLine($"Jon's Record: {r1d}");


        Console.WriteLine();
        Record2 r2a = new("Tim", "Corey");
        Console.WriteLine($"r2a value: {r2a}");
        Console.WriteLine($"r2a fn: {r2a.FirstName}  ln: {r2a.LastName}");
        Console.WriteLine(r2a.SayHello());
    }
}

// a record is just a fancy class (like a read only class)
// immutable - Values cannot be changed
public record Record1(string FirstName, string LastName);

// Inheritence
public record User1(int Id, string FirstName, string LastName) : Record1(FirstName, LastName);

// No deconstructor
public record Record2(string FirstName, string LastName)
{
    //public string FirstName { get; init; } = FirstName;
    private string _firstName = FirstName;

    public string FirstName
    {
        get { return _firstName.Substring(0,1); }
        init { }
    }

    public string FullName { get => $"{FirstName} {LastName}"; }

    public string SayHello()
    {
        return $"Hello {FirstName}";
    }
}

public class Class1
{
    // init can only be set in constuctor or new with curly braces
    public string FirstName { get; init; }
    public string LastName { get; init; }

    public Class1(string firstName, string lastName)
    {
        FirstName = firstName;
        LastName = lastName;
    }

    public void Deconstruct(out string FirstName, out string LastName)
    {
        FirstName = this.FirstName;
        LastName = this.LastName;
    }
}


// Dont do this:
public record Record3 // No constuctor, so no desconstructor
{
    public string FirstName { get; set; } // SET MAKES THIS MUTABLE!!!
    public string LastName { get; set; }
}

// Dont just make clones all over to update state