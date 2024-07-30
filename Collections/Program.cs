using Collections;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");

        List<int> numbers = new List<int>
        {
            1,2, 3, 4,5, 6, 7
        };

        numbers.Add(8);

        List<string> names = new List<string> {
            "Ideal","Softwares","Haladi"
        };
        names.Add("Test");
        names.Remove("Test");
        foreach (int n in numbers)
        {
            Console.WriteLine($"The Number is {n}");
        }

        foreach (string s in names)
        {
            if (s == "Softwares")
            {
                Console.WriteLine(s);
            }
        }

        Console.WriteLine("-------------------------------------------------");


            Employee e1 = new Employee
            {
                emapId = 101,
                empName = "Ideal",
                sal = 25000
            };
        Employee e2 = new Employee
        {
            emapId = 101,
            empName = "Ideal",
            sal = 25000
        };
        Employee e3 = new Employee
        {
            emapId = 101,
            empName = "Ideal",
            sal = 25000
        };

        List<Employee> emps = new List<Employee> { e1, e2, e3 };

        List<Employee> e = new List<Employee>
        {
            new Employee{emapId=101, empName="test", sal=10000},
            new Employee{emapId=102, empName="test", sal=10000},
            new Employee{emapId=103, empName="test", sal=10000},
        };

    }
}