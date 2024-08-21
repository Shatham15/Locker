using lockerSystem.Models;
using lockerSystem.ViewModels;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace lockerSystem.ViewModels
{
    public class PermissionViewsModels
    {
        //public int? Id { get; set; }

        [DisplayName("الاسم")]
        public string fullName { get; set; }

        public Guid? Guid { get; set; }
        public bool? IsDeleted { get; set; }
        [DisplayName("اسم المستخدم")]
        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        public string usrName { get; set; }
        [DisplayName("نوع الصلاحية")]
        [Required(ErrorMessage = "هذا الحقل مطلوب")]

        public int roleId { get; set; }
        [DisplayName("نوع الصلاحية")]

        public string roleName { get; set; }



    }
}
