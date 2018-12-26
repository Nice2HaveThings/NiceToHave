using System.Collections.Generic;
using System.Reflection;

namespace NiceToHave.Reflection
{
    public interface IReflectionCache
    {
        IReadOnlyList<FieldInfo> Fields { get; }
        IReadOnlyList<PropertyInfo> Properties { get; }
    }
}