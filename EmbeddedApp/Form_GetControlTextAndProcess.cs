using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EmbeddedApp
{
    public partial class Form_GetControlTextAndProcess : Form
    {
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

        //应用程序发送此消息来复制对应窗口的文本到缓冲区
        public static int WM_GETTEXT = 0x0D;
        //得到与一个窗口有关的文本的长度（不包含空字符）
        public static int WM_GETTEXTLENGTH = 0x0E;

        bool isRuning = false;
        IntPtr lastHwnd = IntPtr.Zero;
        System.Threading.AutoResetEvent resetEvent = new System.Threading.AutoResetEvent(true);
        string title = "";

        public Form_GetControlTextAndProcess()
        {
            InitializeComponent();
            Load += Form1_Load;
            FormClosing += Form1_FormClosing;
            title = $"{Text}  -  ";
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            changeState();
            bool r = RegisterHotKey(Handle, 100, KeyModifiers.Alt, Keys.S);
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            UnregisterHotKey(Handle, 100);
        }
        protected override void WndProc(ref Message m)
        {
            const int WM_HOTKEY = 0x0312;
            if (m.Msg == WM_HOTKEY)
            {
                switch (m.WParam.ToInt32())
                {
                    case 100:
                        changeState();
                        break;
                    default:
                        break;
                }
            }
            base.WndProc(ref m);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            changeState();
        }
        private void changeState()
        {
            if (button1.Text.StartsWith("停止捕捉"))
            {
                isRuning = false;
            }
            else
            {
                isRuning = true;
                button1.Text = "停止捕捉(Alt+S)";
                BackgroundWorker bw = new BackgroundWorker();
                bw.DoWork += Bw_DoWork;
                bw.ProgressChanged += Bw_ProgressChanged;
                bw.WorkerReportsProgress = true;
                bw.RunWorkerAsync();
            }
        }

        private void Bw_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            Text = title + string.Format("坐标：X={0},Y={1}", Cursor.Position.X, Cursor.Position.Y);
            if (e.ProgressPercentage == 1)
            {
                IntPtr hwnd = (IntPtr)e.UserState;
                textBox_cHandle.Text = hwnd.ToString(); // hwnd.ToString("X8")
                int len = SendMessage(hwnd, WM_GETTEXTLENGTH, 0, 0);
                StringBuilder sb = new StringBuilder(len + 1);
                SendMessage(hwnd, WM_GETTEXT, sb.Capacity, sb);
                textBox_cText.Text = sb.ToString();

                sb = new StringBuilder(255);
                len = GetClassName(hwnd, sb, sb.Capacity);
                textBox_cClassName.Text = sb.ToString();

                IntPtr pHwnd = GetParent(hwnd);
                if (pHwnd != IntPtr.Zero)
                {
                    textBox_pHandle.Text = pHwnd.ToString();
                    sb.Clear();
                    len = GetWindowText(pHwnd, sb, sb.Capacity);
                    textBox_pTitle.Text = sb.ToString();
                    sb.Clear();
                    len = GetClassName(pHwnd, sb, sb.Capacity);
                    textBox_pClassName.Text = sb.ToString();
                }
                else
                {
                    textBox_pHandle.Text = "";
                    textBox_pTitle.Text = "";
                    textBox_pClassName.Text = "";
                }
                int pID = 0;
                int threadID = GetWindowThreadProcessId(hwnd, ref pID);
                textBox_id.Text = pID.ToString();
                textBox_description.Text = ""; textBox_fileName.Text = ""; textBox_Company.Text = "";
                try
                {
                    System.Diagnostics.Process process = System.Diagnostics.Process.GetProcessById(pID);
                    if (process != null)
                    {
                        textBox_fileName.Text = process.MainModule.FileName;
                        System.Diagnostics.FileVersionInfo info = System.Diagnostics.FileVersionInfo.GetVersionInfo(process.MainModule.FileName);
                        textBox_description.Text = info.FileDescription;
                        textBox_Company.Text = info.LegalCopyright;
                    }
                }
                catch { }
            }
            else if (e.ProgressPercentage == 100)
                button1.Text = "开始捕捉(Alt+S)";//等线程处理结束后再切换状态，防止按键过快导致线程没能及时退出。

            resetEvent.Set();
        }

        private void Bw_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker me = sender as BackgroundWorker;
            while (isRuning)
            {
                resetEvent.WaitOne();
                Point p = Cursor.Position;
                IntPtr hwnd = WindowFromPoint(p);//获取当前坐标位置的控件句柄（不能获取Disabled未激活的控件）
                ScreenToClient(hwnd, ref p);//将屏幕坐标转换为窗口客户区坐标
                IntPtr curHwnd = ChildWindowFromPoint(hwnd, p);//从当前坐标查找子控件（可获取Disabled未激活的控件）.如果没有则返回自己,如果在控件客户区以外返回0
                if (curHwnd == IntPtr.Zero)
                    curHwnd = hwnd;
                if (curHwnd != lastHwnd)
                {

                    me.ReportProgress(1, curHwnd);
                    lastHwnd = curHwnd;
                }
                else
                    me.ReportProgress(2);
                System.Threading.Thread.Sleep(200);
            }

            me.ReportProgress(100);//线程结束
        }
    }
}
