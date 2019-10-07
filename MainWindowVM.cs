using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Selectize
{
    public class MainWindowVM : ViewModelBase
    {

        private string _title;
        private string _unfrozenText;
        private bool _boolAutoComplete;
        private int _caretPosition;
        private ObservableCollection<FilterCriteriaVM> _filterCritera;

        public string Title {
            get { return _title; }
            set { Set(ref _title, value); }
        }

        public string UnfrozenText {
            get { return _unfrozenText; }
            set { Set(ref _unfrozenText, value); }
        }

        public int CaretPosition {
            get { return _caretPosition; }
            set { Set(ref _caretPosition, value); }
        }

        public bool BoolAutoComplete
        {
            get { return _boolAutoComplete; }
            set { Set(ref _boolAutoComplete, value); }
        }

        public ObservableCollection<FilterCriteriaVM> FilterCriteria
        {
            get { return _filterCritera; }
            set { Set(ref _filterCritera, value); }
        }

        public RelayCommand testRelay { get; private set; }

        public RelayCommand<KeyEventArgs> PreviewKeyDown { get; private set; }
        public RelayCommand PreviewKeyUp { get; private set; }
        


        public MainWindowVM()
        {

            UnfrozenText = "";
            Title = "Test Title";

            testRelay = new RelayCommand(
                ExecuteTestRelay,
                () => true
            );

            PreviewKeyDown = new RelayCommand<KeyEventArgs>(
                ExecutePreviewKeyDown,
                (e) => true
            );

            PreviewKeyUp = new RelayCommand(
                ExecutePreviewKeyUp,
                () => true
            );

            FilterCriteria = new ObservableCollection<FilterCriteriaVM>();
            FilterCriteria.Add(new FilterCriteriaVM("TheChangeIsNow", _filterCritera));
            FilterCriteria.Add(new FilterCriteriaVM("WeAreTheChange", _filterCritera));

        }

        private void ExecutePreviewKeyUp()
        {
            BoolAutoComplete = true;
        }

        private void ExecutePreviewKeyDown(KeyEventArgs kea)
        {
            if (kea.Key == Key.Enter && _unfrozenText.Length > 0)
            {
                bool add = true;
                foreach (var fe in FilterCriteria)
                {
                    if (fe.FrozenText.Equals(_unfrozenText))
                    {
                        add = false;
                    }
                }
                if (add)
                { 
                    FilterCriteria.Add(new FilterCriteriaVM(_unfrozenText, _filterCritera));
                }
                UnfrozenText = "";
            }
            else if (kea.Key == Key.Back && CaretPosition == 0)
            {
                if (FilterCriteria.Any())
                { 
                    FilterCriteriaVM fe = FilterCriteria[FilterCriteria.Count() - 1];
                    FilterCriteria.RemoveAt(FilterCriteria.Count() - 1);
                    UnfrozenText = fe.FrozenText + _unfrozenText;
                    CaretPosition = _unfrozenText.Length;
                }
            }
        }

        private void ExecuteTestRelay()
        {
            Title = "test worked";
        }
    }
}
