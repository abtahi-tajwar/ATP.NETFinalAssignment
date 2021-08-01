using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BEL
{
    public class ProductModel
    {
        public int id { get; set; }
        public string name { get; set; }
        public int category_id { get; set; }
        public string category_name { get; set; }
        public Nullable<decimal> price { get; set; }
        public Nullable<int> qty { get; set; }
        public string description { get; set; }
        public string image { get; set; }
        public Nullable<System.DateTime> created_at { get; set; }
        public Nullable<System.DateTime> updated_at { get; set; }
        public string created_by { get; set; }
        public string updated_by { get; set; }
        public string deleted_by { get; set; }
    }
}
