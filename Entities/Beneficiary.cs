namespace WebApi.Entities;

public class Beneficiary
{
    public int Id { get; set; }
    public int EmployeeRef { get; set; }
    public Employee Employee { get; set; }
    public string FullName { get; set; }
    public string Relationship { get; set; }
    public DateTime Birthday { get; set; }
    public Gender Gender { get; set; }
}