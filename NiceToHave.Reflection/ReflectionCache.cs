using PowerExtensions.Pipeline;
using PowerExtensions.Reflection;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;

namespace NiceToHave.Reflection
{
    public class ReflectionCache<TType>
    {
        public IReadOnlyList<PropertyInfo> Properties { get; private set; }

        public IReadOnlyList<FieldInfo> Fields { get; private set; }

        private Type _type;

        public ReflectionCache()
        {
            _type = typeof(TType);

            Properties = new ReadOnlyCollection<PropertyInfo>(_type.GetPropertiesAll().ToList());
            Fields = new ReadOnlyCollection<FieldInfo>(_type.GetFieldsAll().ToList());
        }
    }
}
