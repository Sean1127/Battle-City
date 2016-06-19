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
            this.button_stage1.Click += new System.EventHandler(this.button_stage1_Click);
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
            // Form_stage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 561);
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
    }
}