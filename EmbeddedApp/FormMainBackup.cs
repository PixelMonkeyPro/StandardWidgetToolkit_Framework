using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using Gma.System.MouseKeyHook;
using Loamen.KeyMouseHook;

namespace EmbeddedApp
{
    public partial class FormMainBackup : Form
    {
        private AppContainer appContainer = new AppContainer();

        public FormMainBackup()
        {
            InitializeComponent();

            InitAppContainer();
            //InitKeyMouseHook();
            //Application.Idle += Application_Idle;
        }

        void Application_Idle(object sender, EventArgs e)
        {
            if (appContainer.IsStarted)
            {
                if (!appContainer.AppProcess.HasExited)
                {

                }
            }
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            //火祭
            dgv_EventProcedure.Rows.Add(new object[] { "1", "WM_CLICK", "1000", "550", "200" });
            dgv_EventProcedure.Rows.Add(new object[] { "1", "WM_CLICK", "515", "400", "200" });
            dgv_EventProcedure.Rows.Add(new object[] { "1", "WM_CLICK", "900", "120", "200" });
            //回收
            dgv_EventProcedure.Rows.Add(new object[] { "1", "WM_CLICK", "1000", "215", "200" });
            dgv_EventProcedure.Rows.Add(new object[] { "1", "WM_CLICK", "400", "515", "200" });
            dgv_EventProcedure.Rows.Add(new object[] { "1", "WM_CLICK", "680", "480", "200" });
            dgv_EventProcedure.Rows.Add(new object[] { "1", "WM_CLICK", "1000", "215", "200" });
            //聚宝盆
            dgv_EventProcedure.Rows.Add(new object[] { "1", "WM_CLICK", "220", "300", "200" });
            dgv_EventProcedure.Rows.Add(new object[] { "1", "WM_CLICK", "690", "460", "200" });

            dgv_EventProcedure.EndEdit();
        }

        private void FormMain_Resize(object sender, EventArgs e)
        {
            var app = appContainer.AppProcess;
            if (app == null) { return; }

            var c = FromHandle(app.MainWindowHandle);
            var f = c as Form;
            if (f != null)
            {
                Console.WriteLine(f.Parent == null);
            }
        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (eventHookFactory != null)
            {
                eventHookFactory.Dispose();
            }

            CancelEmbedApplication();
        }

        #region 向窗口发送消息事件

        private void 测试点击ToolStripButton_Click(object sender, EventArgs e)
        {
            SendTextMouseEvent();
        }

        private void SendTextMouseEvent()
        {
            int.TryParse(鼠标XToolStripTextBox.Text, out int mouseX);
            int.TryParse(鼠标YToolStripTextBox.Text, out int mouseY);
            SendMouseClick(EmbedHWND, mouseX, mouseY);
        }

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

        #region 向窗口发送关闭指令

        public static void CloseWindow(IntPtr hwnd)
        {
            SendMessage(hwnd, WM_CLOSE, 0, 0);
        }
        const int WM_CLOSE = 0x0010;

        #endregion

        #endregion

        #endregion

        #region 窗体嵌入

        [DllImport("user32.dll", SetLastError = true)]
        private static extern long SetParent(IntPtr hWndChild, IntPtr hWndNewParent);

        //[DllImport("user32.dll", EntryPoint = "SetWindowLongA", SetLastError = true, CallingConvention = CallingConvention.Cdecl)]
        //private static extern long SetWindowLong(IntPtr hwnd, int nIndex, long dwNewLong);
        [DllImport("user32", EntryPoint = "SetWindowLong", SetLastError = true)]
        private static extern uint SetWindowLong(IntPtr hwnd, int nIndex, uint dwNewLong);

        private const int GWL_STYLE = -16;
        private const int WS_VISIBLE = 0x10000000;

        private static IntPtr EmbedHWND = IntPtr.Zero;
        private static IntPtr OriginalParentHWND = IntPtr.Zero;

        void InitAppContainer()
        {
            appContainer.Name = "appBox";
            appContainer.Dock = DockStyle.Fill;
            appContainer.TabStop = false;
            appContainer.AppProcess = null;
            appContainer.AppFilename = string.Empty;
            appContainer.ShowEmbedResult = false;
            splitContainer_Main.Panel2.Controls.Add(appContainer);
        }

        void EmbedApplication()
        {
            OriginalParentHWND = new IntPtr(SetParent(EmbedHWND, appContainer.Handle));
            //Win32API.SetWindowLong(new HandleRef(appContainer, EmbedHWND), GWL_STYLE, WS_VISIBLE);
        }

