﻿using System.Reflection;

namespace ClangSharp.Pathogen.InfoDumperSupport
{
    internal struct PropertyOrFieldInfo
    {
        private readonly PropertyInfo Property;
        private readonly FieldInfo Field;

        public PropertyOrFieldInfo(PropertyInfo property)
        {
            Property = property;
            Field = null;
        }

        public PropertyOrFieldInfo(FieldInfo field)
        {
            Property = null;
            Field = field;
        }

        public string Name => Property is object ? Property.Name : Field.Name;

        public object GetValue(object obj)
            => Property is object ? Property.GetValue(obj) : Field.GetValue(obj);
    }
}
