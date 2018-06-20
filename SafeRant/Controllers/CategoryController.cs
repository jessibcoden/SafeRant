using SafeRant.Models;
using SafeRant.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace SafeRant.Controllers
{
    [RoutePrefix("api/categories")]
    public class CategoryController : ApiController
    {

            [Route(""), HttpGet]
            public HttpResponseMessage ListRants()
            {
                var repo = new CategoriesRepository();
                List<Category> rants = repo.GetAll();
                return Request.CreateResponse(HttpStatusCode.OK, rants);
            }

        }
    
}