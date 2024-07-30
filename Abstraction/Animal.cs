using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstraction
{
    abstract class Animal
    {
        /// <summary>
        /// Abstract Methods
        /// Abstract methods does not have a body
        /// </summary>
        public abstract void MakeSound();

        /// <summary>
        /// Regular Method
        /// </summary>
        public void Sleep()
        {
            Console.WriteLine("Zzz....");
        }
    }
}
