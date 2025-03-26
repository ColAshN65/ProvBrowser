namespace ProvBrowser
{
    public interface IAbstractFactory<T>
    {
        T Create();
    }
}