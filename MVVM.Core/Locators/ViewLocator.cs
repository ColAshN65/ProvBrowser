using MVVM.Core.Locators.Exceptions;
using MVVM.Core.Locators.Helpers.Validators;
using System.Text;

namespace MVVM.Core.Locators;

/// <summary>
/// Class that can locate views by their viewmodel
/// </summary>
public static class ViewLocator
{
    private static LocatorSettings? _settings;

    static ViewLocator()
    {
        UseSettings(LocatorSettings.Default);
    }

    /// <summary>
    /// Method that locates view type by its viewmodel
    /// </summary>
    /// <param name="viewmodelType">Type of the viewmodel</param>
    /// <exception cref="TypeNotFoundException">Occurs if requested type not exists</exception>
    /// <returns>Requested view</returns>
    public static Type Locate(Type viewmodelType)
    {
        ViewModelValidator.Validate(viewmodelType);
        var name = viewmodelType.Name;

        var viewTypeFullname = new StringBuilder();
        viewTypeFullname.Append(_settings.ViewNamespace);
        viewTypeFullname.Append(".");
        var viewName = name.Replace(_settings.ViewModelSuffix, _settings.ViewSuffix);
        viewTypeFullname.Append(viewName);

        var type = _settings.ViewAssembly.GetType(viewTypeFullname.ToString());
        if (type == null)
            throw new TypeNotFoundException("View type not found");
        return type;
    }

    /// <summary>
    /// Method that updates locator's settings
    /// </summary>
    /// <param name="settings">Updated settings</param>
    public static void UseSettings(LocatorSettings settings) => 
        _settings = settings;
}
