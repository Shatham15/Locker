using lockerSystem.Models;
using lockerSystem.ViewsModels;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using System;


namespace lockerSystem.Domain
{
    public class BuildingDomain
    {
        private readonly LockerSystemContext _context;
        private readonly UserDomain _UserDomain;
        public BuildingDomain(LockerSystemContext context, UserDomain userDomain)
        {
            _context = context;
            _UserDomain = userDomain;
        }
        public async Task<IEnumerable<BuildingViewsModels>> GetAllBuildings()
        {

            return await _context.tblBuilding.Where(x=>x.IsDeleted==false).Select(x => new BuildingViewsModels
            {

                BuildingId = x.Id,
                code=x.code,
                no=x.no,
                NameAr=x.NameAr,
                NameEn=x.NameEn,
                Guid=x.Guid,
                gender = x.gender,

            }).ToListAsync();// select * from tblBuilding
        }
        public async Task<IEnumerable<BuildingViewsModels>> GetBuildingsByGenderAsync(string Email)
        {
            var userInfo = await _UserDomain.GetlUserByUserName(Email);

            return await _context.tblBuilding.Where(x => x.IsDeleted == false && x.gender == userInfo.gender).Select(x => new BuildingViewsModels
            {

                BuildingId = x.Id,
                code = x.code,
                no = x.no,
                NameAr = x.NameAr,
                NameEn = x.NameEn,
                Guid = x.Guid,
                gender = x.gender,

            }).ToListAsync();// select * from tblBuilding
        }
        public async Task<string> addBuilding(BuildingViewsModels Building)
        { 
            
            try
            {

                tblBuilding checkRepetedCode = _context.tblBuilding.AsNoTracking().SingleOrDefault(A => A.code == Building.code && A.IsDeleted==false );
                if (checkRepetedCode != null)
                    return "3";
                tblBuilding checkRepetedno = _context.tblBuilding.AsNoTracking().SingleOrDefault(A => A.no == Building.no && A.IsDeleted == false);
                if (checkRepetedno != null)
                    return "4";

                tblBuilding Buildinginfo = new tblBuilding();
                Buildinginfo.code = Building.code;
                Buildinginfo.no = Building.no;
                Buildinginfo.NameAr = Building.NameAr;
                Buildinginfo.NameEn = Building.NameEn;
                Buildinginfo.Guid = Building.Guid;
                Buildinginfo.gender = Building.gender;


                _context.Add(Buildinginfo);
                await _context.SaveChangesAsync();
                var BuildingLog = new BuildingLog();
                BuildingLog.Building_Id= Buildinginfo.Id;
                BuildingLog.operationType = "Add";
                BuildingLog.generatedBy = ClaimTypes.GivenName;
                BuildingLog.date_time = DateTime.UtcNow;
                //BuildingLog.additionalInfo = ;
                _context.Add(BuildingLog);
                await _context.SaveChangesAsync();
                return "1";
            }
            catch (Exception ex)
            {
                return "-1";
            }
        }
        public async Task<BuildingViewsModels> getBuildingById(Guid id)
        {
            var Buildinginfo = await _context.tblBuilding.FirstOrDefaultAsync(x => x.Guid == id && x.IsDeleted== false);
            BuildingViewsModels models = new BuildingViewsModels
            {
                code = Buildinginfo.code,
                no = Buildinginfo.no,
                NameAr = Buildinginfo.NameAr,
                NameEn = Buildinginfo.NameEn,
                Guid = Buildinginfo.Guid,
                gender = Buildinginfo.gender,

            }; return  models;
            

           
        }
        public async Task<string> getBuildingNameById(int id)
        {
            var Buildinginfo =  _context.tblBuilding.AsNoTracking().FirstOrDefault(x => x.Id == id && x.IsDeleted == false);
            BuildingViewsModels models = new BuildingViewsModels
            {
                code = Buildinginfo.code,
                no = Buildinginfo.no,
                NameAr = Buildinginfo.NameAr,
                NameEn = Buildinginfo.NameEn,
                Guid = Buildinginfo.Guid,
                gender = Buildinginfo.gender,

            }; 
            return models.NameAr;



        }
        public async Task<tblBuilding> getBuildingByGuid(Guid id)
        {
            return await _context.tblBuilding.FirstOrDefaultAsync(x => x.Guid == id);

        }
        public async Task<string> editBuilding(BuildingViewsModels Building)
        {
            try
            {
                tblBuilding checkRepetedCode = _context.tblBuilding.AsNoTracking().SingleOrDefault(A => A.code == Building.code && A.IsDeleted == false);
                if (checkRepetedCode != null && checkRepetedCode.Guid != Building.Guid)
                    return "3";
                tblBuilding checkRepetedno = _context.tblBuilding.AsNoTracking().SingleOrDefault(A => A.no == Building.no && A.IsDeleted == false);
                if (checkRepetedno != null && checkRepetedno.Guid != Building.Guid)
                    return "4";

                tblBuilding Buildinginfo = await getBuildingByGuid(Building.Guid);
                Buildinginfo.code = Building.code;
                Buildinginfo.no = Building.no;
                Buildinginfo.NameEn = Building.NameEn;
                Buildinginfo.NameAr = Building.NameAr;
                Buildinginfo.gender = Building.gender;



                _context.Update(Buildinginfo);
              await  _context.SaveChangesAsync();
                var BuildingLog = new BuildingLog();
                BuildingLog.Building_Id = Buildinginfo.Id;
                BuildingLog.operationType = "Edit";
                BuildingLog.generatedBy = ClaimTypes.GivenName;
                BuildingLog.date_time = DateTime.UtcNow;
                //BuildingLog.additionalInfo = ;
                _context.Add(BuildingLog);
                await _context.SaveChangesAsync();
                return "1";
            }
            catch (Exception ex)
            {
                return "-1";
            }
        }
        //public tblBuilding GetBuildingModelId(Guid id) {
        //    var BuildingById = _context.tblBuilding.FirstOrDefault(x => x.Guid == id);
        //    return BuildingById;
        //}

        public async Task<string> DeleteBuilding(Guid Id)

        { 
            try
            {
                tblBuilding Buildinginfo = await getBuildingByGuid(Id);
                Buildinginfo.IsDeleted = true;

                _context.Update(Buildinginfo);
              await  _context.SaveChangesAsync();
                var BuildingLog = new BuildingLog();
                BuildingLog.Building_Id = Buildinginfo.Id;
                BuildingLog.operationType = "Delete";
                BuildingLog.generatedBy = ClaimTypes.GivenName;
                BuildingLog.date_time = DateTime.UtcNow;
                //BuildingLog.additionalInfo = ;
                _context.Add(BuildingLog);
                await _context.SaveChangesAsync();
                return "1";
            }
            catch (Exception ex)
            {
                return "-1";
            }

        }


    }
}
