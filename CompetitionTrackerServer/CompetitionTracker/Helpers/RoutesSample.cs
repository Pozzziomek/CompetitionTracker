using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CompetitionTracker.Exceptions;
using CompetitionTracker.Models;

namespace CompetitionTracker.Helpers
{
    public static class RoutesSample
    {
        public static readonly List<Route> Routes = new List<Route>()
        {
            new Route("Bardzo łatwa", 10),
            new Route("Łatwa", 30),
            new Route("Średniej trudności", 50),
            new Route("Trudna", 70),
            new Route("Bardzo trudna", 100)
        };

        public static void AddRoute(string routeName, int points)
        {
            Route route = new Route(routeName, points);
            Routes.Add(route);
        }

        public static List<Route> GetAllRoutes()
        {
            return Routes;
        }

        public static Route GetRoute(long id)
        {
            return FindRoute(id);
        }

        public static Route UpdateRouteInfo(long id, string routeName, int points)
        {
            Route route = FindRoute(id);
            route.RouteName = routeName;
            route.Points = points;
            return route;
        }

        public static void DeleteRoute(long id)
        {
            Route route = FindRoute(id);
            Routes.Remove(route);
        }


        private static Route FindRoute(long id)
        {
            Route route = Routes.FirstOrDefault(r => r.RouteId == id);
            if (route == null)
            {
                throw new UserNotFoundException($"Route with id {id} not found!");
            }
            return route;
        }
    }
}