using lockerSystem.Models;
using lockerSystem.ViewsModels;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

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
                LockerStateId = x.Id,
                Guid = x.Guid,
                IsDeleted = x.IsDeleted,
                stateAr = x.stateAr,
                stateEn = x.stateEn

            }).ToListAsync();
        }
        public async Task<string> addLockerState(LockerStateViewsModels State)
        {

            try
            {
                var existingState = await _context.tblLockerState
                    .FirstOrDefaultAsync(s => s.stateAr == State.stateAr && s.stateEn
                    == State.stateEn && s.IsDeleted == false);

                if (existingState != null)
                {
                    return "هذه الحالة موجودة بالفعل.";
                }

                tblLockerState Stateinfo = new tblLockerState
                {
                    stateAr = State.stateAr,
                    stateEn = State.stateEn
                };

                _context.Add(Stateinfo);
                _context.SaveChanges();
                var stateLog = new LockerStateLog();
                stateLog.Locker_state_Id = Stateinfo.Id;
                stateLog.operationType = "Add";
                stateLog.generatedBy = ClaimTypes.GivenName;
                stateLog.date_time = DateTime.UtcNow;

                return "1";
            }
            catch (Exception ex)
            {
                return "فشلت عملية الاضافه!!";
            }
        }
        public async Task<LockerStateViewsModels> getlockerstateById(Guid id)
        {
            var Stateinfo = await _context.tblLockerState.FirstOrDefaultAsync(x => x.Guid == id && x.IsDeleted == false);
            LockerStateViewsModels models = new LockerStateViewsModels
            {

                Guid = Stateinfo.Guid,
                stateAr = Stateinfo.stateAr,
                stateEn = Stateinfo.stateEn

            }; return models;


        }
        public async Task<tblLockerState> getLockerStateByGuid(Guid id)
        {
            return await _context.tblLockerState.FirstOrDefaultAsync(x => x.Guid == id);
        }
        public async Task<string> editLockerState(LockerStateViewsModels state)
        {
            try
            {
                tblLockerState Stateinfo = await getLockerStateByGuid(state.Guid);

                var existingState = await _context.tblLockerState
                    .FirstOrDefaultAsync(
                    s => s.stateAr == state.stateAr
                    && s.stateEn == state.stateEn
                    && s.IsDeleted == false);

                if (existingState != null)
                {
                    return "هذه الحالة موجودة بالفعل.";
                }

                Stateinfo.stateAr = state.stateAr;
                Stateinfo.stateEn = state.stateEn;

                _context.Update(Stateinfo);
                await _context.SaveChangesAsync();
                var stateLog = new LockerStateLog();
                stateLog.Locker_state_Id = Stateinfo.Id;
                stateLog.operationType = "Add";
                stateLog.generatedBy = ClaimTypes.GivenName;
                stateLog.date_time = DateTime.UtcNow;
                return "1";
            }
            catch (Exception ex)
            {
                return "فشلت عملية التعديل!!";
            }
        }


        public async Task<string> DeleteLockerState(Guid Id)

        {
            try
            {

                tblLockerState Stateinfo = await getLockerStateByGuid(Id);
                Stateinfo.IsDeleted = true;

                _context.Update(Stateinfo);
                _context.SaveChanges();
                var stateLog = new LockerStateLog();
                stateLog.Locker_state_Id = Stateinfo.Id;
                stateLog.operationType = "Add";
                stateLog.generatedBy = ClaimTypes.GivenName;
                stateLog.date_time = DateTime.UtcNow;
                return "1";
            }
            catch (Exception ex)
            {
                return "فشلت عملية الحذف!!";
            }

        }
    }
}
