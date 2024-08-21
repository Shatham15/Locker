using lockerSystem.Models;
using lockerSystem.ViewsModels;
using Microsoft.EntityFrameworkCore;


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


        public string addSemster(SemsterViewsModels Semster)
        {

            try
            {

                tblSemster checkRepetedStartDate = _context.tblSemster.AsNoTracking().SingleOrDefault(D => D.startSemster == Semster.startSemster);
                if (checkRepetedStartDate != null)
                    return "3";
                tblSemster checkRepetedEndDate = _context.tblSemster.AsNoTracking().SingleOrDefault(D => D.endSemster == Semster.endSemster);
                if (checkRepetedEndDate != null)
                    return "4";
                tblSemster Semsterinfo = new tblSemster();
                Semsterinfo.Guid = Semster.Guid;
                Semsterinfo.startSemster = Semster.startSemster;
                Semsterinfo.endSemster = Semster.endSemster;
                Semsterinfo.semsterNameAr = Semster.semsterNameAr;
                Semsterinfo.semsterNameEn = Semster.semsterNameEn;

                _context.Add(Semsterinfo);
                _context.SaveChanges();
                return "1";
            }
            catch (Exception ex)
            {
                return "-1";
            }
        }
        //public string addSemster(SemsterViewsModels Semster)
        //{

        //    try
        //    {
        //        tblSemster Semsterinfo = new tblSemster();
        //        Semsterinfo.Guid = Semster.Guid;
        //        Semsterinfo.startSemster = Semster.startSemster;
        //        Semsterinfo.endSemster = Semster.endSemster;
        //        Semsterinfo.semsterNameAr = Semster.semsterNameAr;
        //        Semsterinfo.semsterNameEn = Semster.semsterNameEn;
        //        _context.Add(Semsterinfo);
        //        _context.SaveChanges();
        //        return "1";
        //    }
        //    catch (Exception ex)
        //    {
        //        return "-1";
        //    }
        //}
        public SemsterViewsModels getSemsterByGuId(Guid id)
        {
            var Semsterinfo = _context.tblSemster.FirstOrDefault(x => x.Guid == id);
            SemsterViewsModels models = new SemsterViewsModels
            {

                Guid = Semsterinfo.Guid,
                startSemster = Semsterinfo.startSemster,
                endSemster = Semsterinfo.endSemster,
                semsterNameAr = Semsterinfo.semsterNameAr,
                semsterNameEn = Semsterinfo.semsterNameEn,

            }; return models;


        }
        public tblSemster getSemsterByGuid(Guid id)
        {
            return _context.tblSemster.FirstOrDefault(x => x.Guid == id);

        }
        public string editSemster(SemsterViewsModels Semster)
        {


            try
            {
                tblSemster Semsterinfo = getSemsterByGuid(Semster.Guid);
                Semsterinfo.startSemster = Semster.startSemster;
                Semsterinfo.endSemster = Semster.endSemster;
                Semsterinfo.semsterNameAr = Semster.semsterNameAr;
                Semsterinfo.semsterNameEn = Semster.semsterNameEn;

                _context.Update(Semsterinfo);
                _context.SaveChanges();
                return "1";
            }
            catch (Exception ex)
            {
                return " فشل التعديل!!";
            }

        }



        public string DeleteSemster(Guid id/*, bool permanentDelete = false*/)
        {
            try
            {
                var semsterInfo = getSemsterByGuid(id);
                semsterInfo.IsActive = true;
                _context.Update(semsterInfo);
                _context.SaveChanges();
                return "1";
            }
            catch (Exception ex)
            {
                return "تم الحذف بنجاح";

            }

        }
        public tblSemster getActiveSemster()
        {
            return _context.tblSemster.FirstOrDefault(x => x.IsActive);

        }



    }
}
