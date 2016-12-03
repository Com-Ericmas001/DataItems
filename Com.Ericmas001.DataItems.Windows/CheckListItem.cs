using Com.Ericmas001.Windows;

namespace Com.Ericmas001.DataItems.Windows
{
    public class CheckListItem : BaseViewModel
    {
        private string m_Name;
        private bool m_IsSelected;

        public string Name
        {
            get { return m_Name; }
            set { Set(ref m_Name, value); }
        }

        public bool IsSelected
        {
            get { return m_IsSelected; }
            set { Set(ref m_IsSelected, value); }
        }

        public object Value { get; set; }

        public CheckListItem(string name, object value, bool isSelected = false)
        {
            m_Name = name;
            m_IsSelected = isSelected;
            Value = value;
        }
    }
}
