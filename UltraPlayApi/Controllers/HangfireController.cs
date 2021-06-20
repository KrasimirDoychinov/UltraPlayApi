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
        private readonly ISportServices sportServices;
        private readonly IHttpServices httpServices;
        private readonly IXmlServices xmlServices;
        private readonly IEventServices eventServices;
        private readonly IMatchServices matchServices;
        private readonly IBetServices betServices;
        private readonly IOddsServices oddsServices;
        private readonly ApplicationDbContext context;

        public HangfireController(ISportServices sportServices, IHttpServices httpServices, IXmlServices xmlServices,
            IEventServices eventServices, IMatchServices matchServices, IBetServices betServices, IOddsServices oddsServices,
            ApplicationDbContext context)
        {
            this.sportServices = sportServices;
            this.httpServices = httpServices;
            this.xmlServices = xmlServices;
            this.eventServices = eventServices;
            this.matchServices = matchServices;
            this.betServices = betServices;
            this.oddsServices = oddsServices;
            this.context = context;

            ServicePointManager.ServerCertificateValidationCallback = delegate (object sender, X509Certificate certificate,
                X509Chain chain, SslPolicyErrors sslPolicyErrors)
            {
                return true;
            };
        }

        [HttpGet]
        public async Task<OkObjectResult> UpdateJob()
        {
            await DataSeeder.ConsumeXml(this.sportServices, this.httpServices, this.xmlServices, this.eventServices, this.matchServices,
                 this.betServices, this.oddsServices, this.context);
            return Ok("Job updated");
        }

    }
}
