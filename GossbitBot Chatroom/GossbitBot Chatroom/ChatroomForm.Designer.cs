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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChatroomForm));
            this.UserMessageBox = new System.Windows.Forms.RichTextBox();
            this.SendButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.CharCount1Label = new System.Windows.Forms.Label();
            this.CharCount2Label = new System.Windows.Forms.Label();
            this.ConversationBox = new System.Windows.Forms.ListBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.SuspendLayout();
            // 
            // UserMessageBox
            // 
            this.UserMessageBox.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UserMessageBox.Location = new System.Drawing.Point(12, 373);
            this.UserMessageBox.MaxLength = 160;
            this.UserMessageBox.Name = "UserMessageBox";
            this.UserMessageBox.Size = new System.Drawing.Size(418, 64);
            this.UserMessageBox.TabIndex = 1;
            this.UserMessageBox.Text = "";
            this.UserMessageBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.UserMessageBox_KeyDown);
            // 
            // SendButton
            // 
            this.SendButton.Location = new System.Drawing.Point(452, 390);
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
            this.label1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(12, 353);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 18);
            this.label1.TabIndex = 3;
            // 
            // CharCount1Label
            // 
            this.CharCount1Label.AutoSize = true;
            this.CharCount1Label.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CharCount1Label.Location = new System.Drawing.Point(373, 353);
            this.CharCount1Label.Name = "CharCount1Label";
            this.CharCount1Label.Size = new System.Drawing.Size(27, 16);
            this.CharCount1Label.TabIndex = 4;
            this.CharCount1Label.Text = "   0";
            // 
            // CharCount2Label
            // 
            this.CharCount2Label.AutoSize = true;
            this.CharCount2Label.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CharCount2Label.Location = new System.Drawing.Point(397, 353);
            this.CharCount2Label.Name = "CharCount2Label";
            this.CharCount2Label.Size = new System.Drawing.Size(37, 16);
            this.CharCount2Label.TabIndex = 5;
            this.CharCount2Label.Text = "/ 150";
            // 
            // ConversationBox
            // 
            this.ConversationBox.ColumnWidth = 480;
            this.ConversationBox.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ConversationBox.FormattingEnabled = true;
            this.ConversationBox.HorizontalScrollbar = true;
            this.ConversationBox.ItemHeight = 18;
            this.ConversationBox.Location = new System.Drawing.Point(12, 77);
            this.ConversationBox.MaximumSize = new System.Drawing.Size(489, 300);
            this.ConversationBox.Name = "ConversationBox";
            this.ConversationBox.Size = new System.Drawing.Size(489, 274);
            this.ConversationBox.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(400, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(109, 40);
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(121, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 13);
            this.label2.TabIndex = 8;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(15, 12);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(124, 60);
            this.pictureBox3.TabIndex = 9;
            this.pictureBox3.TabStop = false;
            // 
            // ChatroomForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(514, 443);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.CharCount2Label);
            this.Controls.Add(this.CharCount1Label);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.SendButton);
            this.Controls.Add(this.UserMessageBox);
            this.Controls.Add(this.ConversationBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ChatroomForm";
            this.Text = "Chat";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.RichTextBox UserMessageBox;
        private System.Windows.Forms.Button SendButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label CharCount1Label;
        private System.Windows.Forms.Label CharCount2Label;
        private System.Windows.Forms.ListBox ConversationBox;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox3;
    }
}