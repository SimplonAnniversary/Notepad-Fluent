using NotepadUwp.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

namespace NotepadUwp.Views
{
    public sealed partial class MainPage : Page
    {
        //public MainPageViewModel ViewModel => DataContext as MainPageViewModel;
        public MainPageViewModel ViewModel { get; set; }

        public MainPage()
        {
            this.InitializeComponent();
            ViewModel = new MainPageViewModel();
        }

        private async void cbtnOpenFile_Click(object sender, RoutedEventArgs e)
        {
            await ViewModel.Load();
        }

        private async void cbtnPaste_Click(object sender, RoutedEventArgs e)
        {
            await ViewModel.Paste(txtContent.SelectionStart);
        }

        private void cbtnCopy_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.Copy(txtContent.SelectedText);
            // TODO: Show UI indication/message that the selected text has been copied to the clipboard
        }
    }
}
