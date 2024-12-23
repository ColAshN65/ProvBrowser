using MVVM.Core.Locators.Exceptions;
using MVVM.Core.Locators.Helpers.Validators;
using System.Text;

namespace MVVM.Core.Locators;

/// <summary>
/// Class that can locate viewmodels by their view
/// </summary>
public static class ViewModelLocator
{
    private static LocatorSettings _settings;

    static ViewModelLocator()
    {
        UseSettings(LocatorSettings.Default);
    }

    /// <summary>
    /// Method that locates viewmodel type by its view
    /// </summary>
    /// <param name="viewType">Type of the view</param>
    /// <exception cref="TypeNotFoundException">Occurs if requested type not exists</exception>
    /// <returns>Requested viewmodel</returns>
    public static Type Locate(Type viewType)
    {
        ViewValidator.Validate(viewType);
        var name = viewType.Name;

        var viewmodelTypeFullname = new StringBuilder();
        viewmodelTypeFullname.Append(_settings.ViewModelNamespace);
        viewmodelTypeFullname.Append(".");
        var viewmodelName = name.Replace(_settings.ViewSuffix, _settings.ViewModelSuffix);
        viewmodelTypeFullname.Append(viewmodelName);

        var type = _settings.ViewModelAssembly.GetType(viewmodelTypeFullname.ToString());
        if (type == null)
            throw new TypeNotFoundException("Viewmodel type not found");
        return type;
    }

    /// <summary>
    /// Method that updates locator's settings
    /// </summary>
    /// <param name="settings">Updated settings</param>
    public static void UseSettings(LocatorSettings settings) =>
        _settings = settings;
}