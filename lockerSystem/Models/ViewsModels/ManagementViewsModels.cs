namespace lockerSystem.Models.ViewsModels
{
    public class ManagementViewsModels
    {
        public int Id { get; set; }
        public Guid Guid { get; set; } = Guid.NewGuid();
        public bool IsDeleted { get; set; }
        public string name { get; set; }
        public int value { get; set; }
    }
}
