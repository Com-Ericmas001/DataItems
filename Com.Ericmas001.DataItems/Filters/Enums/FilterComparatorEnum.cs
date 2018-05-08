using Com.Ericmas001.DataItems.Fields;
using Com.Ericmas001.Common.Attributes;

namespace Com.Ericmas001.DataItems.Filters.Enums
{
    public enum FilterComparatorEnum
    {
        [DisplayName("")]
        [FieldType(FieldTypeEnum.None)]
        None,

        [FieldType(FieldTypeEnum.CheckList)]
        [DisplayName("One of Those:")]
        TextEqual,

        [DisplayName("Starting With")]
        [FieldType(FieldTypeEnum.Text)]
        StartsWith,

        [DisplayName("Ending With")]
        [FieldType(FieldTypeEnum.Text)]
        EndsWith,

        [DisplayName("Containing")]
        [FieldType(FieldTypeEnum.Text)]
        Contains,

        [DisplayName("=")]
        IntEqual,

        [DisplayName("≠")]
        IntNotEqual,

        [DisplayName("<")]
        SmallerThan,

        [DisplayName("<=")]
        SmallerEqual,

        [DisplayName(">=")]
        GreaterEqual,

        [DisplayName(">")]
        GreaterThan,

        [FieldType(FieldTypeEnum.IntPair)]
        [DisplayName("Between")]
        IntBetween

    }
}
