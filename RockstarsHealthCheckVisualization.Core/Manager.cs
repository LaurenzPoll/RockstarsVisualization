using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockstarsHealthCheckVisualization.Core
{
    internal class Manager
    {
        internal string managerEmail { get; }   // key
        private string name;
        private string company; // Rockstars or other
        internal List<Project> projects { get; }

        public Manager(string managerEmail)
        {
            this.managerEmail = managerEmail;
        }

        public Manager(string name, string company, List<Project> projects)
        {
            this.name = name;
            this.company = company;
            this.projects = projects;
        }

        


    }
}
