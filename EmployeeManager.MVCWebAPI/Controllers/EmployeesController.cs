using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using EmployeeManager.DTO;
using EmployeeManager.DTO.Factory;
using EmployeeManager.Service;

namespace EmployeeManager.WebAPI.Controllers
{
    public class EmployeesController : ApiController
    {
        //using local variable to not use any external IOC container for the sake of the test (ninject, unity, etc)
        private static readonly string _employeeImplLibrary = ConfigurationManager.AppSettings["EmployeeModelLibrary"];
        private static readonly string _employeeImplClass = ConfigurationManager.AppSettings["EmployeeModelImpl"];
        private EmployeeBO _employeeBO = new EmployeeBO(EmployeeModelFactory.GetEmployeeModel(_employeeImplLibrary, _employeeImplClass));

        public async Task<IHttpActionResult> Get()
        {
            try
            {
                var employees = (await _employeeBO.Get()).ToList();
                List<EmployeeDTO> employeeDTOList = new List<EmployeeDTO>();
                foreach (var employee in employees)
                {
                    employeeDTOList.Add(new ConcreteEmployeeFactory().GetEmployee(employee));
                }
                return Ok(employeeDTOList);
            }
            catch (ArgumentException)
            {
                return NotFound();
            }
        }

        public async Task<IHttpActionResult> Get(int id)
        {
            try
            {
                var employee = await _employeeBO.Get(id);
                var employeeDTO = new ConcreteEmployeeFactory().GetEmployee(employee);
                return Ok(employeeDTO);
            }
            catch (ArgumentException)
            {
                return NotFound();
            }
        }
    }
}
