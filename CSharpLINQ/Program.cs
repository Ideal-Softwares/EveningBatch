using CSharpLINQ;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("C# LINQ");

        int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };

        var evenNum = from n in numbers
                      where n % 2 == 0
                      orderby n descending
                      select n;

        Console.WriteLine("---------------------Numbers Start --------------------------");
        foreach (int n in numbers)
        {
            Console.WriteLine($"{n}");
        }
        Console.WriteLine("---------------------Numbers End --------------------------");
        Console.WriteLine("---------------------Even Numbers Start --------------------------");
        foreach (int n in evenNum)
        {
            Console.WriteLine($"{n}");
        }
        Console.WriteLine("---------------------Even Numbers End --------------------------");

        var oddNum = numbers
                    .Where(n => n % 2 != 0)
                    .OrderByDescending(n => n);

        Console.WriteLine("---------------------oddNum Numbers Start --------------------------");
        foreach (int n in oddNum)
        {
            Console.WriteLine($"{n}");
        }
        Console.WriteLine("---------------------oddNum Numbers End --------------------------");

        Console.WriteLine("--------LINQ with Objects---------");

        List<Student> students = new List<Student>();

        students.Add(new Student { Name = "Swapnil", Age = 31, Gender = "Male" });
        students.Add(new Student { Name = "Akash", Age = 25, Gender = "Male" });
        students.Add(new Student { Name = "Asha", Age = 31, Gender = "Female" });
        students.Add(new Student { Name = "Suresh", Age = 20, Gender = "Male" });
        students.Add(new Student { Name = "Suresh1", Age = 20, Gender = "Male" });
        students.Add(new Student { Name = "Suresh2", Age = 25, Gender = "Male" });
        students.Add(new Student { Name = "Asha2", Age = 31, Gender = "Female" });
        students.Add(new Student { Name = "Asha3", Age = 33, Gender = "Female" });
        students.Add(new Student { Name = "Asha4", Age = 20, Gender = "Female" });


        var youngStudents = from s in students
                            where s.Age <= 25
                            select s;

        Console.WriteLine("--------------------youngStudents Start --------------------------");
        foreach (Student s in youngStudents)
        {
            Console.WriteLine($"Student Name : {s.Name} | Student Age : {s.Age} | Student Gender : {s.Gender}");
        }
        Console.WriteLine("---------------------youngStudents End --------------------------");
        var youngStudents1 = students.Where(s => s.Age <= 25);

        Console.WriteLine("--------------------youngStudents1 method Start --------------------------");
        foreach (Student s in youngStudents1)
        {
            Console.WriteLine($"Student Name : {s.Name} | Student Age : {s.Age} | Student Gender : {s.Gender}");
        }
        Console.WriteLine("---------------------youngStudents1 method End --------------------------");

        var studgroupby= students.GroupBy(s => s.Age);
        Console.WriteLine("--------------------studgroupby method Start --------------------------");
        foreach (var studs in studgroupby)
        {
            Console.WriteLine($"Students Count for Age {studs.Key} : {studs.Count()}");
            foreach (var s in studs)
            {
                Console.WriteLine($"Student Name : {s.Name} | Student Age : {s.Age} | Student Gender : {s.Gender}");
            }
        }
        Console.WriteLine("---------------------studgroupby method End --------------------------");
    }

}