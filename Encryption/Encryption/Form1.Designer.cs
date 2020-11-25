namespace Encryption
{
    partial class Form1
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
            this.encode_button = new System.Windows.Forms.Button();
            this.decode_button = new System.Windows.Forms.Button();
            this.new_key_textbox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.decode_textbox = new System.Windows.Forms.TextBox();
            this.exit_button = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.online_button = new System.Windows.Forms.Button();
            this.help_label = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // encode_button
            // 
            this.encode_button.BackColor = System.Drawing.Color.DarkOliveGreen;
            this.encode_button.FlatAppearance.BorderSize = 0;
            this.encode_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.encode_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.encode_button.ForeColor = System.Drawing.SystemColors.Control;
            this.encode_button.Location = new System.Drawing.Point(166, 91);
            this.encode_button.Name = "encode_button";
            this.encode_button.Size = new System.Drawing.Size(132, 45);
            this.encode_button.TabIndex = 2;
            this.encode_button.Text = "Закодировать";
            this.encode_button.UseVisualStyleBackColor = false;
            this.encode_button.Click += new System.EventHandler(this.button1_Click);
            // 
            // decode_button
            // 
            this.decode_button.BackColor = System.Drawing.Color.DarkOliveGreen;
            this.decode_button.FlatAppearance.BorderSize = 0;
            this.decode_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.decode_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.decode_button.ForeColor = System.Drawing.SystemColors.Control;
            this.decode_button.Location = new System.Drawing.Point(166, 210);
            this.decode_button.Name = "decode_button";
            this.decode_button.Size = new System.Drawing.Size(132, 45);
            this.decode_button.TabIndex = 3;
            this.decode_button.Text = "Декодировать";
            this.decode_button.UseVisualStyleBackColor = false;
            this.decode_button.Click += new System.EventHandler(this.decode_button_Click);
            // 
            // new_key_textbox
            // 
            this.new_key_textbox.BackColor = System.Drawing.Color.DarkOliveGreen;
            this.new_key_textbox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.new_key_textbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.new_key_textbox.ForeColor = System.Drawing.SystemColors.Control;
            this.new_key_textbox.Location = new System.Drawing.Point(32, 114);
            this.new_key_textbox.MaxLength = 7;
            this.new_key_textbox.Name = "new_key_textbox";
            this.new_key_textbox.Size = new System.Drawing.Size(128, 22);
            this.new_key_textbox.TabIndex = 4;
            this.new_key_textbox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.new_key_textbox_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.Control;
            this.label1.Location = new System.Drawing.Point(28, 91);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 20);
            this.label1.TabIndex = 5;
            this.label1.Text = "Ключ";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.Control;
            this.label2.Location = new System.Drawing.Point(28, 210);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 20);
            this.label2.TabIndex = 7;
            this.label2.Text = "Ключ";
            // 
            // decode_textbox
            // 
            this.decode_textbox.BackColor = System.Drawing.Color.DarkOliveGreen;
            this.decode_textbox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.decode_textbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.decode_textbox.ForeColor = System.Drawing.SystemColors.Control;
            this.decode_textbox.Location = new System.Drawing.Point(32, 233);
            this.decode_textbox.MaxLength = 7;
            this.decode_textbox.Name = "decode_textbox";
            this.decode_textbox.Size = new System.Drawing.Size(128, 22);
            this.decode_textbox.TabIndex = 6;
            this.decode_textbox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.textBox1_MouseClick);
            this.decode_textbox.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            this.decode_textbox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            // 
            // exit_button
            // 
            this.exit_button.AutoSize = true;
            this.exit_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.exit_button.ForeColor = System.Drawing.SystemColors.Control;
            this.exit_button.Location = new System.Drawing.Point(293, 9);
            this.exit_button.Name = "exit_button";
            this.exit_button.Size = new System.Drawing.Size(25, 24);
            this.exit_button.TabIndex = 8;
            this.exit_button.Text = "X";
            this.exit_button.Click += new System.EventHandler(this.exit_button_Click_1);
            this.exit_button.MouseLeave += new System.EventHandler(this.exit_button_MouseLeave_1);
            this.exit_button.MouseHover += new System.EventHandler(this.exit_button_MouseHover_1);
            this.exit_button.MouseMove += new System.Windows.Forms.MouseEventHandler(this.exit_button_MouseMove);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.ForeColor = System.Drawing.SystemColors.Control;
            this.label3.Location = new System.Drawing.Point(253, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(21, 24);
            this.label3.TabIndex = 9;
            this.label3.Text = "_";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            this.label3.MouseLeave += new System.EventHandler(this.label3_MouseLeave);
            this.label3.MouseHover += new System.EventHandler(this.label3_MouseHover);
            // 
            // online_button
            // 
            this.online_button.BackColor = System.Drawing.Color.DarkOliveGreen;
            this.online_button.FlatAppearance.BorderSize = 0;
            this.online_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.online_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.online_button.ForeColor = System.Drawing.SystemColors.Control;
            this.online_button.Location = new System.Drawing.Point(32, 379);
            this.online_button.Name = "online_button";
            this.online_button.Size = new System.Drawing.Size(266, 35);
            this.online_button.TabIndex = 10;
            this.online_button.Text = "Режим онлайн";
            this.online_button.UseVisualStyleBackColor = false;
            this.online_button.Click += new System.EventHandler(this.online_button_Click);
            // 
            // help_label
            // 
            this.help_label.AutoSize = true;
            this.help_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.help_label.ForeColor = System.Drawing.SystemColors.Control;
            this.help_label.Location = new System.Drawing.Point(12, 9);
            this.help_label.Name = "help_label";
            this.help_label.Size = new System.Drawing.Size(21, 24);
            this.help_label.TabIndex = 11;
            this.help_label.Text = "?";
            this.help_label.Click += new System.EventHandler(this.help_label_Click);
            this.help_label.MouseClick += new System.Windows.Forms.MouseEventHandler(this.help_label_MouseClick);
            this.help_label.MouseLeave += new System.EventHandler(this.help_label_MouseLeave);
            this.help_label.MouseHover += new System.EventHandler(this.help_label_MouseHover);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(330, 448);
            this.Controls.Add(this.help_label);
            this.Controls.Add(this.online_button);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.exit_button);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.decode_textbox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.new_key_textbox);
            this.Controls.Add(this.decode_button);
            this.Controls.Add(this.encode_button);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form1_MouseDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button encode_button;
        private System.Windows.Forms.Button decode_button;
        private System.Windows.Forms.TextBox new_key_textbox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox decode_textbox;
        private System.Windows.Forms.Label exit_button;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button online_button;
        private System.Windows.Forms.Label help_label;
    }
}

