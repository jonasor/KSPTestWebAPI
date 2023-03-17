namespace WebApi.Controllers;

using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using WebApi.Models.Employees;
using WebApi.Services;

[ApiController]
[Route("[controller]")]
public class EmployeesController : ControllerBase
{
    private IEmployeeService _employeeService;
    private IMapper _mapper;

    public EmployeesController(
        IEmployeeService employeeService,
        IMapper mapper)
    {
        _employeeService = employeeService;
        _mapper = mapper;
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        var employees = _employeeService.GetAll();
        return Ok(employees);
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        var employee = _employeeService.GetById(id);
        return Ok(employee);
    }

    [HttpPost]
    public IActionResult Create(CreateRequest model)
    {
        _employeeService.Create(model);
        return Ok(new { message = "Employee created" });
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, UpdateRequest model)
    {
        _employeeService.Update(id, model);
        return Ok(new { message = "Employee updated" });
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        _employeeService.Delete(id);
        return Ok(new { message = "Employee deleted" });
    }
}