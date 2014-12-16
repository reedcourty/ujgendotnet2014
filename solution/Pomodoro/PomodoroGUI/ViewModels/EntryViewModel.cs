using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using PomodoroGUI.Messaging;
using PomodoroGUI.PomodoroServiceReference;
using System;
using System.ComponentModel;
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
    public class EntryViewModel : ViewModelBase
    {

        Entry entry;

        private int entryId;

        public int EntryId
        {
            get { return entry.Id; }
            set { entry.Id = value; RaisePropertyChanged("EntryId"); }
        }


        

        public DateTime EntryTimestamp
        {
            get { return entry.Timestamp; }
            set { entry.Timestamp = value; RaisePropertyChanged("EntryTimestamp"); }
        }



        public string EntryDescription
        {
            get { return entry.Description; }
            set 
            { 
                entry.Description = value;
                RaisePropertyChanged("EntryDescription");
            }
        }





        public string EntryTags
        {
            get { return entry.Tags.ToString(); }
        }
        





        private string tagsBoxValue;

        public string TagsBoxValue
        {
            get { return tagsBoxValue; }
            set { tagsBoxValue = value; RaisePropertyChanged("TagsBoxValue"); }
        }


        private bool tagsBoxEnabled;

        public bool TagsBoxEnabled
        {
            get { return tagsBoxEnabled; }
            set { tagsBoxEnabled = value; RaisePropertyChanged("TagsBoxEnabled"); }
        }


        private bool saveNewEntryEnabled;

        public bool SaveNewEntryEnabled
        {
            get { return saveNewEntryEnabled; }
            set { saveNewEntryEnabled = value; RaisePropertyChanged("SaveNewEntryEnabled"); }
        }



        private string descriptionBoxValue;

        public string DescriptionBoxValue
        {
            get { return descriptionBoxValue; }
            set { descriptionBoxValue = value; RaisePropertyChanged("DescriptionBoxValue"); }
        }

        

        private bool descriptionBoxEnabled;

        public bool DescriptionBoxEnabled
        {
            get { return descriptionBoxEnabled; }
            set { descriptionBoxEnabled = value; RaisePropertyChanged("DescriptionBoxEnabled"); }
        }


        private DateTime startCounterAt;

        public DateTime StartCounterAt
        {
            get { return startCounterAt; }
            set { startCounterAt = value; RaisePropertyChanged("StartCounterAt"); }
        }

        #region Commands

        private RelayCommand<object> saveNewEntryCommand;
        public ICommand SaveNewEntryCommand
        {
            get
            {
                if (saveNewEntryCommand == null)
                {
                    saveNewEntryCommand = new RelayCommand<object>(s => SaveEntry(), null);
                }
                return saveNewEntryCommand;
            }
        }

        #endregion


        /// <summary>
        /// Initializes a new instance of the EntryViewModel class.
        /// </summary>
        public EntryViewModel()
        {
            DisableEntryView();

            DescriptionBoxValue = "What have U done?";
            TagsBoxValue = "";

            Messenger.Default.Register<PomodoroTimerMessage>(this, ProcessMessages);
            
            // this.RaisePropertyChanged("EntryDescription");
            
        }

        void EntryViewModel_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            MessageBox.Show(sender.ToString());




        }

        public EntryViewModel(Entry entry)
        {
            this.entry = entry;
            PropertyChanged += EntryViewModel_PropertyChanged;
        }

        private void ProcessMessages(PomodoroTimerMessage receivedMessage)
        {
            switch (receivedMessage.Type)
            {

                case PomodoroTimerMessage.MessageType.TimerCountedDown:
                    SaveNewEntryEnabled = true;
                    break;
                case PomodoroTimerMessage.MessageType.TimerStarted:
                    DescriptionBoxEnabled = true;
                    TagsBoxEnabled = true;
                    StartCounterAt = receivedMessage.Timestamp;
                    break;
            }
        }

        private void SaveEntry()
        {
            DisableEntryView();

            BackgroundWorker bw = new BackgroundWorker();

            bw.DoWork += new DoWorkEventHandler(SaveEntryAsync);
            bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(DoStuffAfterCompleted);

            bw.RunWorkerAsync();

            
        }

        private void DoStuffAfterCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            DescriptionBoxValue = "What have U done?";
            TagsBoxValue = "";
            MessageBox.Show("Entry was saved to DB.");
        }

        private async void SaveEntryAsync(object sender, DoWorkEventArgs e)
        {
            using (PomodoroServiceClient psc = new PomodoroServiceClient())
            {
                await psc.SaveEntryAsync(StartCounterAt, DescriptionBoxValue, TagsBoxValue);
            }
        }


        private void DisableEntryView()
        {
            SaveNewEntryEnabled = false;
            DescriptionBoxEnabled = false;
            TagsBoxEnabled = false;
            
        }

    }
}