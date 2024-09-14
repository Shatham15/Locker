using lockerSystem.Models;

using lockerSystem.ViewsModels;
using lockerSystem.Models;
using lockerSystem.ViewsModels;
using Microsoft.EntityFrameworkCore;
using System.Collections;
using Microsoft.VisualBasic;
using System.Security.Claims;




namespace lockerSystem.Domain
{
    public class BookingDomain
    {
        private readonly BuildingDomain _buildingDomain;
        private readonly LockerSystemContext _context;
        private readonly FloorDomain _floorDomain;
        private readonly UserDomain _UserDomain;
        private readonly SemsterDomain _SemsterDomain;
        private readonly LockerDomain _LockerDomain;

        
        public BookingDomain(LockerSystemContext context, BuildingDomain buildingDomain, FloorDomain floorDomain, UserDomain userDomain, SemsterDomain semsterDomain, LockerDomain lockerDomain)
        {
            _context = context;
            _buildingDomain = buildingDomain;
            _floorDomain = floorDomain;
            _UserDomain = userDomain;
            _SemsterDomain = semsterDomain;
            _LockerDomain = lockerDomain;
        }
        public async Task<IEnumerable<BookingViewsModels>> GetAllbooking()

        {

            return await _context.tblBooking.Include(x => x.BookingState).Include(y => y.Locker).ThenInclude(g => g.Floor).Where(x => x.IsDeleted == false).Select(x => new BookingViewsModels
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
        public async Task<IEnumerable<BookingViewsModels>> GetAllbybooking(string email)

        {

            return await _context.tblBooking.Include(x => x.BookingState).Include(y => y.Locker).ThenInclude(g => g.Floor).Where(x => x.IsDeleted == false && x.email == email).Select(x => new BookingViewsModels
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

        public async Task<string> AddBooking(Guid lookerGuid, string userName)
        {
            try
            {
                tblUser user = await _UserDomain.GetlUserByUserNamAsynce(userName);
                var semeter = await _SemsterDomain.getActiveSemster();
                var loocker = await _LockerDomain.getLockerModelById(lookerGuid);
                tblBooking bookInfo = new tblBooking
                {
                    fullName = user.fullName,
                    email = user.email,
                    phone = user.phone,
                    BookingStateId = 1,
                    
                    IsDeleted = false,
                    bokingDateTime = DateTime.Now,
                    LockerId = loocker.Id,
                    SemsterId = semeter.Id
                };
               await _context.AddAsync(bookInfo);
                await _context.SaveChangesAsync();

                //var bookingLog = new BookingLog();
                //bookingLog.Booking_Id = bookInfo.Id;
                //bookingLog.bookBy = ClaimTypes.Email;
                //// bookingLog.modifyBy =  bookInfo.email;
                //bookingLog.bookingStatues = bookInfo.Book;
                //bookingLog.date_time = DateTime.Now;

                // _context.Add(bookingLog);
                //await _context.SaveChangesAsync();

                return  "1";
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
        public async Task<tblBookingState> getBookingStateByGuid(Guid id)
        {
            return await _context.tblBookingState.FirstOrDefaultAsync(x => x.Guid == id);
        }
        public async Task<tblBooking> getBookingByGuid(Guid id)
        {
            return await _context.tblBooking.FirstOrDefaultAsync(x => x.Guid == id);
        }
        public async Task<BookingViewsModels> GetBookingByGuid(Guid guid)
        {
            var booking = await _context.tblBooking
                .Where(b => b.Guid == guid)
                .Include(b => b.BookingState)
                .Include(b => b.Locker)
                .ThenInclude(l => l.Floor)
                .ThenInclude(f => f.Building)
                .Include(b => b.Semster)
                .Select(b => new BookingViewsModels
                {
                    Guid = b.Guid,
                    bokingDateTime= b.bokingDateTime,
                    fullName = b.fullName,
                    email = b.email,
                    phone = b.phone,
                    BookingStateId = b.BookingStateId,
                    IsDeleted = b.IsDeleted,
                    LockerId = b.LockerId,
                    rejectionReason = b.rejectionReason,
                    SemsterId = b.SemsterId,
                    floornumer = b.Locker.Floor.no,
                    colegename = b.Locker.Floor.Building.NameAr,
                    BookingState = b.BookingState,
                    Locker = b.Locker,
                    Semster = b.Semster
                })
                .FirstOrDefaultAsync();

            return booking;
        }
      
        public async Task<string> UpdateBooking(BookingViewsModels bookingViewModel)
        {
            try
            {
                var stateInfo = await getBookingByGuid(bookingViewModel.Guid);
                stateInfo.BookingStateId = bookingViewModel.BookingStateId;
                _context.Update(stateInfo);
                await _context.SaveChangesAsync();

                //var bookingLog = new BookingLog();
                //bookingLog.Booking_Id = stateInfo.Id;
                //bookingLog.bookBy = stateInfo.fullName;
                //// bookingLog.modifyBy =  stateInfo.email;
                //bookingLog.bookingStatues = stateInfo.BookingState.NameAr;
                //bookingLog.date_time = DateTime.Now;

                // _context.Update(bookingLog);
                //await _context.SaveChangesAsync();
                return "1";
            }
            catch (Exception ex)
            {
                
                return "فشلت عملية التحديث ";
            }
        }

       
    public async Task<IEnumerable<tblBuilding>> GetBuildingsByGenderAsync(string gender)
        {
            return await _context.tblBuilding.Where(b => b.gender == gender).ToListAsync();
        }

    }
}



