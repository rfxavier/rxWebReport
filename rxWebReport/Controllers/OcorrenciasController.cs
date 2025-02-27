using rxWebReport.Domain.Entities;
using rxWebReport.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Web.Http;

namespace rxWebReport.Controllers
{
    [RoutePrefix("api/ocorrencias")]
    public class OcorrenciasController : ApiController
    {
        private ApplicationDbContext db;

        public OcorrenciasController()
        {
            db = new ApplicationDbContext();
        }

        public class OcorrenciasRequest
        {
            public string cofre_id { get; set; }
            public DateTime data_inicio { get; set; }
            public DateTime data_fim { get; set; }
        }

        public class OcorrenciasResponse
        {
            public List<GetLockMessageView> ocorrencias { get; set; }
        }

        // GET api/<controller>
        //[HttpGet]
        //[Route("")]
        //public IEnumerable<string> Get()
        //{
        //    var identity = (ClaimsIdentity)User.Identity;
        //    var cofres = identity.Claims.FirstOrDefault(c => c.Type == "Cofres").Value;
        //    return new string[] { "value1", "value2" }; 
        //}

        // GET api/<controller>/5
        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST api/<controller>
        [HttpPost]
        [Route("")]
        public HttpResponseMessage Post([FromBody] OcorrenciasRequest ocorrenciasRequest)
        {
            var identity = (ClaimsIdentity)User.Identity;
            var cofres = identity.Claims.FirstOrDefault(c => c.Type == "Cofres").Value;

            var ret = new OcorrenciasResponse();

            if (!cofres.Split(',').Contains(ocorrenciasRequest.cofre_id))
            {
                var log = new GetLockApiLog() { 
                    ApiName = "ocorrencias",
                    UserName = identity.Name,
                    CofreId = ocorrenciasRequest.cofre_id,
                    DataInicio = ocorrenciasRequest.data_inicio,
                    DataFim = ocorrenciasRequest.data_fim,
                    Error = true,
                    Response = $"401 Unauthorized",
                    TrackCreationTime = DateTime.Now,
                    TrackLastWriteTime = DateTime.Now
                };

                db.GetLockApiLogs.Add(log);
                db.SaveChanges();

                return Request.CreateResponse(HttpStatusCode.Unauthorized);
            } else
            {
                var hours = (ocorrenciasRequest.data_fim - ocorrenciasRequest.data_inicio).TotalHours;

                if (hours > 168) // 7 dias
                {
                    var log = new GetLockApiLog()
                    {
                        ApiName = "ocorrencias",
                        UserName = identity.Name,
                        CofreId = ocorrenciasRequest.cofre_id,
                        DataInicio = ocorrenciasRequest.data_inicio,
                        DataFim = ocorrenciasRequest.data_fim,
                        Error = true,
                        Response = $"400 Bad Request",
                        TrackCreationTime = DateTime.Now,
                        TrackLastWriteTime = DateTime.Now
                    };

                    db.GetLockApiLogs.Add(log);
                    db.SaveChanges();

                    return Request.CreateResponse(HttpStatusCode.BadRequest, "Período maior que 7 dias");
                } else
                {
                    ret.ocorrencias = new List<GetLockMessageView>();

                    var ds = db.GetLockMessageViews.AsNoTracking().Where(m => m.id_cofre == ocorrenciasRequest.cofre_id && m.data_tmst_end_datetime >= ocorrenciasRequest.data_inicio && m.data_tmst_end_datetime <= ocorrenciasRequest.data_fim).ToList();

                    var log = new GetLockApiLog()
                    {
                        ApiName = "ocorrencias",
                        UserName = identity.Name,
                        CofreId = ocorrenciasRequest.cofre_id,
                        DataInicio = ocorrenciasRequest.data_inicio,
                        DataFim = ocorrenciasRequest.data_fim,
                        Error = false,
                        Response = $"200 OK",
                        TrackCreationTime = DateTime.Now,
                        TrackLastWriteTime = DateTime.Now
                    };

                    db.GetLockApiLogs.Add(log);
                    db.SaveChanges();

                    ret.ocorrencias = ds;

                    return Request.CreateResponse(HttpStatusCode.Created, ret);
                }
            }
        }

        // PUT api/<controller>/5
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        // DELETE api/<controller>/5
        //public void Delete(int id)
        //{
        //}
    }
}