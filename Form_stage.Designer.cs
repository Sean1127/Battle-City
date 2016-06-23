namespace Tank
{
    partial class Form_stage
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
            this.button_stage1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.button_stage2 = new System.Windows.Forms.Button();
            this.button_stage3 = new System.Windows.Forms.Button();
            this.button_stage4 = new System.Windows.Forms.Button();
            this.button_stage5 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button_stage1
            // 
            this.button_stage1.Location = new System.Drawing.Point(95, 95);
            this.button_stage1.Name = "button_stage1";
            this.button_stage1.Size = new System.Drawing.Size(75, 23);
            this.button_stage1.TabIndex = 0;
            this.button_stage1.Text = "stage 1";
            this.button_stage1.UseVisualStyleBackColor = true;
            this.button_stage1.Click += new System.EventHandler(this.button_stage_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(213, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "select stage";
            // 
            // button_stage2
            // 
            this.button_stage2.Location = new System.Drawing.Point(95, 144);
            this.button_stage2.Name = "button_stage2";
            this.button_stage2.Size = new System.Drawing.Size(75, 23);
            this.button_stage2.TabIndex = 2;
            this.button_stage2.Text = "stage2";
            this.button_stage2.UseVisualStyleBackColor = true;
            this.button_stage2.Click += new System.EventHandler(this.button_stage_Click);
            // 
            // button_stage3
            // 
            this.button_stage3.Location = new System.Drawing.Point(95, 185);
            this.button_stage3.Name = "button_stage3";
            this.button_stage3.Size = new System.Drawing.Size(75, 23);
            this.button_stage3.TabIndex = 3;
            this.button_stage3.Text = "stage3";
            this.button_stage3.UseVisualStyleBackColor = true;
            this.button_stage3.Click += new System.EventHandler(this.button_stage_Click);
            // 
            // button_stage4
            // 
            this.button_stage4.Location = new System.Drawing.Point(95, 234);
            this.button_stage4.Name = "button_stage4";
            this.button_stage4.Size = new System.Drawing.Size(75, 23);
            this.button_stage4.TabIndex = 4;
            this.button_stage4.Text = "stage4";
            this.button_stage4.UseVisualStyleBackColor = true;
            this.button_stage4.Click += new System.EventHandler(this.button_stage_Click);
            // 
            // button_stage5
            // 
            this.button_stage5.Location = new System.Drawing.Point(95, 289);
            this.button_stage5.Name = "button_stage5";
            this.button_stage5.Size = new System.Drawing.Size(75, 23);
            this.button_stage5.TabIndex = 5;
            this.button_stage5.Text = "stage5";
            this.button_stage5.UseVisualStyleBackColor = true;
            this.button_stage5.Click += new System.EventHandler(this.button_stage_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(331, 163);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = "fight";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form_stage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 561);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button_stage5);
            this.Controls.Add(this.button_stage4);
            this.Controls.Add(this.button_stage3);
            this.Controls.Add(this.button_stage2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button_stage1);
            this.Name = "Form_stage";
            this.Text = "Battle City 2016";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form_stage_FormClosed);
            this.Load += new System.EventHandler(this.Form_stage_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_stage1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button_stage2;
        private System.Windows.Forms.Button button_stage3;
        private System.Windows.Forms.Button button_stage4;
        private System.Windows.Forms.Button button_stage5;
        private System.Windows.Forms.Button button1;
    }
}