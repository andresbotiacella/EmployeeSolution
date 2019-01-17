using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using EmployeeManager.Common;

namespace EmployeeManager.DTO
{
    public class MonthlyEmployeeDTO : EmployeeDTO
    {
        public MonthlyEmployeeDTO(Employee employee)
        {
            Id = employee.Id;
            Name = employee.Name;
            ContractTypeName = "Monthly";
            RoleId = employee.RoleId;
            RoleName = employee.RoleName;
            RoleDescription = employee.RoleDescription;
            BaseSalary = employee.MonthlySalary;
            AnnualSalary = employee.AnnualSalary;
        }
    }
}
