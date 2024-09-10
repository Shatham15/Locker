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
        [DisplayName("الخزنة")]
        public int no { get; set; }
        public tblFloor Floor { get; set; }

        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        public int FloorId { get; set; }
        [Required(ErrorMessage = "هذا الحقل مطلوب")]
       
        public Guid FloorGuid { get; set; }

        [DisplayName("الطابق")]
        public int FloorNo { get; set; }


        public tblLockerState LockerState { get; set; }
        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        [DisplayName("حالة الخزنة")]
        public int LockerStateId { get; set; }

        //[Required(ErrorMessage = "هذا الحقل مطلوب")]
        //[DisplayName("اسم الحاله باللغه العربيه ")]

        
        [DisplayName("حالة الخزنة")]
        public string stateAr { get; set; }


        //[Required(ErrorMessage = "هذا الحقل مطلوب")]
        //[DisplayName("اسم الحاله باللغه الانجليزيه ")]
        public string stateEn { get; set; }

        public tblBuilding Building { get; set; }
        
       
        [DisplayName("المبنى")]
        public string BuildingName { get; set; }

        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        public int BuildingId { get; set; }

        //statsguid
        public Guid BuildingGuid { get; set; }

        //[DisplayName("اسم المبنى")]
        //public string BuildingName { get; set; }
    }
}
