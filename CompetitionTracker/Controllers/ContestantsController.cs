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
        [HttpPost]
        public IHttpActionResult AddContestant([FromBody] string firstName, string lastName)
        {
            ContestantsSample.AddContestant(firstName, lastName);
            return Ok();
        }

        [HttpGet]
        public IHttpActionResult GetAllContestants()
        {
            return Ok(ContestantsSample.GetAllContestants());
        }

        [HttpGet]
        public IHttpActionResult GetContestant(long id)
        {
            try
            {
                Contestant contestant = ContestantsSample.GetContestant(id);
                return Ok(contestant);
            }
            catch (UserNotFoundException e)
            {
                //TODO: logowanie wyjątków! 
                return NotFound();
            }
        }

        [HttpPut]
        public IHttpActionResult UpdateContestantInfo(long id, string firstName, string lastName)
        {
            try
            {
                Contestant contestant = ContestantsSample.UpdateContestantInfo(id, firstName, lastName);
                return Ok(contestant);
            }
            catch (UserNotFoundException e)
            {
                return NotFound();
            }
        }

        [HttpDelete]
        public IHttpActionResult DeleteContestant(int id)
        {
            try
            {
                ContestantsSample.DeleteContestant(id);
                return Ok();
            }
            catch (UserNotFoundException e)
            {
                return NotFound();
            }
        }
    }
}
