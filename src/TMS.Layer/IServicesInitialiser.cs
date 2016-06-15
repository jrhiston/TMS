using Microsoft.Extensions.DependencyInjection;

namespace TMS.Layer
{
    public interface IServicesInitialiser<TData> where TData : IServiceInitialiserDataProvider
    {
        void Initialise(IServiceCollection servicesCollection, TData serviceDataProvider);
    }
}
