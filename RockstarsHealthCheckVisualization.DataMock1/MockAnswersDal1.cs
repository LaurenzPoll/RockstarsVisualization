using RockstarsHealthCheckVisualization.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockstarsHealthCheckVisualization.DataMock1
{
    public class MockAnswersDal1
    {
        public List<MockAnswerDto1> mockAnswers;
        public int nrOfFilledOutQuestionnaires;
        public int nrOfQuestionsInQuestionnaire;
        public int nrOfAnswers;
        public MockDataGenerator generator;

        public List<int> IDs;
        public List<int> FilledOutQuestionnaireIDs;
        public List<int> QuestionIDs;
        public List<string> Questions;
        public List<string> QuestionCategories;
        public List<int> UserIDs;
        public List<string> UserIDstrings;
        public List<string> UserNames;
        public List<int> AnswerRanges;
        public List<string?> AnswerComments;
        public List<DateTime> Dates;


        public MockAnswersDal1()
        {
            this.nrOfFilledOutQuestionnaires = 36;
            this.nrOfQuestionsInQuestionnaire = 12;
            this.nrOfAnswers = nrOfFilledOutQuestionnaires * nrOfQuestionsInQuestionnaire;

            generator = new MockDataGenerator();

            this.IDs = generator.GenerateIDs(nrOfAnswers);
            this.FilledOutQuestionnaireIDs = generator.GetRepeatedIdsLong(36, 12);
            this.QuestionIDs = generator.GetRepeatedIdsShort(12, 36);

            
        }

        /*public List<MockAnswerDto1> GenerateList()
        {
            for (int i = 0; i < nrOfFilledOutQuestionnaires; i++)
            {
                MockAnswerDto1 answer = new MockAnswerDto1();

            }
        }*/

        

        









    }
}
