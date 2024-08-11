using lockerSystem.Models;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace lockerSystem.ViewsModels
{
    public class SemsterViewsModels
    {
        //public int Id { get; set; }
        public Guid Guid { get; set; } = Guid.NewGuid();
        public bool IsDeleted { get; set; }
        public bool IsActive { get; set; }
        // year
        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        [DisplayName("تاريخ بداية الفصل الدراسي")]
        public DateTime startSemster { get; set; }

        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        [DisplayName("تاريخ نهاية الفصل الدراسي")]
        public DateTime endSemster { get; set; }

        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        [DisplayName("اسم الفصل الدراسي باللغة العربية")]
        public string semsterNameAr { get; set; }

        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        [DisplayName("اسم الفصل الدراسي باللغة الإنجليزية")]
        public string semsterNameEn { get; set; }

        public ICollection<tblBooking>? Booking { get; set; }
    }
}
