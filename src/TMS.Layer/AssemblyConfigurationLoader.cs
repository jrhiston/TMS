using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace TMS.Layer
{
    public class AssemblyConfigurationLoader
    {
        public static IList<TResolverConfigurationInterface> GetImplementationOfResolverConfigurationInterface<TResolverConfigurationInterface>(IList<string> assembliesToLoad, string assemblyOverrideKey= null)
        {
            try
            {
                IList<string> layerAssemblyFullNames = GetAssemblyConfigurationList(assembliesToLoad, assemblyOverrideKey);

                if (layerAssemblyFullNames.Count < 1)
                {
                    return new List<TResolverConfigurationInterface>();
                }

                IList<TResolverConfigurationInterface> resolverConfigurationInterfaces = new List<TResolverConfigurationInterface>();
                foreach (string assemblyName in layerAssemblyFullNames)
                {
                    Assembly assembly = Assembly.Load(new AssemblyName(assemblyName));
                    Type assemblyConfigurationType = typeof(TResolverConfigurationInterface);
                    Type resolverConfigurationType = assembly.GetTypes().FirstOrDefault(type => assemblyConfigurationType.IsAssignableFrom(type) && type.GetTypeInfo().IsClass && !type.GetTypeInfo().IsAbstract && type.GetTypeInfo().IsPublic);
                    if (resolverConfigurationType != null)
                    {
                        resolverConfigurationInterfaces.Add((TResolverConfigurationInterface)Activator.CreateInstance(resolverConfigurationType));
                    }
                    else
                    {
                        throw new Exception(String.Format("Resolver unable to locate type from assembly", typeof(TResolverConfigurationInterface), assemblyName));
                    }
                }
                return resolverConfigurationInterfaces;
            }
            catch (ReflectionTypeLoadException exception)
            {
                //ApplicationBase.LogError("Error resolving type implementation of interface", exception, LogGroups.LogGroupIdentifierForResolver);
                //if (exception.LoaderExceptions != null)
                //{
                //    foreach (Exception loaderException in exception.LoaderExceptions)
                //    {
                //        if (loaderException != null)
                //        {
                //            ApplicationBase.LogError("Error resolving type implementation of interface", loaderException, LogGroups.LogGroupIdentifierForResolver);
                //        }
                //    }
                //}
                throw exception;
            }
            catch (Exception exception)
            {
                //ApplicationBase.LogError("Error resolving type implementation of interface", exception, LogGroups.LogGroupIdentifierForResolver);
                throw exception;
            }
        }

        /// <summary>
        /// Get the configuration for this resolver.
        /// </summary>
        /// <param name="defaultAssemblyFullNames"></param>
        /// <param name="assemblyConfigurationKey"></param>
        /// <returns></returns>
        protected static IList<string> GetAssemblyConfigurationList(IList<string> defaultAssemblyFullNames, string assemblyConfigurationKey)
        {
            //string assemblyConfigurationValue = ApplicationBase.ApplicationConfiguration.GetValue(assemblyConfigurationKey);
            IList<String> assemblyConfigurationList = new List<string>();
            //if (!String.IsNullOrWhiteSpace(assemblyConfigurationValue))
            //{
            //    String[] assemblyConfigurationValues = assemblyConfigurationValue.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
            //    foreach (String configurationValue in assemblyConfigurationValues)
            //    {
            //        if (!assemblyConfigurationList.Contains(configurationValue))
            //        {
            //            assemblyConfigurationList.Add(configurationValue);
            //        }
            //        //else
            //        //{
            //        //    ApplicationBase.LogWarning("Duplicate assembly configuration", LogGroups.LogGroupIdentifierForResolver);
            //        //}
            //    }
            //}

            if (assemblyConfigurationList.Count < 1)
            {
                assemblyConfigurationList = defaultAssemblyFullNames;
            }
            return assemblyConfigurationList;
        }
    }
}
