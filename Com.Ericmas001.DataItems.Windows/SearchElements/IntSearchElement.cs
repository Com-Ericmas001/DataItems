using Com.Ericmas001.DataItems.Fields;
using Com.Ericmas001.Windows.Validations;

namespace Com.Ericmas001.DataItems.Windows.SearchElements
{
    [FieldType(FieldTypeEnum.Int)]
    public class IntSearchElement : BaseSearchElement
    {
        private string m_Valeur;

        [NullOrEmptyValidation]
        [DigitValidation]
        public string Valeur
        {
            get { return m_Valeur; }
            set { Set(ref m_Valeur, value); }
        }

        public override string TextValue => Valeur;
    }
}
