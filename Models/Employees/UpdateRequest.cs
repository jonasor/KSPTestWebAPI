namespace WebApi.Models.Employees;

using System.ComponentModel.DataAnnotations;

public class UpdateRequest
{
    public string Picture { get; set; }
    public string FullName { get; set; }
    public string Job { get; set; }
    [Range( 0,9999999)]
    public decimal Salary { get; set; }
    public string Status { get; set; }
    public DateTime ContractDate { get; set; }
    public Beneficiaries.UpdateRequest Beneficiary {get; set; }

}