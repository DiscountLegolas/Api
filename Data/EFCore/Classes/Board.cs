using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Data.EFCore.Classes
{
    public class Board
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id {get;set;}
        [Required]
        public string Title {get;set;}
        public virtual Workplace Workplace { get;set;}
        public virtual ICollection<CardList> Lists {get;set;}
        public virtual ICollection<BoardMember> BoardMembers { get; set; }


    }
}