using DogHouseApi.Constants;
using DogHouseApi.Models.Config;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace DogHouseApi.Controllers
{
    [ApiController]
    public class AppController : ControllerBase
    {
        #region Properties

        private IConfiguration Configuration { get; }

        #endregion

        #region Constructor

        public AppController(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        #endregion

        #region Get

        [HttpGet]
        [Route(ApiRoutes.Ping)]
        public IActionResult GetPing()
        {
            var appSettings = Configuration.GetSection(ConfigSections.AppVersion).Get<AppSettings>();

            return Ok($"{ApiMessages.PingMessage} {appSettings.Version}");
        }

        #endregion
    }
}