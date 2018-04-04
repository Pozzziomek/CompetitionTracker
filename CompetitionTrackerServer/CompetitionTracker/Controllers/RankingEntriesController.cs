using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CompetitionTracker.Exceptions;
using CompetitionTracker.Helpers;
using CompetitionTracker.Models;

namespace CompetitionTracker.Controllers
{
    public class RankingEntriesController : ApiController
    {
        [HttpOptions]
        public HttpResponseMessage Post(object json)
        {
            return new HttpResponseMessage(HttpStatusCode.OK);
        }

        [HttpPost]
        public HttpResponseMessage AddRankingEntry([FromBody] Contestant contestant, [FromBody] Route route)
        {
            if (ModelState.IsValid)
            {
                RankingEntriesSample.AddRankingEntry(contestant, route);
                return new HttpResponseMessage(HttpStatusCode.OK);
            }
            return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
        }

        [HttpGet]
        public HttpResponseMessage GetAllRankingEntries()
        {
            return Request.CreateResponse(HttpStatusCode.OK, RankingEntriesSample.GetRankingEntries());
        }

        [HttpDelete]
        public HttpResponseMessage DeleteRankingEntry(long id)
        {
            try
            {
                RankingEntriesSample.DeleteRankingEntry(id);
                return new HttpResponseMessage(HttpStatusCode.OK);
            }
            catch (RankingEntryNotFoundException e)
            {
                return new HttpResponseMessage(HttpStatusCode.NotFound);
            }
        }
    }
}
