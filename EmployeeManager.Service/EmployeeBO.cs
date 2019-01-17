using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeManager.Common;
using System.Configuration;

namespace EmployeeManager.Service
{
    public class EmployeeBO
    {
        private readonly IEmployeeModel _employeeModel;
        public EmployeeBO(IEmployeeModel employeeModel)
        {
            _employeeModel = employeeModel;
        }

        public async Task<IEnumerable<Employee>> Get()
        {
            var employees = (await _employeeModel.Get()).ToList();
            Parallel.ForEach(employees, GetAnnualSalary);
            return employees;
        }

        public async Task<Employee> Get(int id)
        {
            var employee = await _employeeModel.Get(id);
            GetAnnualSalary(employee);
            return employee;
        }

        private decimal GetTotalHourlySalary(decimal hourlySalary)
        {
            return 120 * hourlySalary * 12;
        }

        private decimal GetTotalMonthlySalary(decimal monthlySalary)
        {
            return monthlySalary * 12;
        }

        private void GetAnnualSalary(Employee employee)
        {
            if (employee != null)
            {
                switch (employee.ContractTypeName) {
                    case "HourlySalaryEmployee":
                        employee.AnnualSalary = GetTotalHourlySalary(employee.HourlySalary);
                        break;
                    case "MonthlySalaryEmployee":
                        employee.AnnualSalary = GetTotalMonthlySalary(employee.MonthlySalary);
                        break;
                    default:
                        //take whichever is higher (not in the requirements of the assessment)
                        var hourly = GetTotalHourlySalary(employee.HourlySalary);
                        var monthly = GetTotalMonthlySalary(employee.MonthlySalary);
                        employee.AnnualSalary = hourly > monthly ? hourly : monthly;
                        employee.ContractTypeName = hourly > monthly ? "HourlySalaryEmployee" : "MonthlySalaryEmployee";
                        break;
                }
            }
        }

        
    }
}
