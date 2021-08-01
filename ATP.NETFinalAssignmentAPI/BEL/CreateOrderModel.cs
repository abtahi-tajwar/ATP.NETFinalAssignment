using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BEL
{
    public class OrderProductDetails
    {
        public int id { get; set; }
        public int qty { get; set; }
    }
    public class CreateOrderModel
    {
        public int id { get; set; }
        public System.DateTime created_at { get; set; }
        public int status { get; set; }
        public List<OrderProductDetails> ordered_products { get; set; }
        public int delivery_charge { get; set; }
    }
}
