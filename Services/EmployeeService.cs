namespace WebApi.Services;

using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WebApi.Entities;
using WebApi.Helpers;
using WebApi.Models.Employees;

public interface IEmployeeService
{
    IEnumerable<Employee> GetAll();
    Employee GetById(int id);
    void Create(CreateRequest model);
    void Update(int id, UpdateRequest model);
    void Delete(int id);
}

public class EmployeeService : IEmployeeService
{
    private DataContext _context;
    private readonly IMapper _mapper;

    public EmployeeService(
        DataContext context,
        IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public IEnumerable<Employee> GetAll()
    {
        return _context.Employees
                .Include(e => e.Beneficiary)
                .ToList();    
    }

    public Employee GetById(int id)
    {
        return getEmployee(id);
    }

    public void Create(CreateRequest model)
    {
        // validate
        if (_context.Employees.Any(x => x.FullName == model.FullName))
            throw new AppException("Employee with the full name '" + model.FullName + "' already exists");

        // map model to new employee object
        var employee = _mapper.Map<Employee>(model);
        
        // save employee
        _context.Employees.Add(employee);
        _context.SaveChanges();
    }

    public void Update(int id, UpdateRequest model)
    {
        var employee = getEmployee(id);

        // validate
        if (model.FullName != employee.FullName && _context.Employees.Any(x => x.FullName == model.FullName))
            throw new AppException("employee with the full name '" + model.FullName + "' already exists");

        // copy model to employee and save
        _mapper.Map(model, employee);
        _context.Employees.Update(employee);
        _context.SaveChanges();
    }

    public void Delete(int id)
    {
        var employee = getEmployee(id);
        _context.Employees.Remove(employee);
        _context.SaveChanges();
    }

    // helper methods

    private Employee getEmployee(int id)
    {
        var employee = _context.Employees.Find(id);
        if (employee == null) throw new KeyNotFoundException("Employee not found");
        var beneficiary = _context.Beneficiaries.FirstOrDefault(x => x.EmployeeRef == id);
        employee.Beneficiary = beneficiary;
        return employee;
    }
}