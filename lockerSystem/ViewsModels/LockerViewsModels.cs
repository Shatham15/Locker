using lockerSystem.Models;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace lockerSystem.ViewsModels
{
    public class LockerViewsModels
    {
        public int Id { get; set; }
        public Guid Guid { get; set; } = Guid.NewGuid();
        public bool IsDeleted { get; set; }
        [DisplayName("رقم الخزنة")]
        public int no { get; set; }
        public tblFloor Floor { get; set; }
        [DisplayName("رقم الطابق")]
        public int FloorId { get; set; }
        public tblLockerState LockerState { get; set; }
        public int LockerStateId { get; set; }
    }
}
