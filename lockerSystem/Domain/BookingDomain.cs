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
        private readonly FloorDomain _floorDomain;
        private readonly UserDomain _UserDomain;
        private readonly SemsterDomain _SemsterDomain;
        private readonly LockerDomain _LockerDomain;
        //
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
        //هذا الكود اللي تحت حاطته كومنت هو اللي انا اشتغلت عليه وبرضوا يطلع نفس الخطا اما الكود اللي تحته اللي مو محطوط فليه كومنت هذا الكود حقك انا اضفت المعلومات الثانيه اللي احنا نبي نخليها تطلع بس برضوا يطلع نفس الايرور

        //public string addBooking(BookingViewsModels booking)
        //{
        //    try
        //    {


        //                tblBooking booking1 = new tblBooking();
        //                booking1.fullName = booking.fullName;
        //                booking1.email = booking.email;
        //                booking1.phone = booking.phone;
        //                booking1.BookingState.NameAr = booking.BookingState.NameAr;
        //                booking1.Locker.no = booking.Locker.no;
        //                booking1.Locker.Floor.no = booking.Locker.Floor.no;
        //                booking1.colegename = booking.colegename;



        //                _context.Add(booking1);
        //                _context.SaveChanges();
        //                return "1";




        //    }
        //    catch (Exception ex)
        //    {
        //        return "حدث خطأ أثناء معالجة طلبك, الرجاء المحاولة في وقت لاحق";
        //    }


        //}
        public string AddBooking(Guid lookerGuid, string userName)
        {
            try
            {
                tblUser user = _UserDomain.GetlUserByUserName(userName);
                int semeterId = _SemsterDomain.getActiveSemster().Id;
                int loockerId = _LockerDomain.getLockerModelById(lookerGuid).Id;
                tblBooking bookInfo = new tblBooking
                {
                    fullName = user.fullName,
                    email = user.email,
                    phone = user.phone,
                    BookingStateId = 1,
                    IsDeleted = false,
                    bokingDateTime = DateTime.Now,
                    LockerId = loockerId,
                    SemsterId = semeterId
                };
                _context.Add(bookInfo);
                _context.SaveChanges();
                return "1";
            }
            catch (Exception ex)
            {
                return "حدث خطأ أثناء معالجة طلبك, الرجاء المحاولة في وقت لاحق";
            }


        }
        //public tblBooking getUserModelByUserName(string UserName)
        //{
        //    var UserById = _context.tblBooking.Include(b => b.fullName).FirstOrDefault(x => x.fullName == UserName && x.IsDeleted == false);
        //    return UserById;
        //}
        public IEnumerable<tblBooking> getBook()
        {
            return _context.tblBooking;
        }

    }
}


