using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.ComponentModel;
using System.Reactive.Linq;
using System.Threading;
using System.Windows.Input;

namespace PomodoroGUI.ViewModels
{
    /// <summary>
    /// This class contains properties that a View can data bind to.
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class PomodoroTimerViewModel : ViewModelBase
    {

        public const string DEFAULT_TIMER_VALUE = "00:05";

        #region Public properties

        private string currentTimerValue;

        public string CurrentTimerValue
        {
            get { return currentTimerValue; }
            set { currentTimerValue = value; RaisePropertyChanged("CurrentTimerValue"); }
        }


        private DateTime startCounterAt;

        public DateTime StartCounterAt
        {
            get { return startCounterAt; }
            set { startCounterAt = value; RaisePropertyChanged("StartCounterAt"); }
        }


        private bool startEnabled;

        public bool StartEnabled
        {
            get { return startEnabled; }
            set { startEnabled = value; RaisePropertyChanged("StartEnabled"); }
        }


        private string timerBackgroundColor;

        public string TimerBackgroundColor
        {
            get { return timerBackgroundColor; }
            set { timerBackgroundColor = value; RaisePropertyChanged("TimerBackgroundColor"); }
        }
        

        
        #endregion

        #region Private properties

        private DateTime stopCounterAt;

        private DateTime StopCounterAt
        {
            get { return stopCounterAt; }
            set { stopCounterAt = value; }
        }


        private DateTime currentTime;

        private DateTime CurrentTime
        {
            get { return currentTime; }
            set { currentTime = value; }
        }

        #endregion

        IObservable<long> observable;
        IDisposable disposableForUnsubscribe; 

        /// <summary>
        /// Initializes a new instance of the PomodoroTimerViewModel class.
        /// </summary>
        public PomodoroTimerViewModel()
        {
            CurrentTimerValue = DEFAULT_TIMER_VALUE;
            StartEnabled = true;
            TimerBackgroundColor = "white";
        }

        #region Commands

        private RelayCommand<object> startTimerCommand;
        public ICommand StartTimerCommand
        {
            get
            {
                if (startTimerCommand == null)
                {
                    startTimerCommand = new RelayCommand<object>(s => StartTimer(), null);
                }
                return startTimerCommand;
            }
        }

        #endregion


        private void BeforeStartTimer()
        {
            StartCounterAt = DateTime.Now;

            DateTime parsedTimerValue;          

            try
            {
                parsedTimerValue = DateTime.ParseExact(CurrentTimerValue, "mm:ss", System.Globalization.CultureInfo.InvariantCulture);
            }
            catch (System.FormatException)
            {
                CurrentTimerValue = DEFAULT_TIMER_VALUE;
                parsedTimerValue = DateTime.ParseExact(CurrentTimerValue, "mm:ss", System.Globalization.CultureInfo.InvariantCulture);
            }

            TimeSpan time = new TimeSpan(0, 0, 0, parsedTimerValue.Minute * 60 + parsedTimerValue.Second);

            StopCounterAt = StartCounterAt.Add(time);

            StartEnabled = false;

            TimerBackgroundColor = "white";
        }


        private void StartTimerThread()
        {
            BeforeStartTimer();

            Thread thread = new Thread(new ThreadStart(WorkerForThread));
            thread.Start();
        }


        private void StartTimer()
        {
            BeforeStartTimer();           

            observable = Observable.Interval(TimeSpan.FromMilliseconds(500));

            disposableForUnsubscribe = observable.Subscribe(_ => Worker());
        }


        private void UpdateCurrentTimerValue()
        {
            CurrentTime = DateTime.Now;
            CurrentTimerValue = new DateTime((StopCounterAt - DateTime.Now).Ticks).ToString("mm:ss");
        }


        public void WorkerForThread()
        {
            bool running = true;
            while (running)
            {

                Thread.Sleep(10);

                if (StopCounterAt >= DateTime.Now)
                {
                    UpdateCurrentTimerValue();
                }
                else
                {
                    running = false;
                    AfterTimerCountdown();
                }
            }
        }

        private void Worker()
        {
            if (StopCounterAt >= DateTime.Now)
            {
                UpdateCurrentTimerValue();
            }
            else
            {
                disposableForUnsubscribe.Dispose();
                AfterTimerCountdown();
            }
        }

        private void AfterTimerCountdown()
        {
            StartEnabled = true;
            TimerBackgroundColor = "salmon";
        }
    }
}