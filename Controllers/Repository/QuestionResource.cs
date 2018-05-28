using System;
using TechAche.Models;

namespace TechAche.Controllers.Repository
{
    public class QuestionResource
    {
        public int Id { get; set; }
        public User User { get; set; }
        public string Title { get; set; }
        public string Details { get; set; } 
        public DateTime CreateDate { get; set; }
    }
}