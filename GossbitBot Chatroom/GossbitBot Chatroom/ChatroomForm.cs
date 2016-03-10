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
            //AB - Deals with the users message being sent.
            //AB - Handles an empty message box.
            if (string.IsNullOrWhiteSpace(UserMessageBox.Text))
                MessageBox.Show("Please enter a message to send.");

            //AB - Adds the data in the UserMessageBox to the ConversationBox.
            ConversationBox.Items.Add(Program.UserName + ": " + UserMessageBox.Text);

            //AB - Takes user string and generates the response from the AIML knowledge base.
            Request r = new Request(UserMessageBox.Text, Program.myUser, Program.myBot);
            Result res = Program.myBot.Chat(r);

            //AB - Adds back the response genereated by the bot back into the conversation window.
            ConversationBox.Items.Add("Marvin: " + res.Output);

            //AB - Sets the UserMessageBox to being empty.
            UserMessageBox.Text = null;
        }
    }
}
