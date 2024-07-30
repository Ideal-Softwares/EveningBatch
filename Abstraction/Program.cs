using Abstraction;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");

        Dog myDog= new Dog();
        myDog.MakeSound();
        myDog.Sleep();
        myDog.Eat();
        myDog.Play();

        Cat c = new Cat();
        c.Eat();
        c.Play();
    }
}