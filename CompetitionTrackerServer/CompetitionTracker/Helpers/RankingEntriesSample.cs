using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CompetitionTracker.Exceptions;
using CompetitionTracker.Models;

namespace CompetitionTracker.Helpers
{
    public class RankingEntriesSample
    {
        public static readonly List<RankingEntry> RankingEntries = new List<RankingEntry>()
        {
            new RankingEntry(new Contestant("Marek", "Drozd"), new Route("Trasa A", 50)),
            new RankingEntry(new Contestant("Paulina", "Glik"), new Route("Trasa A", 50)),
            new RankingEntry(new Contestant("Maria", "Janik"), new Route("Trasa C", 150)),
            new RankingEntry(new Contestant("Marcin", "Kot"), new Route("Trasa D", 200)),
            new RankingEntry(new Contestant("Piotr", "Wolski"), new Route("Trasa B", 90)),
            new RankingEntry(new Contestant("Ewa", "Baran"), new Route("Trasa D", 200)),
        };

        public static void AddRankingEntry(Contestant contestant, Route route)
        {
            RankingEntry rankingEntry = FindRankingEntry(contestant.ContestantId, false);
            if (rankingEntry != null)
            {
                rankingEntry.PointsSum += route.Points;
                rankingEntry.ContestantRoutes.Add(route.RouteName);
            }
            else
            {
                rankingEntry = new RankingEntry(contestant, route);
                RankingEntries.Add(rankingEntry);
            }
        }

        public static List<RankingEntry> GetRankingEntries()
        {
            return RankingEntries;
        }

        public static void DeleteRankingEntry(long id)
        {
            RankingEntry rankingEntry = FindRankingEntry(id, true);
            RankingEntries.Remove(rankingEntry);
        }

        private static RankingEntry FindRankingEntry(long id, bool throwIfNotFound)
        {
            RankingEntry rankingEntry = RankingEntries.FirstOrDefault(r => r.RankingEntryId == id);
            if (rankingEntry == null && throwIfNotFound)
            {
                throw new RankingEntryNotFoundException($"Contestant with id {id} in ranking not found!");
            }
            return rankingEntry;
        }
    }
}