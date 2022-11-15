using System.Windows;
using System.Windows.Forms;
using UserControl = System.Windows.Controls.UserControl;

namespace Controls
{
    public partial class PathSelector : UserControl
    {
        #region Fields

        // Using a DependencyProperty as the backing store for CanEdit.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CanEditProperty =
            DependencyProperty.Register("CanEdit", typeof(bool), typeof(PathSelector), new PropertyMetadata(false, OnPropertyCanEditChanged));

        // Using a DependencyProperty as the backing store for SelectedPath.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SelectedPathProperty =
            DependencyProperty.Register("SelectedPath", typeof(string), typeof(PathSelector), new PropertyMetadata(""));

        private FolderBrowserDialog folderBrowserDialog;

        #endregion Fields

        #region Constructors

        public PathSelector()
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
            if (d is PathSelector ps)
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
            if (folderBrowserDialog is null)
            {
                folderBrowserDialog = new FolderBrowserDialog
                {
                    Description = "请选择文件夹"
                };
            }

            folderBrowserDialog.SelectedPath = SelectedPath;
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
            {
                SelectedPath = folderBrowserDialog.SelectedPath;
            }
        }

        private void DoSelectPathClick(object sender, RoutedEventArgs e)
        {
            DoSelectPath();
        }

        #endregion Methods
    }
}