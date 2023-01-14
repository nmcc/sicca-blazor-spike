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

    public async Task StartAsync(CancellationToken cancellationToken)
    {
        await this.hubConnection.StartAsync(cancellationToken);
        this.hubConnection.On("AccessChannel", (Action<string>)(accessChannelStateJson => UpdateChannelState(accessChannelStateJson)));
    }

    private void UpdateChannelState(string accessChannelStateJson)
    {
        var accessChannelState = JsonSerializer.Deserialize<AccessChannelState>(accessChannelStateJson);

        if (accessChannelState != null)
        {
            pluginStateMap[accessChannelState.PluginId] = accessChannelState;

            logger.LogInformation("Access channel state {0} updated", accessChannelState.PluginId);
        }
    }

    public async Task StopAsync(CancellationToken cancellationToken)
    {
        await this.hubConnection.StopAsync(cancellationToken);
    }
}
