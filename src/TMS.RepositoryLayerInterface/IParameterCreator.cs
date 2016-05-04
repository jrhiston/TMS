namespace TMS.RepositoryLayerInterface
{
    public interface IParameterCreator<T>
    {
        void AddInputParameter(string parameterName, T type, object value);
    }
}
