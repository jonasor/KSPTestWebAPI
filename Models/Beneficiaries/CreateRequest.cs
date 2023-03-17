namespace WebApi.Models.Beneficiaries;

using System.ComponentModel.DataAnnotations;
using WebApi.Entities;

public class CreateRequest
{
    [Required]
    public string FullName { get; set; }
    [Required]
    public string Relationship { get; set; }
    [Required]
    public DateTime Birthday { get; set; }
    [Required]
    public Gender Gender { get; set; }
}