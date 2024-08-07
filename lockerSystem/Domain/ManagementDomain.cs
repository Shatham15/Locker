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

        public async Task<IEnumerable<ManagementViewsModels>> GetAllMangement() //مافهمت فكرةTask 

        {
            return await _managementContext.tblManagement.Where(m => m.IsDeleted == false).Select(x => new ManagementViewsModels
            {
                // Id = x.Id,
                Guid = x.Guid,
                name = x.name,
                value = x.value
            }).ToListAsync();// I do not understand what the ToList??

        }

        public string addMangement(ManagementViewsModels management)
        {
            try
            {
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
        public ManagementViewsModels getManagementById(Guid? id)
        {
            var managementInfo = _managementContext.tblManagement.FirstOrDefault(x => x.Guid == id);
            ManagementViewsModels models = new ManagementViewsModels
            {
                //Id = managementInfo.Id,
                Guid = managementInfo.Guid,
                name = managementInfo.name,
                value = managementInfo.value
            };
            return models;

        }

        public tblManagement getManagementByGuid(Guid? id)
        {


            return _managementContext.tblManagement.FirstOrDefault(x => x.Guid == id);



        }

        public string editManagement(ManagementViewsModels management)
        {
            try
            {
                tblManagement managementInfo = getManagementByGuid(management.Guid);

                managementInfo.name = management.name;
                managementInfo.value = management.value;
                //management.IsDeleted = false;

                _managementContext.Update(managementInfo);
                _managementContext.SaveChanges();
                return "1";
            }
            catch (Exception ex)
            {
                return "فشلت عملية التعديل ";
            }

        }


        public string DeleteManagement(Guid id)

        {
            try
            {
                tblManagement managementInfo = getManagementByGuid(id);
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

