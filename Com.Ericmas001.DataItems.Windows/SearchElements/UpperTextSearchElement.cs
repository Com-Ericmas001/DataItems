﻿using Com.Ericmas001.DataItems.Fields;

namespace Com.Ericmas001.DataItems.Windows.SearchElements
{
    [FieldType(FieldTypeEnum.UpperText)]
    public class UpperTextSearchElement : TextSearchElement
    {
        public override string TextValue => Valeur.ToUpper();
    }
}
