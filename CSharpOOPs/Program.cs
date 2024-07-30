using CSharpOOPs;

internal class Program
{
    private static void Main(string[] args)
    {
       // Console.WriteLine("Hello, World!");
       Student s1 = new Student();
        
        s1.RollNo = 1;
        s1.Name= "Test";

        s1.DisplyDetails();

        s1.UpdateMob(8788531164);

        s1.DisplyDetails();

        Console.WriteLine("__________________________________________________________");
        Nokia n1 = new Nokia();

        n1.Call();
        n1.SMS();
        n1.Settings();

        Samsung samsung = new Samsung();

        samsung.SMS();
        samsung.Settings();
        Console.WriteLine("__________________________________________________________");
        Swift sf = new Swift();
        sf.Start();
        sf.CNG();

        Nexon n= new Nexon();
        n.Start();
        n.Petrol();
    }
}