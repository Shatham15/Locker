using lockerSystem.Models;
using lockerSystem.ViewsModels;
using Microsoft.EntityFrameworkCore;
using System.Collections;




namespace lockerSystem.Domain
{
    public class BookingDomain
    {
        private readonly BuildingDomain _buildingDomain;
        private readonly LockerSystemContext _context;
        public BookingDomain(LockerSystemContext context, BuildingDomain buildingDomain)
        {
            _context = context;
            _buildingDomain = buildingDomain;
        }
        public async Task<IEnumerable<BookingViewsModels>> GetAllbooking()

        {

            return await _context.tblBooking.Include(x => x.BookingState).Include(y => y.Locker).ThenInclude(g => g.Floor).Select(x => new BookingViewsModels
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
                floornumer = x.Locker.Floor.no,
                colegename = x.Locker.Floor.Building.NameAr,

            }).ToListAsync();

        }
        public string addbooking(BookingViewsModels booking)
        {
            try
            {
                tblBuilding booking1 = new tblBuilding();
                booking1.NameAr = booking.colegename;

                tblFloor floor = new tblFloor();
                floor.no = booking.floornumer;

                _context.Add(booking1);
                _context.SaveChanges();
                return "1";
            }



            catch (Exception ex)
            {
                return "حدث خطأ أثناء معالجة طلبك, الرجاء المحاولة في وقت لاحق";
            }


        }
        public IEnumerable<tblBooking> getBook()
        {
            return _context.tblBooking;
        }
       

        }
    }


