using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BEL
{
    public class OrderDetailsModel
    {
        public int id { get; set; }
        public System.DateTime created_at { get; set; }
        public int status { get; set; }
        public List<ProductModel> products { get; set; }
        public Nullable<int> delivery_charge { get; set; }
    }
}