        void CancelEmbedApplication()
        {
            if (IntPtr.Zero.Equals(EmbedHWND)) { return; }
            if (IntPtr.Zero.Equals(OriginalParentHWND)) { return; }
            SetParent(EmbedHWND, OriginalParentHWND);
        }

        private static Point[] MousePoints = new Point[0];
        private void 模拟事件ToolStripButton_Click(object sender, EventArgs e)
        {
            if (IntPtr.Zero.Equals(EmbedHWND)) { return; }
            MousePoints = new Point[dgv_EventProcedure.Rows.Count];
            for (int i = 0; i < dgv_EventProcedure.Rows.Count; i++)
            {
                DataGridViewRow row = dgv_EventProcedure.Rows[i];
                int.TryParse(row.Cells[$"{dgv_EventProcedure.Name}_X"].Value.ToString(), out int mouseX);
                int.TryParse(row.Cells[$"{dgv_EventProcedure.Name}_Y"].Value.ToString(), out int mouseY);
                MousePoints[i] = new Point(mouseX, mouseY);
            }
            if (MousePoints.Length < 0) { return; }

            if (sender is ToolStripButton button)
            {
                if (button.Checked)
                {
                    isLoopStopPlay = true;
                    button.Enabled = false;
                }
                else
                {
                    isLoopStopPlay = false;
                    button.Checked = true;
                    if (checkBox_LoopPlay.Checked)
                    {
                        int.TryParse(textBox_WaitTime.Text, out int waitTime);
                        if (waitTime > 0)
                        {
                            Timer timer = new Timer()
                            {
                                Interval = (int)TimeSpan.FromSeconds(waitTime).TotalMilliseconds,
                            };
                            timer.Tick += (timerObject, eventArgs) =>
                            {
                                if (isLoopStopPlay)
                                {
                                    (timerObject as Timer).Stop();
                                    button.Enabled = true;
                                    button.Checked = false;
                                    return;
                                }
                                SimulateMouseWithKeyboardInput();
                            };
                            timer.Start();
                            return;
                        }
                    }
                    SimulateMouseWithKeyboardInput();
                    button.Enabled = true;
                    button.Checked = false;
                }
            }
        }

        private static void SimulateMouseWithKeyboardInput()
        {
            foreach (Point point in MousePoints)
            {
                System.Threading.Thread.Sleep(1000);
                SendMouseClick(EmbedHWND, point.X, point.Y);
            }
        }

