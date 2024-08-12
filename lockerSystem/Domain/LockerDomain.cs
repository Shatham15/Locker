using lockerSystem.Models;
using lockerSystem.ViewsModels;
using Microsoft.EntityFrameworkCore;

namespace lockerSystem.Domain
{
    public class LockerDomain
    {
        private readonly LockerSystemContext _context;

        public LockerDomain(LockerSystemContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<LockerViewsModels>> GetAllLockers()
        {

            return await _context.tblLocker.Include(x => x.Floor).Where(d => d.IsDeleted == false).Select(x => new LockerViewsModels
            {
                Id = x.Id,
                Guid = x.Guid,
                no = x.no,
                Floor = x.Floor,
                FloorId = x.FloorId,
                LockerState = x.LockerState,
                LockerStateId = x.LockerStateId



            }).ToListAsync();// select * from tblUser
        }

        public string addLocker(LockerViewsModels Locker)
        {
            try
            {
                tblLocker Lockerinfo = new tblLocker();
                Lockerinfo.no = Locker.no;
                Lockerinfo.FloorId = Locker.FloorId;
                _context.Add(Lockerinfo);
                _context.SaveChanges();
                return "1";
            }
            catch (Exception ex)
            {
                return "حدث خطأ أثناء معالجة طلبك, الرجاء المحاولة في وقت لاحق";
            }
        }
        public LockerViewsModels getLockerById(Guid id)
        {
            var LockerById = _context.tblLocker.Include(s => s.Floor).FirstOrDefault(x => x.Guid == id);
            LockerViewsModels lockerViewsModels = new LockerViewsModels
            {
                Id = LockerById.Id,
                Guid = LockerById.Guid,
                no = LockerById.no,
                Floor = LockerById.Floor,
                FloorId = LockerById.FloorId,
                LockerState = LockerById.LockerState,
                LockerStateId = LockerById.LockerStateId


            };
            return lockerViewsModels;
        }
        public tblLocker getLockerModelById(Guid id)
        {
            var LockerById = _context.tblLocker.Include(s => s.Floor).FirstOrDefault(x => x.Guid == id);
            return LockerById;
        }

        public IEnumerable<tblFloor> GetFloor()
        {
            return _context.tblFloor;
        }
        public string editLocker(LockerViewsModels Locker)
        {
            try
            {
                var LockerByGuid = getLockerModelById(Locker.Guid);
                LockerByGuid.no = Locker.no;
                LockerByGuid.FloorId = Locker.FloorId;
                _context.Update(LockerByGuid);
                _context.SaveChanges();
                return "1";
            }
            catch (Exception ex)
            {
                return "حدث خطأ , الرجاء المحاولة في وقت لاحق";
            }

        }

        public string deleteLocker(Guid id)
        {
            try
            {
                tblLocker Locker = getLockerModelById(id);
                Locker.IsDeleted = true;
                _context.Update(Locker);
                _context.SaveChanges();
                return "1";
            }
            catch (Exception ex)
            {
                return "حدث خطأ , الرجاء المحاولة في وقت لاحق";
            }

        }

    }
}