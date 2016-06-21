using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using TMS.Layer.Data;
using TMS.Layer.Visitors;

namespace TMS.Database.Converters
{
    public class Visitor<TData> : IVisitor<TData> where TData : IData
    {
        public TData DataObject { get; private set; }
        public List<PropertyInfo> PropertyMappings { get; set; }

        public void Visit(TData data)
        {
            DataObject = data;
            PropertyMappings = data.GetType().GetProperties().ToList();
        }
    }
}
