using lockerSystem.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace lockerSystem.ViewsModels
{
    public class LockerStateViewsModels
    {
        public int LockerStateId { get; set; }
        public Guid Guid { get; set; } = Guid.NewGuid();
        public bool IsDeleted { get; set; }

        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        [DisplayName("اسم الحاله باللغه العربيه ")]
        public string stateAr { get; set; }


        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        [DisplayName("اسم الحاله باللغه الانجليزيه ")]
        public string stateEn { get; set; }

        public ICollection<tblLocker> Lockers { get; set; }
    }
}
