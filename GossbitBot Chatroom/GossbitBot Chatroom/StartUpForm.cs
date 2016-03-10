using System;
using System.Windows.Forms;
using AIMLbot;

namespace GossbitBot_Chatroom
{
    public partial class StartUpForm : Form
    {
        public StartUpForm()
        {
            InitializeComponent();
        }

        private void ChatButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(UserNameBox.Text))
                MessageBox.Show("Please enter your name and try again.");

            else
            {
                Program.UserName = UserNameBox.Text;

                ChatroomForm Chatroom = new ChatroomForm();
                Chatroom.ShowDialog();
            }




        }
    }
}
