using lockerSystem.Models;

namespace lockerSystem.ViewsModels
{
    public class BuildingViewsModels
    {
        public int Id { get; set; }
        public Guid Guid { get; set; } = Guid.NewGuid();
        public bool IsDeleted { get; set; }
        public string NameAr { get; set; }
        public string NameEn { get; set; }
        public string code { get; set; }
        public int no { get; set; }
        public ICollection<tblFloor> Floor { get; }
    }
}
