namespace TMS.RepositoryLayerInterface
{
    public interface IParameterBuilder<in TData, TDataType>
    {
        void BuildParameters(TData tagFilterData, IParameterCreator<TDataType> parameterCreator);
    }
}