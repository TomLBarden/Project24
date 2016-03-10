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
            UserNameBox.SelectionStart = UserNameBox.Text.Length;//AB & ABo - Cursor starts in message box
            UserNameBox.Focus();
        }

        //AB & ABo - Enter button calls ChatButton click event
        private void UserNameBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ChatButton.PerformClick();
                e.Handled = true;
            }
        }

        private void ChatButton_Click(object sender, EventArgs e)
        {
            //AB - Checks to ensure a name is entered. If not shows a message box.
            if (string.IsNullOrWhiteSpace(UserNameBox.Text))
                MessageBox.Show("Please enter your name and try again.");

            //AB - If name is valid then it stores the name in the string and launches form2.
            else
            {
                Program.UserName = UserNameBox.Text;

                ChatroomForm Chatroom = new ChatroomForm();
                Hide();
                Chatroom.ShowDialog();
                Close();
            }




        }
    }
}
