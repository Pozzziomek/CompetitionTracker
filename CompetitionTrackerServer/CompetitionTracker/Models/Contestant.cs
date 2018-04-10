using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CompetitionTracker.Models
{
    public class Contestant
    {
        private static long _nextId = 0;

        public long ContestantId { get; }

        [Required(ErrorMessage = "Imię jest wymagane")]
        [StringLength(40, MinimumLength = 3, ErrorMessage = "Imię musi zawierać od 3 do 40 znaków.")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Nazwisko jest wymagane")]
        [StringLength(40, MinimumLength = 3, ErrorMessage = "Nazwisko musi zawierać od 3 do 40 znaków.")]
        public string LastName { get; set; }

        public Contestant(string firstName, string lastName)
        {
            ContestantId = ++_nextId;
            FirstName = firstName;
            LastName = lastName;
        }
    }    
}