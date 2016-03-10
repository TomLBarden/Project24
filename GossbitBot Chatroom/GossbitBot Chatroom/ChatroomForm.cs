using System;
using System.Windows.Forms;
using AIMLbot;

namespace GossbitBot_Chatroom
{
    public partial class ChatroomForm : Form
    {
        public ChatroomForm()
        {
            InitializeComponent();

            ConversationBox.Items.Add("Marvin: " + "Hi " + Program.UserName + " Nice to meet you. How are you?");
        }

        private void SendButton_Click(object sender, EventArgs e)
        {
            //Deals with the users message being sent.
            //Handles an empty message box.
            if (string.IsNullOrWhiteSpace(UserMessageBox.Text))
                MessageBox.Show("Please enter a message to send.");

            //Adds the data in the UserMessageBox to the ConversationBox.
            ConversationBox.Items.Add(Program.UserName + ": " + UserMessageBox.Text);
            //Sets the UserMessageBox to being empty.
            UserMessageBox.Text = null;


            // -----    -----


            //Deals with the chat rooms reply. 
            ConversationBox.Items.Add("Marvin: Here is my generic response, I am only a basic AI please love me.");
        }
    }
}
