using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockstarsHealthCheckVisualization.Core.GarbageBin
{
    internal class Question
    {
        private int questionID;
        private Enum.QuestionCategory category;
        private string question;
        internal Enum.QuestionType type;

        public Question(int questionId, string question, Enum.QuestionCategory category, Enum.QuestionType type)
        {
            questionID = questionId;
            this.question = question;
            this.category = category;
            this.type = type;
        }
    }
}
