using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstraction
{
     class Dog : Animal, IPet
    {
       
        public override void MakeSound()
        {
            Console.WriteLine("Bark!...");
        }
        public void Eat()
        {
            Console.WriteLine("Dot is Eating!....");
        }

        public void Play()
        {
            Console.WriteLine("Dog is Playing!....");
        }
    }

    class Cat : IPet
    {
        public void Eat()
        {
            Console.WriteLine("Cat is Eating!....");
        }

        public void Play()
        {
            Console.WriteLine("Cat is Playing!....");
        }
    }
}
