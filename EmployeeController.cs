using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication3.model;


namespace WebApplication3.controller
{
    public class EmployeeController:Controller
    {
        //IEmployeeRepository er=new EmployeeRepository();

       private readonly IEmployeeRepository employeeRepository;//dependency injected object
        public EmployeeController(IEmployeeRepository emRepository)
        {
            employeeRepository = emRepository;


        }
        public IActionResult Search(int? id)
        {
            int ID =(int)( (id == null) ? 1 : id);

           MyEmployee emp=employeeRepository.GetEmployee(ID);
            //if(emp!=null)
            //{
            //    return Content(emp.Id + "\n" + emp.Name + "\n" + emp.Email + "\n" + emp.Dept);
            //}
            //return Content("employee does not exist");
            //return emp.Id+"\n"+emp.Name+"\n"+emp.Email+"\n"+emp.Dept; 



            //**************************************************************************************************
            //this code is for """"viewData****
            //ViewData["id"] = emp.Id;
            //ViewData["name"] = emp.Name;
            //ViewData["email"] = emp.Email;
            //ViewData["dept"] = emp.Dept;

            //********object is passing ******//
            //ViewData["Employee"]=emp;

            //******************************************************************************************************

            //***********VIEWbag code****************************************************************************



            //ViewBag.id = emp.Id;
            //ViewBag.name = emp.Name;
            //ViewBag.email = emp.Email;
            //ViewBag.dept = emp.Dept;

            //ViewBag.employee = emp;
            //return View();



            return View(emp);
        }
        public IActionResult Index()
        {
            List<MyEmployee> elist = employeeRepository.DisplayDetails();
            return View(elist);
          
        }
       public ViewResult AboutEmployee()
        {
            MyEmployee emp = employeeRepository.GetEmployee(2);
            //ViewBag.projectName = "BookHive";
            EmployeeProjectView ep = new EmployeeProjectView();
            ep.employee = emp;
            ep.projectName = "Book Hive";

            return View(ep);

           
        }


        public IActionResult GetAllEmployees()
        {
            List<MyEmployee> elist = (employeeRepository.DisplayDetails()).Where(e=>e.Dept== "insurance").ToList();
            //abosulet path to refer a view
            //return View("~/Views/Employee/Index.cshtml", elist);
            return View("Index", elist);

        }
    }
}
