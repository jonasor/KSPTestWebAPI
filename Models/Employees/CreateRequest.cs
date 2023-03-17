namespace WebApi.Models.Employees;

using System.ComponentModel.DataAnnotations;

public class CreateRequest
{
    [Required]
    public string Picture { get; set; }

    [Required]
    public string FullName { get; set; }

    [Required]
    public string Job { get; set; }

    [Required]
    [Range( 0,9999999)]
    public decimal Salary { get; set; }

    [Required]
    public string Status { get; set; }

    [Required]
    public DateTime ContractDate { get; set; }

    [Required]
    public Beneficiaries.CreateRequest Beneficiary {get; set; }
}