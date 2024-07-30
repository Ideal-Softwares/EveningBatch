using AdvanceConcepts.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvanceConcepts.Classes
{
    internal class Client
    {
        private readonly IService _service;

        public Client(IService service)
        {
            _service = service;
        }

        public void Start()
        {
            _service.Serve();
        }
    }
}
