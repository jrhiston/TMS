using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TMS.Layer.Persistence
{
    public class Writer<T> : IWriter<T>
    {


        public void Save(T objectToSave)
        {
            throw new NotImplementedException();
        }
    }
}
