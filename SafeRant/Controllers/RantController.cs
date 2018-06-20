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
    [RoutePrefix("api/rants")]
    public class RantController: ApiController
    {
        [Route(""), HttpGet]
            public HttpResponseMessage ListRants()
            {
                var repo = new RantsRepository();
                List<Rant> rants = repo.GetAll();
                return Request.CreateResponse(HttpStatusCode.OK, rants);
            }

            [Route(""), HttpPost]
            public HttpResponseMessage AddRant(AddRantDTO rant)
            {
                var repository = new RantsRepository();
                var result = repository.Create(rant);

                if (result)
                {
                    return Request.CreateResponse(HttpStatusCode.Created);
                }
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Customer could not be created, please try again later.");
            }

            [Route("{Id}"), HttpPut]
            public HttpResponseMessage UpdateRant(Rant rant, int Id)
            {
                rant.Id = Id;
                var repository = new RantsRepository();
                var result = repository.Update(rant);

                if (result)
                {
                    return Request.CreateResponse(HttpStatusCode.OK);
                }
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Could not update rant information, please try again later.");
            }

            [Route("{Id}"), HttpDelete]
            public HttpResponseMessage DeleteRant(int Id)
            {

                var repository = new RantsRepository();
                var result = repository.Delete(Id);

                if (result)
                {
                    return Request.CreateResponse(HttpStatusCode.OK);
                }
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, "Could not delete rant, please try again later.");
            }

            [Route("{Id}"), HttpGet]
            public HttpResponseMessage GetRantById(int Id)
            {
                var repo = new RantsRepository();
                var result = repo.GetRant(Id);

                return Request.CreateResponse(HttpStatusCode.OK, result);
            }
        
    }
}