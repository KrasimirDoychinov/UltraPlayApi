using Microsoft.AspNetCore.Mvc;

using System.Net;
using System.Net.Security;
using System.Threading.Tasks;
using System.Security.Cryptography.X509Certificates;

using UltraPlayApi.Services.Interfaces;

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
