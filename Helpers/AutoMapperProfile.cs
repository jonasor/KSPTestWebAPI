namespace WebApi.Helpers;

using AutoMapper;
using WebApi.Entities;
using WebApi.Models.Employees;
using WebApi.Models.Beneficiaries;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        // CreateRequest -> Employee
        CreateMap<Models.Employees.CreateRequest, Employee>();

        // UpdateRequest -> Employee
        CreateMap<Models.Employees.UpdateRequest, Employee>()
        .ForAllMembers(x => x.Condition(
                (src, dest, prop) =>
                {
                    // ignore both null & empty string properties
                    if (prop == null) return false;
                    if (prop.GetType() == typeof(string) && string.IsNullOrEmpty((string)prop)) return false;

                    return true;
                }
            ));
        
        // CreateRequest -> Beneficiary
        CreateMap<Models.Beneficiaries.CreateRequest, Beneficiary>();

        // UpdateRequest -> Beneficiary
        CreateMap<Models.Beneficiaries.UpdateRequest, Beneficiary>();
            
    }
}