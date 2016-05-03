using System;
using System.Windows.Forms;
using System.Threading.Tasks;
using AIMLbot;

namespace GossbitBot_Chatroom
{
    public partial class StartUpForm : Form
    {
        public StartUpForm()
        {
            InitializeComponent();

            //AB - Creates a random number between 100 and 999 and displays it as the current number of online users.
            Random r = new Random();
            label3.Text = Convert.ToString(r.Next(100, 1000));

            //AB & ABo - Cursor starts in the text box when the form is launched.
            UserNameBox.SelectionStart = UserNameBox.Text.Length;
            UserNameBox.Focus();
        }

        //AB & ABo - Pressing the enter key has same affect as pressing the send button.
        private void UserNameBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ChatButton.PerformClick();
                e.Handled = true;
            }
        }

        //AB - All functionality that occures when the Chat Now! button is pressed.
        private void ChatButton_Click(object sender, EventArgs e)
        {
            //AB - Checks to ensure a name is entered. If not shows a message box.
            if (string.IsNullOrWhiteSpace(UserNameBox.Text))
                MessageBox.Show("Please enter your name and try again.");

            //AB - If name is valid then it stores the name in the string and launches form2.
            else
            {
                //AB - Stores the name entered by the user.
                Program.UserName = UserNameBox.Text;

                //AB - Launches a please wait form which emulates searching for someone to 
                //     chat with.
                WaitingForm PleaseWait = new WaitingForm();
                PleaseWait.ShowDialog();

                //AB - Once the form has completed the search and is closed, it launches the chatroom.
                ChatroomForm Chatroom = new ChatroomForm();
                Hide();
                Chatroom.ShowDialog();
                Close();
            }
        }
    }
}