        private void 句柄嵌入ToolStripTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar != 13) { return; }
            if (sender is ToolStripTextBox textBox)
            {
                if (string.IsNullOrWhiteSpace(textBox.Text)) { return; }
                if (int.TryParse(textBox.Text, out int intPtr))
                {
                    EmbedHWND = (IntPtr)intPtr;
                    EmbedApplication();
                }
            }
        }

        private void 取消嵌入ToolStripButton_Click(object sender, EventArgs e)
        {
            CancelEmbedApplication();
        }

        #endregion

        #region 鼠标键盘监听

        private readonly KeyMouseFactory eventHookFactory = new KeyMouseFactory(Hook.GlobalEvents());
        private KeyboardWatcher keyboardWatcher;
        private MouseWatcher mouseWatcher;
        private List<MacroEvent> _macroEvents;

        private bool isRecording = false;
        private bool isLoopStopPlay = false;

        private void InitKeyMouseHook()
        {
            keyboardWatcher = eventHookFactory.GetKeyboardWatcher();
            keyboardWatcher.OnKeyboardInput += (s, e) =>
            {
                if (_macroEvents != null)
                {
                    _macroEvents.Add(e);
                }

                if (e.KeyMouseEventType == MacroEventType.KeyPress)
                {
                    var keyEvent = (KeyPressEventArgs)e.EventArgs;
                    Log(string.Format("Key {0}\t\t{1}\n", keyEvent.KeyChar, e.KeyMouseEventType));
                }
                else
                {
                    var keyEvent = (KeyEventArgs)e.EventArgs;
                    Log(string.Format("Key {0}\t\t{1}\n", keyEvent.KeyCode, e.KeyMouseEventType));
                }
            };

            mouseWatcher = eventHookFactory.GetMouseWatcher();
            mouseWatcher.OnMouseInput += (s, e) =>
            {
                if (_macroEvents != null)
                {
                    _macroEvents.Add(e);
                }
                switch (e.KeyMouseEventType)
                {
                    case MacroEventType.MouseMove:
                        var mouseEvent = (MouseEventArgs)e.EventArgs;
                        LogMouseLocation(mouseEvent.X, mouseEvent.Y);
                        break;
                    case MacroEventType.MouseWheel:
                        mouseEvent = (MouseEventArgs)e.EventArgs;
                        LogMouseWheel(mouseEvent.Delta);
                        break;
                    case MacroEventType.MouseClick:
                    case MacroEventType.MouseDown:
                    case MacroEventType.MouseUp:
                        mouseEvent = (MouseEventArgs)e.EventArgs;
                        Log(string.Format("Mouse {0}\t\t{1}\n", mouseEvent.Button, e.KeyMouseEventType));
                        break;
                    case MacroEventType.MouseDownExt:
                        MouseEventExtArgs downExtEvent = (MouseEventExtArgs)e.EventArgs;
                        if (downExtEvent.Button != MouseButtons.Right)
                        {
                            Log(string.Format("Mouse Down \t\t {0}\n", downExtEvent.Button));
                            return;
                        }
                        Log(string.Format("Mouse Down \t\t {0} Suppressed\n", downExtEvent.Button));
                        downExtEvent.Handled = true;
                        break;
                    case MacroEventType.MouseWheelExt:
                        MouseEventExtArgs wheelEvent = (MouseEventExtArgs)e.EventArgs;
                        labelWheel.Text = string.Format("Wheel={0:000}", wheelEvent.Delta);
                        Log("Mouse Wheel Move Suppressed.\n");
                        wheelEvent.Handled = true;
                        break;
                }
            };
        }

        public void StartWatch(IKeyboardMouseEvents events = null)
        {
            _macroEvents = new List<MacroEvent>();
            keyboardWatcher.Start(events);
            mouseWatcher.Start(events);
        }

        public void StopWatch()
        {
            keyboardWatcher.Stop();
            mouseWatcher.Stop();
        }

        private void OnPlayback(object sender, MacroEvent e)
        {
            switch (e.KeyMouseEventType)
            {
                case MacroEventType.MouseMove:
                    var mouseEvent = (MouseEventArgs)e.EventArgs;
                    LogMouseLocation(mouseEvent.X, mouseEvent.Y);
                    break;
                case MacroEventType.MouseWheel:
                    mouseEvent = (MouseEventArgs)e.EventArgs;
                    LogMouseWheel(mouseEvent.Delta);
                    break;
                case MacroEventType.MouseDown:
                case MacroEventType.MouseUp:
                    mouseEvent = (MouseEventArgs)e.EventArgs;
                    Log(string.Format("Mouse {0}\t\t{1}\t\tSimulator\n", mouseEvent.Button, e.KeyMouseEventType));
                    break;
                case MacroEventType.MouseDownExt:
                    MouseEventExtArgs downExtEvent = (MouseEventExtArgs)e.EventArgs;
                    if (downExtEvent.Button != MouseButtons.Right)
                    {
                        Log(string.Format("Mouse Down \t {0}\t\t\tSimulator\n", downExtEvent.Button));
                        return;
                    }
                    Log(string.Format("Mouse Down \t {0} Suppressed.\t\tSimulator\n", downExtEvent.Button));
                    downExtEvent.Handled = true;
                    break;
                case MacroEventType.MouseWheelExt:
                    MouseEventExtArgs wheelEvent = (MouseEventExtArgs)e.EventArgs;
                    labelWheel.Text = string.Format("Wheel={0:000}", wheelEvent.Delta);
                    Log("Mouse Wheel Move Suppressed.\t\tSimulator\n");
                    wheelEvent.Handled = true;
                    break;
                case MacroEventType.MouseDragStarted:
                    Log("MouseDragStarted\t\tSimulator\n");
                    break;
                case MacroEventType.MouseDragFinished:
                    Log("MouseDragFinished\t\tSimulator\n");
                    break;
                case MacroEventType.MouseDoubleClick:
                    mouseEvent = (MouseEventArgs)e.EventArgs;
                    Log(string.Format("Mouse {0}\t\t{1}\t\tSimulator\n", mouseEvent.Button, e.KeyMouseEventType));
                    break;
                case MacroEventType.KeyPress:
                    var keyEvent = (KeyPressEventArgs)e.EventArgs;
                    Keys key = (Keys)Enum.Parse(typeof(Keys), ((int)Char.ToUpper(keyEvent.KeyChar)).ToString());
                    Log(string.Format("Key {0}\t\t{1}\t\tSimulator\n", key, e.KeyMouseEventType));
                    break;
                case MacroEventType.KeyDown:
                case MacroEventType.KeyUp:
                    var kEvent = (KeyEventArgs)e.EventArgs;
                    Log(string.Format("Key {0}\t\t{1}\t\tSimulator\n", kEvent.KeyCode, e.KeyMouseEventType));
                    break;
                default:
                    break;
            }
        }

        private void Log(string text)
        {
            dgv_EventProcedure.Rows.Add(dgv_EventProcedure.Rows.Count + 1, text, string.Empty, string.Empty);
        }

        private void LogMouseWheel(int Delta)
        {
            labelWheel.Text = string.Format("Wheel={0:000}", Delta);
        }

        private void LogMouseLocation(int X, int Y)
        {
            labelMousePosition.Text = string.Format("x={0:0000}; y={1:0000}", X, Y);
        }

        private void LogMouseLocation(Point location)
        {
            labelMousePosition.Text = string.Format($"X={location.X}; Y={location.Y}");
        }

        private void Button_Record_Click(object sender, EventArgs e)
        {
            if (!isRecording)
            {
                if (radioApplication.Checked)
                {
                    StartWatch(Hook.AppEvents());
                }
                else if (radioGlobal.Checked)
                {
                    StartWatch(Hook.GlobalEvents());
                }

                isRecording = true;
                btnRecord.Text = "Stop";
            }
            else
            {
                StopWatch();
                isRecording = false;
                btnRecord.Text = "Record";
                if (_macroEvents != null && _macroEvents.Count > 0)
                {
                    btnPlayback.Enabled = true;
                }
            }
        }

        private void BtnPlayback_Click(object sender, EventArgs e)
        {
            if (_macroEvents.Count < 0) { return; }

            if ("StopPlay".Equals(btnPlayback.Text))
            {
                isLoopStopPlay = true;
            }
            else
            {
                btnPlayback.Text = "StopPlay";

                InputSimulator sim = new InputSimulator();
                //sim.OnPlayback += OnPlayback;

                if (checkBox_LoopPlay.Checked)
                {
                    int.TryParse(textBox_WaitTime.Text, out int waitTime);
                    if (waitTime > 0)
                    {
                        Timer timer = new Timer()
                        {
                            Interval = (int)TimeSpan.FromMinutes(1).TotalMilliseconds,
                        };
                        timer.Tick += (timerObject, eventArgs) =>
                        {
                            if (isLoopStopPlay)
                            {
                                (timerObject as Timer).Stop();
                                btnPlayback.Text = "Playback";
                                return;
                            }
                            sim.PlayBack(_macroEvents);
                        };
                        timer.Start();
                        return;
                    }
                }
                sim.PlayBack(_macroEvents);
                btnPlayback.Text = "Playback";
            }
        }

        private void Radio_CheckedChanged(object sender, EventArgs e)
        {
            if (sender is RadioButton radio)
            {
                if (radio.Name.Equals(radioNone.Name))
                {
                    if (radio.Checked)
                    {
                        StopWatch();
                        isRecording = false;
                        btnRecord.Text = "Record";
                        if (_macroEvents != null && _macroEvents.Count > 0)
                        {
                            btnPlayback.Enabled = true;
                        }
                    }
                }
            }
        }

        private void CheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (eventHookFactory.KeyboardMouseEvents == null) { return; }
            if (sender is CheckBox check)
            {
                if (check.Name.Equals(checkBoxSupressMouse))
                {
                    mouseWatcher.SupressMouse(check.Checked, MacroEventType.MouseDown);
                }
                else if (check.Name.Equals(checkBoxSupressMouseWheel))
                {
                    mouseWatcher.SupressMouse(check.Checked, MacroEventType.MouseWheel);
                }
            }
        }

        #endregion

        private void EventProcedure_新建ToolStripButton_Click(object sender, EventArgs e)
        {
            dgv_EventProcedure.Rows.Add();
        }

        private void EventProcedure_复制ToolStripButton_Click(object sender, EventArgs e)
        {
            dgv_EventProcedure.Rows.AddCopy(dgv_EventProcedure.CurrentRow.Index);
        }

        private void EventProcedure_删除ToolStripButton_Click(object sender, EventArgs e)
        {
            dgv_EventProcedure.Rows.RemoveAt(dgv_EventProcedure.CurrentRow.Index);
        }
    }
}