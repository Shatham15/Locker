using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace lockerSystem.ViewsModels
{
    public class UserViewsModels
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="هذا الحقل مطلوب")]
        [DisplayName("اسم المستخدم")]
        public string fullName { get; set; }
        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        [DisplayName("البريد الإلكتروني")]
        public string email { get; set; }
        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        [DisplayName("كلمة المرور")]
        public string password { get; set; }
        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        [DisplayName("رقم الجوال")]
        public int phone { get; set; }
        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        [DisplayName("نوع المستخدم")]
        public string userType { get; set; }
    }
}
