﻿using System.ComponentModel.DataAnnotations;

namespace HotelManagementProjectfeb.Model.DTO
{
    public class GuestDTO
    {
        [Key]

        public string Guest_id { get; set; }

        public string E_mail { get; set; }

        public string Gender { get; set; }

        public string Address { get; set; }

        public long Phone_number { get; set; }
    }
}
