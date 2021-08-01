using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BEL
{
    public class ProductAddModel
    {
        public int id { get; set; }
        public string name { get; set; }
        public Nullable<int> category_id { get; set; }
        public Nullable<decimal> price { get; set; }
        public Nullable<int> qty { get; set; }
        public string description { get; set; }
        public string image { get; set; }
    }
}
