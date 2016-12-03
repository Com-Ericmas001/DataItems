using System;
using System.Windows.Input;
using Com.Ericmas001.Windows;
using GalaSoft.MvvmLight.CommandWpf;

namespace Com.Ericmas001.DataItems.Windows.SearchElements
{
    public abstract class BaseSearchElement : BaseViewModel 
    {
        public event EventHandler ValueSubmitted = delegate { };

        public abstract string TextValue { get; }

        private RelayCommand m_SubmitValue;
        public ICommand SubmitValue { get { return m_SubmitValue ?? (m_SubmitValue = new RelayCommand(() => ValueSubmitted(this,new EventArgs()), IsAllInputsValidated)); } }

        public BaseSearchElement()
        {
        }
    }
}
