namespace HotelManagementProjectfeb.Model
{
    public class Reservation
    {
        public Guid reservation_code { get; set; }

        public int no_of_adults { get; set; }   

        public int no_of_children { get; set; }

        public  DateTime Check_out { get; set; }
        
        public DateOnly Check_in { get; set; }

        public bool status { get; set; }

        public int no_of_nights { get; set; }

    }
}
