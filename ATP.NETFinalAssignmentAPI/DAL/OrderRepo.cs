using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class OrderRepo
    {
        public static Entities context;
        static OrderRepo()
        {
            context = new Entities();
        }
        public static List<order> getAll()
        {
            return context.orders.ToList();
        }
        public static order get(int id)
        {
            return context.orders.FirstOrDefault(o => o.id == id);
        }
        public static int createOrder(order o)
        {
            context.orders.Add(o);
            context.SaveChanges();
            return o.id;
        }
        public static void addOderProduct(order_products op)
        {
            context.order_products.Add(op);
            context.SaveChanges();
        }
    }
}
