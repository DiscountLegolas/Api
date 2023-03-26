using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Data.EFCore.Classes
{
    public class Comment
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id {get;set;}
        public string Text {get;set;}
        public virtual Card Card { get; set; }
        public virtual ApplicationUser User {get;set;}
    }
}