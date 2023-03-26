using IdentityServer4.Models;
using System.ComponentModel.DataAnnotations;

namespace Application.Model.WorkplaceController
{
    public class WorkplaceCreateModel
    {
        [Required(ErrorMessage = "Name zorunludur.")]
        public string Name { get; set; }
        public string? Description { get; set; }
    }
}
