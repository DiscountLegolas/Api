using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Data.EFCore.Classes
{
    public class CardList
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id {get;set;}
        [Required]
        public string Title {get;set;}
        public int Index { get;set;}
        public virtual Board Board { get; set; }
        public virtual ICollection<Card> Cards {get;set;}
    }
}