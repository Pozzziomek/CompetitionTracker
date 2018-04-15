using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CompetitionTracker.Models
{
    public class RankingEntryDetails
    {
        [Required]
        public long ContestantId { get; set; }

        [Required]
        public long RouteId { get; set; }
    }
}