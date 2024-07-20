namespace lockerSystem.Models
{
    public class FloorLog
    {
        public int Id { get; set; }
        public string operationType { get; set; }
        public string generatedBy { get; set; }
        public DateTime date_time { get; set; }
        public int Floor_Id { get; set; }
        public string? additionalInfo { get; set; }

       
    }
}
