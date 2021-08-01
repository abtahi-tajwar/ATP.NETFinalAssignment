using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BEL
{
    public class OrderModel
    {
        public int id { get; set; }
        public System.DateTime created_at { get; set; }
        public int status { get; set; }
        public int amount { get; set; }
    }
}
