namespace lockerSystem.Models
{
    public class tblRole
    {
        public int Id { get; set; }
        public Guid Guid { get; set; } = Guid.NewGuid();
        public bool IsDeleted { get; set; }
        public string RoleNameAr { get; set; }
        public string RoleNameEn { get; set; }
        public ICollection<tblPermission> Permission { get; set; }

    }
}
