using Aps.Domain;
using Aps19.Infra.Data.Context;
using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Aps.API.Controllers
{
    [EnableCors(origins:"*",headers:"*",methods:"*")]
    [RoutePrefix("api/v1")]
    public class UsersController : ApiController
    {
        private DataContext db = new DataContext();

        //Get
        [Route("users")]
        public HttpResponseMessage GetUsers()
        {
            var result = db.Users.ToList();
            return Request.CreateResponse(HttpStatusCode.OK,result) ;
        }

        //Post 
        [HttpPost]
        [Route("users")]
        public HttpResponseMessage PostUsers(User user )
        {
            if (user == null)
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            try
            {
                db.Users.Add(user);
                db.SaveChanges();

                var result = user;
                return Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch (Exception)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError,"Falha");
            }
        }
        //Patch
        [HttpPatch]
        [Route("users")]
        public HttpResponseMessage PatchUsers(User user)
        {
            if (user == null)
                return Request.CreateResponse(HttpStatusCode.BadRequest);

            try
            {
                db.Entry<User>(user).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();

                var result = user;
                return Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch(Exception)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "Falha");
            }

        }
        //Put
        [HttpPut]
        [Route("users")]
        public HttpResponseMessage PutUsers(User user)
        {
            if (user == null)
                return Request.CreateResponse(HttpStatusCode.BadRequest);

            try
            {
                db.Entry<User>(user).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();

                var result = user;
                return Request.CreateResponse(HttpStatusCode.OK, result);
            }
            catch (Exception)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, "Falha");
            }
        }
        //Delete
        [HttpDelete]
        [Route("users")]
        public HttpResponseMessage DeleteUsers(int userId)
        {
            if (userId <= 0)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError,"Falha");
            }
            try
            {
                db.Users.Remove(db.Users.Find(userId));
                db.SaveChanges();

                return Request.CreateResponse(HttpStatusCode.OK,"Usuario Excluido");
            }
            catch (Exception)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError,"Falha");
            }
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
        }
    }
}