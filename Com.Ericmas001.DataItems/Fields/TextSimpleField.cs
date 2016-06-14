namespace Com.Ericmas001.DataItems.Fields
{
    [FieldType(FieldTypeEnum.Text)]
    public class TextSimpleField : SimpleField
    {
        public virtual string StringValue { get { return (string)Value; } }
    }
}
