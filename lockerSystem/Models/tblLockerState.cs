using System.ComponentModel;

namespace lockerSystem.Models
{
    public class tblLockerState
    {
        public int Id { get; set; }
        public Guid Guid { get; set; } = Guid.NewGuid();
        public bool IsDeleted { get; set; }
        [DisplayName("حالة الخزانة")]
        public string stateAr { get; set; }
        public string stateEn { get; set; }
        public ICollection<tblLocker> Lockers{ get; set; }
    }
}
