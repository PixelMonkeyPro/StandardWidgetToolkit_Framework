using System.Windows;
using System.Windows.Forms;
using UserControl = System.Windows.Controls.UserControl;

namespace Controls
{
    public partial class FileSelector : UserControl
    {
        #region Fields

        // Using a DependencyProperty as the backing store for CanEdit.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CanEditProperty =
            DependencyProperty.Register("CanEdit", typeof(bool), typeof(FileSelector), new PropertyMetadata(false, OnPropertyCanEditChanged));

        // Using a DependencyProperty as the backing store for SelectedPath.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SelectedPathProperty =
            DependencyProperty.Register("SelectedPath", typeof(string), typeof(FileSelector), new PropertyMetadata(""));

        private OpenFileDialog openFileDialog;

        #endregion Fields

        #region Constructors

        public FileSelector()
        {
            InitializeComponent();
        }

        #endregion Constructors

        #region Properties

        public bool CanEdit
        {
            get { return (bool)GetValue(CanEditProperty); }
            set { SetValue(CanEditProperty, value); }
        }

        public string SelectedPath
        {
            get { return (string)GetValue(SelectedPathProperty); }
            set { SetValue(SelectedPathProperty, value); }
        }

        #endregion Properties

        #region Methods

        private static void OnPropertyCanEditChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is FileSelector ps)
            {
                ps.txtPath.IsReadOnly = !(bool)e.NewValue;
            }
        }

        private void Btn_SelectPath_Click(object sender, RoutedEventArgs e)
        {
            DoSelectPath();
        }

        private void DoSelectPath()
        {
            if (openFileDialog is null)
            {
                openFileDialog = new OpenFileDialog
                {
                    Title = "请选择Excel文件",
                    Filter = "Excel files (*.xls;*.xlsx)|*.xls;*.xlsx",
                    InitialDirectory = SelectedPath,
                    Multiselect = false,
                    CheckFileExists = true,
                    CheckPathExists = true
                };
            }
            openFileDialog.FileName = SelectedPath;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                SelectedPath = openFileDialog.FileName;
            }
        }

        private void DoSelectPathClick(object sender, RoutedEventArgs e)
        {
            DoSelectPath();
        }

        #endregion Methods
    }
}