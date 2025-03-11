namespace HanoiTower
{
    partial class GameForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GameForm));
            this.buttonSolve = new System.Windows.Forms.Button();
            this.buttonReset = new System.Windows.Forms.Button();
            this.diskCountField = new System.Windows.Forms.NumericUpDown();
            this.buttonStop = new System.Windows.Forms.Button();
            this.buttonResume = new System.Windows.Forms.Button();
            this.resolutionBox = new System.Windows.Forms.ComboBox();
            this.diskLabel = new System.Windows.Forms.Label();
            this.resolutionLabel = new System.Windows.Forms.Label();
            this.speedLabel = new System.Windows.Forms.Label();
            this.speedField = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.diskCountField)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.speedField)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonSolve
            // 
            this.buttonSolve.Location = new System.Drawing.Point(12, 12);
            this.buttonSolve.Name = "buttonSolve";
            this.buttonSolve.Size = new System.Drawing.Size(126, 23);
            this.buttonSolve.TabIndex = 0;
            this.buttonSolve.Text = "Решить";
            this.buttonSolve.UseVisualStyleBackColor = true;
            this.buttonSolve.Click += new System.EventHandler(this.ButtonSolveClick);
            // 
            // buttonReset
            // 
            this.buttonReset.Location = new System.Drawing.Point(276, 41);
            this.buttonReset.Name = "buttonReset";
            this.buttonReset.Size = new System.Drawing.Size(126, 23);
            this.buttonReset.TabIndex = 1;
            this.buttonReset.Text = "Сброс";
            this.buttonReset.UseVisualStyleBackColor = true;
            this.buttonReset.Click += new System.EventHandler(this.ButtonResetClick);
            // 
            // diskCountField
            // 
            this.diskCountField.Location = new System.Drawing.Point(144, 44);
            this.diskCountField.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.diskCountField.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.diskCountField.Name = "diskCountField";
            this.diskCountField.Size = new System.Drawing.Size(126, 20);
            this.diskCountField.TabIndex = 2;
            this.diskCountField.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.diskCountField.ValueChanged += new System.EventHandler(this.DiskCountFieldValueChanged);
            // 
            // buttonStop
            // 
            this.buttonStop.Location = new System.Drawing.Point(144, 12);
            this.buttonStop.Name = "buttonStop";
            this.buttonStop.Size = new System.Drawing.Size(126, 23);
            this.buttonStop.TabIndex = 0;
            this.buttonStop.Text = "Остановить";
            this.buttonStop.UseVisualStyleBackColor = true;
            this.buttonStop.Click += new System.EventHandler(this.ButtonStopClick);
            // 
            // buttonResume
            // 
            this.buttonResume.Location = new System.Drawing.Point(276, 12);
            this.buttonResume.Name = "buttonResume";
            this.buttonResume.Size = new System.Drawing.Size(126, 23);
            this.buttonResume.TabIndex = 3;
            this.buttonResume.Text = "Возобновить";
            this.buttonResume.UseVisualStyleBackColor = true;
            this.buttonResume.Click += new System.EventHandler(this.ButtonResumeClick);
            // 
            // resolutionBox
            // 
            this.resolutionBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.resolutionBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.resolutionBox.Location = new System.Drawing.Point(1126, 12);
            this.resolutionBox.Name = "resolutionBox";
            this.resolutionBox.Size = new System.Drawing.Size(126, 21);
            this.resolutionBox.TabIndex = 4;
            this.resolutionBox.SelectedIndexChanged += new System.EventHandler(this.ResolutionBoxSelectedIndexChanged);
            // 
            // diskLabel
            // 
            this.diskLabel.AutoSize = true;
            this.diskLabel.Location = new System.Drawing.Point(33, 46);
            this.diskLabel.Name = "diskLabel";
            this.diskLabel.Size = new System.Drawing.Size(105, 13);
            this.diskLabel.TabIndex = 5;
            this.diskLabel.Text = "Количество дисков";
            // 
            // resolutionLabel
            // 
            this.resolutionLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.resolutionLabel.AutoSize = true;
            this.resolutionLabel.Location = new System.Drawing.Point(1011, 17);
            this.resolutionLabel.Name = "resolutionLabel";
            this.resolutionLabel.Size = new System.Drawing.Size(109, 13);
            this.resolutionLabel.TabIndex = 6;
            this.resolutionLabel.Text = "Разрешение экрана";
            // 
            // speedLabel
            // 
            this.speedLabel.AutoSize = true;
            this.speedLabel.Location = new System.Drawing.Point(83, 72);
            this.speedLabel.Name = "speedLabel";
            this.speedLabel.Size = new System.Drawing.Size(55, 13);
            this.speedLabel.TabIndex = 8;
            this.speedLabel.Text = "Скорость";
            // 
            // speedField
            // 
            this.speedField.Increment = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.speedField.Location = new System.Drawing.Point(144, 70);
            this.speedField.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.speedField.Minimum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.speedField.Name = "speedField";
            this.speedField.Size = new System.Drawing.Size(126, 20);
            this.speedField.TabIndex = 7;
            this.speedField.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.speedField.ValueChanged += new System.EventHandler(this.SpeedFieldValueChanged);
            // 
            // GameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1264, 681);
            this.Controls.Add(this.speedLabel);
            this.Controls.Add(this.speedField);
            this.Controls.Add(this.resolutionLabel);
            this.Controls.Add(this.diskLabel);
            this.Controls.Add(this.resolutionBox);
            this.Controls.Add(this.buttonResume);
            this.Controls.Add(this.buttonStop);
            this.Controls.Add(this.diskCountField);
            this.Controls.Add(this.buttonReset);
            this.Controls.Add(this.buttonSolve);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimumSize = new System.Drawing.Size(1280, 720);
            this.Name = "GameForm";
            this.Text = "Ханойская башня";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.OnFormClosed);
            this.Load += new System.EventHandler(this.OnFormLoaded);
            ((System.ComponentModel.ISupportInitialize)(this.diskCountField)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.speedField)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonSolve;
        private System.Windows.Forms.Button buttonReset;
        private System.Windows.Forms.NumericUpDown diskCountField;
        private System.Windows.Forms.Button buttonStop;
        private System.Windows.Forms.Button buttonResume;
        private System.Windows.Forms.ComboBox resolutionBox;
        private System.Windows.Forms.Label diskLabel;
        private System.Windows.Forms.Label resolutionLabel;
        private System.Windows.Forms.Label speedLabel;
        private System.Windows.Forms.NumericUpDown speedField;
    }
}

