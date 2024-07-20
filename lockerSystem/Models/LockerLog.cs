namespace lockerSystem.Models
{
    public class LockerLog
    {
        public int Id { get; set; }
        public string operationType { get; set; }
        public string generatedBy { get; set; }
        public DateTime date_time { get; set; }
        public int Locker_Id { get; set; }
        public string? additionalInfo { get; set; }
    }
}
