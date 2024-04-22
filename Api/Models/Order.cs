﻿namespace Api.Models
{
    public class Order
    {
        public int OrderId { get; set; }

        public string CompanyName { get; set; }

        public string Description { get; set; }

        public decimal OrderTotal { get; set; }

        public IEnumerable<OrderProduct> OrderProducts { get; set; }
    }
}
