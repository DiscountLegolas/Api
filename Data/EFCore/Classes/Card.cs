using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Data.EFCore.Classes
{
    public class Card
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id{get;set;}
        [Required]
        public string Title { get;set;}
        public string? Desc{get;set;}
        public int Index { get; set; }
        public virtual CardList CardList { get; set; }
        public virtual ICollection<CardAssingment> Assingments { get; set; }
        public virtual ICollection<Detail> Details {get;set;}
        public virtual ICollection<Comment> Comments {get;set;}
    }
}