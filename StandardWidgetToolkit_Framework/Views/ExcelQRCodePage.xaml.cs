using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Utils;
using ViewModels;

namespace StandardWidgetToolkit_Framework.Views
{
    public partial class ExcelQRCodePage : Page
    {
        public static ExcelQRCodeViewModel ViewModel { get; set; }

        public ExcelQRCodePage()
        {
            InitializeComponent();
            ViewModel = new ExcelQRCodeViewModel();
            DataContext = ViewModel;
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            ViewModel.InitProgram();
        }

        private void Page_Drop(object sender, DragEventArgs e)
        {

        }

        private void Button_Execute_Click(object sender, RoutedEventArgs e)
        {
            ViewModel.HandleExcelFile();
        }
    }
}
