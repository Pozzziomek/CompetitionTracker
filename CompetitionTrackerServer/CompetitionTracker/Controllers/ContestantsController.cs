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
    public class ContestantsController : ApiController
    {

        [HttpOptions]
        public HttpResponseMessage Post(object json)
        {
           return new HttpResponseMessage(HttpStatusCode.OK);
        }

        [HttpPost]
        public HttpResponseMessage AddContestant([FromBody] Contestant contestant)
        {
            if (ModelState.IsValid)
            {
                ContestantsSample.AddContestant(contestant.FirstName, contestant.LastName);
                return new HttpResponseMessage(HttpStatusCode.OK);
            }
            return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
        }

        [HttpGet]
        public HttpResponseMessage GetAllContestants()
        {
            List<Contestant> sortedContestants =
                ContestantsSample.GetAllContestants().OrderBy(c => c.LastName).ToList();
            return Request.CreateResponse(HttpStatusCode.OK, sortedContestants);
        }

        [HttpGet]
        public HttpResponseMessage GetContestant(long id)
        {
            try
            {
                Contestant contestant = ContestantsSample.GetContestant(id);
                return Request.CreateResponse(HttpStatusCode.OK, contestant);
            }
            catch (UserNotFoundException e)
            {
                //TODO: logowanie wyjątków! 
                return new HttpResponseMessage(HttpStatusCode.NotFound);
            }
        }

        [HttpPut]
        public HttpResponseMessage UpdateContestantInfo(long id, [FromBody] Contestant contestant)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Contestant updatedContestant = ContestantsSample.UpdateContestantInfo(id, contestant.FirstName, contestant.LastName);
                    return Request.CreateResponse(HttpStatusCode.OK, updatedContestant);
                }
                catch (UserNotFoundException e)
                {
                    return new HttpResponseMessage(HttpStatusCode.NotFound);
                }
            }
            return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
        }

        [HttpDelete]
        public HttpResponseMessage DeleteContestant(int id)
        {
            try
            {
                ContestantsSample.DeleteContestant(id);
                return new HttpResponseMessage(HttpStatusCode.OK);
            }
            catch (UserNotFoundException e)
            {
                return new HttpResponseMessage(HttpStatusCode.NotFound);
            }
        }
    }
}
