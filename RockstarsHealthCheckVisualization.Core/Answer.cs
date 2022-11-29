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
        private string? why;    // nullable for if answerRating 3 or 4, in which case no comment with reason (why) should be added
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

        // overloaded answer for self assessed trends per category
        public Answer(Enum.QuestionCategory category, Enum.Trend trend)
        {
            this.answerType = Enum.AnswerType.Trend;
            this.category = category;
            this.trend = trend;
        }
    }

}