namespace MVVM.Core.Locators.Helpers.Validators;
/// <summary>
/// Class that validates view types
/// </summary>
public static class ViewValidator
{
    private static Type _viewType;
    static ViewValidator()
    {
        _viewType = typeof(object);
    }
    
    /// <summary>
    /// Method that sets base view type
    /// </summary>
    /// <param name="type">Base view type</param>
    public static void SetViewType(Type type) => 
        _viewType = type;

    /// <summary>
    /// Method that sets base view type
    /// </summary>
    public static void SetViewType<T>() => 
        SetViewType(typeof(T));
    /// <summary>
    /// Method that validates if target is view type
    /// </summary>
    /// <param name="target">Target type</param>
    public static void Validate(Type target) =>
        TypeValidator.Validate(target, _viewType);
}