namespace Com.Ericmas001.DataItems.Fields
{
    [FieldType(FieldTypeEnum.Int)]
    public class IntSimpleField : SimpleField
    {
        public int IntValue { get { return (int)Value; } }
    }
}
