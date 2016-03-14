using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using AIMLbot;

namespace GossbitBot_Chatroom
{
    public partial class ChatroomForm : Form
    {
        bool waitDone = false;

        public ChatroomForm()
        {
            InitializeComponent();

            //AB - Calls the shown method when the form is first initialised.
            this.Shown += new System.EventHandler(this.ChatroomForm_Shown);
        }

        //AB - Method used upon creation and first run of the form.
        private void ChatroomForm_Shown(object sender, EventArgs e)
        {
            //AB - Inputs a first message to the chat bot telling it the Users name.
            string FirstMessageToBot = "my name is " + Program.UserName;
            Request r = new Request(FirstMessageToBot, Program.myUser, Program.myBot);
            Result res = Program.myBot.Chat(r);

            //AB - Causes chatbot to wait briefly before sending the first message.
            var delay = Task.Delay(1000); //1 second/1000 ms
            delay.Wait();
            isTyping(res.Output);

            //AB - Outputs the first sentence from the chatbot.
            ConversationBox.Items.Add("Marvin: " + res.Output);

            //AB & ABo - Cursor starts in the text box.
            UserMessageBox.SelectionStart = UserMessageBox.Text.Length;
            UserMessageBox.Focus();
        }

        //AB & ABo - Event that occurs when the user tpyes in the UserMessageBox.
        private void UserMessageBox_KeyDown(object sender, KeyEventArgs e)
        {
            //AB - Boolean flag that indicates if the key pressed was a character of a digit. 
            bool isCharOrDigit = char.IsLetterOrDigit((char)e.KeyCode);

            //AB & ABo - Pressing the enter key has same affect as pressing the send button.
            if (e.KeyCode == Keys.Enter)
            {
                SendButton.PerformClick();
                e.Handled = true;
            }

            //AB - Performs a decrease of the count when the backspace or enter key is pressed.
            if (e.KeyCode == Keys.Back || e.KeyCode == Keys.Delete)
            {
                //AB - Updates the count display, with the correct formatting for a 1 digit count.
                if (UserMessageBox.Text.Length + 1 > 1 && UserMessageBox.Text.Length + 1 <= 9)
                {
                    CharCount1Label.Text = "   " + Convert.ToString(UserMessageBox.Text.Length - 1);
                    CharCount1Label.Refresh();
                }

                //AB - Updates the count display, with the correct formatting for a 2 digit count.
                if (UserMessageBox.Text.Length + 1 >= 10 && UserMessageBox.Text.Length + 1 <= 99)
                {
                    CharCount1Label.Text = "  " + Convert.ToString(UserMessageBox.Text.Length - 1);
                    CharCount1Label.Refresh();
                }

                //AB - Updates the count display, with the correct formatting for a 3 digit count.
                if (UserMessageBox.Text.Length + 1 >= 100 && UserMessageBox.Text.Length + 1 <= 150)
                {
                    CharCount1Label.Text = Convert.ToString(UserMessageBox.Text.Length - 1);
                    CharCount1Label.Refresh();                    
                }
            }

            //AB - Performs an increase of the count when a alphanumeric character is pressed.
            if (isCharOrDigit == true | e.KeyCode == Keys.Space)
            {
                //AB - Updates the count display, with the correct formatting for a 1 digit count.
                if (UserMessageBox.Text.Length + 1 <= 9)
                {
                    CharCount1Label.Text = "   " + Convert.ToString(UserMessageBox.Text.Length + 1);
                    CharCount1Label.Refresh();
                }

                //AB - Updates the count display, with the correct formatting for a 2 digit count.
                if (UserMessageBox.Text.Length + 1 >= 10 && UserMessageBox.Text.Length + 1 <= 99)
                {
                    CharCount1Label.Text = "  " + Convert.ToString(UserMessageBox.Text.Length + 1);
                    CharCount1Label.Refresh();
                }

                //AB - Updates the count display, with the correct formatting for a 3 digit count.
                if (UserMessageBox.Text.Length + 1 >= 100 && UserMessageBox.Text.Length + 1 <= 150)
                {
                    CharCount1Label.Text = Convert.ToString(UserMessageBox.Text.Length + 1);
                    CharCount1Label.Refresh();
                }
            }


        }   

