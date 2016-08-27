using System;
using System.Collections.Generic;

namespace TMS.Layer.Extensions
{
    /// <summary>
    /// Extensions for dictionaries.
    /// </summary>
    public static class DictionaryExtensions
    {
        /// <summary>
        /// Add a dictionary entry to the given list of instances. This will automatically add the entity using the identifier of the <see cref="IIdentifiable{T}"/> object given.
        /// </summary>
        /// <typeparam name="T">The type of objec to add. This must be of type <see cref="IIdentifiable{T}"/>.</typeparam>
        /// <typeparam name="R">The type of the identifier.</typeparam>
        /// <param name="instances">The dictionary to add to.</param>
        /// <param name="entry">The entry to add</param>
        public static void AddEntry<T, R>(
            this Dictionary<R, Func<T>> instances,
            T entry) where T : IIdentifiable<R>
            => instances.Add(entry.Identifier, () => entry) ;
    }
}
