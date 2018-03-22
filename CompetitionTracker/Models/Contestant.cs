using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CompetitionTracker.Models
{
    public class Contestant: Result
    {
        public long ContestantId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        //public Contestant(string firstName, string lastName)
        //{
        //    FirstName = firstName;
        //    LastName = lastName;
        //}
    }    
}