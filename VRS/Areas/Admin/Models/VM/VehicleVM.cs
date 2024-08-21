using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace VRS.Areas.Admin.Models.VM
{
    public class VehicleVM
    {
        public long Id { get; set; }

        public int CategoryId { get; set; }

        public int BrandId { get; set; }


        public string VehicleName { get; set; }

        public string ModelName { get; set; }

        public string ModelYear { get; set; }

        public string Color { get; set; }

        public int Seats { get; set; }

        public double Price { get; set; }

        public double RentPerHour { get; set; }

       // public string VehicleImage { get; set; }

        public IFormFile ImageFile { get; set; }

        public bool Availability { get; set; }

        //public virtual Category Category { get; set; } = null!;

        //public virtual Brand Brand { get; set; } = null!;
    }
}
