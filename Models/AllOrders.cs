using System;
using System.Collections.Generic;
using System.Collections;

namespace centiro_anstallning.Models
{
    public class AllOrders
    {
        public List<Order> Orders { get; set; } = new List<Order>();

        public int NumberOrders()
        {
            return this.Orders.Count;
        }

        public void AddOrder(Order OrderToAdd)
        {
            this.Orders.Add(OrderToAdd);
        }
    }
}
