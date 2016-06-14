using System;

namespace Com.Ericmas001.DataItems.Fields
{
    [FieldType(FieldTypeEnum.Guid)]
    public class GuidSimpleField : SimpleField
    {
        public Guid GuidValue { get { return (Guid)Value; } }
    }
}
