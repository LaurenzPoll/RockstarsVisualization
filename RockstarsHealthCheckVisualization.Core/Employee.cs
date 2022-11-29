using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockstarsHealthCheckVisualization.Core
{
    internal class Employee
    {
        internal string employeeEmail { get; } // key
        private string employeeName;
        private string employeeCompany; // Rockstars or other company employee is on payroll of, not company they are dispatched to!

        public Employee(string employeeEmail, string employeeName, string employeeCompany)
        {
            this.employeeEmail = employeeEmail;
            this.employeeName = employeeName;
            this.employeeCompany = employeeCompany;
            List<Project> projects = new List<Project>();
        }


    }
}
