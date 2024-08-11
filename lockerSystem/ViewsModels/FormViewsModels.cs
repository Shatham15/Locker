using lockerSystem.Models;

namespace lockerSystem.ViewsModels
{
    public class FormViewsModels
    {
        public int BuildingId { get; set; }
        public IEnumerable<tblBuilding> Buildings { get; set; }
        public int FloorId { get; set; }
        public IEnumerable<tblFloor> Floors { get; set; } = new List<tblFloor>();


    }
}
