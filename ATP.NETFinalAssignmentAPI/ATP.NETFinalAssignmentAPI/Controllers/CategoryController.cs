using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Threading.Tasks;
using System.Diagnostics;
using BEL;
using BLL;

namespace ATP.NETFinalAssignmentAPI.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class CategoryController : ApiController
    {
        [Route("api/Category/getAll")]
        [HttpGet]
        public List<CategoryModel> getlAll()
        {
            return CategoryProvider.getAll();
        }
        [Route("api/Category/{id}")]
        [HttpGet]
        public CategoryDetailsModel get(int id)
        {
            return CategoryProvider.get(id);
        }
        [Route("api/Category/create")]
        [HttpPost]
        public async Task<HttpResponseMessage> create()
        {
            if (!Request.Content.IsMimeMultipartContent())
            {
                throw new HttpResponseException(HttpStatusCode.UnsupportedMediaType);
            }
            string root = HttpContext.Current.Server.MapPath("~/Uploads/Categories");
            var provider = new MultipartFormDataStreamProvider(root);
            try
            {
                // Read the form data.
                await Request.Content.ReadAsMultipartAsync(provider);
                var Timestamp = new DateTimeOffset(DateTime.UtcNow).ToUnixTimeSeconds();

                var postedFile = HttpContext.Current.Request.Files[0];
                string fileName = Timestamp.ToString() + postedFile.FileName;
                var filePath = HttpContext.Current.Server.MapPath("~/Uploads/Categories/" + fileName);
                
                postedFile.SaveAs(filePath);
                
                
                CategoryModel category = new CategoryModel()
                {
                    name = provider.FormData.Get("name"),
                    image = fileName
                };
                CategoryProvider.create(category);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (System.Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e);
            }
        }
        [Route("api/Category/edit")]
        [HttpPost]
        public async Task<HttpResponseMessage> edit()
        {
            if (!Request.Content.IsMimeMultipartContent())
            {
                throw new HttpResponseException(HttpStatusCode.UnsupportedMediaType);
            }
            string root = HttpContext.Current.Server.MapPath("~/Uploads/Categories");
            var provider = new MultipartFormDataStreamProvider(root);
            try
            {
                // Read the form data.
                await Request.Content.ReadAsMultipartAsync(provider);
                var Timestamp = new DateTimeOffset(DateTime.UtcNow).ToUnixTimeSeconds();

                var postedFile = HttpContext.Current.Request.Files[0];
                string fileName = Timestamp.ToString() + postedFile.FileName;
                var filePath = HttpContext.Current.Server.MapPath("~/Uploads/Categories/" + fileName);

                postedFile.SaveAs(filePath);


                CategoryModel category = new CategoryModel()
                {
                    id = Int32.Parse(provider.FormData.Get("id")),
                    name = provider.FormData.Get("name"),
                    image = fileName
                };
                CategoryProvider.edit(category);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (System.Exception e)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, e);
            }
        }
        [Route("api/Category/delete/{id}")]
        [HttpGet]
        public void delete(int id)
        {
            CategoryProvider.delete(id);
        }
    }
}
