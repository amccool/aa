using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Server.HttpSys;
using RB.FacilityConfig.Client;

namespace aa.Controllers
{
    [Route("api/[controller]")]
    public class FacilityController : Controller
    {
        //[Authorize("policy, olicy1", AuthenticationSchemes.Kerberos, )]
        [HttpGet("[action]")]
        public async Task<IActionResult> FacilityList()
        {
            IFacilityConfigurationClient fc = new FacilityConfigurationClient(new Uri("http://facilityconfigurationservice.devint.dev-r5ead.net"));

            var facilities = await fc.GetAllFacilities();

            return Ok(facilities);
        }

    }
}
