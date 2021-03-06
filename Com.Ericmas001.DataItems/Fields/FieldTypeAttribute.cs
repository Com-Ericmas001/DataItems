﻿using System;

namespace Com.Ericmas001.DataItems.Fields
{
    public class FieldTypeAttribute : Attribute
    {
        public FieldTypeEnum FieldType { get; private set; }

        public FieldTypeAttribute(FieldTypeEnum fieldType)
        {
            FieldType = fieldType;
        }
    }
}
