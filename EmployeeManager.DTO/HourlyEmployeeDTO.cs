using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using EmployeeManager.Common;

namespace EmployeeManager.DTO
{
    public class HourlyEmployeeDTO : EmployeeDTO
    {
        public HourlyEmployeeDTO(Employee employee)
        {
            Id = employee.Id;
            Name = employee.Name;
            ContractTypeName = "Hourly";
            RoleId = employee.RoleId;
            RoleName = employee.RoleName;
            RoleDescription = employee.RoleDescription;
            BaseSalary = employee.HourlySalary;
            AnnualSalary = employee.AnnualSalary;
        }
    }
}
