using System.ComponentModel;

namespace lockerSystem.Models
{
    public class tblFloor
    {
        public int Id { get; set; }
        public Guid Guid { get; set; } = Guid.NewGuid();
        public bool IsDeleted { get; set; }
        [DisplayName("رقم الطابق")]
        public int no { get; set; }
        public tblBuilding Building { get; set; }
        public int BuildingId { get; set; }
        public ICollection<tblLocker> Lockers { get; }

    }
}