        //AB & LE & TB - All functionality that occurs when the send button is pressed.
        private void SendButton_Click(object sender, EventArgs e)
        {
            string[] UserLines = new string[4];
            string[] BotLines = new string[4];

            //AB - Deals with the users message being sent.
            //AB - Handles an empty message box.
            if (string.IsNullOrWhiteSpace(UserMessageBox.Text))
                MessageBox.Show("Please enter a message to send.");

            else
            {
                //AB - Resets character counter upon pressing send.
                CharCount1Label.Text = "   0";
                CharCount1Label.Refresh();

                //AB & ABo - Method call to the lineSplitter function, that splits long messages into separate lines and outputs them.
                lineSplitter(UserMessageBox.Text, UserLines, Program.UserName);

                //AB - If the list box is filled, this scroll the list box down to the most recently added item.
                ConversationBox.TopIndex = ConversationBox.Items.Count - 1;

                //AB - Takes user string and generates the response from the AIML knowledge base.
                Request r = new Request(UserMessageBox.Text, Program.myUser, Program.myBot);
                Result res = Program.myBot.Chat(r);

                //AB - Sets the UserMessageBox to being empty.
                string userInput = UserMessageBox.Text;
                UserMessageBox.Text = null;

                //AB - Adds a delay time to represent the lag of the connection between hosts before showing 'Seen', indicating the message arrived.
                var delay = Task.Delay(1000); //1 second/1000 ms
                delay.Wait();
                label1.Text = "✔Seen";

                //LE & TB - Adds a delay with the Bot's response to allow for 'Reading Time'.
                isReading(userInput);

                //LE & TB - Displays 'Marvin is tpying...' label animation while bot replies 
                isTyping(res.Output);

                //AB & ABo - Method call to the lineSplitter function, that splits long messages into separate lines and outputs them.
                lineSplitter(res.Output, BotLines, "Marvin");    

                //AB - If the list box is filled, this scroll the list box down to the most recently added item.
                ConversationBox.TopIndex = ConversationBox.Items.Count - 1;
            }
        }

        //LE & TB - Method for Reading time.
        private void isReading(string userInput)
        {
            var delay = Task.Delay(userInput.Length * 75);
            delay.Wait();
        }

        //LE & TB - Method for displaying "User Is Typing". 
        private void isTyping(string output)
        {
            int waitDelay = 300;

            var delay = Task.Delay(output.Length * 100).ContinueWith(_ =>
            {
                waitDone = true;
            });
            
            while (waitDone == false)
            {
                Task.Delay(waitDelay).Wait();
                label1.Text = "Marvin is typing";
                Task.Delay(waitDelay).Wait();
                label1.Text = "Marvin is typing.";
                Task.Delay(waitDelay).Wait();
                label1.Text = "Marvin is typing..";
                Task.Delay(waitDelay).Wait();
                label1.Text = "Marvin is typing...";
                Task.Delay(waitDelay).Wait();
            }

            waitDone = false;
            label1.Text = "";
        }

        //AB & ABo - Function to split long messages down into lines and output them to the conversation windows. Does not break mid word.
        private void lineSplitter(string input, string[] output, string name)
        {
            //AB & ABo - An integer to store the number of characters iterated through in the message string.
            int count = 0;

            //AB & ABo - Three flags to determine which line of the message is being manipulated.
            bool Line1 = true;
            bool Line2 = false;
            bool Line3 = false;

            //AB & ABo - Two flags to indicate is a new line is required.
            bool NewLine2 = false;
            bool NewLine3 = false;
            output[0] = input;

            //AB & ABo - A foreach loop which iterates through each letter of the message and assigns it to the appropriate line.
            foreach (char c in output[0])
            {
                //AB & ABo - If the program is dealing with the first line, it adds the characters to the first line string.
                if (Line1 == true)
                {
                    output[1] = output[1] + c;
                    count++;

                    //AB & ABo - Once the first 50 characters have been added to the string AND the next character is an empty space, 
                    //           the program moves to the next line.
                    if (count > 50 && c == ' ')
                    {
                        Line1 = false;
                        Line2 = true;
                        NewLine2 = true;
                        count = 0;
                    }
                }

                //AB & ABo - If the program is dealing with the second, line it adds the characters to the first line string.
                if (Line2 == true)
                {
                    output[2] = output[2] + c;
                    count++;

                    //AB & ABo - Once the first 50 characters have been added to the string AND the next character is an empty space, 
                    //           the program moves to the next line.
                    if (count > 50 && c == ' ')
                    {
                        Line2 = false;
                        Line3 = true;
                        NewLine3 = true;
                        count = 0;
                    }
                }
                //AB & ABo - If the program is dealing with the second, line it adds the characters to the first line string.
                if (Line3 == true)
                {
                    output[3] = output[3] + c;
                }
            }

            //AB & ABo - Creates a blank space for the spare lines equal to the length of the users name.
            int nameLength = name.Length;
            string nameSpacing = "";
            for (int i = 0; i < nameLength; i++)
                nameSpacing = nameSpacing + "   ";


            //AB & ABo - Outputs the first line, and if required the second and third lines.
            ConversationBox.Items.Add(name + ": " + output[1]);

            if (NewLine2 == true)
                ConversationBox.Items.Add(nameSpacing + output[2]);

            if (NewLine3 == true)
                ConversationBox.Items.Add(nameSpacing + output[3]);
        }
    }
}
