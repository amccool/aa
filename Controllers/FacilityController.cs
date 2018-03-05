using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RB.FacilityConfig.Client;

namespace aa.Controllers
{
    [Route("api/[controller]")]
    public class FacilityController : Controller
    {

        [HttpGet("[action]")]
        public async Task<IActionResult> FacilityList()
        {
            IFacilityConfigurationClient fc = new FacilityConfigurationClient(new Uri("http://facilityconfigurationservice.devint.dev-r5ead.net"));

            var facilities = await fc.GetAllFacilities();

            return Ok(facilities);
        }

    }
}
