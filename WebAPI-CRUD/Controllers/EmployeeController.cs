using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPI_CRUD.Models;

namespace WebAPI_CRUD.Controllers
{
    public class EmployeeController : ApiController
    {
        EmployeeEntities _db;
        public EmployeeController()
        {
            _db = new EmployeeEntities();

        }
        public string Post(Employee employee)
        {
            try
            {
                _db.Employees.Add(employee);
                _db.SaveChanges();
                return "Save info successfully!";
            }
            catch (Exception ex)
            {

                return ex.Message;
            }
        }
        public IEnumerable<Employee> Get()
        {
            return _db.Employees.ToList();
        }
        public Employee Get(int id)
        {
            Employee employee = _db.Employees.Find(id);
            if (employee != null)
            {
                return employee;
            }
            else
            {
                return null;
            }
        }
        public string Put(int id, Employee employee)
        {
            try
            {
                var existEmployee = _db.Employees.Find(id);
                if (existEmployee != null)
                {
                    existEmployee.Name = employee.Name;
                    _db.Entry(existEmployee).State = System.Data.Entity.EntityState.Modified;
                    _db.SaveChanges();
                    return "Save info successfully!";
                }
                else
                {
                    return "There no id";
                }
            }
            catch (Exception ex)
            {

                return ex.Message;
            }
        }
        public string Delete(int id)
        {
            try
            {
                Employee employee = _db.Employees.Find(id);
                if (employee != null)
                {
                    _db.Employees.Remove(employee);
                    _db.SaveChanges();
                    return "Delete successfully";
                }
                else
                {
                    return "There no id";
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
