using SICCA.Service.Mock.Models;

namespace SICCA.Service.Mock.Plugins;

public abstract class PluginBase
{
    public PluginBase(int pluginId)
    {
        PluginId = pluginId;
    }

    public int PluginId { get; private set; }
}

internal interface IPluginState<TPluginState> where TPluginState : PluginStateBase
{
    public TPluginState PluginState { get; }
}
