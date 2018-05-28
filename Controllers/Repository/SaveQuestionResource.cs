using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using TechAche.Models;

namespace TechAche.Controllers.Repository
{
    public class SaveQuestionResource
    {
        public int Id { get; set; }
        public User User { get; set; }
        [Required]
        [MinLength(20)]
        [MaxLength(150)]
        public string Title { get; set; }
        [Required]
        [MaxLength(2000)]
        public string Details { get; set; } 

        public ICollection<TextExtension> QuestionExtensions {get; set;}
        public ICollection<Answer> Answers {get; set;}
        
        public SaveQuestionResource()
        {
            this.Answers = new Collection<Answer>();
            this.QuestionExtensions = new Collection<TextExtension>();
            //this.User = context.Users.Where(u => u.Id == 1).FirstOrDefault();
        }
    }
}