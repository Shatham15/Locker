﻿using lockerSystem.Models;
using lockerSystem.ViewsModels;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace lockerSystem.Domain
{
    public class LockerDomain
    {
        private readonly LockerSystemContext _context;
        private readonly BuildingDomain _BuildingDomain;  
        private readonly FloorDomain _FloorDomain;
        private readonly SemsterDomain _SemsterDomain;
        private readonly LockerStateDomain _LockerStateDomain;


        public LockerDomain(LockerSystemContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<LockerViewsModels>> GetAllLockers()
        {

            return await _context.tblLocker.Include(x => x.Floor).Where(d => d.IsDeleted == false).Select(x => new LockerViewsModels
            {
                Id = x.Id,
                Guid = x.Guid,
                no = x.no,
                Floor = x.Floor,
                FloorId = x.FloorId,
                LockerState = x.LockerState,
                LockerStateId = x.LockerStateId,
                FloorNo = x.Floor.no,
               stateAr = x.LockerState.stateAr,
               BuildingName = x.Floor.Building.NameAr,



            }).ToListAsync();// select * from tblUser
        }

        public async Task<string> addLocker(LockerViewsModels Locker)
        {
            try
            {
                var existingLocker = await _context.tblLocker
                    .FirstOrDefaultAsync(l => l.no == Locker.no
                    && l.FloorId == Locker.FloorId && l.IsDeleted == false);

                if (existingLocker != null)
                {
                    return "هذه الخزانه موجود بالفعل في هذا الطابق";
                }

                tblLocker Lockerinfo = new tblLocker();
                Lockerinfo.no = Locker.no;
                Lockerinfo.FloorId = Locker.FloorId;
                Lockerinfo.LockerStateId = Locker.LockerStateId;
                _context.Add(Lockerinfo);
                await _context.SaveChangesAsync();
                var LockerLog = new LockerLog();
                LockerLog.Locker_Id = Lockerinfo.Id;
                LockerLog.operationType = "Add";
                LockerLog.generatedBy = ClaimTypes.GivenName;
                LockerLog.date_time = DateTime.UtcNow;
                _context.Add(LockerLog);
                await _context.SaveChangesAsync();
                return "1";
            }
            catch (Exception ex)
            {
                return "حدث خطأ أثناء معالجة طلبك, الرجاء المحاولة في وقت لاحق";
            }
        }
        public async Task<LockerViewsModels> getLockerById(Guid id)
        {
            var LockerById = await _context.tblLocker.Include(s => s.Floor).FirstOrDefaultAsync(x => x.Guid == id);
            LockerViewsModels lockerViewsModels = new LockerViewsModels
            {
                Id = LockerById.Id,
                Guid = LockerById.Guid,
                no = LockerById.no,
                Floor = LockerById.Floor,
                FloorId = LockerById.FloorId,
                LockerState = LockerById.LockerState,
                LockerStateId = LockerById.LockerStateId


            };
            return lockerViewsModels;
        }
        public async Task<tblLocker> getLockerModelById(Guid id)
        {
            var LockerById = await _context.tblLocker.Include(s => s.Floor).FirstOrDefaultAsync(x => x.Guid == id);
            return LockerById;
        }

        public async Task<IEnumerable<tblFloor>> GetFloor()
        {
            return await _context.tblFloor.ToListAsync();
        }
        public async Task<IEnumerable<tblBuilding>> GetBuilding()
        {
            return await _context.tblBuilding.ToListAsync();
        }
        public async Task<IEnumerable<tblLockerState>> GetLockerState()
        {
            return await _context.tblLockerState.ToListAsync();
        }

        public async Task<string> editLocker(LockerViewsModels Locker)
        {
            try
            {
                var LockerByGuid = await getLockerModelById(Locker.Guid);
                LockerByGuid.no = Locker.no;
                LockerByGuid.FloorId = Locker.FloorId;
                LockerByGuid.LockerStateId= Locker.LockerStateId;

                _context.Update(LockerByGuid);
                await _context.SaveChangesAsync();
                var LockerLog = new LockerLog();
                LockerLog.Locker_Id = LockerByGuid.Id;
                LockerLog.operationType = "Edit";
                LockerLog.generatedBy = ClaimTypes.GivenName;
                LockerLog.date_time = DateTime.UtcNow;
                _context.Add(LockerLog);
                await _context.SaveChangesAsync();
                return "1";
            }
            catch (Exception ex)
            {
                return "حدث خطأ , الرجاء المحاولة في وقت لاحق";
            }

        }

        public async Task<string> deleteLocker(Guid id)
        {
            try
            {
                tblLocker Locker = await getLockerModelById(id);
                Locker.IsDeleted = true;
                _context.Update(Locker);
                await _context.SaveChangesAsync();
                var LockerLog = new LockerLog();
                LockerLog.Locker_Id = Locker.Id;
                LockerLog.operationType = "Delete";
                LockerLog.generatedBy = ClaimTypes.GivenName;
                LockerLog.date_time = DateTime.UtcNow;
                _context.Add(LockerLog);
                await _context.SaveChangesAsync();
                return "1";
            }
            catch (Exception ex)
            {
                return "حدث خطأ , الرجاء المحاولة في وقت لاحق";
            }

        }
       
        public async Task<IEnumerable<LockerViewsModels>> getLockerwithFilter(Guid? BuildingGuid, Guid? FloorGuid)
        {
            var lockers = await _context.tblLocker
                .Include(F => F.Floor)
                    .ThenInclude(B => B.Building)
                .Include(LS => LS.LockerState)
                .Where(x => x.Floor.Guid == FloorGuid)
                .Where(x => !(_context.tblBooking.Any(b => b.LockerId == x.Id && b.BookingStateId == 1))) // Exclude lockers with BookingStateId == 1
                .Select(x => new LockerViewsModels
                {
                    Id = x.Id,
                    LockerState = x.LockerState,
                    Floor = x.Floor,
                    FloorId = x.FloorId,
                    Guid = x.Guid,
                    IsDeleted = x.IsDeleted,
                    LockerStateId = x.LockerStateId,
                    no = x.no
                })
                .ToListAsync();

            return lockers;
        }


    }
}