using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using PomodoroGUI.PomodoroServiceReference;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace PomodoroGUI.ViewModels
{
    /// <summary>
    /// This class contains properties that a View can data bind to.
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel()
        {
        }

        private ObservableCollection<EntryViewModel> entryList = new ObservableCollection<EntryViewModel>();
        public ObservableCollection<EntryViewModel> EntryList
        {
            get { return entryList; }
        }


        #region Commands

        private RelayCommand<object> loadEntryListCommand;
        public ICommand LoadEntryListCommand
        {
            get
            {
                if (loadEntryListCommand == null)
                {
                    loadEntryListCommand = new RelayCommand<object>(s => LoadEntryList(), null);
                }
                return loadEntryListCommand;
            }
        }

        #endregion

        
        public async void LoadEntryList()
        {
            entryList.Clear();

            using (PomodoroServiceClient psc = new PomodoroServiceClient())
            {

                try
                {
                    var entries = await psc.GetEntriesAsync();

                    foreach (var item in entries)
                    {
                        entryList.Add(new EntryViewModel(item));
                    }
                }
                catch (System.Exception e)
                {
                    
                    MessageBox.Show(e.Message);
                }

            
            }
                    
        }
    }
}