namespace WebApi.Models.Beneficiaries;

using System.ComponentModel.DataAnnotations;
using WebApi.Entities;

public class UpdateRequest
{
    public string FullName { get; set; }
    public string Relationship { get; set; }
    public DateTime Birthday { get; set; }
    public Gender Gender { get; set; }
}