namespace Client
{
    partial class TicTacToe
    {
        /// <summary>
        /// Требуется переменная конструктора.
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
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.game_ii = new System.Windows.Forms.Button();
            this.game_lan = new System.Windows.Forms.Button();
            this.options = new System.Windows.Forms.Button();
            this.authors = new System.Windows.Forms.Button();
            this.exit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // game_ii
            // 
            this.game_ii.Location = new System.Drawing.Point(276, 37);
            this.game_ii.Name = "game_ii";
            this.game_ii.Size = new System.Drawing.Size(252, 72);
            this.game_ii.TabIndex = 0;
            this.game_ii.Text = "Играть с ИИ";
            this.game_ii.UseVisualStyleBackColor = true;
            this.game_ii.Click += new System.EventHandler(this.game_ii_Click);
            // 
            // game_lan
            // 
            this.game_lan.Location = new System.Drawing.Point(276, 142);
            this.game_lan.Name = "game_lan";
            this.game_lan.Size = new System.Drawing.Size(252, 72);
            this.game_lan.TabIndex = 1;
            this.game_lan.Text = "Играть по сети";
            this.game_lan.UseVisualStyleBackColor = true;
            // 
            // options
            // 
            this.options.Location = new System.Drawing.Point(276, 248);
            this.options.Name = "options";
            this.options.Size = new System.Drawing.Size(252, 72);
            this.options.TabIndex = 2;
            this.options.Text = "Настройки";
            this.options.UseVisualStyleBackColor = true;
            // 
            // authors
            // 
            this.authors.Location = new System.Drawing.Point(276, 355);
            this.authors.Name = "authors";
            this.authors.Size = new System.Drawing.Size(252, 72);
            this.authors.TabIndex = 3;
            this.authors.Text = "Авторы";
            this.authors.UseVisualStyleBackColor = true;
            // 
            // exit
            // 
            this.exit.Location = new System.Drawing.Point(276, 460);
            this.exit.Name = "exit";
            this.exit.Size = new System.Drawing.Size(252, 72);
            this.exit.TabIndex = 4;
            this.exit.Text = "Выход";
            this.exit.UseVisualStyleBackColor = true;
            // 
            // TicTacToe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(792, 566);
            this.Controls.Add(this.exit);
            this.Controls.Add(this.authors);
            this.Controls.Add(this.options);
            this.Controls.Add(this.game_lan);
            this.Controls.Add(this.game_ii);
            this.MaximumSize = new System.Drawing.Size(800, 600);
            this.MinimumSize = new System.Drawing.Size(800, 600);
            this.Name = "TicTacToe";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "TicTacToe";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button game_ii;
        private System.Windows.Forms.Button game_lan;
        private System.Windows.Forms.Button options;
        private System.Windows.Forms.Button authors;
        private System.Windows.Forms.Button exit;
    }
}

