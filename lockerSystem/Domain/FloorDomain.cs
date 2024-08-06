using lockerSystem.Models;
using lockerSystem.ViewsModels;
using Microsoft.EntityFrameworkCore;

namespace lockerSystem.Domain
{
    public class FloorDomain
    {
        private readonly LockerSystemContext _context;

        public FloorDomain(LockerSystemContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<FloorViewsModels>> GetAllFloor()
        {

            return await _context.tblFloor.Include(x => x.Building).Where(d => d.IsDeleted == false).Select(x => new FloorViewsModels
            {
                Id = x.Id,
                no = x.no,
                BuildingId = x.BuildingId,
                Building = x.Building,
                BuildingName = x.Building.NameAr,
                Guid = x.Guid

            }).ToListAsync();// select * from tblUser
        }

        public string addFloor(FloorViewsModels floor)
        {
            try
            {
                tblFloor floorinfo = new tblFloor();
                floorinfo.no = floor.no;
                floorinfo.BuildingId = floor.BuildingId;
                _context.Add(floorinfo);
                _context.SaveChanges();
                return "1";
            }
            catch (Exception ex)
            {
                return "حدث خطأ أثناء معالجة طلبك, الرجاء المحاولة في وقت لاحق";
            }
        }
        public FloorViewsModels getFloorById(Guid id)
        {
            var FloorById = _context.tblFloor.Include(s => s.Building).FirstOrDefault(x => x.Guid == id);
            FloorViewsModels floorViewsModels = new FloorViewsModels
            {
                Id = FloorById.Id,
                no = FloorById.no,
                BuildingId = FloorById.BuildingId,
                Building = FloorById.Building,
                Guid = FloorById.Guid
            };
            return floorViewsModels;
        }
        public tblFloor getFloorModelById(Guid id)
        {
            var FloorById = _context.tblFloor.Include(s => s.Building).FirstOrDefault(x => x.Guid == id);
            return FloorById;
        }

        public IEnumerable<tblBuilding> GetBuilding()
        {
            return _context.tblBuilding;
        }
        public string editFloor(FloorViewsModels floor)
        {
            try
            {
                var floorByGuid = getFloorModelById(floor.Guid);
                floorByGuid.no = floor.no;
                floorByGuid.BuildingId = floor.BuildingId;
                _context.Update(floorByGuid);
                _context.SaveChanges();
                return "1";
            }
            catch (Exception ex)
            {
                return "حدث خطأ , الرجاء المحاولة في وقت لاحق";
            }

        }

        public string deleteFloor(Guid id)
        {
            try
            {
                tblFloor floor = getFloorModelById(id);
                floor.IsDeleted = true;
                _context.Update(floor);
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
