using lockerSystem.Models;
using lockerSystem.ViewsModels;
using Microsoft.EntityFrameworkCore;

namespace lockerSystem.Domain
{
    public class UserDomain
    {
        private readonly LockerSystemContext _context;
        public UserDomain(LockerSystemContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<UserViewsModels>>   GetAllUsers() {

            return await  _context.tblUser.Select(x=> new UserViewsModels
            {
                Id = x.Id,
                email = x.email, 
                fullName = x.fullName,
                password = x.password,
                phone = x.phone,
                userType = x.userType
            }).ToListAsync();// select * from tblUser
        }
        public string addUser(UserViewsModels user)
        {
            tblUser userinfo=new tblUser();
            userinfo.fullName = user.fullName;
            userinfo.email = user.email;
            userinfo.password = user.password;
            userinfo.phone = user.phone;
            userinfo.userType = user.
        userType;
                


            _context.Add(userinfo);
            _context.SaveChanges();
            return "add";      
        }
        public tblUser getUserById(int id)
        {
            return _context.tblUser.FirstOrDefault(x => x.Id== id);
        }
        public string editUser(tblUser user)
        {
            _context.Update(user);
            _context.SaveChanges();
            return "edit";
        }
    }
}
