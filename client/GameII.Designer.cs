namespace Client
{
    partial class GameII
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
            this.Menu = new System.Windows.Forms.GroupBox();
            this.label_cross = new System.Windows.Forms.Label();
            this.label_circle = new System.Windows.Forms.Label();
            this.Start = new System.Windows.Forms.Button();
            this.Choise = new System.Windows.Forms.Label();
            this.button_cross = new System.Windows.Forms.Button();
            this.button_circle = new System.Windows.Forms.Button();
            this.Menu.SuspendLayout();
            this.SuspendLayout();
            // 
            // Menu
            // 
            this.Menu.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.Menu.AutoSize = true;
            this.Menu.Controls.Add(this.label_cross);
            this.Menu.Controls.Add(this.label_circle);
            this.Menu.Controls.Add(this.Start);
            this.Menu.Controls.Add(this.Choise);
            this.Menu.Controls.Add(this.button_cross);
            this.Menu.Controls.Add(this.button_circle);
            this.Menu.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Menu.Location = new System.Drawing.Point(603, 2);
            this.Menu.Name = "Menu";
            this.Menu.Size = new System.Drawing.Size(190, 240);
            this.Menu.TabIndex = 1;
            this.Menu.TabStop = false;
            // 
            // label_cross
            // 
            this.label_cross.AutoSize = true;
            this.label_cross.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_cross.Location = new System.Drawing.Point(92, 127);
            this.label_cross.Name = "label_cross";
            this.label_cross.Size = new System.Drawing.Size(92, 18);
            this.label_cross.TabIndex = 5;
            this.label_cross.Text = "Противник";
            // 
            // label_circle
            // 
            this.label_circle.AutoSize = true;
            this.label_circle.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_circle.Location = new System.Drawing.Point(92, 72);
            this.label_circle.Name = "label_circle";
            this.label_circle.Size = new System.Drawing.Size(31, 18);
            this.label_circle.TabIndex = 4;
            this.label_circle.Text = "Вы";
            // 
            // Start
            // 
            this.Start.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Start.Location = new System.Drawing.Point(27, 178);
            this.Start.Name = "Start";
            this.Start.Size = new System.Drawing.Size(140, 39);
            this.Start.TabIndex = 3;
            this.Start.Text = "Начать игру";
            this.Start.UseVisualStyleBackColor = true;
            this.Start.Click += new System.EventHandler(this.Start_Click);
            // 
            // Choise
            // 
            this.Choise.AutoSize = true;
            this.Choise.Font = new System.Drawing.Font("Arial", 13.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Choise.Location = new System.Drawing.Point(6, 20);
            this.Choise.Name = "Choise";
            this.Choise.Size = new System.Drawing.Size(174, 21);
            this.Choise.TabIndex = 2;
            this.Choise.Text = "Выберите фигуру";
            // 
            // button_cross
            // 
            this.button_cross.Image = global::Client.Properties.Resources.cross;
            this.button_cross.Location = new System.Drawing.Point(27, 113);
            this.button_cross.Name = "button_cross";
            this.button_cross.Size = new System.Drawing.Size(49, 46);
            this.button_cross.TabIndex = 1;
            this.button_cross.UseVisualStyleBackColor = true;
            this.button_cross.Click += new System.EventHandler(this.button_cross_Click);
            // 
            // button_circle
            // 
            this.button_circle.Image = global::Client.Properties.Resources.circle;
            this.button_circle.Location = new System.Drawing.Point(27, 58);
            this.button_circle.Name = "button_circle";
            this.button_circle.Size = new System.Drawing.Size(49, 46);
            this.button_circle.TabIndex = 0;
            this.button_circle.UseVisualStyleBackColor = true;
            this.button_circle.Click += new System.EventHandler(this.button_circle_Click);
            // 
            // GameII
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(792, 606);
            this.Controls.Add(this.Menu);
            this.IsMdiContainer = true;
            this.MaximumSize = new System.Drawing.Size(800, 640);
            this.MinimumSize = new System.Drawing.Size(800, 640);
            this.Name = "GameII";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Игра с ИИ";
            this.Menu.ResumeLayout(false);
            this.Menu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.GroupBox Menu;
        private System.Windows.Forms.Button button_cross;
        private System.Windows.Forms.Button button_circle;
        public System.Windows.Forms.Label label_circle;
        private System.Windows.Forms.Button Start;
        private System.Windows.Forms.Label Choise;
        private System.Windows.Forms.Label label_cross;
    }
}