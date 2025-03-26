namespace WpfLibrary.Navigation.Helpers.Validators;
/// <summary>
/// Class that validates viewmodel types
/// </summary>
public static class ViewModelValidator
{
    private static Type _viewModelType;

    static ViewModelValidator()
    {
        _viewModelType = typeof(object);
    }
    
    /// <summary>
    /// Method that sets base viewmodel type
    /// </summary>
    /// <param name="type">Base viewmodel type</param>
    public static void SetViewModelType(Type type) =>
        _viewModelType = type;
    /// <summary>
    /// Method that sets base viewmodel type
    /// </summary>
    public static void SetViewModelType<T>() =>
        SetViewModelType(typeof(T));
    /// <summary>
    /// Method that validates if target is viewmodel type
    /// </summary>
    /// <param name="target">Target type</param>
    public static void Validate(Type target) =>
        TypeValidator.Validate(target, _viewModelType);
}