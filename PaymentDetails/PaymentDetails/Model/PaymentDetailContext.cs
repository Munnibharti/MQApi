﻿using Microsoft.EntityFrameworkCore;

namespace PaymentDetails.Model
{
    public class PaymentDetailContext:DbContext

    {
        public PaymentDetailContext(DbContextOptions<PaymentDetailContext> options):base(options)
        {


        }
        public DbSet<PaymentDetail> PaymentDetails { get; set; }

    }
}
