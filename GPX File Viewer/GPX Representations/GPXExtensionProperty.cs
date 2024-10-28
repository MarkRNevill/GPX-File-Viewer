using System;

namespace GPX_File_Viewer.GPX_Representations
{
    public sealed class GPXExtensionProperty
    {
        private PropertyTypeEnumeration _propertyType;

        public GPXExtensionProperty(string PropertyName, PropertyTypeEnumeration PropertyType, string PropertyValue)
        {
            Name = PropertyName;
            _propertyType = PropertyType;
            Value = PropertyValue;
        }

        public string Name { get; }
        public string Value { get; }
    }
}
