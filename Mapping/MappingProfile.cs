using System;
using System.Linq;
using AutoMapper;
using TechAche.Controllers.Repository;
using TechAche.Controllers.Resources;
using TechAche.Models;

namespace TechAche.Mapping
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<Question, SaveQuestionResource>();

            CreateMap<SaveQuestionResource, Question>()
            .ForMember(q => q.QuestionExtensions, opt => opt.Ignore())
            .ForMember(q => q.Answers, opt => opt.Ignore())
            //.ForMember(sqr => sqr.QuestionExtensions, opt=> opt.Ignore())
            .AfterMap(
                (sqr, q) => {
                    var qes = sqr.QuestionExtensions.Where(n => n.Id == 0).ToArray();
                    var qa = sqr.Answers.Where(n => n.Id == 0).ToArray();
                    
                    // For extending questions
                    foreach(var newQe in qes){
                        q.QuestionExtensions.Add(new TextExtension { Details = newQe.Details, CreateDate =DateTime.Now });
                   
                        q.QuestionExtensions.Remove(newQe);
                        }

                    // For adding answers
                    foreach(var newQ in qa){
                        q.Answers.Add(new Answer { Details = newQ.Details, CreateDate =DateTime.Now });
                   
                        q.Answers.Remove(newQ);
                        }

                }
            );
            
            CreateMap<QuestionQueryResource,QuestionQuery>();
            CreateMap<Question, QuestionResource>();
            CreateMap(typeof(QueryResult<>),typeof(QueryResultResource<>));
        }
    }
}