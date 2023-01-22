using Microsoft.AspNetCore.Components;
using SICCA.Web.Spike.Models;

namespace SICCA.Web.Spike.Pages.Admin;

public class CentralConfigBase : ComponentBase
{
    public CentralConfigurationModel? Model { get; set; }

    protected override Task OnInitializedAsync()
    {
        Model = new CentralConfigurationModel
        {
            Central1Ip = "127.0.0.1"
        };

        return base.OnInitializedAsync();
    }
}
