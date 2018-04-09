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
        public HttpResponseMessage AddRankingEntry([FromBody]long contestantId, [FromBody]long routeId)
        {
            if (ModelState.IsValid)
            {
                Contestant contestant = ContestantsSample.GetContestant(contestantId);
                Route route = RoutesSample.GetRoute(routeId);
                RankingEntriesSample.AddRankingEntry(contestant, route);
                return new HttpResponseMessage(HttpStatusCode.OK);
            }
            return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
        }

        [HttpGet]
        public HttpResponseMessage GetAllRankingEntries()
        {
            List<RankingEntry> sortedRankingEntries = RankingEntriesSample.GetRankingEntries()
                .OrderByDescending(x => x.PointsSum)
                .ThenBy(y => y.Contestant.LastName)
                .ToList();
            return Request.CreateResponse(HttpStatusCode.OK, sortedRankingEntries);
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
