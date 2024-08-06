using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VRS.Areas.Admin.Models
{
    [Table("MSBrand")]
    public class Brand :BaseColumns
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(20)]
        public string BrandName { get; set; }

        [Required]
        public bool Status { get; set; }

        public virtual ICollection<Vehicle> Vehicles { get; set; } = new List<Vehicle>();
    }
}
