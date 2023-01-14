using Microsoft.AspNetCore.SignalR.Client;
using SICCA.Service.Mock.Models;
using System.Text.Json;

namespace SICCA.Web.Spike.Services;

internal class PluginStateService : IHostedService
{
    private readonly Dictionary<int, PluginStateBase> pluginStateMap = new();
    private readonly HubConnection hubConnection;
    private readonly ILogger<PluginStateService> logger;

    public PluginStateService(ILogger<PluginStateService> logger)
    {
        this.logger = logger;

        this.hubConnection = new HubConnectionBuilder()
              .WithUrl("http://localhost:5145/StateUpdateHub")
              .Build();
    }

    public event EventHandler StateUpdated;

    public async Task StartAsync(CancellationToken cancellationToken)
    {
        await this.hubConnection.StartAsync(cancellationToken);
        this.hubConnection.On("AccessChannel", (Action<string>)(accessChannelStateJson => UpdateChannelState(accessChannelStateJson)));
    }

    public AccessChannelState? GetAccessChannelState(int id)
        => pluginStateMap.ContainsKey(id) ? (pluginStateMap[id] as AccessChannelState) : null;

    private void UpdateChannelState(string accessChannelStateJson)
    {
        var accessChannelState = JsonSerializer.Deserialize<AccessChannelState>(accessChannelStateJson);

        if (accessChannelState != null)
        {
            pluginStateMap[accessChannelState.PluginId] = accessChannelState;

            // Make a temporary copy of the event to avoid possibility of
            // a race condition if the last subscriber unsubscribes
            // immediately after the null check and before the event is raised.
            var raiseEvent = StateUpdated;

            // Event will be null if there are no subscribers
            if (raiseEvent != null)
            {
                // Call to raise the event.
                raiseEvent(this, new EventArgs());
            }

            logger.LogInformation("Access channel state {0} updated", accessChannelState.PluginId);
        }
    }

    public async Task StopAsync(CancellationToken cancellationToken)
    {
        await this.hubConnection.StopAsync(cancellationToken);
    }
}
