using System;
using System.Collections.Generic;
using TMS.Layer.Extensions;

namespace TMS.Layer.State
{
    public abstract class StateObjectBase<TEntry, TIdentifier> : IIdentifiable<TIdentifier>
        where TEntry : IIdentifiable<TIdentifier> 
        where TIdentifier : class
    {
        static bool _initialised;
        static readonly Dictionary<TIdentifier, Func<TEntry>> _dictionary
            = new Dictionary<TIdentifier, Func<TEntry>>();

        public TIdentifier Identifier { get; }

        protected StateObjectBase(TIdentifier id)
        {
            Identifier = id;
            if (!_initialised)
            {
                _initialised = true;
                InitialiseEntries();
            }
        }

        protected abstract void InitialiseEntries();

        public static TEntry CreateInstance(TIdentifier id)
        {
            Func<TEntry> function;

            if (_dictionary.TryGetValue(id, out function))
                return function.Invoke();

            throw new InvalidOperationException(
                $"No entry found for the given id {id}");
        }

        protected static void AddEntry(TEntry addTagToTagContextType)
            => _dictionary.AddEntry(addTagToTagContextType);

        public bool Equals(IIdentifiable<TIdentifier> other) 
            => other != null && Identifier == other.Identifier;
        public override bool Equals(object obj) 
            => Equals(obj as StateObjectBase<TEntry, TIdentifier>);
        public override int GetHashCode() => Identifier.GetHashCode();
    }
}
