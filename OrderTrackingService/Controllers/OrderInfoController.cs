using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OrderTrackingService.Data;
using SQLitePCL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OrderTrackingService.Entities;

namespace OrderTrackingService.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class OrderInfoController : Controller
    {
        public DataContext _context { get; }
        public OrderInfoController(DataContext context)
        {
            _context = context;
        }
    }
}
