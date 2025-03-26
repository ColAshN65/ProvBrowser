using WpfLibrary.Navigation.Default;

namespace WpfLibrary.Navigation.Builders;

public class DefaultNavigationServiceBuilder
{
    public DefaultNavigationServiceBuilder(DynamicNavigationSettings navigationSettings)
    {
        if (navigationSettings is null)
            throw new ArgumentNullException(nameof(navigationSettings));

        this.navigationSettings = navigationSettings;
    }

    public DefaultNavigationServiceBuilder SetNamespaceTransformer(INamespaceTransformer namespaceTransformer)
    {
        this.namespaceTransformer = namespaceTransformer;
        return this;
    }

    public DynamicNavigationService Build()
    {
        if (namespaceTransformer is null)
            namespaceTransformer = new DefaultViewNamespaceTransformer(navigationSettings);
         
        return new DynamicNavigationService(navigationSettings, namespaceTransformer);
    }


    private DynamicNavigationService navigationService;
    private INamespaceTransformer namespaceTransformer;
    private DynamicNavigationSettings navigationSettings;

}
