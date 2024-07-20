namespace lockerSystem.Models
{
    public class tblPermission
    {
        public int Id { get; set; }
        public Guid Guid { get; set; } = Guid.NewGuid();
        public bool IsDeleted { get; set; }
        public string userName { get; set; }
        public tblRole Role { get; set; }
        public int RoleId { get; set; }

        public string fullName { get; set; }
    }
}
