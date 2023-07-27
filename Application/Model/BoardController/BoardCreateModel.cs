using IdentityServer4.Models;
using System.ComponentModel.DataAnnotations;

namespace Application.Model.BoardController
{
    public class BoardCreateModel
    {
        [Required(ErrorMessage = "Title zorunludur.")]
        public string Title { get; set; }
        [Required(ErrorMessage = "PicUrl zorunludur.")]
        public string PicUrl { get; set; }

        [Required(ErrorMessage = "Workplace Id zorunludur.")]
        public int WorkPlaceId { get; set; }
    }
}
