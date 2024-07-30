using AdvanceConcepts;
using AdvanceConcepts.Classes;
using AdvanceConcepts.Interfaces;
using System.Reflection;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("------Welcome to Ideal Softwares Academy-------");
        Type type = typeof(Example);
        MethodInfo method = type.GetMethod("Display");
        object instance = Activator.CreateInstance(type);
        method.Invoke(instance, new object[] { "Hello Replection" });

        Example e = new Example();
        e.Display("Hi");
        Console.WriteLine("-----------------------------------------");
        IService s = new Service();
        Client c = new Client(s);
        c.Start();

    }
}