using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace lockerSystem.Models
{
    public class tblBookingState
    {
        public int Id { get; set; }
        public Guid Guid { get; set; } = Guid.NewGuid();
        public bool IsDeleted { get; set; }
        [DisplayName("حالة الحجز")]
        public string NameAr { get; set; }
        public string NameEn { get; set; }
        public ICollection<tblBooking> Bookings { get; set; }
    }
}
