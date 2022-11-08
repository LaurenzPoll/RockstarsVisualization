using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockstarsHealthCheckVisualization.Core
{
    internal class QuestionnaireTemplates
    {
        private Questionnaire standardQuestionnaire;
        private List<Questionnaire> customQuestionnaires;  
        private List<Question> questionsStandard;   // for suggestting standard questions when new questionnaire is made
        private List<Question> questionsCustom; // for the suggestion of previously added custom questions when questionnaire is made
        

        public QuestionnaireTemplates()
        {
            this.customQuestionnaires = new List<Questionnaire>();
            this.questionsStandard = new List<Question>();
            this.questionsCustom = new List<Question>();
        }

    }
}
