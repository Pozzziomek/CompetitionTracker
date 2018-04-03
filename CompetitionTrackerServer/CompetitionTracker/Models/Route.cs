using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace CompetitionTracker.Models
{
    public class Route
    {
        public long RouteId { get; set; }

        public string RouteName { get; set; }
    }
}