using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using EmployeeManager.Service;

namespace EmployeeManager.DTO.Factory
{
    public class EmployeeModelFactory
    {
        public static IEmployeeModel GetEmployeeModel(string implLibrary, string implClass)
        {
            object obj = null;
            Assembly a = Assembly.Load(implLibrary);
            //now try to get a reference to the object
            Type type = a.GetType(implClass);

            if (type != null)
            {
                ConstructorInfo info = type.GetConstructor(Type.EmptyTypes);
                Object[] parms = new Object[0];
                obj = info.Invoke(parms);
            }

            return (IEmployeeModel)obj;

        }
    }
}
