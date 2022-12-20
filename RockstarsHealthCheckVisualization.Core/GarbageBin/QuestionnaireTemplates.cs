using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockstarsHealthCheckVisualization.Core.GarbageBin
{
    internal class QuestionnaireTemplates
    {
        private Questionnaire standardQuestionnaire;
        private List<Questionnaire> customQuestionnaires;
        private List<Question> questionsStandard;   // for suggestting standard questions when new questionnaire is made
        private List<Question> questionsCustom; // for the suggestion of previously added custom questions when questionnaire is made


        public QuestionnaireTemplates()
        {
            customQuestionnaires = new List<Questionnaire>();
            questionsStandard = new List<Question>();
            questionsCustom = new List<Question>();
        }

    }
}
