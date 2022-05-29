namespace ImageSlideAnimation
{
    partial class FormMian
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.button_SelectFolder = new System.Windows.Forms.Button();
            this.button_Before = new System.Windows.Forms.Button();
            this.button_Next = new System.Windows.Forms.Button();
            this.checkBox_Auto = new System.Windows.Forms.CheckBox();
            this.nm_AutoTime = new System.Windows.Forms.NumericUpDown();
            this.tableLayoutPanel_Draw = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nm_AutoTime)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 5;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 82F));
            this.tableLayoutPanel1.Controls.Add(this.button_SelectFolder, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.button_Before, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.button_Next, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.checkBox_Auto, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.nm_AutoTime, 4, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(849, 43);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // button_SelectFolder
            // 
            this.button_SelectFolder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button_SelectFolder.Location = new System.Drawing.Point(3, 3);
            this.button_SelectFolder.Name = "button_SelectFolder";
            this.button_SelectFolder.Size = new System.Drawing.Size(302, 37);
            this.button_SelectFolder.TabIndex = 0;
            this.button_SelectFolder.Text = "폴더 선택";
            this.button_SelectFolder.UseVisualStyleBackColor = true;
            this.button_SelectFolder.Click += new System.EventHandler(this.button_SelectFolder_Click);
            // 
            // button_Before
            // 
            this.button_Before.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button_Before.Location = new System.Drawing.Point(311, 3);
            this.button_Before.Name = "button_Before";
            this.button_Before.Size = new System.Drawing.Size(148, 37);
            this.button_Before.TabIndex = 1;
            this.button_Before.Text = "이전";
            this.button_Before.UseVisualStyleBackColor = true;
            this.button_Before.Click += new System.EventHandler(this.button_Before_Click);
            // 
            // button_Next
            // 
            this.button_Next.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button_Next.Location = new System.Drawing.Point(465, 3);
            this.button_Next.Name = "button_Next";
            this.button_Next.Size = new System.Drawing.Size(148, 37);
            this.button_Next.TabIndex = 1;
            this.button_Next.Text = "다음";
            this.button_Next.UseVisualStyleBackColor = true;
            this.button_Next.Click += new System.EventHandler(this.button_Next_Click);
            // 
            // checkBox_Auto
            // 
            this.checkBox_Auto.AutoSize = true;
            this.checkBox_Auto.Dock = System.Windows.Forms.DockStyle.Fill;
            this.checkBox_Auto.Location = new System.Drawing.Point(619, 3);
            this.checkBox_Auto.Name = "checkBox_Auto";
            this.checkBox_Auto.Size = new System.Drawing.Size(144, 37);
            this.checkBox_Auto.TabIndex = 2;
            this.checkBox_Auto.Text = "다음 Auto (sec)";
            this.checkBox_Auto.UseVisualStyleBackColor = true;
            this.checkBox_Auto.CheckedChanged += new System.EventHandler(this.checkBox_Auto_CheckedChanged);
            // 
            // nm_AutoTime
            // 
            this.nm_AutoTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.nm_AutoTime.Location = new System.Drawing.Point(769, 9);
            this.nm_AutoTime.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nm_AutoTime.Name = "nm_AutoTime";
            this.nm_AutoTime.Size = new System.Drawing.Size(77, 25);
            this.nm_AutoTime.TabIndex = 3;
            this.nm_AutoTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nm_AutoTime.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // tableLayoutPanel_Draw
            // 
            this.tableLayoutPanel_Draw.ColumnCount = 1;
            this.tableLayoutPanel_Draw.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel_Draw.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel_Draw.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel_Draw.Location = new System.Drawing.Point(0, 43);
            this.tableLayoutPanel_Draw.Name = "tableLayoutPanel_Draw";
            this.tableLayoutPanel_Draw.RowCount = 1;
            this.tableLayoutPanel_Draw.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel_Draw.Size = new System.Drawing.Size(849, 677);
            this.tableLayoutPanel_Draw.TabIndex = 1;
            // 
            // FormPaging
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(849, 720);
            this.Controls.Add(this.tableLayoutPanel_Draw);
            this.Controls.Add(this.tableLayoutPanel1);
            this.DoubleBuffered = true;
            this.KeyPreview = true;
            this.Name = "FormPaging";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormPaging";
            this.Load += new System.EventHandler(this.FormPaging_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nm_AutoTime)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button button_SelectFolder;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel_Draw;
        private System.Windows.Forms.Button button_Before;
        private System.Windows.Forms.Button button_Next;
        private System.Windows.Forms.CheckBox checkBox_Auto;
        private System.Windows.Forms.NumericUpDown nm_AutoTime;
    }
}