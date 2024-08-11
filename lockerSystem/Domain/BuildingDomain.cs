using lockerSystem.Models;
using lockerSystem.ViewsModels;
using Microsoft.EntityFrameworkCore;


namespace lockerSystem.Domain
{
    public class BuildingDomain
    {
        private readonly LockerSystemContext _context;
        public BuildingDomain(LockerSystemContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<BuildingViewsModels>> GetAllBuildings()
        {

            return await _context.tblBuilding.Where(x=>x.IsDeleted==false).Select(x => new BuildingViewsModels
            {
                
                Id = x.Id,
                code=x.code,
                no=x.no,
                NameAr=x.NameAr,
                NameEn=x.NameEn,
                Guid=x.Guid,
             
            }).ToListAsync();// select * from tblBuilding
        }
        public string addBuilding(BuildingViewsModels Building)
        { 
            
            try
            {
                tblBuilding Buildinginfo = new tblBuilding();
                Buildinginfo.code = Building.code;
                Buildinginfo.no = Building.no;
                Buildinginfo.NameAr = Building.NameAr;
                Buildinginfo.NameEn = Building.NameEn;
                Buildinginfo.Guid = Building.Guid;

                _context.Add(Buildinginfo);
                _context.SaveChanges();
                return "1";
            }
            catch (Exception ex)
            {
                return "-1";
            }
        }
        public BuildingViewsModels getBuildingById(Guid id)
        {
            var Buildinginfo = _context.tblBuilding.FirstOrDefault(x => x.Guid == id && x.IsDeleted== false);
            BuildingViewsModels models = new BuildingViewsModels
            {
                code = Buildinginfo.code,
                no = Buildinginfo.no,
                NameAr = Buildinginfo.NameAr,
                NameEn = Buildinginfo.NameEn,
                Guid = Buildinginfo.Guid,

            }; return models;
            

           
        }
        public string getBuildingNameById(int id)
        {
            var Buildinginfo =  _context.tblBuilding.AsNoTracking().FirstOrDefault(x => x.Id == id && x.IsDeleted == false);
            BuildingViewsModels models = new BuildingViewsModels
            {
                code = Buildinginfo.code,
                no = Buildinginfo.no,
                NameAr = Buildinginfo.NameAr,
                NameEn = Buildinginfo.NameEn,
                Guid = Buildinginfo.Guid,

            }; 
            return models.NameAr;



        }
        public tblBuilding getBuildingByGuid(Guid id)
        {
            return _context.tblBuilding.FirstOrDefault(x => x.Guid == id);




        }
        public string editBuilding(BuildingViewsModels Building)
        {
            try
            {
                tblBuilding Buildinginfo = getBuildingByGuid(Building.Guid);
                Buildinginfo.code = Building.code;
                Buildinginfo.no = Building.no;
                Buildinginfo.NameEn = Building.NameEn;
                Buildinginfo.NameAr = Building.NameAr;

                _context.Update(Buildinginfo);
                _context.SaveChanges();
                return "1";
            }
            catch (Exception ex)
            {
                return "حدث خطأ أثناء معالجتك طلبك الرجاء المحاولة في وقت لاحق";
            }
        }
        //public tblBuilding GetBuildingModelId(Guid id) {
        //    var BuildingById = _context.tblBuilding.FirstOrDefault(x => x.Guid == id);
        //    return BuildingById;
        //}

        public string DeleteBuilding(Guid Id)

        {
            try
            {
                tblBuilding Buildinginfo = getBuildingByGuid(Id);
                Buildinginfo.IsDeleted = true;

                _context.Update(Buildinginfo);
                _context.SaveChanges();
                return "1";
            }
            catch (Exception ex)
            {
                return "-1";
            }

        }


    }
}
