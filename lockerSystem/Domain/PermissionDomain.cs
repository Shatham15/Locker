using lockerSystem.Models;
using lockerSystem.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace lockerSystem.Domain
{
    //اضيفي async  على كل الفنكشن؟؟
    public class PermissionDomain
    {
        private readonly LockerSystemContext _Context;
        private readonly UserDomain _UserDomain;
        public PermissionDomain(LockerSystemContext Context, UserDomain userDomain)
        {
            _Context = Context;
            _UserDomain = userDomain;
        }

        public async Task<IEnumerable<PermissionViewsModels>> getpermissions()
        {
            return await _Context.tblPermission.Include(r => r.Role).Where(x => x.IsDeleted == false).Select(m => new PermissionViewsModels
            {
                fullName = m.fullName,
                Guid = m.Guid,
                //Id = m.Id,
                IsDeleted = m.IsDeleted,
                roleId = m.RoleId,
                usrName = m.userName,
                roleName = m.Role.RoleNameAr

            }
            ).ToListAsync();
        }
        public string addPermission(PermissionViewsModels permission)
        {
            try
            {
                var user = _UserDomain.GetlUserByUserName(permission.usrName);
                if (user != null)
                {
                    var checkPermission = getUserModelByUserName(permission.usrName);
                    if (checkPermission == null)
                    {
                        tblPermission permission1 = new tblPermission();
                        permission1.fullName = user.fullName;
                        permission1.userName = user.email;
                        permission1.RoleId = permission.roleId;

                        _Context.Add(permission1);
                        _Context.SaveChanges();
                        return "1";
                    }
                    else
                        return "توجد لهذا المستخدم صلاحية مسبقا";
                }
                else
                    return "هذا المستخدم غير مخزن في قاعدة البيانات";
            }
            catch (Exception ex)
            {
                return "حدث خطأ أثناء معالجة طلبك, الرجاء المحاولة في وقت لاحق";
            }


        }
        public IEnumerable<tblRole> getRoles()
        {
            return _Context.tblRole;

        }
        public PermissionViewsModels getUserById(Guid id)
        {
            var UserById = _Context.tblPermission.Include(r => r.Role).FirstOrDefault(x => x.Guid == id && x.IsDeleted == false);
            PermissionViewsModels permissionViweModel = new PermissionViewsModels
            {
                //Id = UserById.Id,
                roleId = UserById.RoleId,
                Guid = UserById.Guid,
                fullName = UserById.fullName,
                IsDeleted = UserById.IsDeleted,
                roleName = UserById.Role.RoleNameAr,
                usrName = UserById.userName

            };
            return permissionViweModel;
        }
        public tblPermission getUserModelById(Guid? id)
        {
            var UserById = _Context.tblPermission.Include(r => r.Role).FirstOrDefault(x => x.Guid == id && x.IsDeleted == false);
            return UserById;
        }
        public tblPermission getUserModelByUserName(string UserName)
        {
            var UserById = _Context.tblPermission.Include(r => r.Role).FirstOrDefault(x => x.userName == UserName && x.IsDeleted == false);
            return UserById;
        }
        public string editUser(PermissionViewsModels user)
        {
            try
            {
                tblPermission userPermission = getUserModelById(user.Guid);
                userPermission.RoleId = user.roleId;
                // هذه على عنصر واحد 
                _Context.Update(userPermission);
                _Context.SaveChanges();
                return "1";
            }
            catch (Exception ex)
            {
                return "حدث خطأ اثناء التشغيل حاول مرة اخرى";
            }

        }

        public string removeUser(Guid id)
        {
            try
            {
                tblPermission permission = getUserModelById(id);
                permission.IsDeleted = true;
                _Context.Update(permission);
                _Context.SaveChanges();
                return "1";
            }
            catch (Exception ex)
            {
                return " حدث خطأ اثناء التشغيل حاول مرة اخرى";
            }



        }


    }
}

