namespace Microsoft.AspNetCore.Components;

public static class NavigationManagerExtensions
{
    public static string GetRelativeUri(this NavigationManager navigationManager) 
        => $"/{navigationManager.ToBaseRelativePath(navigationManager.Uri)}";
}
