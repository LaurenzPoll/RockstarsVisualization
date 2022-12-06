using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockstarsHealthCheckVisualization.Core
{
    internal class Question
    {
        private int questionID;
        private Enum.QuestionCategory category;
        private string question;
        internal Enum.QuestionType type;    // nrs can only be added after all questions are added to the questionnaire. Method for adding nrs is in class questionnaire
        // private Enum.Sensitivity sensitivity;
        // open question?

        public Question(int questionId, string question, Enum.QuestionCategory category, Enum.QuestionType type)
        {
            this.questionID = questionId;
            this.question = question;
            this.category = category;
            this.type = type;
        }







    }
}
