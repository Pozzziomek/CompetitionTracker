using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CompetitionTracker.Models
{
    public class RankingEntry
    {
        private static long _nextId = 0;

        public long RankingEntryId { get; }

        [Required(ErrorMessage = "Wybierz zawodnika")]
        public Contestant Contestant { get; set; }

        [Required(ErrorMessage = "Wybierz trasę")]
        public List<string> ContestantRoutes { get; set; } = new List<string>();

        public int PointsSum { get; set; }

        public RankingEntry(Contestant contestant, Route route)
        {
            RankingEntryId = ++_nextId;
            Contestant = contestant;
            ContestantRoutes.Add(route.RouteName);
            PointsSum += route.Points;
        }
    }
}