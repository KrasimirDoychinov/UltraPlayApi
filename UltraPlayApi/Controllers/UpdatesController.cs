using Microsoft.AspNetCore.Mvc;

using UltraPlayApi.Web.ViewModels.UpdateMessages;
using UltraPlayApi.Services.Implementations;

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
            var messages = this.betUpdateMessageServices.GetAll<BetUpdateMessageViewModel>();

            return this.Ok(messages);
        }

        [HttpGet("odds")]
        public IActionResult GetOddUpdates()
        {
            var messages = this.oddUpdateMessageServices.GetAll<OddUpdateMessageViewModel>();

            return this.Ok(messages);
        }

        [HttpGet("matches")]
        public IActionResult GetMatchUpdates()
        {
            var messages = this.matchUpdateMessageServices.GetAll<MatchUpdateMessageViewModel>();

            return this.Ok(messages);
        }
    }
}
