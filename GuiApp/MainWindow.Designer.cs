namespace Lab2._1
{
    partial class MainWindow
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.btnPanel = new System.Windows.Forms.Panel();
            this.enableBtn = new MetroFramework.Controls.MetroButton();
            this.chooseFileBtn = new MetroFramework.Controls.MetroButton();
            this.zipChB = new MetroFramework.Controls.MetroCheckBox();
            this.hashChb = new MetroFramework.Controls.MetroCheckBox();
            this.fileLbl = new MetroFramework.Controls.MetroLabel();
            this.filePathLbl = new MetroFramework.Controls.MetroLabel();
            this.progressSpinner = new MetroFramework.Controls.MetroProgressSpinner();
            this.pngChb = new MetroFramework.Controls.MetroCheckBox();
            this.btnPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnPanel
            // 
            this.btnPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btnPanel.Controls.Add(this.enableBtn);
            this.btnPanel.Controls.Add(this.chooseFileBtn);
            this.btnPanel.Location = new System.Drawing.Point(23, 63);
            this.btnPanel.Name = "btnPanel";
            this.btnPanel.Size = new System.Drawing.Size(226, 52);
            this.btnPanel.TabIndex = 0;
            // 
            // enableBtn
            // 
            this.enableBtn.FontSize = MetroFramework.MetroButtonSize.Medium;
            this.enableBtn.Location = new System.Drawing.Point(133, 15);
            this.enableBtn.Name = "enableBtn";
            this.enableBtn.Size = new System.Drawing.Size(75, 23);
            this.enableBtn.TabIndex = 1;
            this.enableBtn.TabStop = false;
            this.enableBtn.Text = "Enable";
            this.enableBtn.UseSelectable = true;
            this.enableBtn.Click += new System.EventHandler(this.enableBtn_Click);
            // 
            // chooseFileBtn
            // 
            this.chooseFileBtn.FontSize = MetroFramework.MetroButtonSize.Medium;
            this.chooseFileBtn.Location = new System.Drawing.Point(15, 15);
            this.chooseFileBtn.Name = "chooseFileBtn";
            this.chooseFileBtn.Size = new System.Drawing.Size(100, 23);
            this.chooseFileBtn.TabIndex = 0;
            this.chooseFileBtn.Text = "Choose file";
            this.chooseFileBtn.UseSelectable = true;
            this.chooseFileBtn.Click += new System.EventHandler(this.chooseFileBtn_Click);
            // 
            // zipChB
            // 
            this.zipChB.AutoSize = true;
            this.zipChB.FontSize = MetroFramework.MetroCheckBoxSize.Medium;
            this.zipChB.Location = new System.Drawing.Point(38, 175);
            this.zipChB.Name = "zipChB";
            this.zipChB.Size = new System.Drawing.Size(123, 19);
            this.zipChB.TabIndex = 1;
            this.zipChB.Text = "Save zip Archive";
            this.zipChB.UseSelectable = true;
            this.zipChB.CheckedChanged += new System.EventHandler(this.zipChB_CheckedChanged);
            // 
            // hashChb
            // 
            this.hashChb.AutoSize = true;
            this.hashChb.FontSize = MetroFramework.MetroCheckBoxSize.Medium;
            this.hashChb.Location = new System.Drawing.Point(38, 200);
            this.hashChb.Name = "hashChb";
            this.hashChb.Size = new System.Drawing.Size(86, 19);
            this.hashChb.TabIndex = 2;
            this.hashChb.Text = "Save hash";
            this.hashChb.UseSelectable = true;
            this.hashChb.CheckedChanged += new System.EventHandler(this.hashChb_CheckedChanged);
            // 
            // fileLbl
            // 
            this.fileLbl.AutoSize = true;
            this.fileLbl.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.fileLbl.FontWeight = MetroFramework.MetroLabelWeight.Bold;
            this.fileLbl.Location = new System.Drawing.Point(23, 135);
            this.fileLbl.Name = "fileLbl";
            this.fileLbl.Size = new System.Drawing.Size(46, 25);
            this.fileLbl.TabIndex = 3;
            this.fileLbl.Text = "File:";
            // 
            // filePathLbl
            // 
            this.filePathLbl.AutoSize = true;
            this.filePathLbl.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.filePathLbl.FontWeight = MetroFramework.MetroLabelWeight.Regular;
            this.filePathLbl.Location = new System.Drawing.Point(66, 135);
            this.filePathLbl.Name = "filePathLbl";
            this.filePathLbl.Size = new System.Drawing.Size(100, 25);
            this.filePathLbl.TabIndex = 4;
            this.filePathLbl.Text = "not chosen";
            // 
            // progressSpinner
            // 
            this.progressSpinner.Location = new System.Drawing.Point(146, 28);
            this.progressSpinner.Maximum = 100;
            this.progressSpinner.Name = "progressSpinner";
            this.progressSpinner.Size = new System.Drawing.Size(20, 20);
            this.progressSpinner.Speed = 2F;
            this.progressSpinner.Style = MetroFramework.MetroColorStyle.Teal;
            this.progressSpinner.TabIndex = 6;
            this.progressSpinner.TabStop = false;
            this.progressSpinner.UseSelectable = true;
            this.progressSpinner.Value = 70;
            // 
            // pngChb
            // 
            this.pngChb.AutoSize = true;
            this.pngChb.FontSize = MetroFramework.MetroCheckBoxSize.Medium;
            this.pngChb.Location = new System.Drawing.Point(38, 225);
            this.pngChb.Name = "pngChb";
            this.pngChb.Size = new System.Drawing.Size(123, 19);
            this.pngChb.TabIndex = 7;
            this.pngChb.Text = "Convert to PNG";
            this.pngChb.UseSelectable = true;
            this.pngChb.CheckedChanged += new System.EventHandler(this.pngChb_CheckedChanged);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.pngChb);
            this.Controls.Add(this.progressSpinner);
            this.Controls.Add(this.filePathLbl);
            this.Controls.Add(this.fileLbl);
            this.Controls.Add(this.hashChb);
            this.Controls.Add(this.zipChB);
            this.Controls.Add(this.btnPanel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(800, 450);
            this.Name = "MainWindow";
            this.Style = MetroFramework.MetroColorStyle.Default;
            this.Text = "File actions";
            this.Load += new System.EventHandler(this.MainWindow_Load);
            this.btnPanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Panel btnPanel;
        private MetroFramework.Controls.MetroButton enableBtn;
        private MetroFramework.Controls.MetroButton chooseFileBtn;
        private MetroFramework.Controls.MetroCheckBox zipChB;
        private MetroFramework.Controls.MetroCheckBox hashChb;
        private MetroFramework.Controls.MetroLabel fileLbl;
        private MetroFramework.Controls.MetroLabel filePathLbl;
        private MetroFramework.Controls.MetroProgressSpinner progressSpinner;
        private MetroFramework.Controls.MetroCheckBox pngChb;
    }
}

