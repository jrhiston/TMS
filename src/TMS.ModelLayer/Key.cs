using System;
using TMS.Layer.ModelObjects;

namespace TMS.ModelLayer
{
    public class Key : IModelKey, IEquatable<Key>
    {
        private readonly long _id;

        public long Identifier => _id;

        public Key(long id)
        {
            _id = id;
        }

        public bool Equals(Key other) => other._id == _id;
    }
}
