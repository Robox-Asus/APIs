using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APIs.Models
{
    public class Payroll
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PayrollId { get; set; }
        [Required]
        [ForeignKey("Employee")]
        public int EmployeeId { get; set; }
        [Required]
        [Column(TypeName ="decimal(18,2)")]
        [Range(0, double.MaxValue, ErrorMessage = "Salary must be greater than 0")]
        public decimal Salary { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        [Range(0, double.MaxValue, ErrorMessage = "Bomus must be greater than 0")]
        public decimal? Bonus { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        [Range(0, double.MaxValue, ErrorMessage = "Deductions must be greater than 0")]
        public decimal? Deductions { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime PayDate { get; set; }

        public virtual Employee? Employee { get; set; } = null!;
    }

}
