using STG.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace STG.Api.Controllers
{
    public class GamePlayController : ApiController
    {
        // GET: api/GamePlay
        public Set Get()
        {
            return new Set
            {
                Score = new int[] { 1, 2 },
                EndedAt = DateTime.Now,
                FirstServer = 1
            };
        }

        // GET: api/GamePlay/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/GamePlay
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/GamePlay/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/GamePlay/5
        public void Delete(int id)
        {
        }
    }
}
