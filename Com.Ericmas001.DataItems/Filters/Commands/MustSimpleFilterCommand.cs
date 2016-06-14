using Com.Ericmas001.DataItems.Filters.Attributes;
using Com.Ericmas001.DataItems.Filters.Comparators;
using Com.Ericmas001.DataItems.Filters.Enums;

namespace Com.Ericmas001.DataItems.Filters.Commands
{
    [FilterCommand(FilterCommandEnum.Must)]
    public class MustSimpleFilterCommand : SimpleFilterCommand
    {
        public override bool IsDataFiltered(IFilterComparator comparator, object comparatorValue, object value, IDataItem item)
        {
            return comparator.IsDataFiltered(comparatorValue,value,item);
        }
    }
}
