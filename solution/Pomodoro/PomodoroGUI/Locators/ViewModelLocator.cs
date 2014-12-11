/*
  In App.xaml:
  <Application.Resources>
      <vm:ViewModelLocator xmlns:vm="clr-namespace:PomodoroGUI"
                                   x:Key="Locator" />
  </Application.Resources>
  
  In the View:
  DataContext="{Binding Source={StaticResource Locator}, Path=ViewModelName}"
*/

using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;

// Toolkit namespace
using SimpleMvvmToolkit;
using PomodoroGUI.Services;
using PomodoroGUI.ViewModels;

namespace PomodoroGUI
{
    /// <summary>
    /// This class creates ViewModels on demand for Views, supplying a
    /// ServiceAgent to the ViewModel if required.
    /// <para>
    /// Place the ViewModelLocator in the App.xaml resources:
    /// </para>
    /// <code>
    /// &lt;Application.Resources&gt;
    ///     &lt;vm:ViewModelLocator xmlns:vm="clr-namespace:PomodoroGUI"
    ///                                  x:Key="Locator" /&gt;
    /// &lt;/Application.Resources&gt;
    /// </code>
    /// <para>
    /// Then use:
    /// </para>
    /// <code>
    /// DataContext="{Binding Source={StaticResource Locator}, Path=ViewModelName}"
    /// </code>
    /// <para>
    /// Use the <strong>mvvmlocator</strong> or <strong>mvvmlocatornosa</strong>
    /// code snippets to add ViewModels to this locator.
    /// </para>
    /// </summary>
    public class ViewModelLocator
    {
        // Create MainPageViewModel on demand
        public MainPageViewModel MainPageViewModel
        {
            get { return new MainPageViewModel(); }
        }

        // Create EntryListViewModel on demand
        public EntryListViewModel EntryListViewModel    
        {
            get
            {
                IEntryServiceAgent serviceAgent = new MockEntryServiceAgent();
                return new EntryListViewModel(serviceAgent);
            }
        }
    }
}