using Microsoft.EntityFrameworkCore.Storage;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata.Ecma335;

namespace VRS.Areas.Admin.Models
{
    [Table("MSVehicle")]
    public class Vehicle: BaseColumns
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }

        [ForeignKey("CategoryId")]
        [Required]
        public int CategoryId { get; set; }

        [ForeignKey("BrandId")]
        [Required]
        public int BrandId { get; set; }


        [Required]
        [StringLength(100)]
        public string VehicleName { get; set; }

        [Required]
        [StringLength(100)]
        public string ModelName { get; set; }

        [Required]
        [StringLength(5)]
        public string ModelYear { get; set; }

        [Required]
        [StringLength(10)]
        public string Color { get; set; }

        [Required]
        public int Seats { get; set; }

        [Required]
        public double Price { get; set; }

        [Required]
        public double RentPerHour { get; set; }

        [Required]
        public string VehicleImage { get; set; }

        [Required]
        public bool Availability { get; set; }

        public virtual Category Category { get; set; } = null!;

        public virtual Brand Brand { get; set; } = null!;


    }
}
