using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Data.EFCore.Classes
{
    public class WorkplaceMember
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id   {get;set;}
        public bool Admin {get;set;}
        public virtual ApplicationUser User {get;set;}
        public virtual Workplace Workplace {get;set;}
        public virtual ICollection<BoardMember> Boards { get; set; }

    }
}