
namespace EmbeddedApp
{
    partial class Form_GetControlTextAndProcess
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_cHandle = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_cClassName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox_cText = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox_pHandle = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox_pClassName = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox_pTitle = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.textBox_id = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.textBox_description = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.textBox_fileName = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.textBox_Company = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(258, 362);
            this.button1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(369, 54);
            this.button1.TabIndex = 0;
            this.button1.Text = "开始捕捉";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(103, 77);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "控件句柄";
            // 
            // textBox_cHandle
            // 
            this.textBox_cHandle.Location = new System.Drawing.Point(165, 74);
            this.textBox_cHandle.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBox_cHandle.Name = "textBox_cHandle";
            this.textBox_cHandle.Size = new System.Drawing.Size(134, 23);
            this.textBox_cHandle.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(321, 77);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "控件类名";
            // 
            // textBox_cClassName
            // 
            this.textBox_cClassName.Location = new System.Drawing.Point(383, 74);
            this.textBox_cClassName.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBox_cClassName.Name = "textBox_cClassName";
            this.textBox_cClassName.Size = new System.Drawing.Size(392, 23);
            this.textBox_cClassName.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(103, 118);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 17);
            this.label3.TabIndex = 1;
            this.label3.Text = "控件文本";
            // 
            // textBox_cText
            // 
            this.textBox_cText.Location = new System.Drawing.Point(165, 115);
            this.textBox_cText.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBox_cText.Name = "textBox_cText";
            this.textBox_cText.Size = new System.Drawing.Size(610, 23);
            this.textBox_cText.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(91, 160);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 17);
            this.label4.TabIndex = 1;
            this.label4.Text = "父控件句柄";
            // 
            // textBox_pHandle
            // 
            this.textBox_pHandle.Location = new System.Drawing.Point(165, 157);
            this.textBox_pHandle.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBox_pHandle.Name = "textBox_pHandle";
            this.textBox_pHandle.Size = new System.Drawing.Size(134, 23);
            this.textBox_pHandle.TabIndex = 2;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(309, 160);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(68, 17);
            this.label5.TabIndex = 1;
            this.label5.Text = "父控件类名";
            // 
            // textBox_pClassName
            // 
            this.textBox_pClassName.Location = new System.Drawing.Point(383, 157);
            this.textBox_pClassName.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBox_pClassName.Name = "textBox_pClassName";
            this.textBox_pClassName.Size = new System.Drawing.Size(392, 23);
            this.textBox_pClassName.TabIndex = 2;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(91, 201);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(68, 17);
            this.label6.TabIndex = 1;
            this.label6.Text = "父控件标题";
            // 
            // textBox_pTitle
            // 
            this.textBox_pTitle.Location = new System.Drawing.Point(165, 198);
            this.textBox_pTitle.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBox_pTitle.Name = "textBox_pTitle";
            this.textBox_pTitle.Size = new System.Drawing.Size(610, 23);
            this.textBox_pTitle.TabIndex = 2;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(114, 253);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(45, 17);
            this.label7.TabIndex = 1;
            this.label7.Text = "进程ID";
            // 
            // textBox_id
            // 
            this.textBox_id.Location = new System.Drawing.Point(165, 250);
            this.textBox_id.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBox_id.Name = "textBox_id";
            this.textBox_id.Size = new System.Drawing.Size(134, 23);
            this.textBox_id.TabIndex = 2;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(321, 253);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(56, 17);
            this.label8.TabIndex = 1;
            this.label8.Text = "文件描述";
            // 
            // textBox_description
            // 
            this.textBox_description.Location = new System.Drawing.Point(383, 250);
            this.textBox_description.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBox_description.Name = "textBox_description";
            this.textBox_description.Size = new System.Drawing.Size(392, 23);
            this.textBox_description.TabIndex = 2;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(103, 315);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(56, 17);
            this.label9.TabIndex = 1;
            this.label9.Text = "文件路径";
            // 
            // textBox_fileName
            // 
            this.textBox_fileName.Location = new System.Drawing.Point(165, 312);
            this.textBox_fileName.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBox_fileName.Name = "textBox_fileName";
            this.textBox_fileName.Size = new System.Drawing.Size(610, 23);
            this.textBox_fileName.TabIndex = 2;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(103, 284);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(56, 17);
            this.label10.TabIndex = 1;
            this.label10.Text = "公司名称";
            // 
            // textBox_Company
            // 
            this.textBox_Company.Location = new System.Drawing.Point(165, 281);
            this.textBox_Company.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.textBox_Company.Name = "textBox_Company";
            this.textBox_Company.Size = new System.Drawing.Size(610, 23);
            this.textBox_Company.TabIndex = 2;
            // 
            // Form_GetControlTextAndProcess
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(866, 490);
            this.Controls.Add(this.textBox_fileName);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.textBox_pTitle);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.textBox_Company);
            this.Controls.Add(this.textBox_description);
            this.Controls.Add(this.textBox_cText);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.textBox_pClassName);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBox_id);
            this.Controls.Add(this.textBox_cClassName);
            this.Controls.Add(this.textBox_pHandle);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBox_cHandle);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Form_GetControlTextAndProcess";
            this.Text = "Form_GetControlTextAndProcess";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_cHandle;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_cClassName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox_cText;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox_pHandle;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox_pClassName;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox_pTitle;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBox_id;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBox_description;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox textBox_fileName;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox textBox_Company;
    }
}