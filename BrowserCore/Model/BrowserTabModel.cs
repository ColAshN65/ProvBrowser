namespace BrowserCore.Model;

public record BrowserTabModel(Guid Id, string Name, string Url, bool IsFavorite);
