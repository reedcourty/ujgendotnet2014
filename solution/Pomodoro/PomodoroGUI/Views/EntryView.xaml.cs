using PomodoroGUI.ViewModels;
using System.Windows.Controls;

namespace PomodoroGUI.Views
{
    /// <summary>
    /// Description for EntryView.
    /// </summary>
    public partial class EntryView : UserControl
    {
        /// <summary>
        /// Initializes a new instance of the EntryView class.
        /// </summary>
        public EntryView()
        {
            InitializeComponent();
            this.DataContext = new EntryViewModel();
        }
    }
}