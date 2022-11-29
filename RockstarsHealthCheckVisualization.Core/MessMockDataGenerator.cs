/*

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockstarsHealthCheckVisualization.Core
{
    internal class MessMockDataGenerator
    {
        internal DataCollection dataCollection { get; }
        internal QuestionnaireTemplates questionnaireTemplates { get; }

        // only for one kind of questionnaire (the standard one with 12 questions in 4 categories)
        internal int nrOfManagers;
        internal int nrOfProjects;
        internal int[] nrOfEmployeesPerProject;
        internal int[] nrOfFilledOutQuestionnairesPerProject;
        internal int[][] averageOutcomesQuestionsPerProject;
        

        internal MessMockDataGenerator(int nrOfManagers, int nrOfProjects, int[] nrOfEmployeesPerProject, int[] nrOfFilledOutQuestionnairesPerProject, int[][] averageOutcomesQuestionsPerProject) 
        {
            this.nrOfManagers = nrOfManagers;
            this.nrOfProjects = nrOfProjects;
            
            this.nrOfEmployeesPerProject = new int[nrOfProjects];   // how to put on one line?
            this.nrOfEmployeesPerProject = nrOfEmployeesPerProject;
            
            this.nrOfFilledOutQuestionnairesPerProject = new int[nrOfProjects];
            this.nrOfFilledOutQuestionnairesPerProject = nrOfFilledOutQuestionnairesPerProject;

            this.averageOutcomesQuestionsPerProject = new int[nrOfProjects][];
            for(int i = 0; i < nrOfProjects; i++)
            {
                this.averageOutcomesQuestionsPerProject[i] = new int[12];
            }
            this.averageOutcomesQuestionsPerProject = averageOutcomesQuestionsPerProject;
        }


        private List<Question> GetQuestions()
        {
            // Quality
            Question q1 = new Question(000000, "How do you value your delivered work?", Enum.QuestionCategory.Quality, Enum.Sensitivity.Open);
            Question q2 = new Question(000001, "How easy is it to realease?", Enum.QuestionCategory.Quality, Enum.Sensitivity.Open);
            Question q3 = new Question(000002, "How healthy is the code base?", Enum.QuestionCategory.Quality, Enum.Sensitivity.Open);

            // Progress
            Question q4 = new Question(000003, "Is the current working process suitable?", Enum.QuestionCategory.Progress, Enum.Sensitivity.Open);
            Question q5 = new Question(000004, "Is the speed sufficient?", Enum.QuestionCategory.Progress, Enum.Sensitivity.Open);
            Question q6 = new Question(000005, "Is the mission of the project clear?", Enum.QuestionCategory.Progress, Enum.Sensitivity.Open);

            // Team
            Question q7 = new Question(000006, "Is the teamwork going well?", Enum.QuestionCategory.Team, Enum.Sensitivity.Open);
            Question q8 = new Question(000007, "How is the quality of support?", Enum.QuestionCategory.Team, Enum.Sensitivity.Open);
            Question q9 = new Question(000008, "How good is the working atmosphere?", Enum.QuestionCategory.Team, Enum.Sensitivity.Open);

            // Individual
            Question q10 = new Question(000009, "Are you having fun?", Enum.QuestionCategory.Individual, Enum.Sensitivity.Open);
            Question q11 = new Question(000010, "Do you experience autonomy in your work?", Enum.QuestionCategory.Individual, Enum.Sensitivity.Open);
            Question q12 = new Question(000011, "Are you learning enough along the way?", Enum.QuestionCategory.Individual, Enum.Sensitivity.Open);

            List<Question> questionsStandard = new List<Question>()
            {
                q1, q2, q3, q4, q5, q6, q7, q8, q9, q10, q11, q12
            };

            return questionsStandard;
        }

        private Questionnaire GetQuestionnaire()
        {
            Questionnaire questionnaire = new Questionnaire(000000, "Health Check Standard", GetQuestions());
            return questionnaire;
        }




        private FilledOutQuestionnaire GetFilledOutQuestionnaire(int filledOutQuestionnaireId, int questionnaireId, int projectId, string employeeEmail, DateTime dateTime)
        {
            FilledOutQuestionnaire filledOutQuestionnaire = new FilledOutQuestionnaire(filledOutQuestionnaireId, questionnaireId, projectId, employeeEmail, dateTime);
            return filledOutQuestionnaire;
        }

        private List<FilledOutQuestionnaire> GetFilledOutQuestionnaires()







        internal List<string> GetNames()



        private int nrOfManagers;
        private int nrOfProjects;
        private int[] nrOfEmployeesPerProject;
        private int[] nrOfFilledOutQuestionnairesPerProject;
        private int[][] managersWhichProjects;    // index of array equals index of manager in list managers, content array represents indices of projects in list projects


        internal DataCollection CreateMockDataCollection()
        {
            int nrOfManagers = 3;
            int nrOfProjects = 5;
            int[] nrOfEmployeesPerProject = { 3, 1, 6, 2, 1 };
            int[] nrOfFilledOutQuestionnairesPerProject = { 8, 5, 12, 18, 4 };

            float[] averages1 = { 4.3f, 2.7f, 3.9f, 4.6f, 3.7f };
            float[] averages2 = { 4.0f, 3.7f, 0f, 2.5f, 3.3f };
            float[] averages3 = { 3.8f, 3.2f, 4.4f, 4.2f, 3.5f };
            float[] averages4 = { 4.8f, 3.5f, 2.3f, 2.8f, 4.1f };
            float[] averages5 = { 2.6f, 2.4f, 0f, 1.5f, 2.1f };
            float[][] averageOutcomesQuestionsPerProject = new float[][] { averages1, averages2, averages3, averages4, averages5 };

            MessMockDataGenerator mockDataGenerator = new MockDataGenerator(nrOfProjects, nrOfEmployeesPerProject, nrOfFilledOutQuestionnairesPerProject, averageOutcomesQuestionsPerProject);
        }

        internal void SetParameters(
            int nrOfManagers,
            int nrOfProjects,
            int[] managersWhichProjects,
            int[] nrOfEmployeesPerProject,
            int[] nrOfFilledOutQuestionnairesPerProject)
        {
            this.nrOfManagers = nrOfManagers;
            this.nrOfProjects = nrOfProjects;
            this.managersWhichProjects =
            this.nrOfEmployeesPerProject = nrOfEmployeesPerProject;
            this.nrOfFilledOutQuestionnairesPerProject = nrOfFilledOutQuestionnairesPerProject;
        }

    }
}

*/
