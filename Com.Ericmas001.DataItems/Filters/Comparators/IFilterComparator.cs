namespace Com.Ericmas001.DataItems.Filters.Comparators
{
    public interface IFilterComparator
    {
        string Description { get; }
        bool IsDataFiltered(object comparatorValue, object value, IDataItem item);
    }
}
