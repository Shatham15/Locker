using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace lockerSystem.ViewsModels
{
    public class ManagementViewsModels
    {
        //public int Id { get; set; }
        public Guid Guid { get; set; } = Guid.NewGuid();
        public bool IsDeleted { get; set; }
        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        [DisplayName("الاسم")]
        public string name { get; set; }
        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        [DisplayName("القيمة")]
        [Range(1, 999999999999999999, ErrorMessage ="القيمة المدخلة غير صحيحة!")]
        public int value { get; set; }
    }
}
