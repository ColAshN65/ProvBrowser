using System.Reflection;

namespace WpfLibrary.Navigation.Helpers.Validators;

public static class AssemblyValidator
{
    public static void Validate(Assembly? assembly)
    {
        if (assembly == null)
            throw new ArgumentNullException(nameof(assembly), "Assembly cannot be null");
    }
}