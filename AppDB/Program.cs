using AppDB.DContext;
using AppDB.Model;
using Microsoft.Data.SqlClient;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("ISH!");
        
        string cn = "Data Source=DESKTOP-8K28S4N;Database=DbV2;Integrated Security=True;Connect Timeout=300;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False";

        string insertQuery = "Insert Into Students (FName, LName, Gender, Mob) values (@FName, @LName, @Gender, @Mob)";

        using (SqlConnection cnn = new SqlConnection(cn))
        {
            try
            {
                cnn.Open();
                Console.WriteLine("Connection opened successfully");
                //using (SqlCommand cmd = new SqlCommand(insertQuery, cnn))
                //{
                //    cmd.Parameters.AddWithValue("@FName", "Ideal");
                //    cmd.Parameters.AddWithValue("@LName", "Softwares");
                //    cmd.Parameters.AddWithValue("@Gender", "Male");
                //    cmd.Parameters.AddWithValue("@Mob", "878853164");

                //    int res = cmd.ExecuteNonQuery();
                //    Console.WriteLine($"The REcords is inserted successfully");
                //}

                //string updstr = "Update Students Set FName=@FName where Id=@Id";

                //using(SqlCommand cmd = new SqlCommand(updstr, cnn))
                //{
                //    cmd.Parameters.AddWithValue("@FName", "SSK");
                //    //cmd.Parameters.AddWithValue("@LName", "Kunkekar");
                //    //cmd.Parameters.AddWithValue("@Gender", "Male");
                //    //cmd.Parameters.AddWithValue("@Mob", "878853164");
                //    cmd.Parameters.AddWithValue("@Id", "3");

                //    int res=cmd.ExecuteNonQuery();
                //    Console.WriteLine("Record updated successfully");
                //}    
                //

                string str = "Select * from Students";
                using (SqlCommand cmd = new SqlCommand(str, cnn))
                {
                    using (SqlDataReader r = cmd.ExecuteReader())
                    {
                        while(r.Read())
                        {
                            Console.WriteLine($"{r["Id"]}\t\t{r["FName"]}\t\t{r["Mob"]}");
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occurred {ex.Message}");
            }

        }

        

        //EF Core
        try
        {
            //using (var ctx = new AppDbContext())
            //{
            //    Student s1 = new Student
            //    {
            //        FName = "Suresh",
            //        LName = "Ghorpade",
            //        Gender = "Male",
            //        Mob = 9865421575
            //    };
            //    ctx.students.Add(s1);
            //    ctx.SaveChanges();
            //    Console.WriteLine("Inserted successfully");
            //}

            using (var ctx = new AppDbContext())
            {
                Student s1 = ctx.students.First(s => s.Id == 7);
                s1.Mob = 9637296207;
                ctx.Update(s1);
                ctx.SaveChanges();

              var students=  ctx.students.ToList();

                foreach (var student in students)
                {
                    Console.WriteLine($"Student {student.Id}\t Name {student.FName}");
                }
            }
        }
        catch (Exception ex)
        {

            throw;
        }
    }
}