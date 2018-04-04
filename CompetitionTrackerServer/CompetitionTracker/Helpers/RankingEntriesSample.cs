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
            
        };

        public static void AddRankingEntry(Contestant contestant, Route route)
        {
            RankingEntry rankingEntry = new RankingEntry(contestant, route);
            RankingEntries.Add(rankingEntry);
        }

        public static List<RankingEntry> GetRankingEntries()
        {
            return RankingEntries;
        }

        public static void DeleteRankingEntry(long id)
        {
            RankingEntry rankingEntry = FindRankingEntry(id);
            RankingEntries.Remove(rankingEntry);
        }

        private static RankingEntry FindRankingEntry(long id)
        {
            RankingEntry rankingEntry = RankingEntries.FirstOrDefault(r => r.RankingEntryId == id);
            if (rankingEntry == null)
            {
                throw new RankingEntryNotFoundException($"Contestant with id {id} in ranking not found!");
            }
            return rankingEntry;
        }
    }
}