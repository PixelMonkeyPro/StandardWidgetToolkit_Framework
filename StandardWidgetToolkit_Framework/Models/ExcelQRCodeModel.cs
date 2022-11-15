using System.ComponentModel;

namespace Models
{
    public class ExcelQRCodeModel : INotifyPropertyChanged
    {
        private string _guid;
        public string Guid { get => _guid; set { _guid = value; NotifyChanged("Guid"); } }

        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyChanged(string propertyName) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        public ExcelQRCodeModel() { }
    }
}