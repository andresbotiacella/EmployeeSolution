using System;
using System.Collections.Generic;
using System.Text;
using EmployeeManager.Common;
using EmployeeManager.Service;

namespace EmployeeManager.DTO.Factory
{
    public class ConcreteEmployeeFactory : EmployeeFactory
    {
        public override EmployeeDTO GetEmployee(Employee employee)
        {
            switch (employee.ContractTypeName)
            {
                case "HourlySalaryEmployee":
                    return new HourlyEmployeeDTO(employee);
                case "MonthlySalaryEmployee":
                    return new MonthlyEmployeeDTO(employee);
                default:
                    throw new ArgumentException("The Contract Type does not exist.");
            }
        }
    }
}
