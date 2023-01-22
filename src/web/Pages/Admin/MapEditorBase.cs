using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;

namespace SICCA.Web.Spike.Pages.Admin;

public class MapEditorBase : ComponentBase
{
    //protected MapElement Element { get; init; } = new("CAEgn01", "/img/ac/operacional_24.png", 155, 194);
    protected MapElement Element { get; init; } = new("CAEgn01", "/img/ac/operacional_24.png", 0, 0);


    public void OnDrop(DragEventArgs dragEventArgs)
    {
        Element.PositionY = Convert.ToInt32(dragEventArgs.OffsetY);
        Element.PositionX = Convert.ToInt32(dragEventArgs.OffsetX);
    }

    protected void ToggleSelection(string selectedItem)
    {
        Element.Selected = !Element.Selected;
    }

    protected void ClickOnMap(MouseEventArgs e)
    {
        if (Element.Selected)
        {
            Element.PositionY = Convert.ToInt32(e.OffsetY);
            Element.PositionX = Convert.ToInt32(e.OffsetX);
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
