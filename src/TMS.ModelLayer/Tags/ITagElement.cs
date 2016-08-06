using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TMS.Layer.ModelObjects;

namespace TMS.ModelLayer.Tags
{
    public interface ITagElement : IElement<ITagVisitor>
    {
    }
}
