using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BEL
{
    public class CategoryDetailsModel
    {
        public CategoryDetailsModel()
        {
            this.products = new HashSet<ProductModel>();
        }
        public int id { get; set; }
        public string name { get; set; }
        public string image { get; set; }
        public ICollection<ProductModel> products { get; set; }
    }
}
