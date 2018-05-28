using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using TechAche.Persistance;

namespace TechAche.Models
{
    public class Question
    {
        public int Id { get; set; }
        public User User { get; set; }
        public string Title { get; set; }
        public string Details { get; set; } 
        public ICollection<TextExtension> QuestionExtensions { get; set; }
        public ICollection<Photo> Photos { get; set; }        
        public ICollection<Answer> Answers { get; set; }
        public DateTime CreateDate { get; set; }
        public Boolean Editable { get; set; }
        public Boolean Disabled {get;set;}
        public Boolean Closed { get; set; }
        public int Views {get;set;}
        public int Upvotes { get; set; }
        public int Downvotes { get; set; }

        public Question()
        {
            this.Answers = new Collection<Answer>();
            this.Photos = new Collection<Photo>();
            this.QuestionExtensions = new Collection<TextExtension>();
            //this.User = context.Users.Where(u => u.Id == 1).FirstOrDefault();
        }
    }
}