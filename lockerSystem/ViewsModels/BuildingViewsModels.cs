using lockerSystem.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace lockerSystem.ViewsModels
{
    public class BuildingViewsModels
    {
        public int Id { get; set; }
        public Guid Guid { get; set; } = Guid.NewGuid();
        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        [DisplayName("اسم المبنى باللغة العربية")]
        public string NameAr { get; set; }
        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        [DisplayName("اسم المبنى باللغة الإنجليزية")]
        public string NameEn { get; set; }
        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        [DisplayName("رمز المبنى")]
        public string code { get; set; }
        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        [DisplayName("رقم المبنى")]
        public int no { get; set; }
        public ICollection<tblFloor> Floor { get; }
    }
}
