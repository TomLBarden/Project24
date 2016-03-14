namespace GossbitBot_Chatroom
{
    partial class ChatroomForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.CharCount1Label = new System.Windows.Forms.Label();
            this.CharCount2Label = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ConversationBox
            // 
            this.ConversationBox.FormattingEnabled = true;
            this.ConversationBox.Location = new System.Drawing.Point(12, 12);
            this.ConversationBox.Name = "ConversationBox";
            this.ConversationBox.Size = new System.Drawing.Size(489, 303);
            this.ConversationBox.TabIndex = 0;
            // 
            // UserMessageBox
            // 
            this.UserMessageBox.Location = new System.Drawing.Point(12, 396);
            this.UserMessageBox.MaxLength = 160;
            this.UserMessageBox.Name = "UserMessageBox";
            this.UserMessageBox.Size = new System.Drawing.Size(418, 41);
            this.UserMessageBox.TabIndex = 1;
            this.UserMessageBox.Text = "";
            this.UserMessageBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.UserMessageBox_KeyDown);
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.Control;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(13, 361);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 18);
            this.label1.TabIndex = 3;
            // 
            // CharCount1Label
            // 
            this.CharCount1Label.AutoSize = true;
            this.CharCount1Label.Location = new System.Drawing.Point(379, 380);
            this.CharCount1Label.Name = "CharCount1Label";
            this.CharCount1Label.Size = new System.Drawing.Size(22, 13);
            this.CharCount1Label.TabIndex = 4;
            this.CharCount1Label.Text = "   0";
            // 
            // CharCount2Label
            // 
            this.CharCount2Label.AutoSize = true;
            this.CharCount2Label.Location = new System.Drawing.Point(400, 380);
            this.CharCount2Label.Name = "CharCount2Label";
            this.CharCount2Label.Size = new System.Drawing.Size(33, 13);
            this.CharCount2Label.TabIndex = 5;
            this.CharCount2Label.Text = "/ 160";
            // 
            // ChatroomForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(513, 449);
            this.Controls.Add(this.CharCount2Label);
            this.Controls.Add(this.CharCount1Label);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.SendButton);
            this.Controls.Add(this.UserMessageBox);
            this.Controls.Add(this.ConversationBox);
            this.Name = "ChatroomForm";
            this.Text = "Chat";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.RichTextBox UserMessageBox;
        private System.Windows.Forms.Button SendButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox ConversationBox;
        private System.Windows.Forms.Label CharCount1Label;
        private System.Windows.Forms.Label CharCount2Label;
    }
}