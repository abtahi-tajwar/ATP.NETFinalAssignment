using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ProductRepo
    {
        static Entities context;
        static ProductRepo()
        {
            context = new Entities();
        }
        public static List<product> getAll()
        {
            return context.products.ToList();
        }
        public static product get(int id)
        {
            return context.products.FirstOrDefault(pr => pr.id == id);
        }
        public static void create(product p)
        {
            context.products.Add(p);
            context.SaveChanges();
        }
        public static void edit(product p)
        {
            var oldp = context.products.FirstOrDefault(pr => pr.id == p.id);
            context.Entry(oldp).CurrentValues.SetValues(p);
            context.SaveChanges();
        }
        public static void delete(int id)
        {
            var product = context.products.FirstOrDefault(pr => pr.id == id);
            context.products.Remove(product);
            context.SaveChanges();
        }
    }
}
