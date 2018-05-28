using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace TechAche.Models
{
    [Table("TextExtensions")]
    public class TextExtension
    {
        public int Id { get; set; }
        public string Details { get; set; }

        public User User { get; set; }
        public DateTime CreateDate { get; set; }
    }
}