using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polymorphism
{
    public class Animal
    {
        public virtual void MakeSound()
        {
            Console.WriteLine("This is a generic Sound");
        }
    }

    public class Cow : Animal
    {
        public override void MakeSound()
        {
            Console.WriteLine("This is Cow's Sound");
        }
    }
}
