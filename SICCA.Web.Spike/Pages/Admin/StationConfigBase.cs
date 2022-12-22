using Microsoft.AspNetCore.Components;
using SICCA.Web.Spike.Models;
using SICCA.Web.Spike.Services;

namespace SICCA.Web.Spike.Pages.Admin;

public class StationConfigBase : ComponentBase
{
    [Inject]
    public StationService StationService { get; set; }

    protected IEnumerable<Station> Stations { get; set; } = Enumerable.Empty<Station>();

    protected Station SelectedStation { get; set; }

    protected override Task OnInitializedAsync()
    {
        this.Stations = StationService.GetStations();

        return base.OnInitializedAsync();
    }
}
