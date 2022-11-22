using BLL;
using BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SOLID_Testing1.Controllers
{
    public class GroupController : ApiController
    {
        [Route("api/groups")]
        [HttpGet]
        public HttpResponseMessage Get()
        {
            var data = GroupService.Get();
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }
        [Route("api/groups/{id}")]
        [HttpGet]
        public HttpResponseMessage Get(int id)
        {
            var data = GroupService.Get(id);
            return Request.CreateResponse(HttpStatusCode.OK, data);
        }
        [Route("api/groups/add")]
        [HttpPost]
        public HttpResponseMessage Post(GroupDTO group)
        {
            if(ModelState.IsValid)
            {
                var data = GroupService.Add(group);
                if (data)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, new { Msg = "Inserted", data = group });
                }
                return Request.CreateResponse(HttpStatusCode.InternalServerError);
            }
            return Request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
        }
    }
}
