using lockerSystem.Models;

namespace lockerSystem.ViewsModels
{
    public class FloorViewsModels
    {
        public int Id { get; set; }
        public Guid Guid { get; set; } = Guid.NewGuid();
        public bool IsDeleted { get; set; }
        public int no { get; set; }
        public tblBuilding Building { get; set; }
        public int BuildingId { get; set; }
        public ICollection<tblLocker> Lockers { get; }
    }
}
