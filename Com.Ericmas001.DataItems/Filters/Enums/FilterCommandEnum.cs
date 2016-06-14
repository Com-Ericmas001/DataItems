using Com.Ericmas001.Common.Attributes;

namespace Com.Ericmas001.DataItems.Filters.Enums
{
    public enum FilterCommandEnum
    {

        [DisplayName("Can Be")]
        Can,

        [DisplayName("Must Be")]
        Must,

        [DisplayName("Must Not Be")]
        MustNot

    }
}
