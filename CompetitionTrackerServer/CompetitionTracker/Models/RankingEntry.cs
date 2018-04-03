using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CompetitionTracker.Models
{
    public class RankingEntry
    {
        public long RankingEntryId { get; set; }

        public string ContestantIdentities { get; set; }

        public List<Route> ContestantRoutes { get; set; }

        public int PointsSum { get; set; }
    }
}