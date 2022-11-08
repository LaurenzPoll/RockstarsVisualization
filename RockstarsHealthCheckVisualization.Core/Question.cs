using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockstarsHealthCheckVisualization.Core
{
    internal class Question
    {
        private int questionId;
        private string question;
        private Enum.QuestionCategory category;
        private Enum.Sensitivity sensitivity;  // decides who can see the answers
        internal int nr;    // nrs can only be added after all questions are added to the questionnaire. Method for adding nrs is in class questionnaire
        // open question notes to add to questionnaire as whole?

        public Question(int questionId, string question, Enum.QuestionCategory category, Enum.Sensitivity sensitivity)
        {
            this.questionId = questionId;
            this.question = question;
            this.category = category;
            this.sensitivity = sensitivity;
        }







    }
}
