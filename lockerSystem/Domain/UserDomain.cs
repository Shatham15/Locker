using lockerSystem.Models;

namespace lockerSystem.Domain
{
    public class UserDomain
    {
        private readonly LockerSystemContext _context;
        public UserDomain(LockerSystemContext context)
        {
            _context = context;
        }
        public IEnumerable<tblUser> GetAllUsers() {
            return _context.tblUser;// select * from tblUser
        }
        public string addUser(tblUser user)
        {
            _context.Add(user);
            _context.SaveChanges();
            return "addede";      
        }
    }
}
