using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace EmbeddedApp
{
    public partial class FormMain : Form
    {
        private AppContainer appContainer = new AppContainer();

        public FormMain()
        {
            InitializeComponent();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            InitializeNotifyIcon();

            InitAppContainer();
            InitEventProcedure();
        }

        private bool FormIsClosing = false;
        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!exitTag)
            {
                e.Cancel = true;
                WindowState = FormWindowState.Minimized;
                HideForm();
                ShowNotifyTip("请右击托盘图标退出");
                return;
            }

            FormIsClosing = true;

            HackMouseEvent();
            UnRegisterGlobalHotKey();
            CancelEmbedApplication();
        }

        private void FormMain_Deactivate(object sender, EventArgs e)
        {
            if (FormIsClosing) { return; }
            if (WindowState == FormWindowState.Minimized) { HideForm(); }
            if (checkBox_Nontransparent.Checked) { return; }
            Opacity = 0;
        }

        /// <summary>
        /// 注册全局热键
        /// </summary>
        private void RegisterGlobalHotKey()
        {
            RegisterHotKey(Handle, 998, KeyModifiers.Alt, Keys.CapsLock);
            RegisterHotKey(Handle, 999, KeyModifiers.Alt, Keys.Oemtilde);
            RegisterHotKey(Handle, 98, KeyModifiers.Control | KeyModifiers.Windows | KeyModifiers.Alt, Keys.Up);
            RegisterHotKey(Handle, 99, KeyModifiers.Control | KeyModifiers.Windows | KeyModifiers.Alt, Keys.Down);
        }

        /// <summary>
        /// 取消注册全局热键
        /// </summary>
        private void UnRegisterGlobalHotKey()
        {
            UnregisterHotKey(Handle, 998);
            UnregisterHotKey(Handle, 999);
            UnregisterHotKey(Handle, 98);
            UnregisterHotKey(Handle, 99);
        }

        private void HackMouseEvent()
        {
            if (HackIsRuning)
            {
                HackIsRuning = false;
                UnregisterHotKey(Handle, 100);
                UnregisterHotKey(Handle, 101);
                UnregisterHotKey(Handle, 102);
                UnregisterHotKey(Handle, 103);
                UnregisterHotKey(Handle, 104);
            }
            else
            {
                RegisterHotKey(Handle, 100, KeyModifiers.Alt, Keys.S);

                RegisterHotKey(Handle, 101, KeyModifiers.Alt, Keys.A);
                RegisterHotKey(Handle, 102, KeyModifiers.Alt, Keys.D);

                RegisterHotKey(Handle, 103, KeyModifiers.Alt, Keys.Insert);
                RegisterHotKey(Handle, 104, KeyModifiers.Alt, Keys.Delete);

                HackIsRuning = true;
                BackgroundWorker bw = new BackgroundWorker();
                bw.DoWork += Bw_DoWork;
                bw.ProgressChanged += Bw_ProgressChanged;
                bw.WorkerReportsProgress = true;
                bw.RunWorkerAsync();
            }
        }

        private void HideForm()
        {
            Opacity = 0;
            Hide();
        }

        private void ShowForm(double opacity, bool append = false)
        {
            Show();
            if (append)
            {
                Opacity += opacity;
                return;
            }
            Opacity = opacity;
        }

        private void TextBox_Opacity_TextChanged(object sender, EventArgs e)
        {
            if (double.TryParse(textBox_Opacity.Text, out double opacity))
            {
                Opacity = opacity > 1 ? opacity / 100 : opacity;
            }
        }
        private void CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (sender is CheckBox checkbox)
            {
                switch (checkbox.Name)
                {
                    case checkBox_Opacity.Name:
                        if (!checkbox.Checked)
                        {
                            Opacity = 1;
                            return;
                        }

                        if (double.TryParse(textBox_Opacity.Text, out double opacity))
                        {
                            Opacity = opacity > 1 ? opacity / 100 : opacity;
                        }
                        break;
                    case checkBox_Nontransparent.Name:
                        Opacity = 1;
                        break;
                    case checkBox_GlobalHotKey.Name:
                        if (checkbox.Checked)
                        {
                            UnRegisterGlobalHotKey();
                            return;
                        }
                        RegisterGlobalHotKey();
                        break;
                    default:
                        break;
                }
            }
        }

        private void CheckBox_Opacity_CheckedChanged(object sender, EventArgs e)
        {
            if (!checkBox_Opacity.Checked)
            {
                Opacity = 1;
                return;
            }

            if (double.TryParse(textBox_Opacity.Text, out double opacity))
            {
                Opacity = opacity > 1 ? opacity / 100 : opacity;
            }
        }

        private void CheckBox_Nontransparent_CheckedChanged(object sender, EventArgs e)
        {
            Opacity = 1;
        }

        private void CheckBox_GlobalHotKey_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void Button_Click(object sender, EventArgs e)
        {
            if (sender is Button button)
            {
                button.Enabled = false;

                object temp = button.Text;
                button.Text = button.Tag.ToString();
                button.Tag = temp;

                switch (button.Name)
                {
                    case btnRecord.Name:
                        HackMouseEvent();
                        break;
                    case btnPlayback.Name:
                        PlayBackMouseEvent();
                        break;
                    default:
                        break;
                }

                button.Enabled = true;
            }
        }

        private void BtnRecord_Click(object sender, EventArgs e)
        {
            if (sender is Button button)
            {
                button.Enabled = false;

                object temp = button.Text;
                button.Text = button.Tag.ToString();
                button.Tag = temp;

                HackMouseEvent();

                button.Enabled = true;
            }
        }

        private void BtnPlayback_Click(object sender, EventArgs e)
        {
            if (sender is Button button)
            {
                button.Enabled = false;

                dgv_EventProcedure.EndEdit();

                if (checkBox_LoopPlay.Checked)
                {
                    object temp = button.Text;
                    button.Text = button.Tag.ToString();
                    button.Tag = temp;
                }

                PlayBackMouseEvent();

                button.Enabled = true;
            }
        }

        private void Dgv_EventProcedure_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (sender is DataGridView dataGridView)
            {
                DataGridViewCell cell = dataGridView[e.ColumnIndex, e.RowIndex];
                if (cell.Value is null) { return; }
                string columnDataPropertyName = dataGridView.Columns[e.ColumnIndex].DataPropertyName;
                switch (columnDataPropertyName)
                {
                    case "WindowTitle":
                        if (Dic_HWNDTitlePairs.TryGetValue(cell.Value.ToString(), out IntPtr hwnd))
                        {
                            dataGridView.Rows[e.RowIndex].Cells[$"{dataGridView.Name}_HWND"].Value = hwnd;
                        }
                        break;
                    default:
                        break;
                }
            }
        }

        private void InitEventProcedure()
        {
            dgv_EventProcedure.Rows.Add(new object[] { "咸鱼之王", "", "WM_CLICK", "30", "340", "200" });
            dgv_EventProcedure.Rows.Add(new object[] { "咸鱼之王", "", "WM_CLICK", "140", "670", "200" });

            dgv_EventProcedure.Rows.Add(new object[] { "新誓记", "", "WM_CLICK", "1020", "230", "200" });
            dgv_EventProcedure.Rows.Add(new object[] { "新誓记", "", "WM_CLICK", "460", "530", "200" });
            dgv_EventProcedure.Rows.Add(new object[] { "新誓记", "", "WM_CLICK", "710", "475", "200" });
            dgv_EventProcedure.Rows.Add(new object[] { "新誓记", "", "WM_CLICK", "1020", "230", "200" });

            dgv_EventProcedure.Rows.Add(new object[] { "一战称王", "", "WM_CLICK", "990", "225", "200" });
            dgv_EventProcedure.Rows.Add(new object[] { "一战称王", "", "WM_CLICK", "400", "515", "200" });
            dgv_EventProcedure.Rows.Add(new object[] { "一战称王", "", "WM_CLICK", "675", "480", "200" });
            dgv_EventProcedure.Rows.Add(new object[] { "一战称王", "", "WM_CLICK", "990", "225", "200" });
            dgv_EventProcedure.Rows.Add(new object[] { "一战称王", "", "WM_CLICK", "855", "420", "200" });
            dgv_EventProcedure.Rows.Add(new object[] { "一战称王", "", "WM_CLICK", "865", "255", "200" });
            dgv_EventProcedure.Rows.Add(new object[] { "一战称王", "", "WM_CLICK", "655", "515", "200" });
            dgv_EventProcedure.Rows.Add(new object[] { "一战称王", "", "WM_CLICK", "300", "160", "200" });
            dgv_EventProcedure.Rows.Add(new object[] { "一战称王", "", "WM_CLICK", "655", "515", "200" });
            dgv_EventProcedure.Rows.Add(new object[] { "一战称王", "", "WM_CLICK", "865", "110", "200" });

            dgv_EventProcedure.Rows.Add(new object[] { "寒刃", "", "WM_CLICK", "1025", "215", "200" });
            dgv_EventProcedure.Rows.Add(new object[] { "寒刃", "", "WM_CLICK", "400", "515", "200" });
            dgv_EventProcedure.Rows.Add(new object[] { "寒刃", "", "WM_CLICK", "675", "475", "200" });
            dgv_EventProcedure.Rows.Add(new object[] { "寒刃", "", "WM_CLICK", "1025", "215", "200" });
            dgv_EventProcedure.Rows.Add(new object[] { "寒刃", "", "WM_CLICK", "855", "350", "200" });
            dgv_EventProcedure.Rows.Add(new object[] { "寒刃", "", "WM_CLICK", "860", "250", "200" });
            dgv_EventProcedure.Rows.Add(new object[] { "寒刃", "", "WM_CLICK", "655", "520", "200" });
            dgv_EventProcedure.Rows.Add(new object[] { "寒刃", "", "WM_CLICK", "280", "155", "200" });
            dgv_EventProcedure.Rows.Add(new object[] { "寒刃", "", "WM_CLICK", "655", "520", "200" });
            dgv_EventProcedure.Rows.Add(new object[] { "寒刃", "", "WM_CLICK", "865", "110", "200" });

            dgv_EventProcedure.EndEdit();
        }

        private void EventProcedure_新建ToolStripButton_Click(object sender, EventArgs e)
        {
            dgv_EventProcedure.Rows.Add();
        }

        private void EventProcedure_复制ToolStripButton_Click(object sender, EventArgs e)
        {
            DataGridViewRow dataGridRow = dgv_EventProcedure.Rows[dgv_EventProcedure.Rows.AddCopy(dgv_EventProcedure.CurrentRow.Index)];
            foreach (DataGridViewCell cell in dgv_EventProcedure.CurrentRow.Cells)
            {
                dataGridRow.Cells[cell.ColumnIndex].Value = cell.Value;
            }
        }

        private void EventProcedure_删除ToolStripButton_Click(object sender, EventArgs e)
        {
            dgv_EventProcedure.Rows.RemoveAt(dgv_EventProcedure.CurrentRow.Index);
        }

        #region 任务栏及消息通知

        /// <summary>
        /// 托盘图标
        /// </summary>
        private NotifyIcon Notify;

        private static bool exitTag = false;

        private void ShowNotifyTip(string tipText, string tipTitle = "提示", int timeout = 500, ToolTipIcon tipIcon = ToolTipIcon.Info)
        {
            Notify.ShowBalloonTip(timeout, tipTitle, tipText, tipIcon);
        }

        private void InitializeNotifyIcon()
        {
            Notify = new NotifyIcon()
            {
                Text = "工具箱",
                Visible = true,
                Icon = new Icon(Path.Combine(Path.GetDirectoryName(Process.GetCurrentProcess().MainModule.FileName), "appIcon.ico"))
            };

            Notify.ContextMenu = new ContextMenu(new MenuItem[] {
                new MenuItem("显示", (object sender, EventArgs e)=>
                {
                    ShowForm(0);
                }),
                new MenuItem("退出", (object sender, EventArgs e)=>
                {
                    exitTag = true;
                    Close();
                })
            });

            Notify.MouseClick += (object sender, MouseEventArgs e) =>
            {
                if (e.Button != MouseButtons.Right) { return; }
            };

            Notify.DoubleClick += (object sender, EventArgs e) =>
            {
                if (Visible) { return; }

                if (WindowState == FormWindowState.Minimized)
                {
                    ShowInTaskbar = true;
                    WindowState = FormWindowState.Maximized;

                    ShowForm(1);
                    Activate();
                }
            };
        }

        #endregion

        #region 全局热键注册

        /// <summary>
        /// 注册全局热键（需要重写消息处理函数WndProc处理WM_HOTKEY = 0x0312消息）
        /// </summary>
        /// <param name="hWnd">处理热键消息的窗体句柄</param>
        /// <param name="id">热键标识符：应用程序范围0X0000-0xBFFF，共享的动态链接库范围0xC000-0xFFFF，若在程序内注册同一ID值，则旧的热键被覆盖</param>
        /// <param name="fsModifiers">组合键类型</param>
        /// <param name="vk">热键按键的虚拟码</param>
        /// <returns></returns>
        [DllImport("user32.dll")]
        public static extern bool RegisterHotKey(IntPtr hWnd, int id, KeyModifiers fsModifiers, Keys vk);

        /// <summary>
        /// 释放之前注册的全局热键
        /// </summary>
        /// <param name="hWnd">窗体句柄，同RegisterHotKey的hWnd</param>
        /// <param name="id">热键标识符，同RegisterHotKey的id</param>
        /// <returns></returns>
        [DllImport("user32.dll")]
        public static extern bool UnregisterHotKey(IntPtr hWnd, int id);

        public enum KeyModifiers //组合键枚举
        {
            None = 0,
            Alt = 1,
            Control = 2,
            Shift = 4,
            Windows = 8
        }

        private const int WM_HOTKEY = 0x0312;
        protected override void WndProc(ref Message m)
        {
            if (m.Msg == WM_HOTKEY)
            {
                switch (m.WParam.ToInt32())
                {
                    case 998:
                        ShowForm(0.1, true);
                        break;
                    case 999:
                        if (Visible)
                        {
                            HideForm();
                        }
                        else
                        {
                            ShowForm(0);
                        }
                        break;
                    case 98:
                        if (Opacity < 1)
                        {
                            Opacity += 0.01;
                            textBox_Opacity.Text = (Opacity * 100).ToString();
                        }
                        break;
                    case 99:
                        if (Opacity > 0)
                        {
                            Opacity -= 0.1;
                            textBox_Opacity.Text = (Opacity * 100).ToString();
                        }
                        break;
                    case 100:
                        HackMouseEvent();
                        break;
                    case 101:
                    case 103:
                        EmbedApplication();
                        break;
                    case 102:
                    case 104:
                        CancelEmbedApplication(out _);
                        break;
                    default:
                        break;
                }
            }
            base.WndProc(ref m);
        }

        #endregion

        #region 获取应用程序句柄

        [DllImport("User32.dll", EntryPoint = "SendMessage")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, StringBuilder lParam);

        [DllImport("User32.dll", EntryPoint = "SendMessage")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        /// <summary>  
        /// 通过全屏幕坐标获取控件句柄,不获取隐藏或禁止的窗口句柄
        /// </summary>  
        /// <param name="p">屏幕坐标</param>  
        /// <returns>返回值为包含该点的窗口的句柄。如果包含指定点的窗口不存在，返回值为NULL。如果该点在静态文本控件之上，返回值是在该静态文本控件的下面的窗口的句柄。</returns>  
        [DllImport("user32.dll")]
        public static extern IntPtr WindowFromPoint(Point p);

        /// <summary>
        /// 通过相对父控件的坐标获取子控件句柄,可获取隐藏或禁止的窗口句柄
        /// </summary>
        /// <param name="hWndParent">父控件句柄</param>
        /// <param name="p">相对父控件的坐标</param>
        /// <returns>如果坐标在父控件以外返回NULL，如果坐标在父控件以内但坐标位置没有子控件则返回父控件本身句柄，如果坐标位置有子控件返回子控件的句柄</returns>
        [DllImport("user32.dll")]
        public static extern IntPtr ChildWindowFromPoint(IntPtr hWndParent, Point p);

        /// <summary>
        /// 将屏幕坐标转换为控件的相对坐标
        /// </summary>
        /// <param name="hWnd">控件句柄</param>
        /// <param name="lpPoint">引用坐标参数：使用前用屏幕坐标赋值，转换成功则变成控件相对坐标</param>
        /// <returns>是否成功</returns>
        [DllImport("user32.dll")]
        public static extern bool ScreenToClient(IntPtr hWnd, ref Point lpPoint);

        /// <summary>
        /// 获取窗口的父窗口句柄，如果是顶层窗口返回0
        /// </summary>
        /// <param name="hwnd">窗口句柄</param>
        /// <returns>父窗口句柄</returns>
        [DllImport("user32")]
        public static extern IntPtr GetParent(IntPtr hwnd);

        /// <summary>  
        /// 得到此控件的类名  
        /// </summary>  
        /// <param name="hWnd"></param>  
        /// <param name="classname">接收数据的要首先给出空间</param>  
        /// <param name="nlndex">所要取得的最大字符数，如果设置为0 则什么都没有</param>  
        /// <returns></returns>  
        [DllImport("user32.dll", EntryPoint = "GetClassName")]
        public static extern int GetClassName(IntPtr hWnd, StringBuilder lpClassName, int nMaxCount);

        /// <summary>
        /// 获取控件的名称（标题）
        /// </summary>
        /// <param name="hwnd">控件句柄</param>
        /// <param name="lpString">存储字符的对象</param>
        /// <param name="nMaxCount">获取字符的最大长度</param>
        /// <returns>返回字符字节长度（一个中文字符算2个）</returns>
        [DllImport("user32.dll")]
        public static extern int GetWindowText(IntPtr hwnd, StringBuilder lpString, int nMaxCount);

        /// <summary>
        /// 获取窗口的创建者（线程或进程）
        /// </summary>
        /// <param name="hWnd">窗口句柄</param>
        /// <param name="lpdwProcessId">进程ID</param>
        /// <returns>线程号</returns>
        [DllImport("user32.dll")]
        public static extern int GetWindowThreadProcessId(IntPtr hWnd, ref int lpdwProcessId);

        /// <summary>
        /// 获取窗体尺寸
        /// </summary>
        /// <param name="hWnd">窗口句柄</param>
        /// <param name="lpRect">窗体尺寸结构体</param>
        /// <returns></returns>
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GetWindowRect(IntPtr hWnd, ref RECT lpRect);

        /*

        RECT rect = new RECT();
        GetWindowRect(HackLastParentHwnd, ref rect);
        int x = rect.Left;
        int y = rect.Top;
        int width = rect.Right - rect.Left; //窗口的宽度
        int height = rect.Bottom - rect.Top; //窗口的高度 

        */

        /// <summary>
        /// 窗体尺寸结构体
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct RECT
        {
            public int Left; //最左坐标
            public int Top; //最上坐标
            public int Right; //最右坐标
            public int Bottom; //最下坐标
        }

        #region SetWindowPos

        /*

        //声明:
        SetWindowPos(
            hWnd: HWND;            {窗口句柄}
            hWndInsertAfter: HWND; {窗口的 Z 顺序}
            X, Y: Integer;         {位置}
            cx, cy: Integer;       {大小}
            uFlags: UINT           {选项}
        ): BOOL;

        //hWndInsertAfter 参数可选值:
        HWND_TOP       = 0;        {在前面}
        HWND_BOTTOM    = 1;        {在后面}
        HWND_TOPMOST   = HWND(-1); {在前面, 位于任何顶部窗口的前面}
        HWND_NOTOPMOST = HWND(-2); {在前面, 位于其他顶部窗口的后面}

        //uFlags 参数可选值:
        const short SWP_NOSIZE         = 1;    {忽略 cx、cy, 保持大小}
        const short SWP_NOMOVE         = 2;    {忽略 X、Y, 不改变位置}
        const short SWP_NOZORDER       = 4;    {忽略 hWndInsertAfter, 保持 Z 顺序}
        const short SWP_NOREDRAW       = 8;    {不重绘}
        const int SWP_NOACTIVATE     = 0x0010;  {不激活}
        const int SWP_FRAMECHANGED   = 0x0020;  {强制发送 WM_NCCALCSIZE 消息, 一般只是在改变大小时才发送此消息}
        const int SWP_DRAWFRAME      = SWP_FRAMECHANGED; {画边框}
        const int SWP_SHOWWINDOW     = 0x0040;  {显示窗口}
        const int SWP_HIDEWINDOW     = 0x0080;  {隐藏窗口}
        const int SWP_NOCOPYBITS     = 0x00100; {丢弃客户区}
        const int SWP_NOOWNERZORDER  = 0x00200; {忽略 hWndInsertAfter, 不改变 Z 序列的所有者}
        const int SWP_NOREPOSITION   = SWP_NOOWNERZORDER;{}
        const int SWP_NOSENDCHANGING = 0x00400; {不发出 WM_WINDOWPOSCHANGING 消息}
        const int SWP_DEFERERASE     = 0x002000;            {防止产生 WM_SYNCPAINT 消息}
        const int SWP_ASYNCWINDOWPOS = 0x004000;            {若调用进程不拥有窗口, 系统会向拥有窗口的线程发出需求}

        */

        [DllImport("user32.dll", CharSet = CharSet.Auto, EntryPoint = "SetWindowPos")]
        public static extern IntPtr SetWindowPos(IntPtr hWnd, int hWndInsertAfter, int x, int Y, int cx, int cy, int wFlags);

        #endregion

        //应用程序发送此消息来复制对应窗口的文本到缓冲区
        public static int WM_GETTEXT = 0x0D;
        //得到与一个窗口有关的文本的长度（不包含空字符）
        public static int WM_GETTEXTLENGTH = 0x0E;

        private bool HackIsRuning = false;
        private IntPtr HackLastHwnd = IntPtr.Zero;
        private IntPtr HackLastParentHwnd = IntPtr.Zero;
        private string HackLastParentTitle = string.Empty;
        private System.Threading.AutoResetEvent ResetEvent = new System.Threading.AutoResetEvent(true);

        private void EmbedApplication()
        {
            if (IntPtr.Zero.Equals(HackLastParentHwnd))
            {
                return;
            }

            if (Dic_HWNDTitlePairs.ContainsKey(HackLastParentTitle) || Dic_HWNDPairs.ContainsKey(HackLastParentHwnd))
            {
                return;
            }

            SetWindowPos(HackLastParentHwnd, 0, appContainer.Left, appContainer.Top, 0, 0, 1 | 4 | 8);

            Dic_HWNDTitlePairs.Add(HackLastParentTitle, HackLastParentHwnd);
            Dic_HWNDPairs.Add(HackLastParentHwnd, new IntPtr(SetParent(HackLastParentHwnd, appContainer.Handle)));
            dgv_EventProcedure_WindowTitle.Items.Add(HackLastParentTitle);

            foreach (DataGridViewRow dataRow in dgv_EventProcedure.Rows)
            {
                var cell = dataRow.Cells[$"{dgv_EventProcedure.Name}_HWND"];
                if (HackLastParentTitle.Equals(cell.Value))
                {
                    cell.Value = HackLastParentHwnd;
                    dataRow.Cells[$"{dgv_EventProcedure.Name}_WindowTitle"].Value = HackLastParentTitle;
                }
            }
        }

        private void CancelEmbedApplication(out bool successful)
        {
            if (Dic_HWNDTitlePairs.Count is 0 || Dic_HWNDPairs.Count is 0)
            {
                successful = false;
                return;
            }

            Dic_HWNDTitlePairs.TryGetValue(HackLastParentTitle, out IntPtr hwnd);
            Dic_HWNDPairs.TryGetValue(hwnd, out IntPtr parenthwnd);
            if (IntPtr.Zero.Equals(hwnd) || IntPtr.Zero.Equals(parenthwnd))
            {
                successful = false;
                return;
            }

            for (int i = 0; i < dgv_EventProcedure.Rows.Count; i++)
            {
                DataGridViewRow row = dgv_EventProcedure.Rows[i];
                var hwndCell = row.Cells[$"{dgv_EventProcedure.Name}_HWND"];
                if (hwndCell.Value.Equals(hwnd))
                {
                    var titleCell = row.Cells[$"{dgv_EventProcedure.Name}_WindowTitle"];
                    hwndCell.Value = titleCell.Value;
                    titleCell.Value = string.Empty;
                }
            }

            SetParent(hwnd, parenthwnd);

            Dic_HWNDPairs.Remove(hwnd);
            Dic_HWNDTitlePairs.Remove(HackLastParentTitle);
            dgv_EventProcedure_WindowTitle.Items.Remove(HackLastParentTitle);

            successful = true;
        }

        private void Bw_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker me = sender as BackgroundWorker;
            while (HackIsRuning)
            {
                ResetEvent.WaitOne();
                Point p = Cursor.Position;
                IntPtr hwnd = WindowFromPoint(p);//获取当前坐标位置的控件句柄（不能获取Disabled未激活的控件）
                ScreenToClient(hwnd, ref p);//将屏幕坐标转换为窗口客户区坐标
                IntPtr curHwnd = ChildWindowFromPoint(hwnd, p);//从当前坐标查找子控件（可获取Disabled未激活的控件）.如果没有则返回自己,如果在控件客户区以外返回0
                if (curHwnd == IntPtr.Zero)
                {
                    curHwnd = hwnd;
                }

                if (curHwnd != HackLastHwnd)
                {
                    me.ReportProgress(1, curHwnd);
                }
                else
                {
                    me.ReportProgress(2);
                }

                System.Threading.Thread.Sleep(200);
            }

            me.ReportProgress(100);//线程结束
        }

        private void Bw_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            Text = $"坐标：X={Cursor.Position.X}, Y={Cursor.Position.Y}";
            if (e.ProgressPercentage == 1)
            {
                HackLastHwnd = (IntPtr)e.UserState;
                textBox_ControlHwnd.Text = HackLastHwnd.ToString(); // hwnd.ToString("X8")
                StringBuilder sb = new StringBuilder(SendMessage(HackLastHwnd, WM_GETTEXTLENGTH, 0, 0));
                SendMessage(HackLastHwnd, WM_GETTEXT, sb.Capacity, sb);
                textBox_ControlText.Text = sb.ToString();

                HackLastParentHwnd = GetParent(HackLastHwnd);
                if (IntPtr.Zero.Equals(HackLastParentHwnd))
                {
                    textBox_ParentControlTitle.Text = "";
                    textBox_ParentControlHandle.Text = "";
                }
                else
                {
                    textBox_ParentControlHandle.Text = HackLastParentHwnd.ToString();

                    GetWindowText(HackLastParentHwnd, sb, sb.Capacity);
                    HackLastParentTitle = textBox_ParentControlTitle.Text = sb.ToString();
                }
            }
            else if (e.ProgressPercentage == 100)
            {
                btnRecord.Text = "开始捕捉(Alt+S)";//等线程处理结束后再切换状态，防止按键过快导致线程没能及时退出。
            }

            ResetEvent.Set();
        }

        #endregion

        #region 向窗口发送消息事件

        #region SendMessage向窗口发送消息事件

        #region 向窗口发送文字（输入文字）

        /// <summary>
        /// 发送文本到窗口句柄(或控件)
        /// </summary>
        /// <param name="hWnd"></param>
        /// <param name="text"></param>
        public static void SendText(IntPtr hWnd, string text)
        {
            SendMessage(hWnd, WM_SETTEXT, IntPtr.Zero, text);
        }

        const int WM_SETTEXT = 0x000C;
        [DllImport("User32.dll", EntryPoint = "SendMessage")]
        private static extern int SendMessage(IntPtr hWnd, uint Msg, IntPtr wParam, string lParam);

        #endregion

        #region 向窗口发送键盘按键、发送回车键

        /// <summary>
        /// 发送回车键(Enter)到窗口(或控件)
        /// </summary>
        /// <param name="hWnd"></param>
        public static void SendEnter(IntPtr hWnd)
        {
            SendMessage(hWnd, WM_CHAR, VK_ENTER, 0);
        }

        /// <summary>
        /// 发送键盘按键到窗口(或控件)
        /// </summary>
        /// <param name="hWnd"></param>
        /// <param name="keyValue">按键的数字值KeyValue</param>
        public static void SendKey(IntPtr hWnd, uint keyValue)
        {
            SendMessage(hWnd, WM_CHAR, keyValue, 0);
        }

        const int WM_CHAR = 0x0102;
        const uint VK_ENTER = 0x0D; // 13 Enter键

        [DllImport("User32.dll", EntryPoint = "SendMessage")]
        private static extern int SendMessage(IntPtr hWnd, uint Msg, uint wParam, uint lParam);

        [DllImport("User32.dll", EntryPoint = "PostMessage")]
        private static extern int PostMessage(IntPtr hWnd, uint Msg, uint wParam, uint lParam);

        #endregion

        #region 向窗口发送鼠标事件

        /// <summary>
        /// 发送点击事件
        /// </summary>
        /// <param name="hwnd">控件句柄</param>
        public static void SendClick(IntPtr hwnd)
        {
            SendMessage(hwnd, WM_CLICK, 0, 0);
        }

        /// <summary>
        /// 发送点击事件
        /// </summary>
        /// <param name="hwnd">控件句柄</param>
        /// <param name="x">鼠标位置x</param>
        /// <param name="y">鼠标位置y</param>
        public static void SendClick(IntPtr hwnd, int X, int Y)
        {
            int lparm = (Y << 16) + X;
            SendMessage(hwnd, WM_CLICK, 0, lparm);
        }

        [DllImport("user32.dll", EntryPoint = "SendMessage")]
        private static extern int SendMessage(IntPtr hWnd, uint Msg, int wParam, int lParam);

        [DllImport("user32.dll", EntryPoint = "PostMessage")]
        private static extern int PostMessage(IntPtr hWnd, uint Msg, int wParam, int lParam);

        /// <summary>
        /// 点击消息
        /// </summary>
        const uint WM_CLICK = 0xF5;

        /// <summary>
        /// 发送鼠标点击事件，包含MouseDown和MouseUp
        /// </summary>
        /// <param name="hwnd">控件句柄</param>
        /// <param name="x">鼠标位置x</param>
        /// <param name="y">鼠标位置y</param>
        public static void SendMouseClick(IntPtr hwnd, int X, int Y)
        {
            int lparm = (Y << 16) + X;
            int lngResult = PostMessage(hwnd, WM_LBUTTONDOWN, 0, lparm);
            int lngResult2 = PostMessage(hwnd, WM_LBUTTONUP, 0, lparm);
        }

        /// <summary>
        /// 鼠标按下
        /// </summary>
        const uint WM_LBUTTONDOWN = 0x0201;
        /// <summary>
        /// 鼠标抬起
        /// </summary>
        const uint WM_LBUTTONUP = 0x0202;

        #endregion

        #endregion

        #endregion

        #region 窗体嵌入

        [DllImport("user32.dll", SetLastError = true)]
        private static extern long SetParent(IntPtr hWndChild, IntPtr hWndNewParent);

        [DllImport("user32.dll", EntryPoint = "SetWindowLong", SetLastError = true)]
        private static extern uint SetWindowLong(IntPtr hwnd, int nIndex, uint dwNewLong);

        private const int GWL_STYLE = -16;
        private const int WS_VISIBLE = 0x10000000;

        private readonly Dictionary<IntPtr, IntPtr> Dic_HWNDPairs = new Dictionary<IntPtr, IntPtr>(4);
        private readonly Dictionary<string, IntPtr> Dic_HWNDTitlePairs = new Dictionary<string, IntPtr>(4);

        private void InitAppContainer()
        {
            appContainer.Name = "appBox";
            appContainer.Dock = DockStyle.Fill;
            appContainer.TabStop = false;
            appContainer.AppProcess = null;
            appContainer.AppFilename = string.Empty;
            appContainer.ShowEmbedResult = false;
            splitContainer_Main.Panel2.Controls.Add(appContainer);
        }

        private void EmbedApplication(ref int hwnd, out IntPtr embedHWND, out IntPtr parentHWND)
        {
            embedHWND = new IntPtr(hwnd);
            parentHWND = new IntPtr(SetParent(embedHWND, appContainer.Handle));
            //Win32API.SetWindowLong(new HandleRef(appContainer, EmbedHWND), GWL_STYLE, WS_VISIBLE);
        }

        private void CancelEmbedApplication()
        {
            if (Dic_HWNDPairs.Count is 0) { return; }
            foreach (KeyValuePair<IntPtr, IntPtr> pair in Dic_HWNDPairs)
            {
                SetParent(pair.Key, pair.Value);
            }

            Dic_HWNDPairs.Clear();
            Dic_HWNDTitlePairs.Clear();
            dgv_EventProcedure.Rows.Clear();
            dgv_EventProcedure_WindowTitle.Items.Clear();
        }

        private void SimulateMouseWithKeyboardInput()
        {
            foreach (KeyValuePair<IntPtr, Point[]> pair in Dic_MousePoints)
            {
                foreach (Point point in pair.Value)
                {
                    System.Threading.Thread.Sleep(200);
                    SendMouseClick(pair.Key, point.X, point.Y);
                }
            }
        }

        private bool isOnPlayback = false;
        private bool isOnRecurrentPlay = true;
        private Dictionary<IntPtr, Point[]> Dic_MousePoints;

        private void PlayBackMouseEvent()
        {
            if (isOnPlayback) { return; }
            isOnPlayback = true;

            if (!isOnRecurrentPlay)
            {
                isOnRecurrentPlay = true;
                return;
            }

            if (Dic_HWNDPairs.Count is 0) { isOnPlayback = false; return; }
            if (dgv_EventProcedure.Rows.Count is 0) { isOnPlayback = false; return; }

            dgv_EventProcedure.EndEdit();
            Dic_MousePoints = new Dictionary<IntPtr, Point[]>(Dic_HWNDPairs.Count);
            foreach (IntPtr hwnd in Dic_HWNDPairs.Keys)
            {
                List<Point> mousePoints = new List<Point>();
                for (int i = 0; i < dgv_EventProcedure.Rows.Count; i++)
                {
                    DataGridViewCellCollection cells = dgv_EventProcedure.Rows[i].Cells;
                    if (hwnd.ToString().Equals(cells[$"{dgv_EventProcedure.Name}_Hwnd"].Value.ToString()))
                    {
                        int.TryParse(cells[$"{dgv_EventProcedure.Name}_X"].Value.ToString(), out int mouseX);
                        int.TryParse(cells[$"{dgv_EventProcedure.Name}_Y"].Value.ToString(), out int mouseY);
                        mousePoints.Add(new Point(mouseX, mouseY));
                    }
                }

                if (mousePoints.Count is 0) { continue; }
                Dic_MousePoints.Add(hwnd, mousePoints.ToArray());
            }

            if (Dic_MousePoints.Count < 0) { isOnPlayback = false; return; }

            SimulateMouseWithKeyboardInput();
            if (!checkBox_LoopPlay.Checked)
            {
                isOnPlayback = false;
                return;
            }

            int.TryParse(textBox_WaitTime.Text, out int waitTime);
            if (waitTime <= 0)
            {
                isOnPlayback = false;
                return;
            }

            isOnRecurrentPlay = false;
            Timer timer = new Timer()
            {
                Interval = (int)TimeSpan.FromSeconds(waitTime).TotalMilliseconds,
            };
            timer.Tick += (timerObject, eventArgs) =>
            {
                if (isOnRecurrentPlay)
                {
                    (timerObject as Timer).Stop();
                    isOnPlayback = false;
                    return;
                }
                SimulateMouseWithKeyboardInput();
            };
            timer.Start();
        }

        #endregion
    }
}