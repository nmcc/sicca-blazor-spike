using SICCA.Service.Mock.Models;
using SICCA.Service.Mock.Plugins;

namespace SICCA.Service.Mock;

public class PluginStateServer
{
    private readonly Dictionary<int, PluginBase> plugins = new()
    {
        { 1, new AccessChannelPlugin(1) }
    };

    public TPlugin? GetPlugin<TPlugin>(int id) where TPlugin : PluginBase
        => plugins.ContainsKey(id) ? (plugins[id] as TPlugin) : null;
}

