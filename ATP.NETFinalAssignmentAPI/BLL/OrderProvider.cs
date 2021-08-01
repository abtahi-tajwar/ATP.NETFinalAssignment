using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BEL;
using DAL;
namespace BLL
{
    public class OrderProvider
    {
        public static List<OrderModel> getAll()
        {
            var data = OrderRepo.getAll();
            return AutoMapper.Mapper.Map<List<order>, List<OrderModel>>(data);
        }
        public static OrderDetailsModel get(int id)
        {
            var data = OrderRepo.get(id);
            var order_products = data.order_products;
            List<ProductModel> pr = new List<ProductModel>();
            foreach(var p in order_products)
            {
                pr.Add(AutoMapper.Mapper.Map<product, ProductModel>(p.product));
            }
            OrderDetailsModel odm = new OrderDetailsModel()
            {
                id = data.id,
                created_at = data.created_at,
                status = data.status,
                delivery_charge = data.delivery_charge,
                products = pr
            };
            return odm;
        }
        public static void create(CreateOrderModel create_order)
        {
            var order = AutoMapper.Mapper.Map<CreateOrderModel, order>(create_order);
            int id = OrderRepo.createOrder(order);
            create_order.ordered_products.ForEach(op =>
            {
                order_products order_p = new order_products()
                {
                    order_id = id,
                    product_id = op.id,
                    qty = op.qty
                };
                OrderRepo.addOderProduct(order_p);
            });
        }
    }
}
