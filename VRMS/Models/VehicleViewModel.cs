using System.ComponentModel.DataAnnotations;

namespace VRMS.Models
{
    public class VehicleViewModel
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string Model { get; set; }

        public string Color { get; set; }
    }
}
