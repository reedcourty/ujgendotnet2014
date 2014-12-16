using PomodoroGUI.ViewModels;
using System.Windows.Controls;

namespace PomodoroGUI.Views
{
    /// <summary>
    /// Interaction logic for NewEntryView.xaml
    /// </summary>
    public partial class NewEntryView : UserControl
    {
        public NewEntryView()
        {
            InitializeComponent();
            this.DataContext = new EntryViewModel();
        }
    }
}
