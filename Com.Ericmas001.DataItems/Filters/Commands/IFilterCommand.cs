using Com.Ericmas001.DataItems.Filters.Comparators;

namespace Com.Ericmas001.DataItems.Filters.Commands
{
    public interface IFilterCommand
    {
        string Description { get; }
        bool IsDataFiltered(IFilterComparator comparator, object comparatorValue, object value, IDataItem item);
    }
}
