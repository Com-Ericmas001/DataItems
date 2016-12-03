using Com.Ericmas001.DataItems.Fields;
using Com.Ericmas001.Windows.Validations;

namespace Com.Ericmas001.DataItems.Windows.SearchElements
{
    [FieldType(FieldTypeEnum.IntPair)]
    public class IntPairSearchElement : BaseSearchElement
    {
        private string m_Valeur1;
        private string m_Valeur2;

        [NullOrEmptyValidation]
        [DigitValidation]
        public string Valeur1
        {
            get { return m_Valeur1; }
            set { Set(ref m_Valeur1, value); }
        }
        [NullOrEmptyValidation]
        [DigitValidation]
        public string Valeur2
        {
            get { return m_Valeur2; }
            set { Set(ref m_Valeur2, value); }
        }

        public override string TextValue => Valeur1 + ";" + Valeur2;
    }
}
