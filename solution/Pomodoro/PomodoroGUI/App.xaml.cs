using PomodoroGUI.ViewModel;
using PomodoroGUI.ViewModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace PomodoroGUI
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            MainWindow view = new PomodoroGUI.MainWindow();
            MainViewModel mainViewModel = new MainViewModel();

            mainViewModel.LoadEntryList();

            view.DataContext = mainViewModel;
            view.Show();
        }
    }

    
}
