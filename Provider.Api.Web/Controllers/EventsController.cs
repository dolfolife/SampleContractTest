using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Provider.Api.Web.Controllers
{
    public class EventsController : ApiController
    {
        [Route("events")]
        public EventsResponse Get()
        {
            return new EventsResponse(new string[] { "event1", "event2" });
        }
    }
    public class EventsResponse
    {
        public IEnumerable<string> events;

        public EventsResponse(IEnumerable<string> events)
        {
            this.events = events;
        }
    }
}