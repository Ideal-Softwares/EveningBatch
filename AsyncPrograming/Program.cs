using AsyncPrograming;
using System.Data.SqlClient;

internal class Program
{
    private static async Task Main(string[] args)
    {
        Console.WriteLine("Welcome to ISH!");
        Class1.Run();
       await Class1.RunAsync();

        string connStr = "Server=DESKTOP-8K28S4N;Database=DbV1;Trusted_Connection=True;";

        using(SqlConnection cnn = new SqlConnection(connStr))
        {
            try
            {
                cnn.Open();
                Console.WriteLine("Connection opened successfully");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occurred {ex.Message}");
            }

        }
    }
}