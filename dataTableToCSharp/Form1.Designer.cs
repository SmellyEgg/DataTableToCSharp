namespace dataTableToCSharp
{
    partial class Form1
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
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.txtTableName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.txtContent = new System.Windows.Forms.RichTextBox();
            this.lblTips = new System.Windows.Forms.Label();
            this.prgData = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // txtTableName
            // 
            this.txtTableName.Location = new System.Drawing.Point(190, 40);
            this.txtTableName.Name = "txtTableName";
            this.txtTableName.Size = new System.Drawing.Size(186, 21);
            this.txtTableName.TabIndex = 0;
            this.txtTableName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtTableName_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(110, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "表名：";
            // 
            // btnGenerate
            // 
            this.btnGenerate.Location = new System.Drawing.Point(95, 86);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(628, 26);
            this.btnGenerate.TabIndex = 2;
            this.btnGenerate.Text = "转换";
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // txtContent
            // 
            this.txtContent.Location = new System.Drawing.Point(95, 157);
            this.txtContent.Name = "txtContent";
            this.txtContent.Size = new System.Drawing.Size(638, 283);
            this.txtContent.TabIndex = 4;
            this.txtContent.Text = "";
            // 
            // lblTips
            // 
            this.lblTips.AutoSize = true;
            this.lblTips.Location = new System.Drawing.Point(95, 456);
            this.lblTips.Name = "lblTips";
            this.lblTips.Size = new System.Drawing.Size(0, 12);
            this.lblTips.TabIndex = 5;
            // 
            // prgData
            // 
            this.prgData.Location = new System.Drawing.Point(95, 475);
            this.prgData.Name = "prgData";
            this.prgData.Size = new System.Drawing.Size(628, 23);
            this.prgData.TabIndex = 6;
            this.prgData.Visible = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(845, 559);
            this.Controls.Add(this.prgData);
            this.Controls.Add(this.lblTips);
            this.Controls.Add(this.txtContent);
            this.Controls.Add(this.btnGenerate);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtTableName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Form1";
            this.Text = "dataTableToCSharp";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtTableName;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.RichTextBox txtContent;
        private System.Windows.Forms.Label lblTips;
        private System.Windows.Forms.ProgressBar prgData;
    }
}

