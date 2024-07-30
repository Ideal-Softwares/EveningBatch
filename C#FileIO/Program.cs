internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Welcome to Ideal Softwares Academy");
        Console.WriteLine("-----------------------------------");

		try
		{
			using (StreamReader r = new StreamReader("TextFile1.txt"))
            {
				string content = r.ReadToEnd();
				Console.WriteLine(content);
			}

            //using (StreamWriter w = new StreamWriter("TextFile1.txt",true))
            //         {
            //	w.WriteLine($"Lorem Ipsum is simply dummy text of the printing and typesetting industry. \r\nLorem Ipsum has been the industry's standard dummy text ever since the 1500s,\r\nwhen an unknown printer took a galley of type and scrambled it to make a type specimen book. \r\nIt has survived not only five centuries, but also the leap into electronic typesetting, remaining \r\nessentially unchanged. It was popularised in the 1960s with the release of Letraset sheets containing\r\nLorem Ipsum passages, and more recently with desktop publishing software like Aldus PageMaker including versions of Lorem Ipsum.");
            //}
            //Console.WriteLine("Data writen successfully");
            using (StreamReader r = new StreamReader("TextFile1.txt"))
            {
                string content = r.ReadToEnd();
                Console.WriteLine(content);
            }
        }
		catch (FileNotFoundException ex)
		{

			Console.WriteLine($"File not Found {ex}");
            using (StreamWriter w = new StreamWriter("TextFile1.txt", true))
            {
                w.WriteLine($"Error on file {DateTime.Now} | Main Method |TextFile1.txt |Error {ex.Message} | {ex}");
            }
        }
		catch (IOException ex)
		{
			Console.WriteLine($"IO Exception {ex}");
            using (StreamWriter w = new StreamWriter("TextFile1.txt", true))
            {
                w.WriteLine($"Error on file {DateTime.Now} | Main Method |TextFile1.txt |Error {ex.Message} | {ex}");
            }
        }
		catch(Exception ex)
		{
			Console.WriteLine($"Exception {ex.Message}");
            using (StreamWriter w = new StreamWriter("TextFile1.txt", true))
            {
                w.WriteLine($"Error on file {DateTime.Now} | Main Method |TextFile1.txt |Error {ex.Message} | {ex}");
            }
        }
    }
}