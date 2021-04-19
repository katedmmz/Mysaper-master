namespace Mysaper
{
    partial class Saper
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Saper));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.NewGame = new System.Windows.Forms.ToolStripMenuItem();
            this.MapSize = new System.Windows.Forms.ToolStripMenuItem();
            this.SettingsWidth = new System.Windows.Forms.ToolStripMenuItem();
            this.MapWidth = new System.Windows.Forms.ToolStripTextBox();
            this.SettingsHeight = new System.Windows.Forms.ToolStripMenuItem();
            this.MapHeight = new System.Windows.Forms.ToolStripTextBox();
            this.SettingsBombs = new System.Windows.Forms.ToolStripMenuItem();
            this.Bombs = new System.Windows.Forms.ToolStripTextBox();
            this.OkBtn = new System.Windows.Forms.ToolStripMenuItem();
            this.HighScores = new System.Windows.Forms.ToolStripMenuItem();
            this.HighRecords = new System.Windows.Forms.ToolStripMenuItem();
            this.SaperTimer = new System.Windows.Forms.ToolStripTextBox();
            this.BombsLeft = new System.Windows.Forms.ToolStripTextBox();
            this.AboutGame = new System.Windows.Forms.ToolStripMenuItem();
            this.Exit = new System.Windows.Forms.ToolStripMenuItem();
            this.Time = new System.Windows.Forms.Timer(this.components);
            this.UpdateTime = new System.Windows.Forms.Timer(this.components);
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.NewGame,
            this.MapSize,
            this.HighScores,
            this.SaperTimer,
            this.BombsLeft,
            this.AboutGame,
            this.Exit});
            this.menuStrip1.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 31);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // NewGame
            // 
            this.NewGame.Name = "NewGame";
            this.NewGame.Size = new System.Drawing.Size(53, 27);
            this.NewGame.Text = "New";
            this.NewGame.Click += new System.EventHandler(this.NewGame_Click);
            // 
            // MapSize
            // 
            this.MapSize.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SettingsWidth,
            this.MapWidth,
            this.SettingsHeight,
            this.MapHeight,
            this.SettingsBombs,
            this.Bombs,
            this.OkBtn});
            this.MapSize.Name = "MapSize";
            this.MapSize.Size = new System.Drawing.Size(76, 27);
            this.MapSize.Text = "Settings";
            this.MapSize.Click += new System.EventHandler(this.MapSize_Click);
            // 
            // SettingsWidth
            // 
            this.SettingsWidth.Enabled = false;
            this.SettingsWidth.Name = "SettingsWidth";
            this.SettingsWidth.Size = new System.Drawing.Size(174, 26);
            this.SettingsWidth.Text = "Width:";
            // 
            // MapWidth
            // 
            this.MapWidth.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.MapWidth.Name = "MapWidth";
            this.MapWidth.Size = new System.Drawing.Size(100, 27);
            // 
            // SettingsHeight
            // 
            this.SettingsHeight.Enabled = false;
            this.SettingsHeight.Name = "SettingsHeight";
            this.SettingsHeight.Size = new System.Drawing.Size(174, 26);
            this.SettingsHeight.Text = "Height:";
            // 
            // MapHeight
            // 
            this.MapHeight.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.MapHeight.Name = "MapHeight";
            this.MapHeight.Size = new System.Drawing.Size(100, 27);
            // 
            // SettingsBombs
            // 
            this.SettingsBombs.Enabled = false;
            this.SettingsBombs.Name = "SettingsBombs";
            this.SettingsBombs.Size = new System.Drawing.Size(174, 26);
            this.SettingsBombs.Text = "Bombs:";
            // 
            // Bombs
            // 
            this.Bombs.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Bombs.Name = "Bombs";
            this.Bombs.Size = new System.Drawing.Size(100, 27);
            // 
            // OkBtn
            // 
            this.OkBtn.Name = "OkBtn";
            this.OkBtn.Size = new System.Drawing.Size(174, 26);
            this.OkBtn.Text = "Ok";
            this.OkBtn.Click += new System.EventHandler(this.OkBtn_Click);
            // 
            // HighScores
            // 
            this.HighScores.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.HighRecords});
            this.HighScores.Name = "HighScores";
            this.HighScores.Size = new System.Drawing.Size(76, 27);
            this.HighScores.Text = "Records";
            // 
            // HighRecords
            // 
            this.HighRecords.Name = "HighRecords";
            this.HighRecords.Size = new System.Drawing.Size(224, 26);
            this.HighRecords.Text = "High records";
            this.HighRecords.Click += new System.EventHandler(this.HighRecords_Click);
            // 
            // SaperTimer
            // 
            this.SaperTimer.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.SaperTimer.Name = "SaperTimer";
            this.SaperTimer.ReadOnly = true;
            this.SaperTimer.Size = new System.Drawing.Size(100, 27);
            this.SaperTimer.Text = "00:00:00";
            this.SaperTimer.TextBoxTextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // BombsLeft
            // 
            this.BombsLeft.AccessibleName = "";
            this.BombsLeft.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.BombsLeft.Name = "BombsLeft";
            this.BombsLeft.Size = new System.Drawing.Size(50, 27);
            this.BombsLeft.Text = "10";
            // 
            // AboutGame
            // 
            this.AboutGame.Name = "AboutGame";
            this.AboutGame.Size = new System.Drawing.Size(64, 27);
            this.AboutGame.Text = "About";
            this.AboutGame.Click += new System.EventHandler(this.About_Click);
            // 
            // Exit
            // 
            this.Exit.Name = "Exit";
            this.Exit.Size = new System.Drawing.Size(47, 27);
            this.Exit.Text = "Exit";
            this.Exit.Click += new System.EventHandler(this.Exit_Click);
            // 
            // Saper
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 519);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Saper";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Saper";
            this.Load += new System.EventHandler(this.Saper_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem NewGame;
        private System.Windows.Forms.ToolStripMenuItem HighScores;
        private System.Windows.Forms.ToolStripMenuItem AboutGame;
        private System.Windows.Forms.ToolStripMenuItem Exit;
        private System.Windows.Forms.Timer Time;
        private System.Windows.Forms.ToolStripMenuItem MapSize;
        private System.Windows.Forms.ToolStripTextBox SaperTimer;
        private System.Windows.Forms.ToolStripMenuItem HighRecords;
        private System.Windows.Forms.ToolStripMenuItem SettingsWidth;
        private System.Windows.Forms.ToolStripTextBox MapWidth;
        private System.Windows.Forms.ToolStripMenuItem SettingsHeight;
        private System.Windows.Forms.ToolStripTextBox MapHeight;
        private System.Windows.Forms.ToolStripMenuItem SettingsBombs;
        private System.Windows.Forms.ToolStripTextBox Bombs;
        private System.Windows.Forms.ToolStripMenuItem OkBtn;
        private System.Windows.Forms.ToolStripTextBox BombsLeft;
        private System.Windows.Forms.Timer UpdateTime;
    }
}

