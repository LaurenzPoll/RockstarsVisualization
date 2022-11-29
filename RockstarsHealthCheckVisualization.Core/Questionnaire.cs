using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockstarsHealthCheckVisualization.Core
{
    public class Questionnaire
    {
        private int questionnaireId; // key
        private string questionaireName;
        private List<Question> questions;
        


        internal Questionnaire(int questionnaireId, string questionaireName, List<Question> questions)  // object is only made when all questions are added
        {
            this.questionnaireId = questionnaireId;
            this.questionaireName = questionaireName;
            this.questions = new List<Question>();

            this.questions = AddNrs(questions);
        }


        // not in constructor, because questions lateron wont be hardcoded, but added one by one
        internal List<Question> AddNrs(List<Question> questionsTotal)
        {
            int nr = 1;
            foreach (Question question in questionsTotal)
            {
                question.nr = nr;
                nr++;
            }

            return questionsTotal;
        }

        
        

    }
}
