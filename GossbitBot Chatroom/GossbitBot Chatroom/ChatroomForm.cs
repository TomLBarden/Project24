using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using AIMLbot;

namespace GossbitBot_Chatroom
{
    public partial class ChatroomForm : Form
    {
        public ChatroomForm()
        {
            InitializeComponent();
            UserMessageBox.SelectionStart = UserMessageBox.Text.Length; //AB & ABo - Cursor starts in message box
            UserMessageBox.Focus();

            ConversationBox.Items.Add("Marvin: " + "Hi " + Program.UserName + " Nice to meet you. How are you?");

        }

        //AB & ABo - Enter button calls SendButton click event
        private void UserMessageBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendButton.PerformClick();
                e.Handled = true;
            }
        }


        private void SendButton_Click(object sender, EventArgs e)
        {
            //AB - Deals with the users message being sent.
            //AB - Handles an empty message box.
            if (string.IsNullOrWhiteSpace(UserMessageBox.Text))
                MessageBox.Show("Please enter a message to send.");

            else
            {
                //AB - Adds the data in the UserMessageBox to the ConversationBox.
                ConversationBox.Items.Add(Program.UserName + ": " + UserMessageBox.Text);

                //AB - Takes user string and generates the response from the AIML knowledge base.
                Request r = new Request(UserMessageBox.Text, Program.myUser, Program.myBot);
                Result res = Program.myBot.Chat(r);
                
                //AB - Sets the UserMessageBox to being empty.
                UserMessageBox.Text = null;

                /* LE -ALLOW FOR READING TIME - Take string, measure length, calculate appropriate delay. */
                //LE - Adds a delay with the Bot's response.
                isReading();
                var t = Task.Delay(1000); //1 second/1000 ms
                t.Wait();

                /* LE - 'isTyping' Function call - Take response, measure length, calculate appropriate time to display "User Is Typing" label. */
                isTyping();


                //AB - Adds back the response genereated by the bot back into the conversation window.
                ConversationBox.Items.Add("Marvin: " + res.Output);

               

            }
        }

        //LE - Method template for Reading time.
        private void isReading()
        {

        }

        //LE - Method template for displaying "User Is Typing". 
        private void isTyping()
        {

        }
    }
}
