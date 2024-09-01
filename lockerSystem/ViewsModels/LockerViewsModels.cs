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
        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        [DisplayName("رقم الخزنة")]
        public int no { get; set; }
        public tblFloor Floor { get; set; }
        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        [DisplayName("رقم الطابق")]
        public int FloorId { get; set; }
        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        [DisplayName("حالة الخزنة")]


        public tblLockerState LockerState { get; set; }
        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        [DisplayName("حالة الخزنة")]
        public int LockerStateId { get; set; }

        //[Required(ErrorMessage = "هذا الحقل مطلوب")]
        //[DisplayName("اسم الحاله باللغه العربيه ")]

        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        [DisplayName("حالة الخزنة بالعربية")]
        public string stateAr { get; set; }


        //[Required(ErrorMessage = "هذا الحقل مطلوب")]
        //[DisplayName("اسم الحاله باللغه الانجليزيه ")]
        public string stateEn { get; set; }

        public tblBuilding Building { get; set; }
        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        [DisplayName("رمز المبنى")]
        public int BuildingId { get; set; }

        //[DisplayName("اسم المبنى")]
        //public string BuildingName { get; set; }
    }
}
