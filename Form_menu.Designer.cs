namespace Tank
{
    partial class From_menu
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置 Managed 資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器
        /// 修改這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.button_singleplayer = new System.Windows.Forms.Button();
            this.button_multiplayer = new System.Windows.Forms.Button();
            this.label_title1 = new System.Windows.Forms.Label();
            this.button_construct = new System.Windows.Forms.Button();
            this.label_title2 = new System.Windows.Forms.Label();
            this.label_score = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button_singleplayer
            // 
            this.button_singleplayer.Location = new System.Drawing.Point(237, 289);
            this.button_singleplayer.Name = "button_singleplayer";
            this.button_singleplayer.Size = new System.Drawing.Size(75, 23);
            this.button_singleplayer.TabIndex = 0;
            this.button_singleplayer.Text = "1 player";
            this.button_singleplayer.UseVisualStyleBackColor = true;
            this.button_singleplayer.Click += new System.EventHandler(this.button_singleplayer_Click);
            // 
            // button_multiplayer
            // 
            this.button_multiplayer.Location = new System.Drawing.Point(237, 333);
            this.button_multiplayer.Name = "button_multiplayer";
            this.button_multiplayer.Size = new System.Drawing.Size(75, 23);
            this.button_multiplayer.TabIndex = 1;
            this.button_multiplayer.Text = "2 player";
            this.button_multiplayer.UseVisualStyleBackColor = true;
            this.button_multiplayer.Click += new System.EventHandler(this.button_multiplayer_Click);
            // 
            // label_title1
            // 
            this.label_title1.AutoSize = true;
            this.label_title1.Location = new System.Drawing.Point(247, 136);
            this.label_title1.Name = "label_title1";
            this.label_title1.Size = new System.Drawing.Size(32, 12);
            this.label_title1.TabIndex = 2;
            this.label_title1.Text = "Battle";
            // 
            // button_construct
            // 
            this.button_construct.Location = new System.Drawing.Point(237, 376);
            this.button_construct.Name = "button_construct";
            this.button_construct.Size = new System.Drawing.Size(75, 23);
            this.button_construct.TabIndex = 3;
            this.button_construct.Text = "construction";
            this.button_construct.UseVisualStyleBackColor = true;
            this.button_construct.Click += new System.EventHandler(this.button_construct_Click);
            // 
            // label_title2
            // 
            this.label_title2.AutoSize = true;
            this.label_title2.Location = new System.Drawing.Point(247, 148);
            this.label_title2.Name = "label_title2";
            this.label_title2.Size = new System.Drawing.Size(25, 12);
            this.label_title2.TabIndex = 4;
            this.label_title2.Text = "City";
            // 
            // label_score
            // 
            this.label_score.AutoSize = true;
            this.label_score.Location = new System.Drawing.Point(162, 39);
            this.label_score.Name = "label_score";
            this.label_score.Size = new System.Drawing.Size(57, 12);
            this.label_score.TabIndex = 5;
            this.label_score.Text = "High Score";
            // 
            // From_menu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 561);
            this.Controls.Add(this.label_score);
            this.Controls.Add(this.label_title2);
            this.Controls.Add(this.button_construct);
            this.Controls.Add(this.label_title1);
            this.Controls.Add(this.button_multiplayer);
            this.Controls.Add(this.button_singleplayer);
            this.Name = "From_menu";
            this.Text = "Battle City 2016";
            this.Load += new System.EventHandler(this.MenuFrom_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_singleplayer;
        private System.Windows.Forms.Button button_multiplayer;
        private System.Windows.Forms.Label label_title1;
        private System.Windows.Forms.Button button_construct;
        private System.Windows.Forms.Label label_title2;
        private System.Windows.Forms.Label label_score;
    }
}

