using System;
using System.Windows;
using System.Threading;
using System.Collections.ObjectModel;

// Toolkit namespace
using SimpleMvvmToolkit;
using PomodoroGUI.Services;
using PomodoroDAL;

namespace PomodoroGUI.ViewModels
{
    /// <summary>
    /// This class contains properties that a View can data bind to.
    /// <para>
    /// Use the <strong>mvvmprop</strong> snippet to add bindable properties to this ViewModel.
    /// </para>
    /// </summary>
    public class EntryListViewModel : ViewModelBase<EntryListViewModel>
    {
        // TODO: Add a member for IXxxServiceAgent
        private IEntryServiceAgent serviceAgent;

        // Default ctor
        public EntryListViewModel() { }

        // TODO: ctor that accepts IXxxServiceAgent
        public EntryListViewModel(IEntryServiceAgent serviceAgent)
        {
            this.serviceAgent = serviceAgent;
        }

        // TODO: Add events to notify the view or obtain data from the view
        public event EventHandler<NotificationEventArgs<Exception>> ErrorNotice;

        // TODO: Add properties using the mvvmprop code snippet
        private ObservableCollection<Entry> entries;
        public ObservableCollection<Entry> Entries
        {
            get { return entries; }
            set
            {
                entries = value;
                NotifyPropertyChanged(m => m.Entries);
            }
        }

        // TODO: Add methods that will be called by the view

        public void LoadEntries()
        {
            var entries = serviceAgent.LoadEntries();
            Entries = new ObservableCollection<Entry>(entries);
        }

        // TODO: Optionally add callback methods for async calls to the service agent
        
        // Helper method to notify View of an error
        private void NotifyError(string message, Exception error)
        {
            // Notify view of an error
            Notify(ErrorNotice, new NotificationEventArgs<Exception>(message, error));
        }
    }
}