using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.EFCore.Classes
{
    public class CardAssingment
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public bool Admin { get; set; }
        public virtual BoardMember Member { get; set; }
        public virtual Card Card { get; set; }
    }
}
