﻿using System.Collections.Generic;
using System.Linq;
using Com.Ericmas001.DataItems.Fields;
using Com.Ericmas001.Windows;

namespace Com.Ericmas001.DataItems.Windows.SearchElements
{
    [FieldType(FieldTypeEnum.List)]
    public class ListSearchElement : BaseSearchElement
    {
        private DisplayList<string> m_ItemList = new DisplayList<string>();

        public DisplayList<string> ItemList => m_ItemList;

        public override string TextValue => ItemList.Selected;

        public ListSearchElement(IEnumerable<string> items)
            : base()
        {
            items.ToList().ForEach(x => ItemList.Items.Add(x));
        }

        public override bool IsAllInputsValidated()
        {
            return ItemList.Selected != null;
        }
    }
}
