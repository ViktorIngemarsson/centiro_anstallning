using System;
using System.Collections.Generic;
using System.Text.Json;

namespace centiro_anstallning.Models
{
    public class Order
    {
        public void AddOrderLine(OrderLine order)
        {
            this.OrderLines.Add(order);
        }

        public string PrettyPrint()
        {
            var PrintOptions = new JsonSerializerOptions
            {
                WriteIndented = true
            };
            return JsonSerializer.Serialize(this, PrintOptions);
        }

        public int OrderNumber { get; set; }
        public List<OrderLine> OrderLines { get; set; } = new List<OrderLine>();
    }
}
