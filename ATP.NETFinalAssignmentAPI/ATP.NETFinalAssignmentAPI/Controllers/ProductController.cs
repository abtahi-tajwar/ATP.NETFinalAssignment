using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;
using BEL;
using BLL;

namespace ATP.NETFinalAssignmentAPI.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class ProductController : ApiController
    {
        [Route("api/Product/getAll")]
        [HttpGet]
        public List<ProductModel> getlAll()
        {
            return ProductProvider.getAll();
        }
        [Route("api/Product/{id}")]
        [HttpGet]
        public ProductModel get(int id)
        {
            return ProductProvider.get(id);
        }
        [Route("api/Product/create")]
        [HttpPost]
        public async Task<HttpResponseMessage> create()
        {
            if (!Request.Content.IsMimeMultipartContent())
            {
                throw new HttpResponseException(HttpStatusCode.UnsupportedMediaType);
            }
            string root = HttpContext.Current.Server.MapPath("~/Uploads/Products");
            var provider = new MultipartFormDataStreamProvider(root);
            try
            {
                // Read the form data.
                await Request.Content.ReadAsMultipartAsync(provider);
                var Timestamp = new DateTimeOffset(DateTime.UtcNow).ToUnixTimeSeconds();

                var postedFile = HttpContext.Current.Request.Files[0];
                string fileName = Timestamp.ToString() + postedFile.FileName;
                var filePath = HttpContext.Current.Server.MapPath("~/Uploads/Products/" + fileName);

                postedFile.SaveAs(filePath);


                ProductAddModel product = new ProductAddModel()
                {
                    name = provider.FormData.Get("name"),
                    category_id = Int32.Parse(provider.FormData.Get("category_id")),
                    price = Int32.Parse(provider.FormData.Get("price")),
                    qty = Int32.Parse(provider.FormData.Get("qty")),
                    description = provider.FormData.Get("description"),
                    image = fileName
                };

                ProductProvider.create(product);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (System.Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e);
            }
            
        }
        [Route("api/Product/edit")]
        [HttpPost]
        public async Task<HttpResponseMessage> edit()
        {
            if (!Request.Content.IsMimeMultipartContent())
            {
                throw new HttpResponseException(HttpStatusCode.UnsupportedMediaType);
            }
            string root = HttpContext.Current.Server.MapPath("~/Uploads/Products");
            var provider = new MultipartFormDataStreamProvider(root);
            try
            {
                // Read the form data.
                await Request.Content.ReadAsMultipartAsync(provider);
                var Timestamp = new DateTimeOffset(DateTime.UtcNow).ToUnixTimeSeconds();

                var postedFile = HttpContext.Current.Request.Files[0];
                string fileName = Timestamp.ToString() + postedFile.FileName;
                var filePath = HttpContext.Current.Server.MapPath("~/Uploads/Products/" + fileName);

                postedFile.SaveAs(filePath);


                ProductAddModel product = new ProductAddModel()
                {
                    id = Int32.Parse(provider.FormData.Get("id")),
                    name = provider.FormData.Get("name"),
                    category_id = Int32.Parse(provider.FormData.Get("category_id")),
                    price = Int32.Parse(provider.FormData.Get("price")),
                    qty = Int32.Parse(provider.FormData.Get("qty")),
                    description = provider.FormData.Get("description"),
                    image = fileName
                };

                ProductProvider.edit(product);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (System.Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e);
            }
        }
        [Route("api/Product/delete/{id}")]
        [HttpGet]
        public void delete(int id)
        {
            ProductProvider.delete(id);
        }

    }
}
