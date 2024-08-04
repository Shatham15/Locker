using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace lockerSystem.ViewModels
{
    public class UserViweModele
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        [DisplayName("الاسم")]
        public string fullName { get; set; }
        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        [DisplayName("البريد الالكتروني")]
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
