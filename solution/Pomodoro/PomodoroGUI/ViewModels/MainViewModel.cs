using GalaSoft.MvvmLight;
using PomodoroGUI.PomodoroServiceReference;
using System.Collections.ObjectModel;
using System.Windows;

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
        public async void LoadEntryList()
        {

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
                catch (System.Exception)
                {
                    
                    MessageBox.Show("There was an error while trying to load entries!");
                }

            
            }
                    
        }
    }
}