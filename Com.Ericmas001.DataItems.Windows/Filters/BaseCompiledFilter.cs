using System;
using Com.Ericmas001.DataItems.Filters;
using Com.Ericmas001.Windows;
using GalaSoft.MvvmLight.CommandWpf;

namespace Com.Ericmas001.DataItems.Windows.Filters
{
    public abstract class BaseCompiledFilter : BaseViewModel
    {
        public event EventHandler RemoveMeAsAFilter;
        public event EventHandler UpdateAFilter;

        private bool m_IsActive = true;

        public bool IsActive
        {
            get { return m_IsActive; }
            set
            {
                if (value != m_IsActive)
                {
                    m_IsActive = value;
                    UpdateAFilter?.Invoke(this, new EventArgs());
                    RaisePropertyChanged();
                }
            }
        }
        public virtual bool IsReadOnly => false;

        public bool IsDeletable => !IsReadOnly;

        private RelayCommand m_DeleteCommand;
        public RelayCommand DeleteCommand
        {
            get { return m_DeleteCommand ?? (m_DeleteCommand = new RelayCommand(RemoveFilter, () => IsDeletable)); }
        }

        private void RemoveFilter()
        {
            RemoveMeAsAFilter?.Invoke(this, new EventArgs());
        }

        public BaseCompiledFilter(FilterInfo info)
        {
            Info = info;
        }

        public BaseCompiledFilter()
        {
        }

        public string Description => ToString();

        public FilterInfo Info { get; set; }

        public override string ToString()
        {
            return Info.ToString();
        }

        public bool IsSurvivingTheFilter(string value, IDataItem item)
        {
            return !m_IsActive || CheckIfIsSurvivingTheFilter(value, item);
        }

        protected abstract bool CheckIfIsSurvivingTheFilter(string value, IDataItem item);
    }
}
