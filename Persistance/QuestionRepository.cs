using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TechAche.Extensions;
using TechAche.Models;

namespace TechAche.Persistance
{
    public class QuestionRepository: IQuestionRepository
    {
        private readonly TechAcheDbContext context;
        public QuestionRepository(TechAcheDbContext context)
        {
            this.context = context;
        }
        public async Task<QueryResult<Question>> GetQuestions(QuestionQuery queryObj){
            var result = new QueryResult<Question>();
            var query = context.Questions
                                .Include(u => u.User)
                            .AsQueryable();
            var columnsMap = new Dictionary<string, Expression<Func<Question,object>>>()
            {
                ["title"] = x=>x.Title,
                ["details"] = x=>x.Details,
                ["firstname"] = x=>x.User.FirstName,
                ["lastname"] = x=>x.User.LastName
            };
            
            query = query.ApplyOrdering(queryObj, columnsMap);
            result.TotalItems = await query.CountAsync();
            query = query.ApplyPaging(queryObj);

            result.Items = await query.ToListAsync();
            return result;
        }
        public async Task<Question> GetQuestion(int questionId)
        {
            return await context.Questions
                                .Include(qe => qe.QuestionExtensions)
                                .Include(u => u.User)
                                .Include(a => a.Answers)
                                    .ThenInclude(r => r.Replies)
                                    .ThenInclude(u => u.User)
                            .SingleOrDefaultAsync(q => q.Id == questionId);
        }

        public void AddQuestion(Question question){
            context.Questions.Add(question);
        }

        public void UpdateQuestion(Question question){
            context.Questions.Update(question);
        }

        public void RemoveQuestion(Question question){
            context.Remove(question);
        }

        public void AddAnswerReply(int questionid, int answerid, TextExtension reply){
            Question question = context.Questions           
                                .Include(a => a.Answers)
                                .FirstOrDefault(q=> q.Id==questionid) ;
            Answer answer = question.Answers.FirstOrDefault(a => a.Id == answerid);

            answer.Replies.Add(reply);
        }

        public void AddAnswer(int questionid, Answer answer)
        {
            Question question = context.Questions.FirstOrDefault(q=> q.Id==questionid);
            answer.User = context.Users.Where(u => u.Id == 1).FirstOrDefault();
            question.Answers.Add(answer); 
        }
    }
}