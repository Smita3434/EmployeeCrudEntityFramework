using EmployeeCrudEntityFramework.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeCrudEntityFramework.Data
{
    public class EmployeeDAL
    {
        ApplicationDbContext db;

        public EmployeeDAL(ApplicationDbContext db)
        {
            this.db = db;
        }

        public List<Employee> GetAllEmployee()
        {
            return db.Employees.ToList();
        }
        public Employee GetEmployeeById(int id)
        {
            Employee e = db.Employees.Where(x => x.Id == id).FirstOrDefault();
            return e;
        }
        public int AddEmployee(Employee emp)
        {
            // add prod object in the produts collections
            db.Employees.Add(emp);
            // reflect the change in DB
            int result = db.SaveChanges();
            return result;
        }
        public int UpdateEmployee(Employee emp)
        {
            int result = 0;
            // p object hold old data
            Employee e = db.Employees.Where(x => x.Id == emp.Id).FirstOrDefault();
            if (e != null)
            {
                e.Name = emp.Name;
                e.Salary = emp.Salary;
                result = db.SaveChanges();
            }
            return result;
        }
        public int DeleteEmployee(int id)
        {
            int result = 0;
            Employee e = db.Employees.Where(x => x.Id == id).FirstOrDefault();
            if (e != null)
            {
                db.Employees.Remove(e);
                result = db.SaveChanges();
            }
            return result;
        }
    }
}
