namespace RockstarsHealthCheckVisualization.Core
{
    internal class Answer
    {
        private int answerId;   // key
        private int questionaireId;
        private Enum.AnswerType answerType;  
        private Enum.QuestionCategory category;
        private Enum.Sensitivity sensitivity;
        private int nr;
        private int rating; // 1-5 for stars and 0 for 'non applicable' (for the case of team work question when no team there)
        private string why;
        private Enum.Trend trend;

        public Answer(int answerId, int questionnaireId, Enum.QuestionCategory category, Enum.Sensitivity sensitivity, int nr, int rating)
        {
            this.answerType = Enum.AnswerType.WithoutComment;
            this.answerId = answerId;
            this.questionaireId = questionnaireId;
            this.category = category;
            this.sensitivity = sensitivity;
            this.nr = nr;
            this.rating = rating;
        }

        // overloaded answer for if answerRating <= 2 or answerRating = 5, in which case a comment with reason should be added
        public Answer(int answerId, int questionnaireId, Enum.QuestionCategory category, Enum.Sensitivity sensitivity, int nr, int rating, string why)
        {
            this.answerType = Enum.AnswerType.WithComment;
            this.answerId = answerId;
            this.questionaireId = questionnaireId;
            this.category = category;
            this.sensitivity = sensitivity;
            this.nr = nr;
            this.rating = rating;
            this.why = why;
        }

        // overloaded answer for self assessed trends per category
        public Answer(Enum.QuestionCategory category, Enum.Trend trend)
        {
            this.answerType = Enum.AnswerType.Trend;
            this.category = category;
            this.trend = trend;
        }
    }

}