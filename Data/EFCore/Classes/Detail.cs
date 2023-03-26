using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Data.EFCore.Classes
{
    public class Detail
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id {get;set;}
        public string Action {get;set;}
        public virtual Card Card { get; set; }
        public virtual ApplicationUser User{get;set;}

    }
}