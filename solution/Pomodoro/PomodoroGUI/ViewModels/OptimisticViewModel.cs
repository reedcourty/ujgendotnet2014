using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using PomodoroGUI.Messaging;
using PomodoroGUI.Views;
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
                    optimisticUserCommand = new RelayCommand<object>(s => UpdateWithUserVersion((OptimisticView)s), null);
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
                    optimisticOtherUserCommand = new RelayCommand<object>(s => UpdateWithOtherUserVersion((OptimisticView)s), null);
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
                    optimisticServerCommand = new RelayCommand<object>(s => UpdateWithServerVersion((OptimisticView)s), null);
                }
                return optimisticServerCommand;
            }
        }

        #endregion

        private void UpdateWithUserVersion(OptimisticView ov)
        {
            System.Console.WriteLine("UpdateWithUserVersion");
            Messenger.Default.Send(new PomodoroGeneralMessage { Type = PomodoroGeneralMessage.MessageType.UpdateWithUserVersion });
            ov.Close();
        }

        private void UpdateWithOtherUserVersion(OptimisticView ov)
        {
            System.Console.WriteLine("UpdateWithOtherUserVersion");
            Messenger.Default.Send(new PomodoroGeneralMessage { Type = PomodoroGeneralMessage.MessageType.UpdateWithOtherUserVersion });
            ov.Close();
        }

        private void UpdateWithServerVersion(OptimisticView ov)
        {
            System.Console.WriteLine("UpdateWithServerVersion");
            Messenger.Default.Send(new PomodoroGeneralMessage { Type = PomodoroGeneralMessage.MessageType.UpdateWithServerVersion });
            ov.Close();
        }
        
    }
}