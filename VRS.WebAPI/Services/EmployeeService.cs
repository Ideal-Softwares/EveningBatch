using VRS.WebAPI.Data;
using VRS.WebAPI.Data.Model;

namespace VRS.WebAPI.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly AppDbContext _context;

        public EmployeeService(AppDbContext context)
        {
            _context = context;
        }
        public int CreateEmployee(Employee employee)
        {
            _context.Employees.Add(employee);
            return _context.SaveChanges();
        }

        public void DeleteEmployee(int id)
        {
            Employee employee = _context.Employees.First(x => x.Id == id);
            _context.Employees.Remove(employee);
        }

        public IEnumerable<Employee> GetAll()
        {
            return _context.Employees.ToList();
        }

        public IEnumerable<Employee> GetByDesignation(string designation)
        {
            return _context.Employees.Where(e => e.Designation.ToLower().Contains(designation.ToLower())).ToList();
        }

        public Employee GetById(int id)
        {
            return _context.Employees.First(e => e.Id == id);
        }

        public Employee GetByName(string name)
        {
            return _context.Employees.First(e => e.Name.ToLower() == name.ToLower());
        }

        public int UpdateEmployees(Employee employee)
        {
            _context.Employees.Update(employee);
            _context.SaveChanges();
            return employee.Id;
        }
    }
}
