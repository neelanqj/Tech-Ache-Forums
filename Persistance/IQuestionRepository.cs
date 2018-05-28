using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TechAche.Models;

namespace TechAche.Persistance
{
    public interface IQuestionRepository
    {
        Task<QueryResult<Question>> GetQuestions(QuestionQuery queryObj);
        Task<Question> GetQuestion(int id);
        void AddQuestion(Question question);
        void UpdateQuestion(Question question);
        void AddAnswer(int questionid, Answer answer);
        void AddAnswerReply(int questionid, int answerid, TextExtension reply);

        void RemoveQuestion(Question question);
    }
}