using lockerSystem.Models;

namespace lockerSystem.ViewsModels
{
    public class BookingViewsModels
    {
        public int Id { get; set; }
        public Guid Guid { get; set; } = Guid.NewGuid();
        public bool IsDeleted { get; set; }
        public DateTime bokingDateTime { get; set; }
        public string fullName { get; set; }
        public string email { get; set; }
        public int phone { get; set; }
        public tblBookingState BookingState { get; set; }
        public int BookingStateId { get; set; }
        public tblLocker Locker { get; set; }
        public int LockerId { get; set; }
        public tblSemster Semster { get; set; }
        public int SemsterId { get; set; }
        public string? rejectionReason { get; set; }
    }
}
