using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockstarsHealthCheckVisualization.Core.GarbageBin
{
    internal class Logger
    {
        internal DataCollection dataCollection;
        /* interesting to obtain:
        internal DateTime lastTimeFilledOut;
        internal int numberTimesFilledOut;
        internal int averageDaysBetweenFillingOut;*/

        internal Logger(DataCollection dataCollection)
        {
            this.dataCollection = dataCollection;
        }

        // alternative to this method is updating lastTimeFilled out field somewhere every time a questionnaire is filled out
        // the downside of that approach is that it is double bookkeeping and easily forgotten to update somewhere along the way, causing chaos


        internal List<DateTime> GetMomentsFilledOut(int projectId, string employeeEmail)
        {
            List<DateTime> momentsFilledOut = new List<DateTime>();
            foreach (var filledOutQuestionnaire in dataCollection.filledOutQuestionnaires)
            {
                if (filledOutQuestionnaire.projectId == projectId && filledOutQuestionnaire.employeeEmail == employeeEmail)
                {
                    momentsFilledOut.Add(filledOutQuestionnaire.dateTime);
                }
            }
            return momentsFilledOut;
        }

        internal int numberTimesFilledOut(int projectId, string employeeEmail)
        {
            int numberTimesFilledOut = GetMomentsFilledOut(projectId, employeeEmail).Count();
            return numberTimesFilledOut;
        }

        internal DateTime GetLastTimeFilledOut(int projectId, string employeeEmail)
        {
            List<DateTime> momentsFilledOut = GetMomentsFilledOut(projectId, employeeEmail);
            DateTime lastTimeFilledOut = momentsFilledOut.Max();
            return lastTimeFilledOut;
        }
    }
}
