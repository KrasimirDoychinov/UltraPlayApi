using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UltraPlayApi.Services.Implementations;
using UltraPlayApi.Web.Dtos.UpdateMessages;

namespace UltraPlayApi.Web.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UpdatesController : ControllerBase
    {
        private readonly BetUpdateMessageServices betUpdateMessageServices;
        private readonly MatchUpdateMessageServices matchUpdateMessageServices;
        private readonly OddUpdateMessageServices oddUpdateMessageServices;

        public UpdatesController(BetUpdateMessageServices betUpdateMessageServices,
            MatchUpdateMessageServices matchUpdateMessageServices, OddUpdateMessageServices oddUpdateMessageServices)
        {
            this.betUpdateMessageServices = betUpdateMessageServices;
            this.matchUpdateMessageServices = matchUpdateMessageServices;
            this.oddUpdateMessageServices = oddUpdateMessageServices;
        }

        [HttpGet("bets")]
        public IActionResult GetBetUpdates()
        {
            var messages = this.betUpdateMessageServices.GetAll<BetUpdateMessageDto>();

            return this.Ok(messages);
        }

        [HttpGet("odds")]
        public IActionResult GetOddUpdates()
        {
            var messages = this.oddUpdateMessageServices.GetAll<OddUpdateMessageDto>();

            return this.Ok(messages);
        }

        [HttpGet("matches")]
        public IActionResult GetMatchUpdates()
        {
            var messages = this.matchUpdateMessageServices.GetAll<MatchUpdateMessageDto>();

            return this.Ok(messages);
        }
    }
}
