using Microsoft.EntityFrameworkCore;

namespace WebApi.Entities;
public class Employee
{
    public int Id { get; set; }
    public string Picture { get; set; }
    public string FullName { get; set; }
    public string Job { get; set; }
    [Precision(18, 2)]
    public decimal Salary { get; set; }
    public string Status { get; set; }
    public DateTime ContractDate { get; set; }
    public Beneficiary Beneficiary{ get; set; }
}