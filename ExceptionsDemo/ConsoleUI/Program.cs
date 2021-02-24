using ExceptionsLibrary;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            DemoCode demo = new DemoCode();

            try
            {
                int result = demo.GrandparentMethod(4);
                Console.WriteLine($"The value at the given postion is { result }");
            }
            catch (ArgumentException ex)
            {
                // Multiple catches are okay!
                // This is the 1st catch block that matches. Order matters.
                Console.WriteLine("You gave us bad information. Bad user!");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
                var inner = ex.InnerException;

                while(inner != null)
                {
                    Console.WriteLine(inner.StackTrace);
                    inner = inner.InnerException; // Full stack trace 
                }
            }
        }
    }
}
