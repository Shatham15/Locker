using lockerSystem.Models;
using lockerSystem.ViewsModels;
using Microsoft.EntityFrameworkCore;




namespace lockerSystem.Domain
{
    public class BookingDomain
    {
        private readonly LockerSystemContext _context;
        public BookingDomain(LockerSystemContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<BookingViewsModels>> GetAllbooking()
        {

            return await _context.tblBooking.Where(x => x.IsDeleted == false).Select(x => new BookingViewsModels
            {

                Id = x.Id,
                bokingDateTime = x.bokingDateTime,
                Guid = x.Guid,
                BookingState = x.BookingState,
                fullName = x.fullName,
                email = x.email,
                phone = x.phone,
                BookingStateId = x.BookingStateId,
                IsDeleted = x.IsDeleted,
                Locker = x.Locker,
                LockerId = x.LockerId,
                rejectionReason = x.rejectionReason,
                Semster = x.Semster,
                SemsterId = x.SemsterId,

            }).ToListAsync();
        }
        public string addbooking(BookingViewsModels booking)
        {
            try
            {


                tblBooking booking1 = new tblBooking();
                booking1.fullName = booking.fullName;
                booking1.email = booking.email;
                booking1.phone = booking.phone;

                
                

                _context.Add(booking1);
                _context.SaveChanges();
                return "1";
            }



            catch (Exception ex)
            {
                return "حدث خطأ أثناء معالجة طلبك, الرجاء المحاولة في وقت لاحق";
            }


        }
    } }


