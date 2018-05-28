using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace TechAche.Models
{
    public class User
    {
        [Column(Order = 1)]
        public int Id { get; set; }

        [Column(Order = 2)]
        public string Auth0Id {get; set;}
        [Column(Order = 3)]
        public string IntegrationId {get; set;}
        [Column(Order = 4)]
        public string FirstName { get; set; }
        [Column(Order = 5)]
        public string LastName { get; set; }
        [Column(Order = 6)]
        public DateTime BirthDate { get; set; }
        [Column(Order = 7)]
        public string Gender { get; set; }

        [Column(Order = 8)]
        public string Email {get;set;}

        [Column(Order = 9)]
        public Boolean Enabled {get; set; }
        [Column(Order = 10)]
        public DateTime CreateDate { get; set; }
        [Column(Order = 11)]
        public DateTime LastPostDate { get; set; }
    }
}