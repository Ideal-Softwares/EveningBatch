using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VRMS.Data.Entities
{
    [Table("App_Vheicle")]
    public class Vheicle
    {
        [Key]
        [Required]
        public long Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string Model { get; set; }

        [Required]
        public string Color { get; set; }


        public string CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }

        public string? updatedBy { get; set; }
        public DateTime? updatedDate { get; set; }

        public string? DeletedBy { get; set; }
        public DateTime? deletedDate { get; set; }

    }
}
