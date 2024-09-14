using lockerSystem.Models;
using lockerSystem.ViewsModels;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;


namespace lockerSystem.Domain
{
    public class SemsterDomain
    {
        private readonly LockerSystemContext _context;
        public SemsterDomain(LockerSystemContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<SemsterViewsModels>> GetAllSemsters()
        {

            return await _context.tblSemster.Where(s => s.IsActive == false).Select(x => new SemsterViewsModels
            {

                //Id = x.Id,
                Guid = x.Guid,
                startSemster = x.startSemster,
                endSemster = x.endSemster,
                semsterNameAr = x.semsterNameAr,
                semsterNameEn = x.semsterNameEn,



            }).ToListAsync();// select * from tblBuilding
        }


        public async Task<string> addSemster(SemsterViewsModels Semster)
        {

            try
            {

              
                tblSemster Semsterinfo = new tblSemster();
                Semsterinfo.Guid = Semster.Guid;
                Semsterinfo.startSemster = Semster.startSemster;
                Semsterinfo.endSemster = Semster.endSemster;
                Semsterinfo.semsterNameAr = Semster.semsterNameAr;
                Semsterinfo.semsterNameEn = Semster.semsterNameEn;

                _context.Add(Semsterinfo);
                await _context.SaveChangesAsync();
                var SemesterLog = new SemesterLog();
                SemesterLog.Semester_Id = Semsterinfo.Id;
                SemesterLog.operationType = "Add";
                SemesterLog.generatedBy = ClaimTypes.GivenName;
                SemesterLog.date_time = DateTime.UtcNow;
                _context.Add(SemesterLog);
                await _context.SaveChangesAsync();
                return "1";
            }
            catch (Exception ex)
            {
                return "-1";
            }
        }
        
        public async Task<SemsterViewsModels> getSemsterByGuId(Guid id)
        {
            var Semsterinfo = await _context.tblSemster.FirstOrDefaultAsync(x => x.Guid == id);
            SemsterViewsModels models = new SemsterViewsModels
            {

                Guid = Semsterinfo.Guid,
                startSemster = Semsterinfo.startSemster,
                endSemster = Semsterinfo.endSemster,
                semsterNameAr = Semsterinfo.semsterNameAr,
                semsterNameEn = Semsterinfo.semsterNameEn,

            }; return models;


        }
        public async Task<tblSemster> getSemsterByGuid(Guid id)
        {
            return await _context.tblSemster.FirstOrDefaultAsync(x => x.Guid == id);

        }
        public async Task<string> editSemster(SemsterViewsModels Semster)
        {


            try
            {
                tblSemster Semsterinfo = await getSemsterByGuid(Semster.Guid);
                Semsterinfo.startSemster = Semster.startSemster;
                Semsterinfo.endSemster = Semster.endSemster;
                Semsterinfo.semsterNameAr = Semster.semsterNameAr;
                Semsterinfo.semsterNameEn = Semster.semsterNameEn;

                _context.Update(Semsterinfo);
                await _context.SaveChangesAsync();
                var SemesterLog = new SemesterLog();
                SemesterLog.Semester_Id = Semsterinfo.Id;
                SemesterLog.operationType = "Edit";
                SemesterLog.generatedBy = ClaimTypes.GivenName;
                SemesterLog.date_time = DateTime.UtcNow;
                _context.Add(SemesterLog);
                await _context.SaveChangesAsync();
                return "1";
            }
            catch (Exception ex)
            {
                return " فشل التعديل!!";
            }

        }



        public async Task<string> DeleteSemster(Guid id/*, bool permanentDelete = false*/)
        {
            try
            {
                var semsterinfo = await getSemsterByGuid(id);
                semsterinfo.IsActive = true;
                _context.Update(semsterinfo);
                await _context.SaveChangesAsync();
                var SemesterLog = new SemesterLog();
                SemesterLog.Semester_Id = semsterinfo.Id;
                SemesterLog.operationType = "Delete";
                SemesterLog.generatedBy = ClaimTypes.GivenName;
                SemesterLog.date_time = DateTime.UtcNow;
                _context.Add(SemesterLog);
                await _context.SaveChangesAsync();
                return "1";
            }
            catch (Exception ex)
            {
                return "تم الحذف بنجاح";

            }

        }
        public async Task<tblSemster> getActiveSemster()
        {
            return await _context.tblSemster.FirstOrDefaultAsync(x => x.IsActive);

        }



    }
}
