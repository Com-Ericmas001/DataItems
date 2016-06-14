namespace Com.Ericmas001.DataItems.Fields
{
    public class BaseField : IField
    {
        public object Value { get; set; }

        public override string ToString()
        {
            return Value.ToString();
        }
    }
}
