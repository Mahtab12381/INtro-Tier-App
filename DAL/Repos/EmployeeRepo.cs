using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    public class EmployeeRepo
    {
        static EmpContext empContext;

        static EmployeeRepo()
        {
            empContext = new EmpContext();
        }
        public static List<Employee> Get()
        {
            return empContext.Employees.ToList();
        }
        public static Employee Get(int id) {
            return empContext.Employees.Find(id);
        }
        public static bool Create(Employee employee)
        {
            empContext.Employees.Add(employee);
            return empContext.SaveChanges()>0;
        }
        public static bool Delete(int id)
        {
            var extemp=Get(id);
            empContext.Employees.Remove(extemp);
            return empContext.SaveChanges()>0;
        }
        public static bool Update(Employee employee)
        {
            var extemp = empContext.Employees.Find(employee.Id);
            empContext.Entry(extemp).CurrentValues.SetValues(employee);
            return empContext.SaveChanges() > 0;    
        }    
    }
}
