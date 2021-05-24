using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderTrackingService.Entities
{
    public class OrderInfo
    {
        public Guid ID { get; set; }

        public string Price { get; set; }

        public string ProductInfo { get; set; }

        public string ClientInfo { get; set; }
    }
}
