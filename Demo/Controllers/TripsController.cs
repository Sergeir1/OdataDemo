﻿using Demo.DataSource;
using System.Linq;
using System.Web.Http;
using System.Web.OData;
namespace Demo.Controllers
{
    [EnableQuery]
    public class TripsController : ODataController
    {
        public IHttpActionResult Get()
        {
            return Ok(DemoDataSources.Instance.Trips.AsQueryable());
        }
    }
}