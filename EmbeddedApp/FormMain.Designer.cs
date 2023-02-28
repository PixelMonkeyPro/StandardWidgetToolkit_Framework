
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
            this.textBox_WaitTime = new System.Windows.Forms.TextBox();
            this.checkBox_LoopPlay = new System.Windows.Forms.CheckBox();
            this.checkBoxSupressMouseWheel = new System.Windows.Forms.CheckBox();
            this.labelWheel = new System.Windows.Forms.Label();
            this.labelMousePosition = new System.Windows.Forms.Label();
            this.radioNone = new System.Windows.Forms.RadioButton();
            this.radioGlobal = new System.Windows.Forms.RadioButton();
            this.radioApplication = new System.Windows.Forms.RadioButton();
            this.btnPlayback = new System.Windows.Forms.Button();
            this.btnRecord = new System.Windows.Forms.Button();
            this.checkBoxSupressMouse = new System.Windows.Forms.CheckBox();
            this.dgv_EventProcedure = new System.Windows.Forms.DataGridView();
            this.dgv_EventProcedure_RowNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgv_EventProcedure_Action = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgv_EventProcedure_X = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgv_EventProcedure_Y = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgv_EventProcedure_delay = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStrip_Main = new System.Windows.Forms.ToolStrip();
            this.新建NToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.打开OToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.保存SToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.打印PToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.剪切UToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.复制CToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.粘贴PToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.帮助LToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.句柄嵌入ToolStripTextBox = new System.Windows.Forms.ToolStripTextBox();
            this.模拟事件ToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.取消嵌入ToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.鼠标XToolStripTextBox = new System.Windows.Forms.ToolStripTextBox();
            this.鼠标YToolStripTextBox = new System.Windows.Forms.ToolStripTextBox();
            this.测试点击ToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.splitContainer_MainToolStrip = new System.Windows.Forms.SplitContainer();
            this.splitContainer_StatusStrip = new System.Windows.Forms.SplitContainer();
            this.splitContainer_Main = new System.Windows.Forms.SplitContainer();
            this.statusStrip_Main = new System.Windows.Forms.StatusStrip();
            this.toolStripProgressBar1 = new System.Windows.Forms.ToolStripProgressBar();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.EventProcedure_新建ToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.EventProcedure_复制ToolStripButton = new System.Windows.Forms.ToolStripButton();
            this.EventProcedure_删除ToolStripButton = new System.Windows.Forms.ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer_MainLeft)).BeginInit();
            this.splitContainer_MainLeft.Panel1.SuspendLayout();
            this.splitContainer_MainLeft.Panel2.SuspendLayout();
            this.splitContainer_MainLeft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_EventProcedure)).BeginInit();
            this.toolStrip_Main.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer_MainToolStrip)).BeginInit();
            this.splitContainer_MainToolStrip.Panel1.SuspendLayout();
            this.splitContainer_MainToolStrip.Panel2.SuspendLayout();
            this.splitContainer_MainToolStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer_StatusStrip)).BeginInit();
            this.splitContainer_StatusStrip.Panel1.SuspendLayout();
            this.splitContainer_StatusStrip.Panel2.SuspendLayout();
            this.splitContainer_StatusStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer_Main)).BeginInit();
            this.splitContainer_Main.Panel1.SuspendLayout();
            this.splitContainer_Main.SuspendLayout();
            this.statusStrip_Main.SuspendLayout();
            this.toolStrip1.SuspendLayout();
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
            this.splitContainer_MainLeft.Panel1.Controls.Add(this.textBox_WaitTime);
            this.splitContainer_MainLeft.Panel1.Controls.Add(this.checkBox_LoopPlay);
            this.splitContainer_MainLeft.Panel1.Controls.Add(this.checkBoxSupressMouseWheel);
            this.splitContainer_MainLeft.Panel1.Controls.Add(this.labelWheel);
            this.splitContainer_MainLeft.Panel1.Controls.Add(this.labelMousePosition);
            this.splitContainer_MainLeft.Panel1.Controls.Add(this.radioNone);
            this.splitContainer_MainLeft.Panel1.Controls.Add(this.radioGlobal);
            this.splitContainer_MainLeft.Panel1.Controls.Add(this.radioApplication);
            this.splitContainer_MainLeft.Panel1.Controls.Add(this.btnPlayback);
            this.splitContainer_MainLeft.Panel1.Controls.Add(this.btnRecord);
            this.splitContainer_MainLeft.Panel1.Controls.Add(this.checkBoxSupressMouse);
            // 
            // splitContainer_MainLeft.Panel2
            // 
            this.splitContainer_MainLeft.Panel2.Controls.Add(this.dgv_EventProcedure);
            this.splitContainer_MainLeft.Panel2.Controls.Add(this.toolStrip1);
            this.splitContainer_MainLeft.Panel2.Padding = new System.Windows.Forms.Padding(2);
            this.splitContainer_MainLeft.Size = new System.Drawing.Size(319, 715);
            this.splitContainer_MainLeft.SplitterDistance = 189;
            this.splitContainer_MainLeft.TabIndex = 0;
            this.splitContainer_MainLeft.TabStop = false;
            // 
            // textBox_WaitTime
            // 
            this.textBox_WaitTime.Location = new System.Drawing.Point(136, 80);
            this.textBox_WaitTime.Name = "textBox_WaitTime";
            this.textBox_WaitTime.Size = new System.Drawing.Size(72, 23);
            this.textBox_WaitTime.TabIndex = 4;
            this.textBox_WaitTime.Text = "30";
            // 
            // checkBox_LoopPlay
            // 
            this.checkBox_LoopPlay.AutoSize = true;
            this.checkBox_LoopPlay.Location = new System.Drawing.Point(19, 81);
            this.checkBox_LoopPlay.Name = "checkBox_LoopPlay";
            this.checkBox_LoopPlay.Size = new System.Drawing.Size(75, 21);
            this.checkBox_LoopPlay.TabIndex = 2;
            this.checkBox_LoopPlay.Text = "循环执行";
            this.checkBox_LoopPlay.UseVisualStyleBackColor = true;
            this.checkBox_LoopPlay.CheckedChanged += new System.EventHandler(this.CheckBox_CheckedChanged);
            // 
            // checkBoxSupressMouseWheel
            // 
            this.checkBoxSupressMouseWheel.AutoSize = true;
            this.checkBoxSupressMouseWheel.Location = new System.Drawing.Point(136, 47);
            this.checkBoxSupressMouseWheel.Name = "checkBoxSupressMouseWheel";
            this.checkBoxSupressMouseWheel.Size = new System.Drawing.Size(75, 21);
            this.checkBoxSupressMouseWheel.TabIndex = 2;
            this.checkBoxSupressMouseWheel.Text = "禁止滚轮";
            this.checkBoxSupressMouseWheel.UseVisualStyleBackColor = true;
            this.checkBoxSupressMouseWheel.CheckedChanged += new System.EventHandler(this.CheckBox_CheckedChanged);
            // 
            // labelWheel
            // 
            this.labelWheel.AutoSize = true;
            this.labelWheel.Location = new System.Drawing.Point(189, 115);
            this.labelWheel.Name = "labelWheel";
            this.labelWheel.Size = new System.Drawing.Size(103, 17);
            this.labelWheel.TabIndex = 3;
            this.labelWheel.Text = "Wheel={0:####}";
            // 
            // labelMousePosition
            // 
            this.labelMousePosition.AutoSize = true;
            this.labelMousePosition.Location = new System.Drawing.Point(19, 115);
            this.labelMousePosition.Name = "labelMousePosition";
            this.labelMousePosition.Size = new System.Drawing.Size(148, 17);
            this.labelMousePosition.TabIndex = 3;
            this.labelMousePosition.Text = "X={0:####}; Y={1:####}";
            // 
            // radioNone
            // 
            this.radioNone.AutoSize = true;
            this.radioNone.Location = new System.Drawing.Point(253, 13);
            this.radioNone.Name = "radioNone";
            this.radioNone.Size = new System.Drawing.Size(38, 21);
            this.radioNone.TabIndex = 1;
            this.radioNone.Text = "无";
            this.radioNone.UseVisualStyleBackColor = true;
            this.radioNone.CheckedChanged += new System.EventHandler(this.Radio_CheckedChanged);
            // 
            // radioGlobal
            // 
            this.radioGlobal.AutoSize = true;
            this.radioGlobal.Checked = true;
            this.radioGlobal.Location = new System.Drawing.Point(136, 13);
            this.radioGlobal.Name = "radioGlobal";
            this.radioGlobal.Size = new System.Drawing.Size(74, 21);
            this.radioGlobal.TabIndex = 1;
            this.radioGlobal.TabStop = true;
            this.radioGlobal.Text = "全局钩子";
            this.radioGlobal.UseVisualStyleBackColor = true;
            // 
            // radioApplication
            // 
            this.radioApplication.AutoSize = true;
            this.radioApplication.Location = new System.Drawing.Point(19, 13);
            this.radioApplication.Name = "radioApplication";
            this.radioApplication.Size = new System.Drawing.Size(74, 21);
            this.radioApplication.TabIndex = 1;
            this.radioApplication.Text = "应用钩子";
            this.radioApplication.UseVisualStyleBackColor = true;
            // 
            // btnPlayback
            // 
            this.btnPlayback.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPlayback.Location = new System.Drawing.Point(164, 146);
            this.btnPlayback.Name = "btnPlayback";
            this.btnPlayback.Size = new System.Drawing.Size(128, 30);
            this.btnPlayback.TabIndex = 0;
            this.btnPlayback.Text = "Playback";
            this.btnPlayback.UseVisualStyleBackColor = true;
            this.btnPlayback.Click += new System.EventHandler(this.BtnPlayback_Click);
            // 
            // btnRecord
            // 
            this.btnRecord.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRecord.Location = new System.Drawing.Point(19, 145);
            this.btnRecord.Name = "btnRecord";
            this.btnRecord.Size = new System.Drawing.Size(128, 30);
            this.btnRecord.TabIndex = 0;
            this.btnRecord.Text = "Record";
            this.btnRecord.UseVisualStyleBackColor = true;
            this.btnRecord.Click += new System.EventHandler(this.Button_Record_Click);
            // 
            // checkBoxSupressMouse
            // 
            this.checkBoxSupressMouse.AutoSize = true;
            this.checkBoxSupressMouse.Location = new System.Drawing.Point(19, 47);
            this.checkBoxSupressMouse.Name = "checkBoxSupressMouse";
            this.checkBoxSupressMouse.Size = new System.Drawing.Size(75, 21);
            this.checkBoxSupressMouse.TabIndex = 2;
            this.checkBoxSupressMouse.Text = "禁止右键";
            this.checkBoxSupressMouse.UseVisualStyleBackColor = true;
            this.checkBoxSupressMouse.CheckedChanged += new System.EventHandler(this.CheckBox_CheckedChanged);
            // 
            // dgv_EventProcedure
            // 
            this.dgv_EventProcedure.AllowUserToAddRows = false;
            this.dgv_EventProcedure.AllowUserToDeleteRows = false;
            this.dgv_EventProcedure.AllowUserToResizeColumns = false;
            this.dgv_EventProcedure.AllowUserToResizeRows = false;
            this.dgv_EventProcedure.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_EventProcedure.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgv_EventProcedure.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_EventProcedure.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dgv_EventProcedure_RowNo,
            this.dgv_EventProcedure_Action,
            this.dgv_EventProcedure_X,
            this.dgv_EventProcedure_Y,
            this.dgv_EventProcedure_delay});
            this.dgv_EventProcedure.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgv_EventProcedure.Location = new System.Drawing.Point(2, 27);
            this.dgv_EventProcedure.Name = "dgv_EventProcedure";
            this.dgv_EventProcedure.RowHeadersVisible = false;
            this.dgv_EventProcedure.RowHeadersWidth = 24;
            this.dgv_EventProcedure.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgv_EventProcedure.RowTemplate.Height = 23;
            this.dgv_EventProcedure.Size = new System.Drawing.Size(313, 491);
            this.dgv_EventProcedure.TabIndex = 0;
            // 
            // dgv_EventProcedure_RowNo
            // 
            this.dgv_EventProcedure_RowNo.DataPropertyName = "RowNo";
            this.dgv_EventProcedure_RowNo.HeaderText = "RowNo";
            this.dgv_EventProcedure_RowNo.MinimumWidth = 40;
            this.dgv_EventProcedure_RowNo.Name = "dgv_EventProcedure_RowNo";
            this.dgv_EventProcedure_RowNo.ToolTipText = "行号";
            // 
            // dgv_EventProcedure_Action
            // 
            this.dgv_EventProcedure_Action.DataPropertyName = "Action";
            this.dgv_EventProcedure_Action.HeaderText = "Action";
            this.dgv_EventProcedure_Action.MinimumWidth = 60;
            this.dgv_EventProcedure_Action.Name = "dgv_EventProcedure_Action";
            this.dgv_EventProcedure_Action.ToolTipText = "操作";
            // 
            // dgv_EventProcedure_X
            // 
            this.dgv_EventProcedure_X.DataPropertyName = "X";
            this.dgv_EventProcedure_X.HeaderText = "X";
            this.dgv_EventProcedure_X.MinimumWidth = 60;
            this.dgv_EventProcedure_X.Name = "dgv_EventProcedure_X";
            this.dgv_EventProcedure_X.ToolTipText = "X坐标";
            // 
            // dgv_EventProcedure_Y
            // 
            this.dgv_EventProcedure_Y.DataPropertyName = "Y";
            this.dgv_EventProcedure_Y.HeaderText = "Y";
            this.dgv_EventProcedure_Y.Name = "dgv_EventProcedure_Y";
            this.dgv_EventProcedure_Y.ToolTipText = "Y坐标";
            // 
            // dgv_EventProcedure_delay
            // 
            this.dgv_EventProcedure_delay.DataPropertyName = "delay";
            this.dgv_EventProcedure_delay.HeaderText = "delay";
            this.dgv_EventProcedure_delay.MinimumWidth = 40;
            this.dgv_EventProcedure_delay.Name = "dgv_EventProcedure_delay";
            this.dgv_EventProcedure_delay.ToolTipText = "延时";
            // 
            // toolStrip_Main
            // 
            this.toolStrip_Main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStrip_Main.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip_Main.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.新建NToolStripButton,
            this.打开OToolStripButton,
            this.保存SToolStripButton,
            this.打印PToolStripButton,
            this.toolStripSeparator,
            this.剪切UToolStripButton,
            this.复制CToolStripButton,
            this.粘贴PToolStripButton,
            this.toolStripSeparator1,
            this.帮助LToolStripButton,
            this.toolStripSeparator2,
            this.句柄嵌入ToolStripTextBox,
            this.模拟事件ToolStripButton,
            this.取消嵌入ToolStripButton,
            this.toolStripSeparator3,
            this.鼠标XToolStripTextBox,
            this.鼠标YToolStripTextBox,
            this.测试点击ToolStripButton});
            this.toolStrip_Main.Location = new System.Drawing.Point(0, 0);
            this.toolStrip_Main.Name = "toolStrip_Main";
            this.toolStrip_Main.Padding = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.toolStrip_Main.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.toolStrip_Main.Size = new System.Drawing.Size(1190, 25);
            this.toolStrip_Main.TabIndex = 0;
            this.toolStrip_Main.Text = "toolStrip1";
            // 
            // 新建NToolStripButton
            // 
            this.新建NToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("新建NToolStripButton.Image")));
            this.新建NToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.新建NToolStripButton.Name = "新建NToolStripButton";
            this.新建NToolStripButton.Size = new System.Drawing.Size(70, 22);
            this.新建NToolStripButton.Text = "新建(&N)";
            // 
            // 打开OToolStripButton
            // 
            this.打开OToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("打开OToolStripButton.Image")));
            this.打开OToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.打开OToolStripButton.Name = "打开OToolStripButton";
            this.打开OToolStripButton.Size = new System.Drawing.Size(70, 22);
            this.打开OToolStripButton.Text = "打开(&O)";
            // 
            // 保存SToolStripButton
            // 
            this.保存SToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("保存SToolStripButton.Image")));
            this.保存SToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.保存SToolStripButton.Name = "保存SToolStripButton";
            this.保存SToolStripButton.Size = new System.Drawing.Size(67, 22);
            this.保存SToolStripButton.Text = "保存(&S)";
            // 
            // 打印PToolStripButton
            // 
            this.打印PToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("打印PToolStripButton.Image")));
            this.打印PToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.打印PToolStripButton.Name = "打印PToolStripButton";
            this.打印PToolStripButton.Size = new System.Drawing.Size(67, 22);
            this.打印PToolStripButton.Text = "打印(&P)";
            // 
            // toolStripSeparator
            // 
            this.toolStripSeparator.Name = "toolStripSeparator";
            this.toolStripSeparator.Size = new System.Drawing.Size(6, 25);
            // 
            // 剪切UToolStripButton
            // 
            this.剪切UToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("剪切UToolStripButton.Image")));
            this.剪切UToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.剪切UToolStripButton.Name = "剪切UToolStripButton";
            this.剪切UToolStripButton.Size = new System.Drawing.Size(69, 22);
            this.剪切UToolStripButton.Text = "剪切(&U)";
            // 
            // 复制CToolStripButton
            // 
            this.复制CToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("复制CToolStripButton.Image")));
            this.复制CToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.复制CToolStripButton.Name = "复制CToolStripButton";
            this.复制CToolStripButton.Size = new System.Drawing.Size(68, 22);
            this.复制CToolStripButton.Text = "复制(&C)";
            // 
            // 粘贴PToolStripButton
            // 
            this.粘贴PToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("粘贴PToolStripButton.Image")));
            this.粘贴PToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.粘贴PToolStripButton.Name = "粘贴PToolStripButton";
            this.粘贴PToolStripButton.Size = new System.Drawing.Size(67, 22);
            this.粘贴PToolStripButton.Text = "粘贴(&P)";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // 帮助LToolStripButton
            // 
            this.帮助LToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("帮助LToolStripButton.Image")));
            this.帮助LToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.帮助LToolStripButton.Name = "帮助LToolStripButton";
            this.帮助LToolStripButton.Size = new System.Drawing.Size(66, 22);
            this.帮助LToolStripButton.Text = "帮助(&L)";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // 句柄嵌入ToolStripTextBox
            // 
            this.句柄嵌入ToolStripTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.句柄嵌入ToolStripTextBox.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F);
            this.句柄嵌入ToolStripTextBox.Name = "句柄嵌入ToolStripTextBox";
            this.句柄嵌入ToolStripTextBox.Size = new System.Drawing.Size(100, 25);
            this.句柄嵌入ToolStripTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.句柄嵌入ToolStripTextBox_KeyPress);
            // 
            // 模拟事件ToolStripButton
            // 
            this.模拟事件ToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.模拟事件ToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("模拟事件ToolStripButton.Image")));
            this.模拟事件ToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.模拟事件ToolStripButton.Name = "模拟事件ToolStripButton";
            this.模拟事件ToolStripButton.Size = new System.Drawing.Size(60, 22);
            this.模拟事件ToolStripButton.Text = "模拟事件";
            this.模拟事件ToolStripButton.Click += new System.EventHandler(this.模拟事件ToolStripButton_Click);
            // 
            // 取消嵌入ToolStripButton
            // 
            this.取消嵌入ToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.取消嵌入ToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("取消嵌入ToolStripButton.Image")));
            this.取消嵌入ToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.取消嵌入ToolStripButton.Name = "取消嵌入ToolStripButton";
            this.取消嵌入ToolStripButton.Size = new System.Drawing.Size(60, 22);
            this.取消嵌入ToolStripButton.Text = "取消嵌入";
            this.取消嵌入ToolStripButton.Click += new System.EventHandler(this.取消嵌入ToolStripButton_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // 鼠标XToolStripTextBox
            // 
            this.鼠标XToolStripTextBox.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F);
            this.鼠标XToolStripTextBox.Name = "鼠标XToolStripTextBox";
            this.鼠标XToolStripTextBox.Size = new System.Drawing.Size(100, 25);
            // 
            // 鼠标YToolStripTextBox
            // 
            this.鼠标YToolStripTextBox.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F);
            this.鼠标YToolStripTextBox.Name = "鼠标YToolStripTextBox";
            this.鼠标YToolStripTextBox.Size = new System.Drawing.Size(100, 25);
            // 
            // 测试点击ToolStripButton
            // 
            this.测试点击ToolStripButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.测试点击ToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("测试点击ToolStripButton.Image")));
            this.测试点击ToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.测试点击ToolStripButton.Name = "测试点击ToolStripButton";
            this.测试点击ToolStripButton.Size = new System.Drawing.Size(60, 22);
            this.测试点击ToolStripButton.Text = "测试点击";
            this.测试点击ToolStripButton.Click += new System.EventHandler(this.测试点击ToolStripButton_Click);
            // 
            // splitContainer_MainToolStrip
            // 
            this.splitContainer_MainToolStrip.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer_MainToolStrip.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer_MainToolStrip.IsSplitterFixed = true;
            this.splitContainer_MainToolStrip.Location = new System.Drawing.Point(4, 4);
            this.splitContainer_MainToolStrip.Name = "splitContainer_MainToolStrip";
            this.splitContainer_MainToolStrip.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer_MainToolStrip.Panel1
            // 
            this.splitContainer_MainToolStrip.Panel1.Controls.Add(this.toolStrip_Main);
            // 
            // splitContainer_MainToolStrip.Panel2
            // 
            this.splitContainer_MainToolStrip.Panel2.Controls.Add(this.splitContainer_StatusStrip);
            this.splitContainer_MainToolStrip.Size = new System.Drawing.Size(1190, 773);
            this.splitContainer_MainToolStrip.SplitterDistance = 25;
            this.splitContainer_MainToolStrip.TabIndex = 3;
            this.splitContainer_MainToolStrip.TabStop = false;
            // 
            // splitContainer_StatusStrip
            // 
            this.splitContainer_StatusStrip.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer_StatusStrip.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer_StatusStrip.IsSplitterFixed = true;
            this.splitContainer_StatusStrip.Location = new System.Drawing.Point(0, 0);
            this.splitContainer_StatusStrip.Name = "splitContainer_StatusStrip";
            this.splitContainer_StatusStrip.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer_StatusStrip.Panel1
            // 
            this.splitContainer_StatusStrip.Panel1.Controls.Add(this.splitContainer_Main);
            // 
            // splitContainer_StatusStrip.Panel2
            // 
            this.splitContainer_StatusStrip.Panel2.Controls.Add(this.statusStrip_Main);
            this.splitContainer_StatusStrip.Size = new System.Drawing.Size(1190, 744);
            this.splitContainer_StatusStrip.SplitterDistance = 715;
            this.splitContainer_StatusStrip.TabIndex = 0;
            this.splitContainer_StatusStrip.TabStop = false;
            // 
            // splitContainer_Main
            // 
            this.splitContainer_Main.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer_Main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer_Main.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer_Main.IsSplitterFixed = true;
            this.splitContainer_Main.Location = new System.Drawing.Point(0, 0);
            this.splitContainer_Main.Name = "splitContainer_Main";
            // 
            // splitContainer_Main.Panel1
            // 
            this.splitContainer_Main.Panel1.Controls.Add(this.splitContainer_MainLeft);
            this.splitContainer_Main.Size = new System.Drawing.Size(1190, 715);
            this.splitContainer_Main.SplitterDistance = 319;
            this.splitContainer_Main.TabIndex = 4;
            this.splitContainer_Main.TabStop = false;
            // 
            // statusStrip_Main
            // 
            this.statusStrip_Main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.statusStrip_Main.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripProgressBar1});
            this.statusStrip_Main.Location = new System.Drawing.Point(0, 0);
            this.statusStrip_Main.Name = "statusStrip_Main";
            this.statusStrip_Main.Size = new System.Drawing.Size(1190, 25);
            this.statusStrip_Main.TabIndex = 2;
            this.statusStrip_Main.Text = "statusStrip1";
            // 
            // toolStripProgressBar1
            // 
            this.toolStripProgressBar1.Name = "toolStripProgressBar1";
            this.toolStripProgressBar1.Size = new System.Drawing.Size(120, 19);
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
            this.toolStrip1.Size = new System.Drawing.Size(313, 25);
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
            // EventProcedure_复制ToolStripButton
            // 
            this.EventProcedure_复制ToolStripButton.Image = ((System.Drawing.Image)(resources.GetObject("EventProcedure_复制ToolStripButton.Image")));
            this.EventProcedure_复制ToolStripButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.EventProcedure_复制ToolStripButton.Name = "EventProcedure_复制ToolStripButton";
            this.EventProcedure_复制ToolStripButton.Size = new System.Drawing.Size(52, 22);
            this.EventProcedure_复制ToolStripButton.Text = "复制";
            this.EventProcedure_复制ToolStripButton.Click += new System.EventHandler(this.EventProcedure_复制ToolStripButton_Click);
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
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1198, 781);
            this.Controls.Add(this.splitContainer_MainToolStrip);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FormMain";
            this.Padding = new System.Windows.Forms.Padding(4);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "内嵌程序";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMain_FormClosing);
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.Resize += new System.EventHandler(this.FormMain_Resize);
            this.splitContainer_MainLeft.Panel1.ResumeLayout(false);
            this.splitContainer_MainLeft.Panel1.PerformLayout();
            this.splitContainer_MainLeft.Panel2.ResumeLayout(false);
            this.splitContainer_MainLeft.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer_MainLeft)).EndInit();
            this.splitContainer_MainLeft.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_EventProcedure)).EndInit();
            this.toolStrip_Main.ResumeLayout(false);
            this.toolStrip_Main.PerformLayout();
            this.splitContainer_MainToolStrip.Panel1.ResumeLayout(false);
            this.splitContainer_MainToolStrip.Panel1.PerformLayout();
            this.splitContainer_MainToolStrip.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer_MainToolStrip)).EndInit();
            this.splitContainer_MainToolStrip.ResumeLayout(false);
            this.splitContainer_StatusStrip.Panel1.ResumeLayout(false);
            this.splitContainer_StatusStrip.Panel2.ResumeLayout(false);
            this.splitContainer_StatusStrip.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer_StatusStrip)).EndInit();
            this.splitContainer_StatusStrip.ResumeLayout(false);
            this.splitContainer_Main.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer_Main)).EndInit();
            this.splitContainer_Main.ResumeLayout(false);
            this.statusStrip_Main.ResumeLayout(false);
            this.statusStrip_Main.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.SplitContainer splitContainer_MainLeft;
        private System.Windows.Forms.Button btnRecord;
        private System.Windows.Forms.DataGridView dgv_EventProcedure;
        private System.Windows.Forms.RadioButton radioApplication;
        private System.Windows.Forms.RadioButton radioGlobal;
        private System.Windows.Forms.RadioButton radioNone;
        private System.Windows.Forms.CheckBox checkBoxSupressMouse;
        private System.Windows.Forms.CheckBox checkBoxSupressMouseWheel;
        private System.Windows.Forms.Label labelMousePosition;
        private System.Windows.Forms.Label labelWheel;
        private System.Windows.Forms.Button btnPlayback;
        private System.Windows.Forms.TextBox textBox_WaitTime;
        private System.Windows.Forms.CheckBox checkBox_LoopPlay;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgv_EventProcedure_RowNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgv_EventProcedure_Action;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgv_EventProcedure_X;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgv_EventProcedure_Y;
        private System.Windows.Forms.DataGridViewTextBoxColumn dgv_EventProcedure_delay;
        private System.Windows.Forms.ToolStrip toolStrip_Main;
        private System.Windows.Forms.ToolStripButton 新建NToolStripButton;
        private System.Windows.Forms.ToolStripButton 打开OToolStripButton;
        private System.Windows.Forms.ToolStripButton 保存SToolStripButton;
        private System.Windows.Forms.ToolStripButton 打印PToolStripButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator;
        private System.Windows.Forms.ToolStripButton 剪切UToolStripButton;
        private System.Windows.Forms.ToolStripButton 复制CToolStripButton;
        private System.Windows.Forms.ToolStripButton 粘贴PToolStripButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton 帮助LToolStripButton;
        private System.Windows.Forms.SplitContainer splitContainer_Main;
        private System.Windows.Forms.ToolStripTextBox 句柄嵌入ToolStripTextBox;
        private System.Windows.Forms.SplitContainer splitContainer_MainToolStrip;
        private System.Windows.Forms.SplitContainer splitContainer_StatusStrip;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton 取消嵌入ToolStripButton;
        private System.Windows.Forms.StatusStrip statusStrip_Main;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar1;
        private System.Windows.Forms.ToolStripTextBox 鼠标XToolStripTextBox;
        private System.Windows.Forms.ToolStripTextBox 鼠标YToolStripTextBox;
        private System.Windows.Forms.ToolStripButton 测试点击ToolStripButton;
        private System.Windows.Forms.ToolStripButton 模拟事件ToolStripButton;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton EventProcedure_新建ToolStripButton;
        private System.Windows.Forms.ToolStripButton EventProcedure_复制ToolStripButton;
        private System.Windows.Forms.ToolStripButton EventProcedure_删除ToolStripButton;
    }
}