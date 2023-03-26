using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Data.EFCore.Classes
{
    public class Workplace
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int WorkplaceId   {get;set;}
        [Required]
        public string WorkplaceName {get;set;}
        public string? Description { get; set; }
        public virtual ICollection<WorkplaceMember> Members {get;set;}
        public virtual ICollection<Board> Boards { get; set; }

    }
}