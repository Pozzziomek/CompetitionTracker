using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CompetitionTracker.Exceptions;
using CompetitionTracker.Helpers;
using CompetitionTracker.Models;

namespace CompetitionTracker.Controllers
{
    public class RoutesController : ApiController
    {
        [HttpOptions]
        public HttpResponseMessage Post(object json)
        {
            return new HttpResponseMessage(HttpStatusCode.OK);
        }

        [HttpPost]
        public HttpResponseMessage AddRoute([FromBody] Route route)
        {
            if (ModelState.IsValid)
            {
                RoutesSample.AddRoute(route.RouteName, route.Points);
                return new HttpResponseMessage(HttpStatusCode.OK);
            }
            return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
        }

        [HttpGet]
        public HttpResponseMessage GetAllRoutes()
        {
            List<Route> sortedRoutes = RoutesSample.GetAllRoutes().OrderBy(r => r.RouteName).ToList();
            return Request.CreateResponse(HttpStatusCode.OK, sortedRoutes);
        }

        [HttpGet]
        public HttpResponseMessage GetRoute(long id)
        {
            try
            {
                Route route = RoutesSample.GetRoute(id);
                return Request.CreateResponse(HttpStatusCode.OK, route);
            }
            catch (RouteNotFoundException e)
            {
                //TODO: logowanie wyjątków! 
                return new HttpResponseMessage(HttpStatusCode.NotFound);
            }
        }

        [HttpPut]
        public HttpResponseMessage UpdateRouteInfo(long id, [FromBody] Route route)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Route updatedRoute = RoutesSample.UpdateRouteInfo(id, route.RouteName, route.Points);
                    return Request.CreateResponse(HttpStatusCode.OK, updatedRoute);
                }
                catch (RouteNotFoundException e)
                {
                    return new HttpResponseMessage(HttpStatusCode.NotFound);
                }
            }
            return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
        }

        [HttpDelete]
        public HttpResponseMessage DeleteRoute(int id)
        {
            try
            {
                RoutesSample.DeleteRoute(id);
                return new HttpResponseMessage(HttpStatusCode.OK);
            }
            catch (RouteNotFoundException e)
            {
                return new HttpResponseMessage(HttpStatusCode.NotFound);
            }
        }
    }
}
