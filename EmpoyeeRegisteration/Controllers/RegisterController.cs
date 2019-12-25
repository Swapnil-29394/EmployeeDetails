using EmpoyeeRegisteration.EntityFramework;
using EmpoyeeRegisteration.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmpoyeeRegisteration.Controllers
{
    public class RegisterController : Controller
    {
        EmployeeRepository employeeRepository = new EmployeeRepository();
        EmployeeDBContext employeeContext = new EmployeeDBContext();
        // GET: Register
        public ActionResult Index()
        {
            Employee emp = new Employee();
            return View();
        }
        [HttpPost]
        public ActionResult Index(Employee emp)
        {

            if (DateTime.Now.Year - emp.DateOfBirth.Year < 21)
            {
                TempData["idAlreadyExist"] = "The person age should be greater than 21";
                return View();
            }
            if (emp.DateOfJoining.Year - emp.DateOfBirth.Year < 18)
            {
                TempData["idAlreadyExist"] = "Joining Date or Date of birth is not correct";
                return View();
            }
            bool flag = employeeRepository.InsertEmployee(emp);
            if (flag)
                return RedirectToAction("Message", new { Message = "Successfully Registered Employee" });

            AddErrors("Email ID is already Registered");

            return View(emp);
        }
        [HttpGet]
        public ActionResult DisplayData()
        {
            List<Employee> emp = employeeRepository.GetEmployees();
            return View(emp);
        }
        [HttpPost]
        public ActionResult DisplayData(string searchBy, string search)
        {
            if (searchBy == "Gender")
            {
                return View(employeeContext.Employees.Where(x => x.Gender.StartsWith(search) || search == null).ToList());
            }
            else
            {
                return View(employeeContext.Employees.Where(x => x.EmployeeName.StartsWith(search) || search == null).ToList());
            }
        }
        private void AddErrors(string error)
        {

            ModelState.AddModelError("", error);

        }
        public ActionResult Message(string message)
        {
            return View();
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            Employee emp = employeeRepository.GetEmployees(id);
            TempData["ID"] = emp.EmployeeID;
            return View(emp);
        }
        [HttpPost]
        public ActionResult Delete(object emp)
        {
            employeeRepository.DeleteEmployee(Convert.ToInt32(TempData["ID"]));
            return RedirectToAction("DisplayData");
        }
    }
}