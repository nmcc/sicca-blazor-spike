using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.JSInterop;

namespace SICCA.Web.Spike.Pages.Admin;

public class MapEditorBase : ComponentBase
{
    [Inject] protected IJSRuntime? JSRuntime { get; set; }

    protected IEnumerable<MapElement> Elements { get; init; } = new List<MapElement>
    {
        new("CAEgn01", "/img/ac/operacional_24.png", 155, 194),
        new("CAEgn02", "/img/ac/operacional_24.png", 194, 194),
    };

    protected MapElement? SelectedElement => Elements.FirstOrDefault(s => s.Selected);

    protected MapElement? DraggedElement { get; set; }

    protected void SetDraggedElement(MapElement? element)
    {
        DraggedElement = element;
    }

    protected async Task OnDropElement(DragEventArgs e)
    {
        if (DraggedElement is not null)
        {
            var result = await JSRuntime!.InvokeAsync<BoundingClientRect>("MyDOMGetBoundingClientRect", new object?[] { "map" });

            DraggedElement.PositionX = (int)(e.ClientX - result.Left);
            DraggedElement.PositionY = (int)(e.ClientY - result.Top);
        }
    }

    protected void ToggleSelection(MapElement selectedItem)
    {
        foreach (var element in Elements.Where(item => item != selectedItem))
        {
            element.Selected = false;
        }

        selectedItem.Selected = !selectedItem.Selected;
    }

    protected void ClickOnMap(MouseEventArgs e)
    {
        if (SelectedElement is not null)
        {
            SelectedElement.PositionX = Convert.ToInt32(e.OffsetX);
            SelectedElement.PositionY = Convert.ToInt32(e.OffsetY);
        }
    }
}

public class MapElement
{
    public MapElement(string name, string pathToImage, int positionX, int positionY)
    {
        Name = name ?? throw new ArgumentNullException(nameof(name));
        PathToImage = pathToImage ?? throw new ArgumentNullException(nameof(pathToImage));
        PositionX = positionX;
        PositionY = positionY;
    }

    public string Name { get; set; } = string.Empty;

    public string PathToImage { get; set; } = string.Empty;

    public int PositionX { get; set; }

    public int PositionY { get; set; }

    public bool Selected { get; set; }
}

public class BoundingClientRect
{
    public double X { get; set; }
    public double Y { get; set; }
    public double Width { get; set; }
    public double Height { get; set; }
    public double Top { get; set; }
    public double Right { get; set; }
    public double Bottom { get; set; }
    public double Left { get; set; }
}
