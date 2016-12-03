using System;
using Com.Ericmas001.DataItems.Fields;
using Com.Ericmas001.Windows.Validations;

namespace Com.Ericmas001.DataItems.Windows.SearchElements
{
    [FieldType(FieldTypeEnum.Guid)]
    public class GuidSearchElement : BaseSearchElement
    {
        private string m_Valeur;

        [NullOrEmptyValidation]
        [CustomValidation("ValidateGuid")]
        public string Valeur
        {
            get { return m_Valeur; }
            set { Set(ref m_Valeur, value); }
        }

        public override string TextValue => Valeur;

        private string ValidateGuid(string text)
        {
            Guid res;
            if (!Guid.TryParse(text, out res))
                return "Ceci doit être un GUID (Exemple 'BC38C957-C65A-4CB8-A3F8-BE88914DA5C8')";
            return null;
        }
    }
}
