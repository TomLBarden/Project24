namespace GossbitBot_Chatroom
{
    partial class Form2
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
            this.ConversationBox = new System.Windows.Forms.ListBox();
            this.UserMessageBox = new System.Windows.Forms.RichTextBox();
            this.SendButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ConversationBox
            // 
            this.ConversationBox.FormattingEnabled = true;
            this.ConversationBox.Location = new System.Drawing.Point(12, 12);
            this.ConversationBox.Name = "ConversationBox";
            this.ConversationBox.Size = new System.Drawing.Size(489, 368);
            this.ConversationBox.TabIndex = 0;
            // 
            // UserMessageBox
            // 
            this.UserMessageBox.Location = new System.Drawing.Point(12, 396);
            this.UserMessageBox.MaxLength = 256;
            this.UserMessageBox.Name = "UserMessageBox";
            this.UserMessageBox.Size = new System.Drawing.Size(418, 41);
            this.UserMessageBox.TabIndex = 1;
            this.UserMessageBox.Text = "";
            // 
            // SendButton
            // 
            this.SendButton.Location = new System.Drawing.Point(452, 396);
            this.SendButton.Name = "SendButton";
            this.SendButton.Size = new System.Drawing.Size(49, 41);
            this.SendButton.TabIndex = 2;
            this.SendButton.Text = "Send";
            this.SendButton.UseVisualStyleBackColor = true;
            this.SendButton.Click += new System.EventHandler(this.SendButton_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(513, 449);
            this.Controls.Add(this.SendButton);
            this.Controls.Add(this.UserMessageBox);
            this.Controls.Add(this.ConversationBox);
            this.Name = "Form2";
            this.Text = "Form2";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox ConversationBox;
        private System.Windows.Forms.RichTextBox UserMessageBox;
        private System.Windows.Forms.Button SendButton;
    }
}