using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TMS.Layer;
using TMS.Layer.Repositories;

namespace TMS.RepositoryLayer.Repositories
{
    public class ComposedRepository<TModelObject, TModelObjectKey> : IComposedRepository<TModelObject, TModelObjectKey>
    {
        public Maybe<TModelObjectKey> Get(TModelObject key, IObjectComposer<TModelObjectKey> composer)
        {
            
        }
    }
}
