using System.ComponentModel.DataAnnotations;

namespace EmployeeDepartmentManagementAPI.Models
{
    public class Employee
    {
        public int EmployeeId { get; set; }

        [Required(ErrorMessage = "First name is required.")]
        [StringLength(50)]
        public string FirstName { get; set; }
            = string.Empty;

        [Required(ErrorMessage = "Last name is required.")]
        [StringLength(50)]
        public string LastName { get; set; }
            = string.Empty;

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage =
            "Please enter a valid email address.")]
        public string Email { get; set; }
            = string.Empty;

        public string? MobileNumber { get; set; }

        public DateTime? DateOfBirth { get; set; }

        public string? Gender { get; set; }

        [Range(0, double.MaxValue,
            ErrorMessage = "Salary cannot be negative.")]
        public decimal Salary { get; set; }

        [Required(ErrorMessage =
            "Date of joining is required.")]
        public DateTime DateOfJoining { get; set; }

        [Required(ErrorMessage =
            "Department ID is required.")]
        public int DepartmentId { get; set; }

        public string? Designation { get; set; }

        public string EmploymentStatus { get; set; }
            = "Active";
    }
}