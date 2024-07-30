using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpOOPs
{
    public class Student
    {
        //Private Data Members
        private long Mob;

        //Public Data Members
        public int RollNo;
        public string Name;

        public void DisplyDetails()
        {
            Console.WriteLine($"Student Roll Number is {RollNo} and name is {Name} and Mobile number is {Mob}");
        }

        public void UpdateMob(long m)
        {
            Mob = m;
        }

    }
}
