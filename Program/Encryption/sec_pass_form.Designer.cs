namespace Encryption
{
    partial class sec_pass_form
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
            this.exit_button = new System.Windows.Forms.Label();
            this.sec_pass_textbox = new System.Windows.Forms.TextBox();
            this.go_button = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // exit_button
            // 
            this.exit_button.AutoSize = true;
            this.exit_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.exit_button.ForeColor = System.Drawing.SystemColors.Control;
            this.exit_button.Location = new System.Drawing.Point(318, 9);
            this.exit_button.Name = "exit_button";
            this.exit_button.Size = new System.Drawing.Size(25, 24);
            this.exit_button.TabIndex = 11;
            this.exit_button.Text = "X";
            // 
            // sec_pass_textbox
            // 
            this.sec_pass_textbox.BackColor = System.Drawing.Color.DarkOliveGreen;
            this.sec_pass_textbox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.sec_pass_textbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.sec_pass_textbox.ForeColor = System.Drawing.SystemColors.Control;
            this.sec_pass_textbox.Location = new System.Drawing.Point(85, 69);
            this.sec_pass_textbox.MaxLength = 7;
            this.sec_pass_textbox.Name = "sec_pass_textbox";
            this.sec_pass_textbox.Size = new System.Drawing.Size(191, 22);
            this.sec_pass_textbox.TabIndex = 10;
            // 
            // go_button
            // 
            this.go_button.BackColor = System.Drawing.Color.DarkOliveGreen;
            this.go_button.FlatAppearance.BorderSize = 0;
            this.go_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.go_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.go_button.ForeColor = System.Drawing.SystemColors.Control;
            this.go_button.Location = new System.Drawing.Point(85, 97);
            this.go_button.Name = "go_button";
            this.go_button.Size = new System.Drawing.Size(191, 45);
            this.go_button.TabIndex = 9;
            this.go_button.Text = "Go";
            this.go_button.UseVisualStyleBackColor = false;
            this.go_button.Click += new System.EventHandler(this.go_button_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.Control;
            this.label1.Location = new System.Drawing.Point(81, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(229, 20);
            this.label1.TabIndex = 12;
            this.label1.Text = "Введите уникальный пароль";
            // 
            // sec_pass_form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(355, 154);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.exit_button);
            this.Controls.Add(this.sec_pass_textbox);
            this.Controls.Add(this.go_button);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "sec_pass_form";
            this.Text = "sec_pass_form";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label exit_button;
        private System.Windows.Forms.TextBox sec_pass_textbox;
        private System.Windows.Forms.Button go_button;
        private System.Windows.Forms.Label label1;
    }
}