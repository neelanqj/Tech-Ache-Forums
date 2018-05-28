using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace TechAche.Models
{
    [Table("Tags")]
    public class Tag
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Question> Questions {get; set;}
    }
}