using WpfLibrary.Navigation.Default;

namespace WpfLibrary.Navigation.Helpers.Validators;
/// <summary>
/// Class that can validates settings
/// </summary>
public static class SettingsValidator
{
    /// <summary>
    /// Method that validates settings
    /// </summary>
    /// <param name="settings">Settings</param>
    /// <exception cref="ArgumentNullException">Occurs if settings object is null</exception>
    public static void Validate(DynamicNavigationSettings settings)
    {
        if (settings == null)
            throw new ArgumentNullException(nameof(settings), "Locator settings must be not null");
        NamespaceValidator.Validate(settings.ViewModelNamespace);
        NamespaceValidator.Validate(settings.ViewNamespace);    
        TypeSuffixValidator.Validate(settings.ViewModelSuffix);
        TypeSuffixValidator.Validate(settings.ViewSuffix);
        AssemblyValidator.Validate(settings.ViewAssembly);
        AssemblyValidator.Validate(settings.ViewModelAssembly);
    }
}