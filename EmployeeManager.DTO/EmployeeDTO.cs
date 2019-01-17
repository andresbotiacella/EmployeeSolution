using System;
using System.Runtime.Serialization;

namespace EmployeeManager.DTO
{
    public class EmployeeDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ContractTypeName { get; set; }
        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public string RoleDescription { get; set; }
        public decimal BaseSalary { get; set; }
        public decimal AnnualSalary { get; set; }
    }
}
