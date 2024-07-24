namespace lockerSystem.Models 
{
    public class BookingLog
    {
        public int Id { get; set; }
        public string bookBy { get; set; }
        public string bookingStatues { get; set; }
        public  DateTime date_time { get; set; }//required هل مهمه 
        public int Booking_Id { get; set; }
        public string modifyBy { get; set; }
        
    }
}
