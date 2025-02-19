using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APIs.Models
{
    [Table("Employees")]
    public class Employee
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EmployeeId { get; set; }
        [Required]
        [Column(TypeName="nvarchar(50)")]
        public string FirstName { get; set; } = string.Empty;
        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string LastName { get; set; } = string.Empty;
        [Required]
        [Column(TypeName = "nvarchar(100)")]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;
        [Required]
        [Column(TypeName = "nvarchar(15)")]
        [Phone]
        public string? PhoneNumber { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime HireDate { get; set; }
        [Required]
        [Column(TypeName = "decimal(18,2)")]
        [Range(0, double.MaxValue, ErrorMessage = "Salary must be greater than 0")]
        public decimal Salary { get; set; }
    }

}
