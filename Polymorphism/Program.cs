using Polymorphism;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");

        Dog d = new Dog();
        d.MakeSound();

        Animal dog = new Dog();
        dog.MakeSound();

        Animal c = new Cat();
        c.MakeSound();

        Animal a = new Animal();
        a.MakeSound();

    }
}