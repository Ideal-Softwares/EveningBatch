using Polimorphisum;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");

		try
		{
            Animal dog = new Dog();
            Animal cat = new Cat();
            Animal a = new Animal();

            Animal[] animals = { new Dog(), new Cat(), new Animal(), new Dog(), new Cat() };
            animals[5].MakeSound();
            
            dog.MakeSound();
            a.MakeSound();
            cat.MakeSound();

            foreach (Animal animal in animals)
            {
                animal.MakeSound();
            }
            
        }
		catch (Exception ex)
		{
            Console.WriteLine("There is an error occured please contact system admin " + ex.Message);
            
		}

        StreamReader reader = null;
        try
        {
            reader = new StreamReader("file.txt");
            string content = reader.ReadToEnd();
            Console.WriteLine(content);

        }
        catch(FileNotFoundException fex)
        {
            Console.WriteLine($"File not Found {fex.Message}");
        }
        catch (Exception ex)
        {

            Console.WriteLine($"Error is {ex.Message}");
        }
        finally
        {
            //clean up code
            if( reader != null )
            {
                reader.Close();
            }
            Console.WriteLine("Clean up completed");
        }

    }
}