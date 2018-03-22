using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CompetitionTracker.Models;

namespace CompetitionTracker.Controllers
{
    public class ContestantsController : ApiController
    {
        Contestant[] contestants =
        {
            new Contestant { ContestantId = 1, FirstName = "Adam", LastName = "Nowak"},
            new Contestant { ContestantId = 2, FirstName = "Jan", LastName = "Kowalski"},
            new Contestant { ContestantId = 3, FirstName = "Anna", LastName = "Małecka"}
        };
        [HttpGet, ActionName("GetAllContestant")]
        public HttpResponseMessage GetAllContestants()
        {
            Result result;
            try
            {
                var contestantsList = contestants.ToList();
                if(contestantsList.Lenght) 
            }

        }

        public IHttpActionResult GetContestant(int id)
        {
            Contestant contestant = contestants.FirstOrDefault(c => c.ContestantId == id);
            if (contestant == null)
            {
                return NotFound();
            }
            return Ok(contestant);
        }
    }
}
}
