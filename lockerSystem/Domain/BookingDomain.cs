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
        public BookingDomain(LockerSystemContext context, BuildingDomain buildingDomain,FloorDomain floorDomain)
        {
            _context = context;
            _buildingDomain = buildingDomain;
            _floorDomain = floorDomain;
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
        //public string addbooking(BookingViewsModels booking)
        //{
        //    try
        //    {
        //        tblBuilding booking1 = new tblBuilding();
        //        booking1.NameAr = booking.colegename;

        //        tblFloor floor = new tblFloor();
        //        floor.no = booking.floornumer;

        //        _context.Add(booking1);
        //        _context.SaveChanges();
        //        return "1";
        //    }



        //    catch (Exception ex)
        //    {
        //        return "حدث خطأ أثناء معالجة طلبك, الرجاء المحاولة في وقت لاحق";
        //    }


        //}


        //public string addBooking(BookingViewsModels booking)
        //{
        //    try
        //    {
        //        //gg//l,ll
        //        var user = _UserDomain.GetlUserByUserName(booking.fullName);
        //        if (user != null)
        //        {
        //            var checkBooking = getUserModelByUserName(booking.fullName);
        //            if (checkBooking == null)
        //            {
        //                tblBooking booking1 = new tblBooking();
        //                booking1.fullName = user.fullName;
        //                booking1.email = user.email;
        //                booking1.phone = user.phone;
        //                booking1.BookingState.NameAr = booking.BookingState.NameAr;
        //                booking1.Locker.no = booking.Locker.no ;
        //                booking1.Locker.Floor.no = booking.Locker.Floor.no;
        //                booking1.colegename = booking.colegename;


        //                _context.Add(booking1);
        //                _context.SaveChanges();
        //                return "1";
        //            }
        //            else
        //                return "توجد لهذا المستخدم صلاحية مسبقا";
        //        }
        //        else
        //            return "هذا المستخدم غير مخزن في قاعدة البيانات";
        //    }
        //    catch (Exception ex)
        //    {
        //        return "حدث خطأ أثناء معالجة طلبك, الرجاء المحاولة في وقت لاحق";
        //    }


        //}
        public string addbooking(BookingViewsModels booking)
        {
            try
            {
                tblUser user = new tblUser();
                user.fullName = booking.fullName;
                user.email = booking.email;
                user.phone = booking.phone;

                tblBookingState bookingState = new tblBookingState();
                bookingState.NameAr = booking.BookingState.NameAr;

                tblLocker bookLocker = new tblLocker();
                bookLocker.no = booking.Locker.no;

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


