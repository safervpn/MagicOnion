using System;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;

namespace MagicOnion.Server
{
    internal static class ServiceProviderHelper
    {
        internal static TServiceBase CreateService<TServiceBase, TServiceInterface>(ServiceContext context)
            where TServiceBase : ServiceBase<TServiceInterface>
            where TServiceInterface : IServiceMarker
        {
            var instance = context.ServiceProvider.GetService<TServiceBase>();

                if (instance == null)
                    instance = ActivatorUtilities.CreateInstance<TServiceBase>(context.ServiceProvider);

            instance.Context = context;
            return instance;
        }
    }
}