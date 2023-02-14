﻿using HotelManagementProjectfeb.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace HotelManagementProjectfeb.Controllers
{
    [ApiController]
    [Route("Bill")]
    public class BillController : Controller
    {
        private readonly IBillRepository _billRepository;

        public BillController(IBillRepository billRepository)
        {
            _billRepository = billRepository;   
        }
    }
}
