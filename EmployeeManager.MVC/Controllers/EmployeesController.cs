using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using System.Xml;
using EmployeeManager.DTO;
using Newtonsoft.Json;

namespace EmployeeManager.MVC.Controllers
{
    public class EmployeesController : Controller
    {
        // GET: Employees
        public ActionResult Index(FormCollection fc)
        {
            if (fc.Keys.Count > 0)
            {
                var employeeID = fc["ID"];
                var path = !String.IsNullOrEmpty(employeeID) ? "/" + employeeID : String.Empty;
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri("http://localhost:52421");
                HttpResponseMessage response = client.GetAsync("api/employees" + path).Result;
                if (response.IsSuccessStatusCode)
                {
                    if (String.IsNullOrEmpty(path))
                        ViewBag.EmployeeList = response.Content.ReadAsAsync<IEnumerable<EmployeeDTO>>().Result;
                    else
                    {
                        ViewBag.EmployeeList = new List<EmployeeDTO>()
                            {response.Content.ReadAsAsync<EmployeeDTO>().Result};
                    }
                }
            }
            return View();
        }

        //// GET: Employees/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}
    }
}
