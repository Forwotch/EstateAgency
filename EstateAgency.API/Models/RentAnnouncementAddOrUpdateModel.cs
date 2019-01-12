﻿using System;

namespace EstateAgency.API.Models
{
    public class RentAnnouncementAddOrUpdateModel
    {
        public int ApartmentId { get; set; }
        public int OwnerId { get; set; }

        public decimal Rent { get; set; }
        public int TermInDays { get; set; }
    }
}