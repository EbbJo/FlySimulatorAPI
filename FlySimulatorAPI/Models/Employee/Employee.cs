using System.ComponentModel.DataAnnotations;

namespace FlySimulatorAPI.Models.Employee;

[Serializable]
public class Employee {
    [Key]
    public Guid Id { get; set; }

    [Required]
    public string Name { get; set; } = string.Empty;

    [Required]
    public EmployeeType Type { get; set; } = EmployeeType.None;

    /// <summary>
    /// Dollars/Hour
    /// </summary>
    [Required]
    public decimal Salary { get; set; }

    public Employee() {
        Id = Guid.NewGuid();
    }
}