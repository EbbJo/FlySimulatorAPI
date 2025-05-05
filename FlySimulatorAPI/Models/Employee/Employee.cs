using System.ComponentModel.DataAnnotations;

namespace FlySimulatorAPI.Models.Employee;

[Serializable]
public class Employee {
    [Key]
    public Guid Id { get; set; }

    /// <summary>
    /// The name of the employee.
    /// </summary>
    [Required]
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// The job title of the employee.
    /// </summary>
    [Required]
    public EmployeeType Type { get; set; } = EmployeeType.None;

    /// <summary>
    /// The employee's salary in USD/hr.
    /// </summary>
    [Required]
    public decimal Salary { get; set; }

    /// <summary>
    /// Instantiates the employee and gives it a new unique ID.
    /// </summary>
    public Employee() {
        Id = Guid.NewGuid();
    }

    public override string ToString() {
        return $"Employee {Id}: Name: {Name}, Type: {Type}, Salary: {Salary}USD/hr";
    }
}