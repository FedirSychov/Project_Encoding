namespace Encryption
{
    partial class Help_form
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
            this.help_richtextbox = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // exit_button
            // 
            this.exit_button.AutoSize = true;
            this.exit_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.exit_button.ForeColor = System.Drawing.SystemColors.Control;
            this.exit_button.Location = new System.Drawing.Point(257, 9);
            this.exit_button.Name = "exit_button";
            this.exit_button.Size = new System.Drawing.Size(25, 24);
            this.exit_button.TabIndex = 9;
            this.exit_button.Text = "X";
            this.exit_button.Click += new System.EventHandler(this.exit_button_Click);
            this.exit_button.MouseLeave += new System.EventHandler(this.exit_button_MouseLeave);
            this.exit_button.MouseHover += new System.EventHandler(this.exit_button_MouseHover);
            // 
            // help_richtextbox
            // 
            this.help_richtextbox.BackColor = System.Drawing.Color.DimGray;
            this.help_richtextbox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.help_richtextbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.help_richtextbox.ForeColor = System.Drawing.SystemColors.Window;
            this.help_richtextbox.Location = new System.Drawing.Point(12, 36);
            this.help_richtextbox.Name = "help_richtextbox";
            this.help_richtextbox.ReadOnly = true;
            this.help_richtextbox.Size = new System.Drawing.Size(270, 209);
            this.help_richtextbox.TabIndex = 10;
            this.help_richtextbox.Text = "";
            this.help_richtextbox.TextChanged += new System.EventHandler(this.help_richtextbox_TextChanged);
            // 
            // Help_form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(294, 257);
            this.Controls.Add(this.help_richtextbox);
            this.Controls.Add(this.exit_button);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Help_form";
            this.Text = "Help_form";
            this.Load += new System.EventHandler(this.Help_form_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Help_form_MouseDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label exit_button;
        private System.Windows.Forms.RichTextBox help_richtextbox;
    }
}