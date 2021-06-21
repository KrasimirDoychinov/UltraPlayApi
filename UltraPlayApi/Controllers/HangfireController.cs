using Hangfire;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using UltraPlayApi.Data;
using UltraPlayApi.Services.Interfaces;
using UltraPlayApi.Web.Seeder;

namespace UltraPlayApi.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HangfireController : ControllerBase
    {
        private readonly IDataServices dataServices;

        public HangfireController(IDataServices dataServices)
        {
            this.dataServices = dataServices;

            // We use this, because there were exceptions being thrown when trying to access the api.
            ServicePointManager.ServerCertificateValidationCallback = delegate (object sender, X509Certificate certificate,
                X509Chain chain, SslPolicyErrors sslPolicyErrors)
            {
                return true;
            };
        }

        [HttpGet]
        public async Task<OkObjectResult> UpdateJob()
        {
            await this.dataServices.ConsumeXml();
            return Ok("Job updated");
        }

    }
}
