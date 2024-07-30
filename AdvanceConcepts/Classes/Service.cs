using AdvanceConcepts.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvanceConcepts.Classes
{
    internal class Service : IService
    {
        public void Serve()
        {
            Console.WriteLine("Service Called");
        }
    }
}
