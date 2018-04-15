using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CompetitionTracker.Exceptions;
using CompetitionTracker.Models;

namespace CompetitionTracker.Helpers
{
    public static class RankingEntriesSample
    {
        private static readonly List<RankingEntry> RankingEntries = new List<RankingEntry>();

        static RankingEntriesSample()
        {
            List<Contestant> contestants = ContestantsSample.GetAllContestants();
            List<Route> routes = RoutesSample.GetAllRoutes();
            Random r = new Random();
            foreach (Contestant contestant in contestants)
            {
                Route randomRoute = routes[r.Next(routes.Count)];
                RankingEntries.Add(new RankingEntry(contestant, randomRoute));
            }
        }

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

        private static RankingEntry FindRankingEntry(long contestantId, bool throwIfNotFound)
        {
            RankingEntry rankingEntry = RankingEntries.FirstOrDefault(r => r.Contestant.ContestantId == contestantId);
            if (rankingEntry == null && throwIfNotFound)
            {
                throw new RankingEntryNotFoundException($"Contestant with id {contestantId} in ranking not found!");
            }
            return rankingEntry;
        }
    }
}