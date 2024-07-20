namespace lockerSystem.Models
{
    public class LockerStateLog
    {
        public int Id { get; set; }
        public string operationType { get; set; }
        public string generatedBy { get; set; }
        public DateTime date_time { get; set; }
        public int Locker_state_Id { get; set; }
        public string? additionalInfo { get; set; }
    }
}
