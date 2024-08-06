namespace VRS.Areas.Admin.Models
{
    public class BaseColumns
    {
        public Guid CreatedBy { get; set; }
        public DateTime CreatedTime { get; set; }
        public Guid? UpdatedBy { get; set; }
        public DateTime? UpdatedTime { get; set; }
    }
}
