using System.ComponentModel.DataAnnotations;

namespace EmployeeManagementSystem.Models
{
    public class Department
    {
        [Required]
        public string DepartmentName { get; set; } = string.Empty;

        [Required]
        public string DepartmentHead { get; set; } = string.Empty;

        [Required]
        [Phone]
        public string HeadContactNumber { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        public string HeadEmail { get; set; } = string.Empty;
    }
}