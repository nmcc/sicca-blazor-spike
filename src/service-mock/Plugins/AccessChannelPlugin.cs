using SICCA.Service.Mock.Models;

namespace SICCA.Service.Mock.Plugins;

internal class AccessChannelPlugin : PluginBase, IPluginState<AccessChannelState>
{
    public AccessChannelPlugin(int pluginId)
        : base(pluginId)
    {
        this.PluginState = new AccessChannelState(pluginId, mode: "Undefined", direction: "undefined");
    }

    public AccessChannelState PluginState { get; protected set; }

    public void ChangeDirection(string newDirection) => PluginState.Direction = newDirection;
}