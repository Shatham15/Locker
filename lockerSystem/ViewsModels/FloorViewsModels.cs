using lockerSystem.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace lockerSystem.ViewsModels
{
    public class FloorViewsModels
    {
        //public int Id { get; set; }
        public Guid Guid { get; set; } = Guid.NewGuid();
        public bool IsDeleted { get; set; }
        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        [Range(1, 10, ErrorMessage = "يجب ان يكون رقم المبنى من 1 الى 5")]
        [DisplayName("رقم الطابق")]
        public int no { get; set; }
        public tblBuilding Building { get; set; }
        [Required(ErrorMessage = "هذا الحقل مطلوب")]
        [DisplayName("اسم المبنى")]
        public int BuildingId { get; set; }

        [DisplayName("اسم المبنى")]
        public string BuildingName { get; set; }
        public ICollection<tblLocker> Lockers { get; }
    }
}
