using lockerSystem.Models;
using lockerSystem.ViewsModels;
using Microsoft.EntityFrameworkCore;

namespace lockerSystem.Domain
{
    public class LockerStateDomain
    {
        private readonly LockerSystemContext _context;
        public LockerStateDomain(LockerSystemContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<LockerStateViewsModels>> GetLockerState()
        {

            return await _context.tblLockerState.Where(x => x.IsDeleted == false).Select(x => new LockerStateViewsModels
            {
                Id = x.Id,
                Guid = x.Guid,
                IsDeleted = x.IsDeleted,
                stateAr = x.stateAr,
                stateEn = x.stateEn

            }).ToListAsync();
        }
        public string addLockerState(LockerStateViewsModels State)
        {

            try
            {
                tblLockerState Stateinfo = new tblLockerState();
                Stateinfo.stateAr = State.stateAr;
                Stateinfo.stateEn = State.stateEn;

                _context.Add(Stateinfo);
                _context.SaveChanges();
                return "1";
            }
            catch (Exception ex)
            {
                return "حدث خطأ الرجاء المحاوله مره اخرى";
            }
        }
        public LockerStateViewsModels getlockerstateById(Guid id)
        {
            var Stateinfo = _context.tblLockerState.FirstOrDefault(x => x.Guid == id && x.IsDeleted == false);
            LockerStateViewsModels models = new LockerStateViewsModels
            {

                Guid = Stateinfo.Guid,
                stateAr = Stateinfo.stateAr,
                stateEn = Stateinfo.stateEn

            }; return models;


        }
        public tblLockerState getLockerStateByGuid(Guid id)
        {
            return _context.tblLockerState.FirstOrDefault(x => x.Guid == id);
        }
        public string editLockerState(LockerStateViewsModels state)
        {
            try
            {
                tblLockerState Stateinfo = getLockerStateByGuid(state.Guid);
                Stateinfo.stateAr = state.stateAr;
                Stateinfo.stateEn = state.stateEn;

                _context.Update(Stateinfo);
                _context.SaveChanges();
                return "1";
            }
            catch (Exception ex)
            {
                return "حدث خطأ الرجاء المحاوله مره اخرى";
            }
        }


        public string DeleteLockerState(Guid Id)

        {
            try
            {
                tblLockerState Stateinfo = getLockerStateByGuid(Id);
                Stateinfo.IsDeleted = true;

                _context.Update(Stateinfo);
                _context.SaveChanges();
                return "1";
            }
            catch (Exception ex)
            {
                return "حدث خطأ الرجاء المحاوله مره اخرى";
            }

        }
    }
}
