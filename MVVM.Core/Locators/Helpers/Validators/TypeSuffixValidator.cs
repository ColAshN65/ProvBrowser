namespace MVVM.Core.Locators.Helpers.Validators;
/// <summary>
/// Class that can validate type suffixes
/// </summary>
public static class TypeSuffixValidator
{
    /// <summary>
    /// Method that checks suffix for null
    /// </summary>
    /// <param name="value">Suffix</param>
    /// <exception cref="ArgumentNullException">Occurs if suffix is null</exception>
    public static void Validate(string value)
    {
        if (string.IsNullOrEmpty(value))
            throw new ArgumentNullException(nameof(value), "Suffix must be not null or empty");
    }
}