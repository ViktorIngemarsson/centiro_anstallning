using System;
namespace centiro_anstallning.Models
{
    public class OrderLine
    {
        public int OrderNumber{ get; set; }

        public int OrderLineN { get; set; }

        public string ProductNumber { get; set; }

        public int Quantity { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public double Price { get; set; }

        public string ProductGroup { get; set; }

        public DateTime OrderDate { get; set; }

        public string CustomerName { get; set; }

        public int CustomerNumber { get; set; }

    }
}
