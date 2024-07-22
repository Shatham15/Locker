namespace lockerSystem.Models.ViewsModels
{
    public class PermitionViewsModels
    {
        //اللي بينعرض للمستخدم تكون نسخه مب الاصل
        //نسوي لكل التيبلز بنقس الطريقه
        public int Id { get; set; }
        public Guid Guid { get; set; } = Guid.NewGuid();
        public bool IsDeleted { get; set; }
        public string userName { get; set; }
        public tblRole Role { get; set; }
        public int RoleId { get; set; }
        public string fullName { get; set; }
    }
}
