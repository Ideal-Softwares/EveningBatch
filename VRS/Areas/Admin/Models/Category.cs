using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VRS.Areas.Admin.Models
{

    [Table("MSCategory")]
    public class Category : BaseColumns
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(20)]
        public string CategoryName { get; set; }

        [Required]
        public bool Status { get; set; }

        public virtual ICollection<Vehicle> Vehicles { get; set; } = new List<Vehicle>();
    }
}
