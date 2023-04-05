using BLL.DTOs;
using DAL;
using DAL.Models;
using DAL.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Service
{
    public class EmployeeService
    {
        public static List<EmployeeDTO> Get()
        {
            var data = DataAccessFactory.EmployeeData().Get();
            return Convert(data);
        }
        public static EmployeeDTO Get(int id)
        {
            var data= DataAccessFactory.EmployeeData().Get(id);
            return Convert(data);
        }
        public static bool Create(Employee employee) { 
            return EmployeeRepo.Create(employee);
        }
        public static bool Update(Employee employee)
        {
            return EmployeeRepo.Update(employee);   
        }
        public static bool Delete(int id)
        {
            return EmployeeRepo.Delete(id);
        }
        public static List<Employee>Get10()
        {
            var data = from e in EmployeeRepo.Get()
                       where e.Id <11
                       select e;    
            return data.ToList();
        }

        static List<EmployeeDTO> Convert(List<Employee> employees)
        {
            var data = new List<EmployeeDTO>();
            foreach (var employee in employees)
            {
                data.Add(new EmployeeDTO()
                {
                    Id = employee.Id,
                    Name = employee.Name
                });
            }
            return data;

        }
        static Employee Convert(EmployeeDTO emp)
        {
            return new Employee()
            {
                Id = emp.Id,
                Name = emp.Name
            };
        }
        static EmployeeDTO Convert(Employee emp)
        {
            return new EmployeeDTO()
            {
                Id = emp.Id,
                Name = emp.Name
            };
        }
    }
}
