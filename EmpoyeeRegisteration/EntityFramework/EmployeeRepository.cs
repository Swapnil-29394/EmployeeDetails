using EmpoyeeRegisteration.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmpoyeeRegisteration.EntityFramework
{
    public class EmployeeRepository
    {
        EmployeeDBContext employeeContext = new EmployeeDBContext();

        public List<Employee> GetEmployees()
        {
            return employeeContext.Employees.ToList();
        }

        public Employee GetEmployees(int id)
        {
            return employeeContext.Employees.FirstOrDefault(m=>m.EmployeeID==id);
        }

        public bool InsertEmployee(Employee emp)
        {
            List<Employee> employees = employeeContext.Employees.ToList();
            if (employees.Count>0 && employees.Any(m => m.EmployeeID == emp.EmployeeID))
            {
                return false;
            }
            else
            {
                try
                {
                    employeeContext.Employees.Add(emp);
                    employeeContext.SaveChanges();
                    return true;
                }
                catch
                {
                    return false;
                }
            }
        }

        public void DeleteEmployee(int id)
        {
            Employee emp = employeeContext.Employees.FirstOrDefault(m => m.EmployeeID == id);
            employeeContext.Employees.Remove(emp);
            employeeContext.SaveChanges();
        }

        public void DeleteEmployee(Employee emp)
        {
            employeeContext.Employees.Remove(emp);
            employeeContext.SaveChanges();
        }
    }
}