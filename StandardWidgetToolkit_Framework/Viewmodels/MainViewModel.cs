using System;
using System.ComponentModel;
using System.Windows;

namespace ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        #region 未绑定属性

        #endregion

        #region 绑定属性

        private string _title;
        public string Title { get => _title; set { _title = value; NotifyChanged("Title"); } }

        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyChanged(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        #endregion

        public MainViewModel()
        {

        }

        public void InitProgram()
        {
            try
            {
                InitProgramDataList();
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message, "提示", MessageBoxButton.OK, MessageBoxImage.Error);
                Application.Current.Shutdown();
            }
        }

        public void InitProgramDataList()
        {
            Title = "二维码生成小程序";
        }
    }
}