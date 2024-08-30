using VRS.WebAPI.Data.Model;

namespace VRS.WebAPI.Services
{
    public interface IEmployeeService
    {
        public IEnumerable<Employee> GetAll();

        public Employee GetById(int id);

        public Employee GetByName(string name);

        public IEnumerable<Employee> GetByDesignation(string  designation);

        public int CreateEmployee(Employee employee);

        public int UpdateEmployees(Employee employee);

        public void DeleteEmployee(int id);


    }
}
