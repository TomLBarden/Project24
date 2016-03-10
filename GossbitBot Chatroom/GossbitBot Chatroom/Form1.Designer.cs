namespace GossbitBot_Chatroom
{
    partial class Form1
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
            this.UserNameBox = new System.Windows.Forms.RichTextBox();
            this.ChatButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // UserNameBox
            // 
            this.UserNameBox.Location = new System.Drawing.Point(16, 93);
            this.UserNameBox.Name = "UserNameBox";
            this.UserNameBox.Size = new System.Drawing.Size(141, 23);
            this.UserNameBox.TabIndex = 0;
            this.UserNameBox.Text = "";
            // 
            // ChatButton
            // 
            this.ChatButton.Location = new System.Drawing.Point(173, 93);
            this.ChatButton.Name = "ChatButton";
            this.ChatButton.Size = new System.Drawing.Size(67, 23);
            this.ChatButton.TabIndex = 1;
            this.ChatButton.Text = "Chat Now!";
            this.ChatButton.UseVisualStyleBackColor = true;
            this.ChatButton.Click += new System.EventHandler(this.ChatButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(227, 65);
            this.label1.TabIndex = 2;
            this.label1.Text = "Welcome to the chatroom.\r\n\r\nWhen you are ready to chat with someone,\r\n\r\nPlease en" +
    "ter you name and press \"Chat Now\".\r\n";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(246, 127);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ChatButton);
            this.Controls.Add(this.UserNameBox);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox UserNameBox;
        private System.Windows.Forms.Button ChatButton;
        private System.Windows.Forms.Label label1;
    }
}

