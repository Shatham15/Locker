namespace lockerSystem.Models
{
    public class tblUser
    {
        public int Id { get; set; }
        public string fullName { get; set; }
        public string email { get; set; }
        public string password { get; set; }    
        public int phone { get; set; }
        public string userType { get; set; } 
    }
}
