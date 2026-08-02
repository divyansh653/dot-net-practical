using System.ComponentModel.DataAnnotations;

namespace EmployeeDepartmentManagementAPI.Models
{
    public class Department
    {
        public int DepartmentId { get; set; }

        [Required(ErrorMessage = "Department name is required.")]
        [StringLength(50, ErrorMessage =
            "Department name cannot exceed 50 characters.")]
        public string DepartmentName { get; set; }
            = string.Empty;

        [Required(ErrorMessage = "Department code is required.")]
        [StringLength(10, ErrorMessage =
            "Department code cannot exceed 10 characters.")]
        public string DepartmentCode { get; set; }
            = string.Empty;

        [Required(ErrorMessage = "Department status is required.")]
        public string Status { get; set; }
            = "Active";
    }
}