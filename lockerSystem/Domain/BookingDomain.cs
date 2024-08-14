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
        public async Task<IEnumerable<LockerViewsModels>> getLockerwithFilter(Guid? BuildingGuid, Guid? FloorGuid) {
            return await _context.tblLocker.Include(F => F.Floor).ThenInclude(B => B.Building).Include(LS => LS.LockerState).Where(x => x.Floor.Guid == FloorGuid).Select(x => new LockerViewsModels
            {
                Id = x.Id,
                LockerState = x.LockerState,
                Floor = x.Floor,
                FloorId = x.FloorId,
                Guid = x.Guid,
                IsDeleted = x.IsDeleted,
                LockerStateId = x.LockerStateId,
                no = x.no
            }).ToListAsync();
        }
       

        }
    }


