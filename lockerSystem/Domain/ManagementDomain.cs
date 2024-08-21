using lockerSystem.Domain;
using lockerSystem.Models;
using lockerSystem.ViewsModels;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol;

namespace lockerSystem.Domain
{
    public class ManagementDomain
    {
        private readonly LockerSystemContext _managementContext;

        public ManagementDomain(LockerSystemContext managementcontext)
        {
            _managementContext = managementcontext;
        }

        public async Task<IEnumerable<ManagementViewsModels>> GetAllMangement() 

        {
            return await _managementContext.tblManagement.Where(m => m.IsDeleted == false).Select(x => new ManagementViewsModels
            {
                
                Guid = x.Guid,
                name = x.name,
                value = x.value
            }).ToListAsync();

        }

        public async Task<string> addMangement(ManagementViewsModels management)
        {
            try
            {
                var checkManagement = await _managementContext.tblManagement.FirstOrDefaultAsync(m => m.name == management.name &&  m.IsDeleted == false);
                if (checkManagement != null)
                {
                    return "تم اضافة هذه الاعدادات الى النظام مسبقا";
                }
                tblManagement managementInfo = new tblManagement();
                managementInfo.name = management.name;
                managementInfo.value = management.value;


                _managementContext.tblManagement.Add(managementInfo);
                _managementContext.SaveChanges();
                return "1";
            }
            catch (Exception ex)
            {
                return "فشلت عملية الاضافة !!";
            }


        }
        public async Task<ManagementViewsModels> getManagementById(Guid? id)
        {
            var managementInfo = await _managementContext.tblManagement.FirstOrDefaultAsync(x => x.Guid == id);
            ManagementViewsModels models = new ManagementViewsModels
            {
                
                Guid = managementInfo.Guid,
                name = managementInfo.name,
                value = managementInfo.value
            };
            return models;

        }

        public async Task<tblManagement> getManagementByGuid(Guid? id)
        {

            return  await _managementContext.tblManagement.FirstOrDefaultAsync(x => x.Guid == id);

        }

        public async Task<string> editManagement(ManagementViewsModels management)
        {
            try
            {
                tblManagement managementInfo = await getManagementByGuid(management.Guid);

                managementInfo.name = management.name;
                managementInfo.value = management.value;
                

                _managementContext.Update(managementInfo);
                _managementContext.SaveChanges();
                return "1";
            }
            catch (Exception ex)
            {
                return "فشلت عملية التعديل!! ";
            }

        }


        public async Task<string> DeleteManagement(Guid id)

        {
            try
            {
                tblManagement managementInfo = await getManagementByGuid(id);
                managementInfo.IsDeleted = true;
                _managementContext.Update(managementInfo);
                _managementContext.SaveChanges();
                return "1";
            }
            catch (Exception ex)
            {
                return " فشلت عملية الحذف!!";
            }


        }


    }
}

