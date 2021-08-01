using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BLL;
using BEL;
using System.Web.Http.Cors;

namespace ATP.NETFinalAssignmentAPI.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class OrderController : ApiController
    {
        [Route("api/Order/getAll")]
        [HttpGet]
        public List<OrderModel> getAll()
        {
            return OrderProvider.getAll();
        }
        [Route("api/Order/{id}")]
        public OrderDetailsModel get(int id)
        {
            return OrderProvider.get(id);
        }
        [Route("api/Order/create")]
        [HttpPost]
        public void create(CreateOrderModel create_order)
        {
            create_order.created_at = DateTime.Now;
            OrderProvider.create(create_order);
        }
    }
}
