using lockerSystem.Models;
using lockerSystem.ViewsModels;
using Microsoft.EntityFrameworkCore;
using System.Text;

namespace lockerSystem.Domain
{
    public class UserDomain 
    {

        private readonly LockerSystemContext _context;
        public UserDomain(LockerSystemContext context)
        {
            _context = context;
        }
        //lll
        public IEnumerable<UserViweModele> GetAllUsers()
        {
            return _context.tblUser.Select(X => new UserViweModele
            {
                Id = X.Id,
                email = X.email,
                fullName = X.fullName,
                password = X.password,
                phone = X.phone,
                userType = X.userType
            });// select * from tblUser
        }
        public string addUser(UserViweModele user)
        {
            tblUser userinfo = new tblUser();
            userinfo.fullName = user.fullName;
            userinfo.password = user.password;
            userinfo.email = user.email;
            userinfo.phone = user.phone;
            userinfo.userType = user.userType;
            _context.Add(userinfo);
            _context.SaveChanges();
            return "addede";
        }

        public async Task<tblUser> GetlUserByUserName(string UserName)
        
        {
            return await _context.tblUser.FirstOrDefaultAsync(x => x.email == UserName);// select * from tblUser
        }
        public async Task<tblUser> GetlUserByUserNamAsynce(string UserName)

        {
            return await _context.tblUser.FirstOrDefaultAsync(x => x.email == UserName);// select * from tblUser
        }
        public  UserViweModele GetUsersForLogin(UserViweModele UsertInfo)
        {
           var data=  _context.tblUser.FirstOrDefault(x => x.email == UsertInfo.email && x.password == UsertInfo.password  )  ;// select * from tblUser
            
            return new UserViweModele
            { userType = data.userType,
                fullName = data.fullName,
                Id = data.Id,
                phone = data.phone,
                email = data.email
                

            };
        }
        public async Task<UserViweModele> GetlUserModelByUserName(string UserName)

        {
            tblUser userinfo = await _context.tblUser.FirstOrDefaultAsync(x => x.email == UserName);
            if (userinfo == null) return null;
            else
            {
                return new UserViweModele
                {
                    fullName = userinfo.fullName,
                    Id = userinfo.Id,
                    phone = userinfo.phone,
                    email = userinfo.email
                };
            }
        }



    }
}
