using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockstarsHealthCheckVisualization.Core
{
    internal class DataCollection   // collection and way of working with all data that is relevant for visualisation
    {
        private List<Manager> managers;

        // Can get all these from manager, but having them as fields works better for methods. See method AddManager and UpdateManager for how these fields are defined
        internal List<Project> projects { get; }
        internal List<Employee> employees { get; }
        internal List<FilledOutQuestionnaire> filledOutQuestionnaires { get; }


        internal DataCollection(List<Manager> managers)
        {
            foreach (Manager manager in managers)
            {
                AddAndUpdateFromManager(manager);
            }
        }


        internal void AddAndUpdateFromManager(Manager magager)
        {
            managers.Add(magager);
            UpdateFieldsBasedOnManager(magager);
        }
        
        internal void UpdateManager(Manager manager)
        {
            for (int i = 0; i == managers.Count();  i++)
            {
                if (managers[i].managerEmail == manager.managerEmail)
                {
                    managers[i] = manager;
                }
            }
            UpdateFieldsBasedOnManager(manager);
        }

        internal void UpdateFieldsBasedOnManager(Manager manager)   // also happens inside methods AddManager and UpdateManager
        {
            foreach (var project in manager.projects)
            {
                this.projects.Add(project);
                foreach (var employee in project.employees)
                {
                    this.employees.Add(employee);
                }
                foreach (var filledOutQuestionnaire in project.filledOutQuestionnaires)
                {
                    this.filledOutQuestionnaires.Add(filledOutQuestionnaire);
                }
            }
        }

        




        // never used but see if comes in handy
        // getting stuff based on ids
        // putting these methods here in this case makes more sense than forcing single responsibility upon them

        /*
        public List<FilledOutQuestionnaire> GetFilledOutQuestionnaires(int projectId)
        {
            List<FilledOutQuestionnaire> filledOutQuestionnaires = new List<FilledOutQuestionnaire>();

            foreach (var filledOutQuestionnaire in this.filledOutQuestionnaires)
            {
                if (filledOutQuestionnaire.projectId == projectId)
                {
                    filledOutQuestionnaires.Add(filledOutQuestionnaire);
                }

            }
            return filledOutQuestionnaires;
        }

        internal Project? GetProject(int projectId)
        {
            foreach (var p in this.projects)
            {
                if (p.projectId == projectId)
                {
                    return p;
                }
            }
            return null;    // in case no project with that id found
        }

        internal List<Employee> GetEmployees(int projectId)
        {
            List<Employee> employees = new List<Employee>();
            foreach (var employee in this.employees)
            {
                employees.Add(employee);
            }
            return employees;
        }

        internal Employee? GetEmployee(string employeeEmail)
        {
            foreach (var e in this.employees)
            {
                if (e.employeeEmail == employeeEmail)
                {
                    return e;
                }
            }
            return null;
        }
        */
    }
}
