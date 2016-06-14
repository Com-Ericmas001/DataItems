using Com.Ericmas001.DataItems.Filters.Attributes;
using Com.Ericmas001.DataItems.Filters.Enums;

namespace Com.Ericmas001.DataItems.Filters.Comparators
{
    [FilterComparator(FilterComparatorEnum.Contains)]
    public class ContainsSimpleFilterComparator : SimpleFilterComparator
    {
        public override bool IsDataFiltered(object comparatorValue, object value, IDataItem item)
        {
            return value.ToString().ToLowerInvariant().Contains(comparatorValue.ToString().ToLowerInvariant());
        }
    }
}
