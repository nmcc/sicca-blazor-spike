namespace SICCA.Service.Mock.Models;

public class AccessChannelState : PluginStateBase
{
    public AccessChannelState(int pluginId, string mode, string direction)
        : base(pluginId)
    {
        this.Mode = mode;
        this.Direction = direction;
    }

    public string Mode { get; set; }
    
    public string Direction { get; set; }
}
