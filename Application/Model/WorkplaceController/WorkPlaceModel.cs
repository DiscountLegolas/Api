using Application.Model.AccountController;
using Application.Model.BoardController;
using Application.Model.WorkplaceMemberController;
using Data.EFCore.Classes;

namespace Application.Model.WorkplaceController
{
    public class WorkPlaceModel
    {
        public int WorkplaceId { get; set; }
        public string WorkplaceName { get; set; }
        public string? Description { get; set; }
        public List<BoardSimpleModel> Boards { get; set; }
        public List<WorkplaceMemberModel> Members { get; set; }
    }
    public class WorkPlaceSimpleModel
    {
        public int WorkplaceId { get; set; }
        public string WorkplaceName { get; set; }
        public string? Description { get; set; }
        public List<BoardSimpleModel> Boards { get; set; }
        public List<WorkplaceMemberModel> Members { get; set; }
    }
    public class WorkPlacesModel
    {
        public List<WorkPlaceSimpleModel> WorkPlaces { get; set; }
    }
}
