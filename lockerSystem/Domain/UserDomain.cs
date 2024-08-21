using lockerSystem.Models;
using lockerSystem.ViewsModels;
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

        public tblUser GetlUserByUserName(string UserName)
        
        {
            return _context.tblUser.FirstOrDefault(x => x.email == UserName);// select * from tblUser
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



    }
}
