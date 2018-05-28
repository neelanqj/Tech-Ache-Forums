using System; 
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks; 
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc; 
using TechAche.Controllers.Repository;
using TechAche.Controllers.Resources;
using TechAche.Models; 
using TechAche.Persistance;

namespace TechAche.Controllers
{
    [Route("/api/questions")]
    public class QuestionController : Controller
    {
        private readonly IQuestionRepository repository;
        private readonly IMapper mapper;
        private readonly IUnitOfWork unitOfWork;
        private readonly TechAcheDbContext context;

        public QuestionController(IMapper mapper, IQuestionRepository repository, TechAcheDbContext context, IUnitOfWork unitOfWork)
        {
            this.context = context;
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            this.repository = repository;
        }

        [HttpGet]
        public async Task<QueryResultResource<QuestionResource>> GetQuestions(QuestionQueryResource filterResource)
        {
            var filter = mapper.Map<QuestionQueryResource,QuestionQuery>(filterResource);
            var queryResult = await repository.GetQuestions(filter);
            return mapper.Map<QueryResult<Question>,QueryResultResource<QuestionResource>>(queryResult);
        }

        [HttpGet("{questionid}")]
        public async Task<IActionResult> GetQuestion(int questionid)
        {
            Question question = await repository.GetQuestion(questionid);
            return Ok(question);
        }

        [HttpPost("new")]
        [Authorize]
        public async Task<IActionResult> AddQuestion([FromBody]SaveQuestionResource questionResource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var question = mapper.Map<SaveQuestionResource, Question>(questionResource);
            question.CreateDate = DateTime.Now;
            question.User = context.Users.Where(u => u.Id == 1).FirstOrDefault();
            repository.AddQuestion(question);

            await unitOfWork.CompleteAsync();

            question = await repository.GetQuestion(question.Id);

            return Ok(question);
        }
        
        [HttpPut("{questionid}")]
        [Authorize]
        public async Task<IActionResult> UpdateQuestion(int questionid, [FromBody]SaveQuestionResource questionResource)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            //var question = repository.GetQuestion(questionid);
            //var addExtension = new TextExtension();
            var question = mapper.Map<SaveQuestionResource, Question>(questionResource);
            
            repository.UpdateQuestion(question);

            await unitOfWork.CompleteAsync();

            question = await repository.GetQuestion(question.Id);

            return Ok(question);
        }

        [HttpPost("{questionid}")]
        [Authorize]
        public async Task<IActionResult> AddAnswer(int questionid, [FromBody]Answer answer)
        {
            repository.AddAnswer(questionid, answer);
            await unitOfWork.CompleteAsync();
            return Ok(answer);
        }

        [HttpPost("{questionid}/{answerid}")]
        [Authorize]
        public async Task<IActionResult> AddReply(int questionid, int answerid, [FromBody]TextExtension reply)
        {
            repository.AddAnswerReply(questionid, answerid, reply);
            await unitOfWork.CompleteAsync();
            return Ok(reply);
        }
    }
}