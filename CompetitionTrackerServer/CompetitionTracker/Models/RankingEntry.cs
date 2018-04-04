using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CompetitionTracker.Models
{
    public class RankingEntry
    {
        private static long _nextId;

        public long RankingEntryId { get; }

        [Required(ErrorMessage = "Wybierz zawodnika")]
        public string ContestantIdentities { get; set; }

        [Required(ErrorMessage = "Wybierz trasę")]
        public List<string> ContestantRoutes { get; set; }

        public int PointsSum { get; set; }

        public RankingEntry(Contestant contestant, Route route)
        {
            RankingEntryId = ++_nextId;
            ContestantIdentities = contestant.FirstName + contestant.LastName;
            ContestantRoutes.Add(route.RouteName);
            PointsSum += route.Points;
        }
    }
}