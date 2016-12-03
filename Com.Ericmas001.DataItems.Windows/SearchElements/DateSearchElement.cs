using System;
using System.Globalization;
using Com.Ericmas001.DataItems.Fields;

namespace Com.Ericmas001.DataItems.Windows.SearchElements
{
    [FieldType(FieldTypeEnum.Date)]
    public class DateSearchElement : BaseSearchElement
    {

        private bool m_Ok = true;
        private DateTime m_Valeur = DateTime.Now;
        
        public string Valeur
        {
            get
            {
                return m_Valeur.ToString("yyyy-MM-dd");
            }
            set
            {
                DateTime myDate = m_Valeur = DateTime.Now;
                if (DateTime.TryParseExact(value, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out myDate))
                {
                    m_Ok = true;
                }
                else
                    m_Ok = false;
                RaisePropertyChanged(nameof(Valeur));
                RaisePropertyChanged(nameof(TextValue));
            }
        }

        public override string TextValue => Valeur;

        public override bool IsAllInputsValidated()
        {
            return m_Ok;
        }
    }
}
