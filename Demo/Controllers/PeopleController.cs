using Demo.DataSource;
using Demo.Models;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.OData;
using System.Web.OData.Routing;

namespace Demo.Controllers
{
    [EnableQuery]
    public class PeopleController : ODataController
    {
        [HttpGet]
        public IHttpActionResult Get()
        {
            return Ok(DemoDataSources.Instance.People.AsQueryable());
        }

        [HttpPost]
        public IHttpActionResult AddPerson([FromODataUri] string key, ODataActionParameters parameters)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            string description = (string)parameters["Description"];
            string name = (string)parameters["Name"];
            string tripName = (string)parameters["TripName"];

            DemoDataSources.Instance.People.Add(new Person
            {
                 ID = key,
                 Description = description,
                 Name = name,
                 Trips = new System.Collections.Generic.List<Trip>() { new Trip() { ID = key + "Trip", Name = tripName }  }
            });

            return StatusCode(HttpStatusCode.NoContent);
        }

        [HttpGet]
        [ODataRoute("GetNewPerson(Key={key})")]
        public IHttpActionResult GetNewPerson([FromODataUri] string key)
        {
            return Ok(DemoDataSources.Instance.People.AsQueryable().Where(w => w.ID == key).FirstOrDefault());
        }
    }
}