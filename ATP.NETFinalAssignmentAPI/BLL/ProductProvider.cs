using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BEL;
using DAL;

namespace BLL
{
    public class ProductProvider
    {
        public static List<ProductModel> getAll()
        {
            var data = ProductRepo.getAll();
            return AutoMapper.Mapper.Map<List<product>, List<ProductModel>>(data);
        }
        public static ProductModel get(int id)
        {
            var data = ProductRepo.get(id);
            return AutoMapper.Mapper.Map<product, ProductModel>(data);
        }
        public static void create(ProductAddModel product)
        {
            var p = AutoMapper.Mapper.Map<ProductAddModel, product>(product);
            ProductRepo.create(p);
        }
        public static void edit(ProductAddModel product)
        {
            var p = AutoMapper.Mapper.Map<ProductAddModel, product>(product);
            ProductRepo.edit(p);
        }
        public static void delete(int id)
        {
            ProductRepo.delete(id);
        }
    }
}
