using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CompetitionTracker.Exceptions
{
    public class RouteNotFoundException: Exception
    {
        public RouteNotFoundException(string message) : base(message)
        {
        }
    }
}