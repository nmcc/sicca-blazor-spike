using Microsoft.AspNetCore.Components;

namespace SICCA.Web.Spike.Pages.Admin;

public class SoftwareUpdatesBase : ComponentBase
{
    protected IList<SoftwareUpdateEntry> Entries = new List<SoftwareUpdateEntry>();

    protected override void OnInitialized()
    {
        base.OnInitialized();

        for (int i = 0; i < 10; ++i)
        {
            Entries.Add(new SoftwareUpdateEntry(i, $"Ficheiro {i}", $"SV{i}.zip", $"v{i}", null, $"/SV/{i}.zip"));
        }
    }
}

public record SoftwareUpdateEntry(
    int Id,
    string Description,
    string FileName,
    string Version,
    DateTime? StartDateTime,
    string FileUrl
    );
