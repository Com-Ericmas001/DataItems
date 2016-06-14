using System;
using Com.Ericmas001.DataItems.Filters.Attributes;
using Com.Ericmas001.DataItems.Filters.Enums;

namespace Com.Ericmas001.DataItems.Filters.Comparators
{
    [FilterComparator(FilterComparatorEnum.GreaterEqual)]
    public class GreaterEqualSimpleFilterComparator : ComparableSimpleFilterComparator
    {
        public override bool IsComparableDataFiltered(IComparable comparatorValue, IComparable value, IDataItem item)
        {
            return value.CompareTo(comparatorValue) >= 0;
        }
    }
}
