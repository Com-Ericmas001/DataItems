using Com.Ericmas001.DataItems.Fields;
using Com.Ericmas001.DataItems.Filters.Attributes;
using Com.Ericmas001.Common.Attributes;

namespace Com.Ericmas001.DataItems.Filters.Enums
{
    public enum FilterEnum
    {
        None,

        [FilterCommand(FilterCommandEnum.Must, FilterCommandEnum.MustNot)]
        [FilterComparator(FilterComparatorEnum.TextEqual, FilterComparatorEnum.StartsWith, FilterComparatorEnum.Contains, FilterComparatorEnum.EndsWith)]
        [FieldType(FieldTypeEnum.Text)]
        [DisplayName("Filter Text")]
        Text,

        [FilterCommand(FilterCommandEnum.Must, FilterCommandEnum.MustNot)]
        [FilterComparator(FilterComparatorEnum.StartsWith, FilterComparatorEnum.Contains, FilterComparatorEnum.EndsWith)]
        [FieldType(FieldTypeEnum.Text)]
        [DisplayName("Filter Data")]
        Blob,

        [FilterCommand(FilterCommandEnum.Must, FilterCommandEnum.MustNot)]
        [FilterComparator(FilterComparatorEnum.SmallerThan, FilterComparatorEnum.SmallerEqual, FilterComparatorEnum.IntEqual, FilterComparatorEnum.IntNotEqual, FilterComparatorEnum.GreaterEqual, FilterComparatorEnum.GreaterThan, FilterComparatorEnum.IntBetween)]
        [FieldType(FieldTypeEnum.Int)]
        [DisplayName("Filter Int")]
        Int,

        [FilterCommand(FilterCommandEnum.Must)]
        [FilterComparator(FilterComparatorEnum.SmallerThan, FilterComparatorEnum.SmallerEqual, FilterComparatorEnum.IntEqual, FilterComparatorEnum.IntNotEqual, FilterComparatorEnum.GreaterEqual, FilterComparatorEnum.GreaterThan)]
        [FieldType(FieldTypeEnum.Date)]
        [DisplayName("Filter Date")]
        Date,

        [FilterCommand(FilterCommandEnum.Must)]
        [FilterComparator(FilterComparatorEnum.SmallerThan, FilterComparatorEnum.SmallerEqual, FilterComparatorEnum.IntEqual, FilterComparatorEnum.IntNotEqual, FilterComparatorEnum.GreaterEqual, FilterComparatorEnum.GreaterThan)]
        [FieldType(FieldTypeEnum.Time)]
        [DisplayName("Filter Time")]
        Time

    }
}
