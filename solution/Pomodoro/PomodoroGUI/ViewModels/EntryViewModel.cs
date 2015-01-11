using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using PomodoroGUI.Messaging;
using PomodoroGUI.PomodoroServiceReference;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Linq;
using Pomodoro.Utils;
using System.Diagnostics;

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
        Entry originalEntry = null;

        private int entryId;

        public int EntryId
        {
            get { return entry.Id; }
            set { entry.Id = value; RaisePropertyChanged("EntryId"); Logger.TraceEvent(TraceEventType.Verbose, 0, "EntryId property changed"); }
        }


        

        public DateTime EntryTimestamp
        {
            get { return entry.Timestamp; }
            set { entry.Timestamp = value; RaisePropertyChanged("EntryTimestamp"); Logger.TraceEvent(TraceEventType.Verbose, 0, "EntryTimestamp property changed"); }
        }


        public string EntryDescription
        {
            get { return entry.Description; }
            set 
            {
                if (originalEntry == null)
                {
                    originalEntry = new Entry() { Id = entry.Id, Timestamp = entry.Timestamp, Description = entry.Description, Tags = entry.Tags, RowVersion = entry.RowVersion };
                }
                
                entry.Description = value;
                RaisePropertyChanged("EntryDescription");
                Logger.TraceEvent(TraceEventType.Verbose, 0, "EntryDescription property changed");
            }
        }





        public string EntryTags
        {
            get 
            { 
                var tags = new List<Tag>(entry.Tags);
                return String.Join(", ", tags.Select(x => x.TagName)); 
            }
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
            Entry modifiedEntry = ((EntryViewModel)sender).entry;

            BackgroundWorker bw = new BackgroundWorker();

            bw.DoWork += (s, ev) => UpdateEntry(modifiedEntry, ev);
            bw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(DoStuffAfterUpdateCompleted);
            
            bw.RunWorkerAsync();
            
            
            // var ize = UpdateEntryAsync(modifiedEntry.Id, oldDescription, modifiedEntry.Description);

            
            // Messenger.Default.Send(new PomodoroGeneralMessage { Type = PomodoroGeneralMessage.MessageType.LoadEntryList });

        }

        private void DoStuffAfterUpdateCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Entry resultEntry = (Entry)e.Result;
            entry.RowVersion = resultEntry.RowVersion;
            entry.Description = resultEntry.Description;
            // TODO: A frissítést még meg kell oldani.
            // EntryDescription = resultEntry.Description;
            originalEntry = null;
        }

        private Entry UpdateEntry(Entry modifiedEntry, DoWorkEventArgs e)
        {
            Entry result = null;
            using (PomodoroServiceClient psc = new PomodoroServiceClient())
            {
                try
                {
                    result = psc.UpdateEntry(modifiedEntry);
                }
                catch (Exception fe)
                {
                    try
                    {
                        result = psc.GetEntryById(modifiedEntry.Id);
                    }
                    catch (Exception gebie)
                    {

                        MessageBox.Show(gebie.Message);
                    }
                    
                    MessageBox.Show(fe.Message);
                }
            }
            e.Result = result;
            return result;
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
            MessageBox.Show("Entry was send to DB.");
            Messenger.Default.Send(new PomodoroGeneralMessage { Type = PomodoroGeneralMessage.MessageType.LoadEntryList });
        }

        private async void SaveEntryAsync(object sender, DoWorkEventArgs e)
        {
            using (PomodoroServiceClient psc = new PomodoroServiceClient())
            {
                try
                {
                    await psc.SaveEntryAsync(StartCounterAt, DescriptionBoxValue, TagsBoxValue);
                }
                catch (Exception fe)
                {
                    MessageBox.Show(fe.Message);
                }
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