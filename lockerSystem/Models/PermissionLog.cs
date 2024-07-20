namespace lockerSystem.Models
{
    public class PermissionLog
    {
        public int Id { get; set; }
        public string permissionType { get; set; }
        public string generatedBy { get; set; }
        public string generatedTo { get; set; }
        public DateTime date_time { get; set; }
        public string operationType { get; set; }
        public int Permission_Id { get; set; }
    }
}
