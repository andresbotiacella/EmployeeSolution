using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using EmployeeManager.Common;
using EmployeeManager.Service;

namespace EmployeeManager.DataAccess
{
    public class MASGlobalEmployeeModel : MASGlobalModel<Employee>, IEmployeeModel
    {
        public override async Task<IEnumerable<Employee>> Get()
        {
            IEnumerable<Employee> employeeList = null;
            using (client)
            {
                HttpResponseMessage response = await client.GetAsync("api/employees");
                if (response.IsSuccessStatusCode)
                {
                    employeeList = await response.Content.ReadAsAsync<List<Employee>>();
                }
            }
            return employeeList;
        }

        public override async Task<Employee> Get(int id)
        {
            var employeeList = await Get();
            return employeeList?.FirstOrDefault(employee => employee.Id == id);
        }
    }
}
