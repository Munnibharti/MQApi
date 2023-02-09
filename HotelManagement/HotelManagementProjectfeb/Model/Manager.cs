namespace HotelManagementProjectfeb.Model
{
    public class Manager
    {
        public Guid manager_id { get; set; }

        public string manager_name { get; set; }

        public string address { get; set; }

        public double salary { get; set; }

        public Guid department_id { get; set; }

        public Department Department { get; set; }
        
        public Guid Room_id { get; set; }

        //navigation property
        public List<Room> Rooms { get; set; }

        public Guid Receptionist_id { get; set; }

        public List<Receptionist> Receptionist { get; set; }

    }
}
