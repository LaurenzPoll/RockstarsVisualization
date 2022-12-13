namespace RockstarsHealthCheckVisualization.Core
{
    public class Answer
    {
        public int answerID { get; private set; }   // key
        public int questionID { get; private set; }
        public string question { get; private set; }
        public int filledOutQuestionnaireID { get; private set; }
        public int answerRange { get; private set; } // 1-5 for stars and maybe in future 0 for 'non applicable' (for the case of team work question when no team there)
        public string? answerComment { get; private set; }    // nullable for if answerRating 2 - 4, in which case no answerComment should be added
        public DateTime answerDate { get; private set; }
        public int userID { get; private set; }
        public int questionnaireID { get; private set; }

        public Answer(int answerId, int questionId, string question, int filledOutQuestionnaireId, int answerRange, string? comment)
        {
            this.answerID = answerId;
            this.filledOutQuestionnaireID = filledOutQuestionnaireId;
            this.questionID = questionId;
            this.question = question;
            this.answerRange = answerRange;
            this.answerComment = comment;
        }

        public Answer(int answerId, int questionId, string question, int filledOutQuestionnaireId, int answerRange, string? comment, DateTime date, int userId, int questionnaireID)
        {
            this.answerID = answerId;
            this.filledOutQuestionnaireID = filledOutQuestionnaireId;
            this.questionID = questionId;
            this.question = question;
            this.answerRange = answerRange;
            this.answerComment = comment;
            this.answerDate = date;
            this.userID = userId;
            this.questionnaireID = questionnaireID;
        }
    }

}