using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;

namespace TechAche.Models
{
    [Table("Answers")]
    public class Answer
    {
        public int Id { get; set; }
        public User User { get; set; }
        public string Details { get; set; } 
        public ICollection<TextExtension> AnswerExtensions { get; set; }
        public ICollection<Photo> Photos { get; set; }
        public DateTime CreateDate { get; set; }
        public ICollection<TextExtension> Replies { get; set; }
        public Boolean Editable { get; set; }
        public Boolean Active { get; set; }
        public int Views { get;set; }
        public int Upvotes { get; set; }
        public int Downvotes { get; set; }

        public Answer()
        {
            this.Replies = new Collection<TextExtension>();
            this.Photos = new Collection<Photo>();
            this.AnswerExtensions = new Collection<TextExtension>();
        }
    }
}