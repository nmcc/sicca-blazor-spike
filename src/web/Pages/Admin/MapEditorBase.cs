using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace SICCA.Web.Spike.Pages.Admin;

public class MapEditorBase : ComponentBase
{
    //protected MapElement Element { get; init; } = new("CAEgn01", "/img/ac/operacional_24.png", 155, 194);
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

    protected void OnDropElement(DragEventArgs e)
    {
        if (DraggedElement is not null)
        {
            DraggedElement.PositionX = Convert.ToInt32(e.OffsetX);
            DraggedElement.PositionY = Convert.ToInt32(e.OffsetY);
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
