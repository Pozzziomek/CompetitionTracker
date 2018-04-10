using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace CompetitionTracker.Models
{
    public class Route
    {
        private static long _nextId = 0;

        public long RouteId { get; }

        [Required(ErrorMessage = "Nazwa trasy jest wymagana.")]
        [MaxLength(100, ErrorMessage = "Nazwa trasy nie może być dłuższa niż 100 znaków.")]
        public string RouteName { get; set; }

        [Required(ErrorMessage = "Liczba punktów dla danej trasy jest wymagana.")]
        [Range(10, 1000, ErrorMessage = "Liczba punktów powinna obejmować zakres 10-1000.")]
        public int Points { get; set; }

        public Route(string routeName, int points)
        {
            RouteId = ++_nextId;
            RouteName = routeName;
            Points = points;
        }
    }
}