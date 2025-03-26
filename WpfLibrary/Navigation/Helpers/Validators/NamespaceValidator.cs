namespace WpfLibrary.Navigation.Helpers.Validators;
/// <summary>
/// Class that can validate namespaces
/// </summary>
public static class NamespaceValidator
{
    /// <summary>
    /// Method that checks namespace for null
    /// </summary>
    /// <param name="value">Namespace</param>
    /// <exception cref="ArgumentNullException">Occurs if namespace is null</exception>
    public static void Validate(string value)
    {
        if (value is null)
            throw new ArgumentNullException(nameof(value), "Namespace must be not null");
    }
}