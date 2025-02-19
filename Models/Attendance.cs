using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APIs.Models
{
    public class Attendance
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AttendanceId { get; set; }
        [Required]
        [ForeignKey("Employee")]
        public int EmployeeId { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime CheckIn { get; set; }
        [DataType(DataType.Date)]
        public DateTime? CheckOut { get; set; }

        public virtual Employee? Employee { get; set; } = null!;
    }

}
