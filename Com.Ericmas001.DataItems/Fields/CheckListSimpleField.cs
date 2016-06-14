using System;
using System.Linq;
using System.Collections.Generic;

namespace Com.Ericmas001.DataItems.Fields
{

    [FieldType(FieldTypeEnum.CheckList)]
    public class CheckListSimpleField : SimpleField
    {
        public virtual IEnumerable<FieldListItem> Values { get { return (IEnumerable<FieldListItem>)Value; } }
        public override string ToString()
        {
            return "{" + string.Join(", ", Values.Select(x => x.Name)) + "}";
        }
    }
}
