using MapsAppWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MapsAppWeb.Controllers
{
    [RoutePrefix("api")]
    public class MapsController : ApiController
    {
        [Route("GetMapaCentro")]
        [HttpGet]
        public Coord GetMapaCentro()
        {
            return new Coord{ Lat = -37.0638296, Lng = -61.9403603 };
        }


        [Route("GetMarkers")]
        [HttpGet]
        public List<Coord> GetMarkers()
        {
            List<Coord> markers = new List<Coord>
            {
                new Coord{ Lat=-37.064604, Lng=-61.948729, Message="mark1" },
                new Coord{ Lat=-37.067934, Lng=-61.942677, Message="mark2" },
                new Coord{ Lat=-37.064218, Lng=-61.944437, Message="mark3" }
            };

            return markers;
        }
    }
}
