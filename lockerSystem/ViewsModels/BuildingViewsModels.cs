using lockerSystem.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Data;

namespace lockerSystem.ViewsModels
{
    public class BuildingViewsModels
    {
        public int BuildingId { get; set; }
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
        
        [Required(ErrorMessage = "هذا الحقل مطلوب" )]
        [DisplayName("رقم المبنى")]
        [Range(1,999999999999999999)]

        public int no { get; set; }
        public ICollection<tblFloor>  Floor { get; }
    }
}
