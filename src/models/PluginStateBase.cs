namespace SICCA.Service.Mock.Models;

public abstract class PluginStateBase
{
	public PluginStateBase(int pluginId)
	{
        this.PluginId = pluginId;
    }

    public int PluginId { get; set; }
}
