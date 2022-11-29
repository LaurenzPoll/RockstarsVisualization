namespace RockstarsHealthCheckVisualization.Core
{
    internal class Answer
    {
        public int answerID { get; private set; }   // key
        public int questionID { get; private set; }
        public int filledOutQuestionnaireID { get; private set; }
        public int answerRange { get; private set; } // 1-5 for stars and maybe in future 0 for 'non applicable' (for the case of team work question when no team there)
        public string? answerComment { get; private set; }    // nullable for if answerRating 2 - 4, in which case no answerComment should be added


        public Answer(int answerId, int questionId, int filledOutQuestionnaireId, int answerRange, int rating, string? comment)
        {
            this.answerID = answerId;
            this.filledOutQuestionnaireID = filledOutQuestionnaireId;
            this.questionID = questionId;
            this.answerRange = answerRange;
            this.answerComment = comment;
        }

        
    }

}