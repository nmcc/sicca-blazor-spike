using SICCA.Web.Spike.Models;

namespace SICCA.Web.Spike.Services;

public class StationService
{
    public IEnumerable<Station> GetStations()
    {
        yield return new Station(10 , " Monte Abraão");
        yield return new Station(59 , " Mercês");
        yield return new Station(121, " Rio de Mouro");
        yield return new Station(224, " Queluz Belas");
        yield return new Station(260, " Rossio");
        yield return new Station(356, " Amadora");
        yield return new Station(429, " Oeiras");
        yield return new Station(469, " Cascais");
        yield return new Station(525, " Cais do Sodré");
        yield return new Station(621, " Campolide");
        yield return new Station(656, " Benfica");
        yield return new Station(732, " Santa Cruz - Damaia");
        yield return new Station(775, " Reboleira");
        yield return new Station(838, " Algueirão -Mem Martins");
        yield return new Station(897, " Portela de Sintra");
        yield return new Station(957, " Sintra");
        yield return new Station(988, " Algés");
        yield return new Station(105, " Massamá -Barcarena");
        yield return new Station(113, " Agualva -Cacém");
        yield return new Station(122, " Carcavelos");
        yield return new Station(131, " Meleças");
    }
}
