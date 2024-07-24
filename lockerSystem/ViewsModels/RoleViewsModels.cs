using lockerSystem.Models;

namespace lockerSystem.ViewsModels
{
    public class RoleViewsModels
    {
        public int Id { get; set; }
        public Guid Guid { get; set; } = Guid.NewGuid();
        public bool IsDeleted { get; set; }
        public string RoleNameAr { get; set; }
        public string RoleNameEn { get; set; }
        public ICollection<tblPermission> Permission { get; set; }
    }
}
