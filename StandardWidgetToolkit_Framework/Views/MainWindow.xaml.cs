using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows;
using StandardWidgetToolkit_Framework.Views;
using Utils;
using ViewModels;

namespace StandardWidgetToolkit_Framework
{
    public partial class MainWindow : Window
    {
        public static MainViewModel ViewModel { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            ViewModel = new MainViewModel();
            DataContext = ViewModel;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            ViewModel.InitProgram();
            fmNavigation.Navigate(new ExcelQRCodePage());
        }

        private void Window_Drop(object sender, DragEventArgs e)
        {

        }
    }
}
