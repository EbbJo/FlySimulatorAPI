using System.ComponentModel.DataAnnotations;

namespace FlySimulatorAPI.Models.Employee;

public class Employee {
    [Key]
    public int Id { get; set; }

    [Required]
    public string Name { get; set; } = string.Empty;

    [Required]
    public EmployeeType Type { get; set; } = EmployeeType.None;

    [Required]
    public decimal Salary { get; set; }
}