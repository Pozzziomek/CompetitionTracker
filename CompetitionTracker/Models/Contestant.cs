using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CompetitionTracker.Models
{
    public class Contestant
    {
        private static long _nextId;

        public long ContestantId { get; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public Contestant(string firstName, string lastName)
        {
            //if (String.IsNullOrEmpty(firstName))
            //{
            //    throw new ArgumentException("FirstName must be specified");
            //}
            //if (String.IsNullOrEmpty(lastName))
            //{
            //    throw new ArgumentException("LastName must be specified");
            //}
            ContestantId = ++_nextId;
            FirstName = firstName;
            LastName = lastName;
        }
    }    
}