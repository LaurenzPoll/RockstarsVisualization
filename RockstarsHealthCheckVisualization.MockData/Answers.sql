CREATE TABLE [dbo].[Answers]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [FilledOutQuestionnaireId] INT NOT NULL, 
    [QuestionId] INT NOT NULL, 
    [UserId] INT NOT NULL, 
    [AnswerRange] TINYINT NOT NULL, 
    [AnswerComment] NVARCHAR(MAX) NULL, 
    [Date] DATETIME NOT NULL
)
