using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APIs.Models
{
    public class Leave
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int LeaveId { get; set; }
        [Required]
        [ForeignKey("Employee")]
        public int EmployeeId { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }
        [Required]
        [Column(TypeName ="nvarchar(50)")]
        public string LeaveType { get; set; } = string.Empty;
        [Required]
        [Column(TypeName ="nvarchar(16)")]
        [DefaultValue("Pending")]
        public string Status { get; set; } = "Pending";

        public virtual Employee? Employee { get; set; } = null!;
    }

}
