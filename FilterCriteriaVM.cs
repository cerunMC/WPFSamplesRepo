using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selectize
{
    public class FilterCriteriaVM : ViewModelBase
    {

        private string _frozenText;
        ObservableCollection<FilterCriteriaVM> _filterCritera;

        public string FrozenText {
            get { return _frozenText; }
            set { Set(ref _frozenText, value); }
        }

        public RelayCommand DeleteFrozenText { get; private set; }

        public FilterCriteriaVM(string frozenText, ObservableCollection<FilterCriteriaVM> filterCriteria)
        {
            FrozenText = frozenText;

            _filterCritera = filterCriteria;

            DeleteFrozenText = new RelayCommand(
                ExecuteDeleteFrozenText,
                () => true
                );
        }

        private void ExecuteDeleteFrozenText()
        {
            _filterCritera.Remove(this);
        }
    }
}
