using System.ComponentModel.DataAnnotations;
using DesktopApplication.Dto;
using DesktopApplication.ExternalHandlers;

namespace DesktopApplication.Services;

public class EmployeeService(DbHandler db)
{
    public IEnumerable<Employee> GetEmployees()
    {
        return db.Employees;
    }

    public Employee? GetEmployee(string username, string password)
    {
        return db.Employees.
            FirstOrDefault(x => x.Username == username && x.Password == password);
    }
    
    public Employee? GetEmployee(int id) => db.Employees.
        FirstOrDefault(x => x.EmployeeId == id);

    public void AddEmployee(Employee employee)
    {
        Validator.ValidateObject(employee, new ValidationContext(employee), true);
        db.Employees.Add(employee);
        db.SaveChanges();
    }

    public void UpdateEmployee(Employee employee)
    {
        Validator.ValidateObject(employee, new ValidationContext(employee), true);
        db.Employees.Update(employee);
        db.SaveChanges();
    }
    
    public void RemoveEmployee(int id)
    {
        Employee? emp = db.Employees.FirstOrDefault(x => x.EmployeeId == id);
        if (emp is not null) db.Employees.Remove(emp);
    } 
}