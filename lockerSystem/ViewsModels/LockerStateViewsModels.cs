using lockerSystem.Models;

namespace lockerSystem.ViewsModels
{
    public class LockerStateViewsModels
    {
        public int Id { get; set; }
        public Guid Guid { get; set; } = Guid.NewGuid();
        public bool IsDeleted { get; set; }
        public string stateAr { get; set; }
        public string stateEn { get; set; }
        public ICollection<tblLocker> Lockers { get; set; }
    }
}
