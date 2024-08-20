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
                // Id = x.Id,
                no = x.no,
                BuildingId = x.BuildingId,
                Building = x.Building,
                BuildingName = x.Building.NameAr,
                Guid = x.Guid

            }).ToListAsync();
        }

        public string addFloor(FloorViewsModels floor)
        {
            try
            {
                // Check if the floor already exists in the specified building
                var existingFloor = _context.tblFloor
                    .FirstOrDefault(f => f.no == floor.no
                    && f.BuildingId == floor.BuildingId && f.IsDeleted == false);

                if (existingFloor != null)
                {
                    return "هذا الطابق موجود بالفعل في هذا المبنى";
                }

                tblFloor floorinfo = new tblFloor();
                floorinfo.no = floor.no;
                floorinfo.BuildingId = floor.BuildingId;
                _context.Add(floorinfo);
                _context.SaveChanges();
                return "1";
            }
            catch (Exception ex)
            {
                return "فشلت عملية الاضافه!!";
            }
           
        }
        public FloorViewsModels getFloorById(Guid id)
        {
            var FloorById = _context.tblFloor.Include(s => s.Building).FirstOrDefault(x => x.Guid == id);
            FloorViewsModels floorViewsModels = new FloorViewsModels
            {
                // Id = FloorById.Id,
                no = FloorById.no,
                BuildingId = FloorById.BuildingId,
                Building = FloorById.Building,
                Guid = FloorById.Guid
            };
            return floorViewsModels;
        }
        //
        public FloorViewsModels getFloorByBuildingId(int BuildingId)
        {
            var FloorById = _context.tblFloor.Include(s => s.Building).FirstOrDefault(x => x.BuildingId == BuildingId);
            FloorViewsModels floorViewsModels = new FloorViewsModels
            {
                // Id = FloorById.Id,
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
        public async Task<IEnumerable<FloorViewsModels>> getFloorByBuildinGuid(Guid id)
        {
            return await _context.tblFloor.Include(s => s.Building).Where(x => x.Building.Guid == id && !x.IsDeleted).Select(x => new FloorViewsModels
            {
                // Id = x.Id,
                no = x.no,
                BuildingId = x.BuildingId,
                Building = x.Building,
                Guid = x.Guid
            }).ToListAsync();
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
                return "فشلت عملية التعديل!!";
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
                return "فشلت عملية الحذف!!";
            }

        }

    }
}
