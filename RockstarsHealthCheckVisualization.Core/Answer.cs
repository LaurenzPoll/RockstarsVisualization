namespace RockstarsHealthCheckVisualization.Core
{
    internal class Answer
    {
        private int answerID;   // key
        private int questionID;
        private int filledOutQuestionnaireID;
        private int answerRange; // 1-5 for stars and maybe in future 0 for 'non applicable' (for the case of team work question when no team there)
        private string? answerComment;    // nullable for if answerRating 2 - 4, in which case no answerComment should be added


        public Answer(int answerId, int questionId, int filledOutQuestionnaireId, int answerRange, int rating, string? comment)
        {
            this.answerID = answerId;
            this.questionID = questionId;
            this.filledOutQuestionnaireID = filledOutQuestionnaireId;
            this.answerRange = answerRange;
            this.answerComment = comment;
        }

        
    }

}