using lockerSystem.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace lockerSystem.ViewsModels
{
    public class BookingViewsModels
    {
        public int Id { get; set; }
        public Guid Guid { get; set; }
        public bool IsDeleted { get; set; }
        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        [DisplayName("التاريخ والوقت المحدد")]
        public DateTime bokingDateTime { get; set; }
        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        [DisplayName("الاسم")]
        public string fullName { get; set; }

        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        [DisplayName("الايميل")]
        public string email { get; set; }
        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        [DisplayName("رقم الجوال")]
        public int phone { get; set; }
        [DisplayName("حالة الطلب")]
        public tblBookingState BookingState { get; set; }
        public int BookingStateId { get; set; }
        [DisplayName("الخزانة")]
        public tblLocker Locker { get; set; }
        public int LockerId { get; set; }
        [DisplayName("الفصل الدراسي")]
        public tblSemster Semster { get; set; }
        public int SemsterId { get; set; }
        [DisplayName("سبب الرفض")]
        public string rejectionReason { get; set; }
        [DisplayName("اسم المبنى")]
        public string colegename { get; set; }
        public int  floornumer { get; set; }

        //public int BuildingId { get; set; }
        //public IEnumerable<tblBuilding> Buildings { get; set; }
        //public int FloorId { get; set; }
        //public IEnumerable<tblFloor> Floors { get; set; } = new List<tblFloor>();

    }
}
