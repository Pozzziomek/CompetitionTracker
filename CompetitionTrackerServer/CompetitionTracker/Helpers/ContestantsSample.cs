using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CompetitionTracker.Exceptions;
using CompetitionTracker.Models;

namespace CompetitionTracker.Helpers
{
    public static class ContestantsSample
    {
        private static readonly List<Contestant> Contestants = new List<Contestant>()
        {
            new Contestant("Adam","Nowak"),
            new Contestant("Jan", "Kowalski"),
            new Contestant("Anna", "Małecka"),
            new Contestant("Karolina", "Kłos"),
            new Contestant("Piotr", "Janicki"),
            new Contestant("Karol", "Nowacki")
        };

        public static void AddContestant(string firstName, string lastName)
        {
            Contestant contestant = new Contestant(firstName, lastName);
            Contestants.Add(contestant);
        }

        public static List<Contestant> GetAllContestants()
        {
            return Contestants;
        }

        public static Contestant GetContestant(long id)
        {
            return FindContestant(id);
        }
       
        public static Contestant UpdateContestantInfo(long id, string firstName, string lastName)
        {
            Contestant contestant = FindContestant(id);
            contestant.FirstName = firstName;
            contestant.LastName = lastName;
            return contestant;
        }

        public static void DeleteContestant(long id)
        {
            Contestant contestant = FindContestant(id);
            Contestants.Remove(contestant);
        }


        private static Contestant FindContestant(long id)
        {
            Contestant contestant = Contestants.FirstOrDefault(c => c.ContestantId == id);
            if (contestant == null)
            {
                throw new UserNotFoundException($"Contestant with id {id} not found!");
            }
            return contestant;
        }
    }
}