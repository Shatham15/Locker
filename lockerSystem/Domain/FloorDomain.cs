using lockerSystem.Migrations;
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

            return await _context.tblFloor.Include(x => x.Building).Where(d => d.IsDeleted == false 
            && d.Building.IsDeleted == false).Select(x => new FloorViewsModels
            {
                FloorId = x.Id,
                FloorNo = x.no,
                BuildingId = x.BuildingId,
                Building = x.Building,
                BuildingName = x.Building.NameAr,
                Guid = x.Guid,
           
            }).ToListAsync();
        }

        public async Task<string> addFloor(FloorViewsModels floor)
        {
            try
            {
                // Check if the floor already exists in the specified building
                var existingFloor = await _context.tblFloor
                    .FirstOrDefaultAsync(f => f.no == floor.FloorNo
                    && f.BuildingId == floor.BuildingId && f.IsDeleted == false);

                if (existingFloor != null)
                {
                    return "هذا الطابق موجود بالفعل في هذا المبنى";
                }

                tblFloor floorinfo = new tblFloor();
                floorinfo.no = floor.FloorNo;
                floorinfo.BuildingId = floor.BuildingId;
                _context.Add(floorinfo);
                _context.SaveChanges();

                //var floorLog = new FloorLog();
                //floorLog.Floor_Id = floorinfo.Id;


                return "1";
            }
            catch (Exception ex)
            {
                return "فشلت عملية الاضافه!!";
            }

        }
        public async Task<FloorViewsModels> getFloorById(Guid id)
        {
            var FloorById = await _context.tblFloor.Include(s => s.Building).FirstOrDefaultAsync(x => x.Guid == id);
            FloorViewsModels floorViewsModels = new FloorViewsModels
            {
                // Id = FloorById.Id,
                FloorNo = FloorById.no,
                BuildingId = FloorById.BuildingId,
                Building = FloorById.Building,
                Guid = FloorById.Guid
            };
            return floorViewsModels;
        }
        //
        public async Task<FloorViewsModels> getFloorByBuildingId(int BuildingId)
        {
            var FloorById = await _context.tblFloor.Include(s => s.Building).FirstOrDefaultAsync(x => x.BuildingId == BuildingId);
            FloorViewsModels floorViewsModels = new FloorViewsModels
            {
                // Id = FloorById.Id,
                FloorNo = FloorById.no,
                BuildingId = FloorById.BuildingId,
                Building = FloorById.Building,
                Guid = FloorById.Guid
            };
            return floorViewsModels;
        }
        public async Task<tblFloor> getFloorModelById(Guid id)
        {
            var FloorById = await _context.tblFloor.Include(s => s.Building).FirstOrDefaultAsync(x => x.Guid == id);
            return FloorById;
        }
        public async Task<IEnumerable<FloorViewsModels>> getFloorByBuildinGuid(Guid id)
        {
            return await _context.tblFloor.Include(s => s.Building).Where(x => x.Building.Guid == id && !x.IsDeleted).Select(x => new FloorViewsModels
            {
                // Id = x.Id,
                FloorNo = x.no,
                BuildingId = x.BuildingId,
                Building = x.Building,
                Guid = x.Guid
            }).ToListAsync();
        }

      
        public async Task<IEnumerable<tblBuilding>> GetBuilding()
        {
            return await _context.tblBuilding
                .Where(b => b.IsDeleted == false) // Filter for non-deleted buildings
                .ToListAsync();
        }
        public async Task<string> editFloor(FloorViewsModels floor)
        {
            try
            {
                var floorByGuid = await getFloorModelById(floor.Guid);

                var existingFloor = await _context.tblFloor
                    .FirstOrDefaultAsync(f => f.no == floor.FloorNo && f.BuildingId == floor.BuildingId && f.IsDeleted == false);

                if (existingFloor != null)
                {
                    return "رقم الطابق موجود بالفعل في هذا المبنى.";
                }


                floorByGuid.no = floor.FloorNo;
                floorByGuid.BuildingId = floor.BuildingId;
                _context.Update(floorByGuid);
                await _context.SaveChangesAsync();
                return "1";
            }
            catch (Exception ex)
            {
                return "فشلت عملية التعديل!!";
            }
        }

        public async Task<string> deleteFloor(Guid id)
        {
            try
            {
                tblFloor floor = await getFloorModelById(id);
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
