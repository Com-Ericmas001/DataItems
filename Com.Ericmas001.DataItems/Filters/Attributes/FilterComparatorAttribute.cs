using System;
using System.Collections.Generic;
using Com.Ericmas001.DataItems.Filters.Enums;

namespace Com.Ericmas001.DataItems.Filters.Attributes
{
    public class FilterComparatorAttribute : Attribute
    {
        public IEnumerable<FilterComparatorEnum> Comparators { get; private set; }
        public FilterComparatorAttribute(params FilterComparatorEnum[] comparators)
        {
            Comparators = comparators;
        }
    }
}
