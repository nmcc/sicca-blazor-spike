using SICCA.Web.Spike.Models;

namespace SICCA.Web.Spike.Services;

public class StationService
{
    public IEnumerable<Station> GetStations()
    {
        yield return new Station(625, "Campolide");
        yield return new Station(1025, "Monte Abrãao");
    }
}
