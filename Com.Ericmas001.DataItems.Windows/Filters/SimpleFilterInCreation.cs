﻿using System;
using System.Collections.Generic;
using System.Linq;
using Com.Ericmas001.Common;
using Com.Ericmas001.DataItems.Fields;
using Com.Ericmas001.DataItems.Filters;
using Com.Ericmas001.DataItems.Filters.Attributes;
using Com.Ericmas001.DataItems.Filters.Commands;
using Com.Ericmas001.DataItems.Filters.Comparators;
using Com.Ericmas001.DataItems.Filters.Enums;

namespace Com.Ericmas001.DataItems.Windows.Filters
{
    public class SimpleFilterInCreation : BaseFilterInCreation
    {
        public FilterEnum FilterType { get; private set; }
        public SimpleFilterInCreation(string field, FilterEnum filterType, IBunchOfDataItems dataItems)
            :base(field,dataItems)
        {
            FilterType = filterType;
        }

        protected override FieldTypeEnum GenerateFieldType()
        {
            var comp = CurrentComparator as SimpleFilterComparator;
            if (comp != null)
            {
                var compAtt = comp.FieldTypeOverrideAttribute;
                if (compAtt != null)
                    return compAtt.FieldType;
            }

            var filterAtt = FilterType.GetAttribute<FieldTypeAttribute>();
            if (filterAtt != null)
                return filterAtt.FieldType;

            return FieldTypeEnum.None;
        }

        protected override IEnumerable<IFilterCommand> GetAllCommands()
        {
            return SimpleFilterCommand.AllCommands(FilterType.GetAttribute<FilterCommandAttribute>().Commands.ToArray());
        }

        protected override IEnumerable<IFilterComparator> GetAllComparators()
        {
            return SimpleFilterComparator.AllComparators(FilterType.GetAttribute<FilterComparatorAttribute>().Comparators.ToArray());
        }

        protected override CheckListItem[] GenerateAvailablesItems()
        {
            if (CurrentFieldType != FieldTypeEnum.List && CurrentFieldType != FieldTypeEnum.CheckList)
                return new CheckListItem[0];

            return DataItems.ObtainAllValues(Field).Select(x => new CheckListItem(RenameEmptyItem(x), x)).ToArray();
        }

        private string RenameEmptyItem(string it)
        {
            if (String.IsNullOrEmpty(it))
                return "{Empty}";
            return it;
        }

        protected virtual FilterInfo GenerateFilterInfo()
        {
            SimpleField sf = SimpleField.GenerateField(CurrentFieldType);
            switch (CurrentFieldType)
            {
                case FieldTypeEnum.CheckList:
                    sf.Value = AvailablesItems.Where(x => x.IsSelected).Select(x => new FieldListItem() { Name = x.Name, Value = x.Value }).ToArray();
                    break;
                case FieldTypeEnum.List:
                    sf.Value = new FieldListItem() {Name = CurrentValueList.Name, Value = CurrentValueList.Value};
                    break;
                case FieldTypeEnum.Date:
                    sf.Value = CurrentValueDate;
                    break;
                case FieldTypeEnum.IntPair:
                    sf.Value = new Tuple<int, int>(int.Parse(CurrentValueStringPair1), int.Parse(CurrentValueStringPair2));
                    break;
                case FieldTypeEnum.Int:
                    sf.Value = int.Parse(CurrentValueString);
                    break;
                case FieldTypeEnum.Guid:
                    sf.Value = Guid.Parse(CurrentValueString);
                    break;
                default:
                    sf.Value = CurrentValueString;
                    break;
            }

            return new FilterInfo(Field, CurrentCommand, CurrentComparator, sf);
        }

        protected override BaseCompiledFilter CompileFilter()
        {
            return new SimpleCompiledFilter(GenerateFilterInfo(), FilterType);
        }
    }
}
