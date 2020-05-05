using IT481Assignment_Data;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IT481Assignment_Business
{
    public class Employees : IEmployees
    {
        private DataManager dataManager;
        private List<Employee> employees = new List<Employee>();

        public int EmployeeCount => employees.Count;

        public IReadOnlyCollection<Employee> EmployeeList => new ReadOnlyCollection<Employee>(employees);


        public Employees(string connectionString)
        {
            DataInitializer initializer = new DataInitializer(connectionString);
            dataManager = initializer.GetCustomerManager();

            Refresh();
        }

        public void Refresh()
        {
            LoadEmployees();
        }

        private void LoadEmployees()
        {
            if (dataManager == null)
                return;

            employees.Clear();

            var rawEmployees = dataManager.GetEmployees();

            foreach (var rawEmployee in rawEmployees)
            {
                var employee = new Employee();
                employee.EmployeeId = rawEmployee.EmployeeID;
                employee.LastName = rawEmployee.LastName;
                employee.FirstName = rawEmployee.FirstName;
                employee.Title = rawEmployee.Title;
                employee.TitleOfCourtesy = rawEmployee.TitleOfCourtesy;
                employee.HireDate = rawEmployee.HireDate;
                employee.Notes = rawEmployee.Notes;

                employees.Add(employee);
            }

        }

    }
}
