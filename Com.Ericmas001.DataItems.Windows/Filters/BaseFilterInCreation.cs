using System;
using System.Collections.Generic;
using System.Linq;
using Com.Ericmas001.DataItems.Fields;
using Com.Ericmas001.DataItems.Filters.Commands;
using Com.Ericmas001.DataItems.Filters.Comparators;
using Com.Ericmas001.Windows;
using GalaSoft.MvvmLight.CommandWpf;

namespace Com.Ericmas001.DataItems.Windows.Filters
{
    public abstract class BaseFilterInCreation : BaseViewModel
    {
        public event EventHandler AddMeAsAFilter;

        private readonly string m_Field;
        private IFilterCommand[] m_AvailablesCommands;
        private IFilterComparator[] m_AvailablesComparators;
        private CheckListItem[] m_AvailablesItems;
        private IFilterCommand m_CurrentCommand;
        private IFilterComparator m_CurrentComparator;
        private FieldTypeEnum m_CurrentFieldType;
        private string m_CurrentValueString;
        private string m_CurrentValueStringPair1;
        private string m_CurrentValueStringPair2;
        private DateTime m_CurrentValueDate = DateTime.Now;
        private CheckListItem m_CurrentValueList;

        public CheckListItem CurrentValueList
        {
            get
            {
                Init();
                return m_CurrentValueList;
            }
            set { Set(ref m_CurrentValueList, value); }
        }

        public string CurrentValueString
        {
            get
            {
                Init();
                return m_CurrentValueString;
            }
            set { Set(ref m_CurrentValueString, value); }
        }

        public string CurrentValueStringPair1
        {
            get
            {
                Init(); 
                return m_CurrentValueStringPair1;
            }
            set { Set(ref m_CurrentValueStringPair1, value); }
        }

        public string CurrentValueStringPair2
        {
            get
            {
                Init(); 
                return m_CurrentValueStringPair2;
            }
            set { Set(ref m_CurrentValueStringPair2, value); }
        }

        public DateTime CurrentValueDate
        {
            get
            {
                Init(); 
                return m_CurrentValueDate;
            }
            set { Set(ref m_CurrentValueDate, value); }
        }

        public IFilterCommand CurrentCommand
        {
            get
            {
                Init(); 
                return m_CurrentCommand;
            }
            set
            {
                Init(); 
                m_CurrentCommand = value;
                RaisePropertyChanged();
            }
        }

        public IFilterComparator CurrentComparator
        {
            get
            {
                Init(); 
                return m_CurrentComparator;
            }
            set
            {
                Init(); 
                m_CurrentComparator = value;
                CurrentFieldType = GenerateFieldType();
                RaisePropertyChanged();
            }
        }

        public FieldTypeEnum CurrentFieldType
        {
            get
            {
                Init();
                return m_CurrentFieldType;
            }
            set
            {
                Init(); 
                m_CurrentFieldType = value;
                AvailablesItems = GenerateAvailablesItems();
                RaisePropertyChanged();
            }
        }

        public CheckListItem[] AvailablesItems
        {
            get
            {
                Init(); 
                return m_AvailablesItems;
            }
            set
            {
                Init(); 
                Set(ref m_AvailablesItems, value);
            }
        }

        protected IBunchOfDataItems DataItems { get; }

        public IFilterComparator[] AvailablesComparators
        {
            get
            {
                Init();
                return m_AvailablesComparators;
            }
        }

        public bool HasOnlyOneComparator => AvailablesComparators.Length == 1;

        public IFilterCommand[] AvailablesCommands
        {
            get
            {
                Init();
                return m_AvailablesCommands;
            }
        }

        public bool HasOnlyOneCommand => AvailablesCommands.Length == 1;

        public string Field => m_Field;

        private RelayCommand m_AddCommand;

        public RelayCommand AddCommand => m_AddCommand ?? (m_AddCommand = new RelayCommand(AddFilter));

        protected abstract BaseCompiledFilter CompileFilter();  
        private void AddFilter()
        {
            AddMeAsAFilter?.Invoke(CompileFilter(), new EventArgs());
        }

        protected abstract IEnumerable<IFilterCommand> GetAllCommands();
        protected abstract IEnumerable<IFilterComparator> GetAllComparators();


        protected BaseFilterInCreation(string field, IBunchOfDataItems dataItems)
        {
            m_Field = field;
            DataItems = dataItems;
        }

        private bool m_IsInit;
        private void Init()
        {
            if (!m_IsInit)
            {
                m_IsInit = true;
                m_AvailablesCommands = GetAllCommands().ToArray();
                m_CurrentCommand = m_AvailablesCommands.First();
                m_AvailablesComparators = GetAllComparators().ToArray();
                m_CurrentComparator = HasOnlyOneComparator ? AvailablesComparators.First() : null;
                CurrentFieldType = GenerateFieldType();
            }
        }

        protected abstract FieldTypeEnum GenerateFieldType();

        protected abstract CheckListItem[] GenerateAvailablesItems();
    }
}
