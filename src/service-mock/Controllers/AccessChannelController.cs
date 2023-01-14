using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using SICCA.Service.Mock.Hubs;
using SICCA.Service.Mock.Models;
using SICCA.Service.Mock.Plugins;
using System.Text.Json;

namespace SICCA.Service.Mock.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccessChannelController : ControllerBase
    {
        private readonly IHubContext<StateUpdateHub> stateUpdateHubContext;
        private readonly PluginStateServer pluginStateServer;

        public AccessChannelController(IHubContext<StateUpdateHub> stateUpdateHubContext, PluginStateServer pluginStateServer)
        {
            this.stateUpdateHubContext = stateUpdateHubContext ?? throw new ArgumentNullException(nameof(stateUpdateHubContext));
            this.pluginStateServer = pluginStateServer ?? throw new ArgumentNullException(nameof(pluginStateServer));
        }
        
        [HttpGet]
        public ActionResult<AccessChannelState> GetState(int id)
        {
            var plugin = this.pluginStateServer.GetPlugin<AccessChannelPlugin>(id);

            if (plugin is null) return NotFound();

            return Ok(plugin.PluginState);
        }

        [HttpPost]
        public ActionResult<AccessChannelState> SetState([FromQuery] int id, [FromQuery] string? mode, [FromQuery] string? direction)
        {
            var plugin = this.pluginStateServer.GetPlugin<AccessChannelPlugin>(id);

            if (plugin is null) return NotFound();

            if (mode is not null)
            {
                plugin.PluginState.Mode = mode;
            }

            if (direction is not null)
            {
                plugin.PluginState.Direction = direction;
            }

            // Publish update message to all clients
            stateUpdateHubContext.Clients.All.SendAsync("AccessChannel", JsonSerializer.Serialize(plugin.PluginState));

            return Ok(plugin.PluginState);
        }
    }
}
