using System;
using System.Collections.Generic;
using System.Text;
using EmployeeManager.Common;

namespace EmployeeManager.DTO.Factory
{
    public abstract class EmployeeFactory
    {
        public abstract EmployeeDTO GetEmployee(Employee employee);
    }
}
