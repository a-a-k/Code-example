using System.Linq;
using System.Web.Http;
using Microsoft.EntityFrameworkCore;

namespace Web.Controllers.Api
{
    [RoutePrefix("api/alerts")]
    public class AlertsApiController : ApiController
    {
        [ReturnShortModel(typeof(UserDTO))]
        [HttpGet]
        [Route("{id}")]
        public AlertDTO Get(string id)
        {
            return new AlertDTO
            {
                Date = "now",
                // ... ,
                Users = db.Users
                    .Select(UserDTOMapping.ToShortDTO)
                    .ToList(),
            };
        }
    }
}