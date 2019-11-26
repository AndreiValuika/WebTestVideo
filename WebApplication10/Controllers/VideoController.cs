using System;
using System.Collections.Generic;
using System.Web.Http;
using WebApplication10.Models;

namespace WebApplication10.Controllers
{
    [RoutePrefix("api/videos")]
    public class VideoController : ApiController
    {
        [HttpGet, Route("{id}")]
        public IHttpActionResult Get(string id)
        {
            if (string.IsNullOrEmpty(id) || !Guid.TryParse(id, out var _))
            {
                return BadRequest();
            }
            try
            {
                var result = FakeRepository.GetById(id);
                return result == null ? NotFound() : (IHttpActionResult)Ok(result);
            }
            catch (InvalidOperationException ex)
            {

                return InternalServerError(ex);
            }
        }

        [HttpGet, Route("")]
        public IHttpActionResult GetAll([FromUri]Level level = Level.None, string name = "", string author = "")
        {
            Filter filter = new Filter
            {
                Level = level,
                Name = name,
                Author = author 
            };
            IEnumerable<VideoBox> result = FakeRepository.GetAll(filter);
            //or Ok(empty) ?????
           
            return result == null ? NotFound() : (IHttpActionResult)Ok(result);
        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}