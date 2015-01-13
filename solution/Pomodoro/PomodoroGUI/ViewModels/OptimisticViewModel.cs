using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using PomodoroGUI.Messaging;
using System.Windows.Input;

namespace PomodoroGUI.ViewModels
{
    /// <summary>
    /// This class contains properties that a View can data bind to.
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class OptimisticViewModel : ViewModelBase
    {
        /// <summary>
        /// Initializes a new instance of the OptimisticViewModel class.
        /// </summary>
        public OptimisticViewModel()
        {
        }


        #region Commands

        private RelayCommand<object> optimisticUserCommand;
        public ICommand OptimisticUserCommand
        {
            get
            {
                if (optimisticUserCommand == null)
                {
                    optimisticUserCommand = new RelayCommand<object>(s => UpdateWithUserVersion(), null);
                }
                return optimisticUserCommand;
            }
        }


        private RelayCommand<object> optimisticOtherUserCommand;
        public ICommand OptimisticOtherUserCommand
        {
            get
            {
                if (optimisticOtherUserCommand == null)
                {
                    optimisticOtherUserCommand = new RelayCommand<object>(s => UpdateWithOtherUserVersion(), null);
                }
                return optimisticOtherUserCommand;
            }
        }


        private RelayCommand<object> optimisticServerCommand;
        public ICommand OptimisticServerCommand
        {
            get
            {
                if (optimisticServerCommand == null)
                {
                    optimisticServerCommand = new RelayCommand<object>(s => UpdateWithServerVersion(), null);
                }
                return optimisticServerCommand;
            }
        }

        #endregion

        private void UpdateWithUserVersion()
        {
            System.Console.WriteLine("UpdateWithUserVersion");
            Messenger.Default.Send(new PomodoroGeneralMessage { Type = PomodoroGeneralMessage.MessageType.UpdateWithUserVersion });
        }

        private void UpdateWithOtherUserVersion()
        {
            System.Console.WriteLine("UpdateWithOtherUserVersion");
            Messenger.Default.Send(new PomodoroGeneralMessage { Type = PomodoroGeneralMessage.MessageType.UpdateWithOtherUserVersion });
        }

        private void UpdateWithServerVersion()
        {
            System.Console.WriteLine("UpdateWithServerVersion");
            Messenger.Default.Send(new PomodoroGeneralMessage { Type = PomodoroGeneralMessage.MessageType.UpdateWithServerVersion });
        }
        
    }
}