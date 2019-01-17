using System;
using System.Configuration;
using System.Threading.Tasks;
using EmployeeManager.DTO.Factory;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace EmployeeManager.Service.Test
{
    [TestClass]
    public class EmployeeBOTest
    {
        [TestMethod]
        public async Task GetEmployeeTest()
        {
            string _employeeImplLibrary = ConfigurationManager.AppSettings["EmployeeModelLibrary"];
            string _employeeImplClass = ConfigurationManager.AppSettings["EmployeeModelImpl"];
            EmployeeBO _employeeBO = new EmployeeBO(EmployeeModelFactory.GetEmployeeModel(_employeeImplLibrary, _employeeImplClass));

            //get employee with Id 1 with name Juan
            var employee = await _employeeBO.Get(1);
            Assert.AreEqual(employee.Name, "Juan");
        }
    }
}
