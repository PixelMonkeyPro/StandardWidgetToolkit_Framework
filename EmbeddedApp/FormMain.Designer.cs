
namespace EmbeddedApp
{
    partial class FormMain
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.splitContainer_MainLeft = new System.Windows.Forms.SplitContainer();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.checkBox_GlobalHotKey = new System.Windows.Forms.CheckBox();
            this.textBox_ParentControlTitle = new System.Windows.Forms.TextBox();
            this.checkBox_Opacity = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_ParentControlHandle = new System.Windows.Forms.TextBox();
            this.textBox_ControlHwnd = new System.Windows.Forms.TextBox();
            this.textBox_ControlText = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.checkBox_LoopPlay = new System.Windows.Forms.CheckBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnPlayback = new System.Windows.Forms.Button();
            this.btnRecord = new System.Windows.Forms.Button();
            this.textBox_WaitTime = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox_Opacity = new System.Windows.Forms.TextBox();
            this.checkBox_Nontransparent = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.EventProcedure_新建ToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.EventProcedure_删除ToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.EventProcedure_复制ToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.dgv_EventProcedure = new System.Windows.Forms.DataGridView();
            this.dgv_EventProcedure_HWND = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgv_EventProcedure_WindowTitle = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.dgv_EventProcedure_Action = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.dgv_EventProcedure_X = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgv_EventProcedure_Y = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgv_EventProcedure_Delay = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.splitContainer_Main = new System.Windows.Forms.SplitContainer();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer_MainLeft)).BeginInit();
            this.splitContainer_MainLeft.Panel1.SuspendLayout();
            this.splitContainer_MainLeft.Panel2.SuspendLayout();
            this.splitContainer_MainLeft.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_EventProcedure)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer_Main)).BeginInit();
            this.splitContainer_Main.Panel1.SuspendLayout();
            this.splitContainer_Main.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer_MainLeft
            // 
            this.splitContainer_MainLeft.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer_MainLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer_MainLeft.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer_MainLeft.IsSplitterFixed = true;
            this.splitContainer_MainLeft.Location = new System.Drawing.Point(0, 0);
            this.splitContainer_MainLeft.Name = "splitContainer_MainLeft";
            this.splitContainer_MainLeft.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer_MainLeft.Panel1
            // 
            this.splitContainer_MainLeft.Panel1.Controls.Add(this.tableLayoutPanel1);
            this.splitContainer_MainLeft.Panel1MinSize = 240;
            // 
            // splitContainer_MainLeft.Panel2
            // 
            this.splitContainer_MainLeft.Panel2.Controls.Add(this.toolStrip1);
            this.splitContainer_MainLeft.Panel2.Controls.Add(this.dgv_EventProcedure);
            this.splitContainer_MainLeft.Panel2.Padding = new System.Windows.Forms.Padding(2);
            this.splitContainer_MainLeft.Size = new System.Drawing.Size(381, 993);
            this.splitContainer_MainLeft.SplitterDistance = 240;
            this.splitContainer_MainLeft.TabIndex = 0;
            this.splitContainer_MainLeft.TabStop = false;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.checkBox_GlobalHotKey, 3, 5);
            this.tableLayoutPanel1.Controls.Add(this.textBox_ParentControlTitle, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.checkBox_Opacity, 2, 4);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.textBox_ParentControlHandle, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.textBox_ControlHwnd, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.textBox_ControlText, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.checkBox_LoopPlay, 2, 5);
            this.tableLayoutPanel1.Controls.Add(this.label5, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.btnPlayback, 2, 6);
            this.tableLayoutPanel1.Controls.Add(this.btnRecord, 0, 6);
            this.tableLayoutPanel1.Controls.Add(this.textBox_WaitTime, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.label6, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.textBox_Opacity, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.checkBox_Nontransparent, 3, 4);
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 5);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 8;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(379, 238);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // checkBox_GlobalHotKey
            // 
            this.checkBox_GlobalHotKey.AutoSize = true;
            this.checkBox_GlobalHotKey.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.checkBox_GlobalHotKey.Location = new System.Drawing.Point(268, 164);
            this.checkBox_GlobalHotKey.Margin = new System.Windows.Forms.Padding(4);
            this.checkBox_GlobalHotKey.MaximumSize = new System.Drawing.Size(100, 24);
            this.checkBox_GlobalHotKey.MinimumSize = new System.Drawing.Size(100, 24);
            this.checkBox_GlobalHotKey.Name = "checkBox_GlobalHotKey";
            this.checkBox_GlobalHotKey.Padding = new System.Windows.Forms.Padding(0, 1, 0, 1);
            this.checkBox_GlobalHotKey.Size = new System.Drawing.Size(100, 24);
            this.checkBox_GlobalHotKey.TabIndex = 3;
            this.checkBox_GlobalHotKey.Text = "全局热键";
            this.checkBox_GlobalHotKey.UseVisualStyleBackColor = true;
            this.checkBox_GlobalHotKey.CheckedChanged += new System.EventHandler(this.CheckBox_CheckedChanged);
            // 
            // textBox_ParentControlTitle
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.textBox_ParentControlTitle, 3);
            this.textBox_ParentControlTitle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_ParentControlTitle.Location = new System.Drawing.Point(92, 100);
            this.textBox_ParentControlTitle.Margin = new System.Windows.Forms.Padding(4);
            this.textBox_ParentControlTitle.MaximumSize = new System.Drawing.Size(0, 24);
            this.textBox_ParentControlTitle.MinimumSize = new System.Drawing.Size(0, 24);
            this.textBox_ParentControlTitle.Name = "textBox_ParentControlTitle";
            this.textBox_ParentControlTitle.Size = new System.Drawing.Size(283, 24);
            this.textBox_ParentControlTitle.TabIndex = 11;
            // 
            // checkBox_Opacity
            // 
            this.checkBox_Opacity.AutoSize = true;
            this.checkBox_Opacity.Dock = System.Windows.Forms.DockStyle.Fill;
            this.checkBox_Opacity.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.checkBox_Opacity.Location = new System.Drawing.Point(180, 132);
            this.checkBox_Opacity.Margin = new System.Windows.Forms.Padding(4);
            this.checkBox_Opacity.MaximumSize = new System.Drawing.Size(80, 24);
            this.checkBox_Opacity.MinimumSize = new System.Drawing.Size(80, 24);
            this.checkBox_Opacity.Name = "checkBox_Opacity";
            this.checkBox_Opacity.Padding = new System.Windows.Forms.Padding(0, 1, 0, 1);
            this.checkBox_Opacity.Size = new System.Drawing.Size(80, 24);
            this.checkBox_Opacity.TabIndex = 2;
            this.checkBox_Opacity.Text = "窗体透明";
            this.checkBox_Opacity.UseVisualStyleBackColor = true;
            this.checkBox_Opacity.CheckedChanged += new System.EventHandler(this.CheckBox_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(4, 4);
            this.label1.Margin = new System.Windows.Forms.Padding(4);
            this.label1.MaximumSize = new System.Drawing.Size(80, 24);
            this.label1.MinimumSize = new System.Drawing.Size(80, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 24);
            this.label1.TabIndex = 6;
            this.label1.Text = "控件句柄";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBox_ParentControlHandle
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.textBox_ParentControlHandle, 3);
            this.textBox_ParentControlHandle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_ParentControlHandle.Location = new System.Drawing.Point(92, 68);
            this.textBox_ParentControlHandle.Margin = new System.Windows.Forms.Padding(4);
            this.textBox_ParentControlHandle.MaximumSize = new System.Drawing.Size(0, 24);
            this.textBox_ParentControlHandle.MinimumSize = new System.Drawing.Size(0, 24);
            this.textBox_ParentControlHandle.Name = "textBox_ParentControlHandle";
            this.textBox_ParentControlHandle.Size = new System.Drawing.Size(283, 24);
            this.textBox_ParentControlHandle.TabIndex = 12;
            // 
            // textBox_ControlHwnd
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.textBox_ControlHwnd, 3);
            this.textBox_ControlHwnd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_ControlHwnd.Location = new System.Drawing.Point(92, 4);
            this.textBox_ControlHwnd.Margin = new System.Windows.Forms.Padding(4);
            this.textBox_ControlHwnd.MaximumSize = new System.Drawing.Size(0, 24);
            this.textBox_ControlHwnd.MinimumSize = new System.Drawing.Size(0, 24);
            this.textBox_ControlHwnd.Name = "textBox_ControlHwnd";
            this.textBox_ControlHwnd.Size = new System.Drawing.Size(283, 24);
            this.textBox_ControlHwnd.TabIndex = 8;
            // 
            // textBox_ControlText
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.textBox_ControlText, 3);
            this.textBox_ControlText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_ControlText.Location = new System.Drawing.Point(92, 36);
            this.textBox_ControlText.Margin = new System.Windows.Forms.Padding(4);
            this.textBox_ControlText.MaximumSize = new System.Drawing.Size(0, 24);
            this.textBox_ControlText.MinimumSize = new System.Drawing.Size(0, 24);
            this.textBox_ControlText.Name = "textBox_ControlText";
            this.textBox_ControlText.Size = new System.Drawing.Size(283, 24);
            this.textBox_ControlText.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Location = new System.Drawing.Point(4, 36);
            this.label3.Margin = new System.Windows.Forms.Padding(4);
            this.label3.MaximumSize = new System.Drawing.Size(80, 24);
            this.label3.MinimumSize = new System.Drawing.Size(80, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 24);
            this.label3.TabIndex = 5;
            this.label3.Text = "控件文本";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Location = new System.Drawing.Point(4, 68);
            this.label4.Margin = new System.Windows.Forms.Padding(4);
            this.label4.MaximumSize = new System.Drawing.Size(80, 24);
            this.label4.MinimumSize = new System.Drawing.Size(80, 24);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 24);
            this.label4.TabIndex = 10;
            this.label4.Text = "父控件句柄";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // checkBox_LoopPlay
            // 
            this.checkBox_LoopPlay.AutoSize = true;
            this.checkBox_LoopPlay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.checkBox_LoopPlay.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.checkBox_LoopPlay.Location = new System.Drawing.Point(180, 164);
            this.checkBox_LoopPlay.Margin = new System.Windows.Forms.Padding(4);
            this.checkBox_LoopPlay.MaximumSize = new System.Drawing.Size(80, 24);
            this.checkBox_LoopPlay.MinimumSize = new System.Drawing.Size(80, 24);
            this.checkBox_LoopPlay.Name = "checkBox_LoopPlay";
            this.checkBox_LoopPlay.Padding = new System.Windows.Forms.Padding(0, 1, 0, 1);
            this.checkBox_LoopPlay.Size = new System.Drawing.Size(80, 24);
            this.checkBox_LoopPlay.TabIndex = 2;
            this.checkBox_LoopPlay.Text = "循环执行";
            this.checkBox_LoopPlay.UseVisualStyleBackColor = true;
            this.checkBox_LoopPlay.CheckedChanged += new System.EventHandler(this.CheckBox_CheckedChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label5.Location = new System.Drawing.Point(4, 132);
            this.label5.Margin = new System.Windows.Forms.Padding(4);
            this.label5.MaximumSize = new System.Drawing.Size(80, 24);
            this.label5.MinimumSize = new System.Drawing.Size(80, 24);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(80, 24);
            this.label5.TabIndex = 9;
            this.label5.Text = "窗体透明度";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnPlayback
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.btnPlayback, 2);
            this.btnPlayback.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnPlayback.Location = new System.Drawing.Point(192, 200);
            this.btnPlayback.Margin = new System.Windows.Forms.Padding(16, 8, 16, 8);
            this.btnPlayback.MaximumSize = new System.Drawing.Size(0, 32);
            this.btnPlayback.MinimumSize = new System.Drawing.Size(0, 32);
            this.btnPlayback.Name = "btnPlayback";
            this.btnPlayback.Size = new System.Drawing.Size(171, 32);
            this.btnPlayback.TabIndex = 0;
            this.btnPlayback.Tag = "停止模拟";
            this.btnPlayback.Text = "模拟回放";
            this.btnPlayback.UseVisualStyleBackColor = true;
            this.btnPlayback.Click += new System.EventHandler(this.Button_Click);
            // 
            // btnRecord
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.btnRecord, 2);
            this.btnRecord.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnRecord.Location = new System.Drawing.Point(16, 200);
            this.btnRecord.Margin = new System.Windows.Forms.Padding(16, 8, 16, 8);
            this.btnRecord.MaximumSize = new System.Drawing.Size(0, 32);
            this.btnRecord.MinimumSize = new System.Drawing.Size(0, 32);
            this.btnRecord.Name = "btnRecord";
            this.btnRecord.Size = new System.Drawing.Size(144, 32);
            this.btnRecord.TabIndex = 0;
            this.btnRecord.Tag = "停止捕捉(Alt+S)";
            this.btnRecord.Text = "开始捕捉(Alt+S)";
            this.btnRecord.UseVisualStyleBackColor = true;
            this.btnRecord.Click += new System.EventHandler(this.Button_Click);
            // 
            // textBox_WaitTime
            // 
            this.textBox_WaitTime.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_WaitTime.Location = new System.Drawing.Point(92, 164);
            this.textBox_WaitTime.Margin = new System.Windows.Forms.Padding(4);
            this.textBox_WaitTime.MaximumSize = new System.Drawing.Size(80, 24);
            this.textBox_WaitTime.MinimumSize = new System.Drawing.Size(80, 24);
            this.textBox_WaitTime.Name = "textBox_WaitTime";
            this.textBox_WaitTime.Size = new System.Drawing.Size(80, 23);
            this.textBox_WaitTime.TabIndex = 4;
            this.textBox_WaitTime.Text = "300";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label6.Location = new System.Drawing.Point(4, 100);
            this.label6.Margin = new System.Windows.Forms.Padding(4);
            this.label6.MaximumSize = new System.Drawing.Size(80, 24);
            this.label6.MinimumSize = new System.Drawing.Size(80, 24);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(80, 24);
            this.label6.TabIndex = 9;
            this.label6.Text = "父控件标题";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBox_Opacity
            // 
            this.textBox_Opacity.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_Opacity.Location = new System.Drawing.Point(92, 132);
            this.textBox_Opacity.Margin = new System.Windows.Forms.Padding(4);
            this.textBox_Opacity.MaximumSize = new System.Drawing.Size(80, 24);
            this.textBox_Opacity.MinimumSize = new System.Drawing.Size(80, 24);
            this.textBox_Opacity.Name = "textBox_Opacity";
            this.textBox_Opacity.Size = new System.Drawing.Size(80, 23);
            this.textBox_Opacity.TabIndex = 4;
            this.textBox_Opacity.Text = "10";
            this.textBox_Opacity.TextChanged += new System.EventHandler(this.TextBox_Opacity_TextChanged);
            // 
            // checkBox_Nontransparent
            // 
            this.checkBox_Nontransparent.AutoSize = true;
            this.checkBox_Nontransparent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.checkBox_Nontransparent.Font = new System.Drawing.Font("微软雅黑", 9F);
            this.checkBox_Nontransparent.Location = new System.Drawing.Point(268, 132);
            this.checkBox_Nontransparent.Margin = new System.Windows.Forms.Padding(4);
            this.checkBox_Nontransparent.MaximumSize = new System.Drawing.Size(80, 24);
            this.checkBox_Nontransparent.MinimumSize = new System.Drawing.Size(80, 24);
            this.checkBox_Nontransparent.Name = "checkBox_Nontransparent";
            this.checkBox_Nontransparent.Padding = new System.Windows.Forms.Padding(0, 1, 0, 1);
            this.checkBox_Nontransparent.Size = new System.Drawing.Size(80, 24);
            this.checkBox_Nontransparent.TabIndex = 2;
            this.checkBox_Nontransparent.Text = "禁止透明";
            this.checkBox_Nontransparent.UseVisualStyleBackColor = true;
            this.checkBox_Nontransparent.CheckedChanged += new System.EventHandler(this.CheckBox_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(4, 164);
            this.label2.Margin = new System.Windows.Forms.Padding(4);
            this.label2.MaximumSize = new System.Drawing.Size(80, 24);
            this.label2.MinimumSize = new System.Drawing.Size(80, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 24);
            this.label2.TabIndex = 9;
            this.label2.Text = "循环时间(秒)";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // toolStrip1
            // 
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.EventProcedure_新建ToolStripButton,
            this.EventProcedure_删除ToolStripButton,
            this.EventProcedure_复制ToolStripButton});
            this.toolStrip1.Location = new System.Drawing.Point(2, 2);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Padding = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip1.Size = new System.Drawing.Size(375, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // EventProcedure_新建ToolStripButton
            // 
            this.EventProcedure_新建ToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("EventProcedure_新建ToolStripButton.Image")));
            this.EventProcedure_新建ToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.EventProcedure_新建ToolStripButton.Name = "EventProcedure_新建ToolStripButton";
            this.EventProcedure_新建ToolStripButton.Size = new System.Drawing.Size(52, 22);
            this.EventProcedure_新建ToolStripButton.Text = "新建";
            this.EventProcedure_新建ToolStripButton.Click += new System.EventHandler(this.EventProcedure_新建ToolStripButton_Click);
            // 
            // EventProcedure_删除ToolStripButton
            // 
            this.EventProcedure_删除ToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("EventProcedure_删除ToolStripButton.Image")));
            this.EventProcedure_删除ToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.EventProcedure_删除ToolStripButton.Name = "EventProcedure_删除ToolStripButton";
            this.EventProcedure_删除ToolStripButton.Size = new System.Drawing.Size(52, 22);
            this.EventProcedure_删除ToolStripButton.Text = "删除";
            this.EventProcedure_删除ToolStripButton.Click += new System.EventHandler(this.EventProcedure_删除ToolStripButton_Click);
            // 
            // EventProcedure_复制ToolStripButton
            // 
            this.EventProcedure_复制ToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("EventProcedure_复制ToolStripButton.Image")));
            this.EventProcedure_复制ToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.EventProcedure_复制ToolStripButton.Name = "EventProcedure_复制ToolStripButton";
            this.EventProcedure_复制ToolStripButton.Size = new System.Drawing.Size(52, 22);
            this.EventProcedure_复制ToolStripButton.Text = "复制";
            this.EventProcedure_复制ToolStripButton.Click += new System.EventHandler(this.EventProcedure_复制ToolStripButton_Click);
            // 
            // dgv_EventProcedure
            // 
            this.dgv_EventProcedure.AllowUserToAddRows = false;
            this.dgv_EventProcedure.AllowUserToDeleteRows = false;
            this.dgv_EventProcedure.AllowUserToResizeColumns = false;
            this.dgv_EventProcedure.AllowUserToResizeRows = false;
            this.dgv_EventProcedure.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgv_EventProcedure.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgv_EventProcedure.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_EventProcedure.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgv_EventProcedure_HWND,
            this.dgv_EventProcedure_WindowTitle,
            this.dgv_EventProcedure_Action,
            this.dgv_EventProcedure_X,
            this.dgv_EventProcedure_Y,
            this.dgv_EventProcedure_Delay});
            this.dgv_EventProcedure.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_EventProcedure.Location = new System.Drawing.Point(2, 2);
            this.dgv_EventProcedure.Name = "dgv_EventProcedure";
            this.dgv_EventProcedure.RowHeadersVisible = false;
            this.dgv_EventProcedure.RowHeadersWidth = 24;
            this.dgv_EventProcedure.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgv_EventProcedure.RowTemplate.Height = 23;
            this.dgv_EventProcedure.Size = new System.Drawing.Size(375, 743);
            this.dgv_EventProcedure.TabIndex = 0;
            this.dgv_EventProcedure.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.Dgv_EventProcedure_CellEndEdit);
            // 
            // dgv_EventProcedure_HWND
            // 
            this.dgv_EventProcedure_HWND.DataPropertyName = "HWND";
            this.dgv_EventProcedure_HWND.HeaderText = "HWND";
            this.dgv_EventProcedure_HWND.Name = "dgv_EventProcedure_HWND";
            this.dgv_EventProcedure_HWND.ReadOnly = true;
            this.dgv_EventProcedure_HWND.Width = 73;
            // 
            // dgv_EventProcedure_WindowTitle
            // 
            this.dgv_EventProcedure_WindowTitle.DataPropertyName = "WindowTitle";
            this.dgv_EventProcedure_WindowTitle.HeaderText = "WindowTitle";
            this.dgv_EventProcedure_WindowTitle.Items.AddRange(new object[] {
            ""});
            this.dgv_EventProcedure_WindowTitle.MinimumWidth = 100;
            this.dgv_EventProcedure_WindowTitle.Name = "dgv_EventProcedure_WindowTitle";
            this.dgv_EventProcedure_WindowTitle.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_EventProcedure_WindowTitle.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dgv_EventProcedure_WindowTitle.Width = 104;
            // 
            // dgv_EventProcedure_Action
            // 
            this.dgv_EventProcedure_Action.DataPropertyName = "Action";
            this.dgv_EventProcedure_Action.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.dgv_EventProcedure_Action.HeaderText = "Action";
            this.dgv_EventProcedure_Action.Items.AddRange(new object[] {
            "WM_CLICK"});
            this.dgv_EventProcedure_Action.MinimumWidth = 100;
            this.dgv_EventProcedure_Action.Name = "dgv_EventProcedure_Action";
            this.dgv_EventProcedure_Action.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_EventProcedure_Action.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dgv_EventProcedure_Action.ToolTipText = "操作";
            // 
            // dgv_EventProcedure_X
            // 
            this.dgv_EventProcedure_X.DataPropertyName = "X";
            this.dgv_EventProcedure_X.HeaderText = "X";
            this.dgv_EventProcedure_X.MinimumWidth = 48;
            this.dgv_EventProcedure_X.Name = "dgv_EventProcedure_X";
            this.dgv_EventProcedure_X.ToolTipText = "X坐标";
            this.dgv_EventProcedure_X.Width = 48;
            // 
            // dgv_EventProcedure_Y
            // 
            this.dgv_EventProcedure_Y.DataPropertyName = "Y";
            this.dgv_EventProcedure_Y.HeaderText = "Y";
            this.dgv_EventProcedure_Y.MinimumWidth = 48;
            this.dgv_EventProcedure_Y.Name = "dgv_EventProcedure_Y";
            this.dgv_EventProcedure_Y.ToolTipText = "Y坐标";
            this.dgv_EventProcedure_Y.Width = 48;
            // 
            // dgv_EventProcedure_Delay
            // 
            this.dgv_EventProcedure_Delay.DataPropertyName = "Delay";
            this.dgv_EventProcedure_Delay.HeaderText = "Delay";
            this.dgv_EventProcedure_Delay.MinimumWidth = 40;
            this.dgv_EventProcedure_Delay.Name = "dgv_EventProcedure_Delay";
            this.dgv_EventProcedure_Delay.ToolTipText = "延时";
            this.dgv_EventProcedure_Delay.Width = 65;
            // 
            // splitContainer_Main
            // 
            this.splitContainer_Main.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer_Main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer_Main.Location = new System.Drawing.Point(4, 4);
            this.splitContainer_Main.Name = "splitContainer_Main";
            // 
            // splitContainer_Main.Panel1
            // 
            this.splitContainer_Main.Panel1.Controls.Add(this.splitContainer_MainLeft);
            this.splitContainer_Main.Size = new System.Drawing.Size(1896, 993);
            this.splitContainer_Main.SplitterDistance = 381;
            this.splitContainer_Main.TabIndex = 4;
            this.splitContainer_Main.TabStop = false;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1904, 1001);
            this.Controls.Add(this.splitContainer_Main);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FormMain";
            this.Padding = new System.Windows.Forms.Padding(4);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "内嵌程序";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Deactivate += new System.EventHandler(this.FormMain_Deactivate);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMain_FormClosing);
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.splitContainer_MainLeft.Panel1.ResumeLayout(false);
            this.splitContainer_MainLeft.Panel1.PerformLayout();
            this.splitContainer_MainLeft.Panel2.ResumeLayout(false);
            this.splitContainer_MainLeft.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer_MainLeft)).EndInit();
            this.splitContainer_MainLeft.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_EventProcedure)).EndInit();
            this.splitContainer_Main.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer_Main)).EndInit();
            this.splitContainer_Main.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.SplitContainer splitContainer_MainLeft;
        private System.Windows.Forms.Button btnRecord;
        private System.Windows.Forms.DataGridView dgv_EventProcedure;
        private System.Windows.Forms.Button btnPlayback;
        private System.Windows.Forms.TextBox textBox_WaitTime;
        private System.Windows.Forms.CheckBox checkBox_LoopPlay;
        private System.Windows.Forms.SplitContainer splitContainer_Main;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton EventProcedure_新建ToolStripButton;
        private System.Windows.Forms.ToolStripButton EventProcedure_复制ToolStripButton;
        private System.Windows.Forms.ToolStripButton EventProcedure_删除ToolStripButton;
        private System.Windows.Forms.TextBox textBox_ControlText;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox_ControlHwnd;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_ParentControlTitle;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox_ParentControlHandle;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgv_EventProcedure_HWND;
        private System.Windows.Forms.DataGridViewComboBoxColumn dgv_EventProcedure_WindowTitle;
        private System.Windows.Forms.DataGridViewComboBoxColumn dgv_EventProcedure_Action;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgv_EventProcedure_X;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgv_EventProcedure_Y;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgv_EventProcedure_Delay;
        private System.Windows.Forms.CheckBox checkBox_Opacity;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox_Opacity;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.CheckBox checkBox_Nontransparent;
        private System.Windows.Forms.CheckBox checkBox_GlobalHotKey;
    }
}