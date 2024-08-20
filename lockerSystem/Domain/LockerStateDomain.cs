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
                //  Id = x.Id,
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
                // Check if the locker state already exists
                var existingState = _context.tblLockerState
                    .FirstOrDefault(s => s.stateAr == State.stateAr && s.stateEn
                    == State.stateEn && s.IsDeleted == false);

                if (existingState != null)
                {
                    return "هذه الحالة موجودة بالفعل.";
                }

                // Create a new locker state record
                tblLockerState Stateinfo = new tblLockerState
                {
                    stateAr = State.stateAr,
                    stateEn = State.stateEn
                };

                // Add the new locker state to the context and save changes
                _context.Add(Stateinfo);
                _context.SaveChanges();
                return "1"; // Indicate success
            }
            catch (Exception ex)
            {
                return "فشلت عملية الاضافه!!";
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
                return "فشلت عملية التعديل!!";
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
                return "فشلت عملية الحذف!!";
            }

        }
    }
}
