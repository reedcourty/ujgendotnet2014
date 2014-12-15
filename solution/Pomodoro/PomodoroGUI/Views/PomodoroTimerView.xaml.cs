using PomodoroGUI.ViewModels;
using System.Windows.Controls;

namespace PomodoroGUI.Views
{
    /// <summary>
    /// Description for PomodoroTimerView.
    /// </summary>
    public partial class PomodoroTimerView : UserControl
    {
        /// <summary>
        /// Initializes a new instance of the PomodoroTimerView class.
        /// </summary>
        public PomodoroTimerView()
        {
            InitializeComponent();
            this.DataContext = new PomodoroTimerViewModel();
        }
    }
}