using Microsoft.AspNetCore.Components;
using SICCA.Web.Spike.Models;
using SICCA.Web.Spike.Services;

namespace SICCA.Web.Spike.Pages.Admin;

public class StationConfigBase : ComponentBase
{
    [Inject]
    public StationService StationService { get; set; }

    [Parameter]
    public string StationId { get; set; } = string.Empty;

    protected IEnumerable<Station> Stations { get; set; } = Enumerable.Empty<Station>();

    protected Station? SelectedStation { get; set; }

    protected override Task OnInitializedAsync()
    {
        this.Stations = StationService.GetStations().OrderBy(s => s.Name);

        if (!string.IsNullOrEmpty(StationId) && int.TryParse(StationId, out var stationId))
        {
            SelectedStation = Stations.SingleOrDefault(s => s.Id == stationId);
        }

        return base.OnInitializedAsync();
    }

    //public void SelectStation(Station station) => this.SelectedStation = station;
}
