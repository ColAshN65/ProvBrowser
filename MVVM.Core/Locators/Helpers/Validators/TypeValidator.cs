using MVVM.Core.Locators.Exceptions;

namespace MVVM.Core.Locators.Helpers.Validators;

/// <summary>
/// Class that can validate types
/// </summary>
public static class TypeValidator
{
    /// <summary>
    /// Method that checks if type is subclass of targetType
    /// </summary>
    /// <param name="type">Validating type</param>
    /// <param name="targetType">Required type</param>
    /// <exception cref="ArgumentNullException">Occurs if type is null</exception>
    /// <exception cref="InvalidTypeException">Occurs if type isn't subclass of targetType</exception>
    public static void Validate(Type type, Type targetType)
    {
        if (type == null)
            throw new ArgumentNullException(nameof(type), "Type must be not null or empty");
        if (targetType.IsClass && targetType.IsSubclassOf(type))
            throw new InvalidTypeException($"Type must be a subclass of {targetType.Name}");
        if (targetType.IsInterface && type.GetInterface(targetType.Name) != null)
            throw new InvalidTypeException($"Type must implement interface {targetType.Name}");
    }
}
