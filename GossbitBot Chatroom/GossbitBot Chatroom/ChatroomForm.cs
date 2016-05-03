using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using AIMLbot;

namespace GossbitBot_Chatroom
{
    public partial class ChatroomForm : Form
    {
        bool waitDone = false;
        bool AIMode = false;
        int conversationCount = 1;

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

            if (e.KeyCode == Keys.F1)
            {
                if (AIMode == false)
                    AIMode = true;  

                else
                    AIMode = false;  
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
                lineSplitter(UserMessageBox.Text, UserLines, "You");

                //AB - If the list box is filled, this scroll the list box down to the most recently added item.
                ConversationBox.TopIndex = ConversationBox.Items.Count - 1;

                //AB - Sets the UserMessageBox to being empty.
                string userInput = UserMessageBox.Text;
                UserMessageBox.Text = null;

                //AB - Adds a delay time to represent the lag of the connection between hosts before showing 'Seen', indicating the message arrived.
                waitFunction(1500);
                label1.Text = "✔Seen";

                //LE & TB - Adds a delay with the Bot's response to allow for 'Reading Time'.
                isReading(userInput);

                //AB - Occurs when the bot is gossiping.
                if (AIMode == false)
                {
                    gossipGenerator();
                }

                //AB - Occurs when the bot is just involved in general conversation.
                if (AIMode == true)
                {
                    //AB - Takes user string and generates the response from the AIML knowledge base.
                    Request r = new Request(userInput, Program.myUser, Program.myBot);
                    Result res = Program.myBot.Chat(r);

                    //AB & ABo - Method call to the lineSplitter function, that splits long messages into separate lines and outputs them.
                    lineSplitterBot(res.Output, BotLines, "Marvin");
                }

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
                    if (count > 60 && c == ' ')
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
                    if (count > 60 && c == ' ')
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
                nameSpacing = nameSpacing + "  ";


            //AB & ABo - Outputs the first line, and if required the second and third lines.
            ConversationBox.Items.Add(name + ": " + output[1]);

            if (NewLine2 == true)
                ConversationBox.Items.Add(nameSpacing + output[2]);

            if (NewLine3 == true)
                ConversationBox.Items.Add(nameSpacing + output[3]);
        }

        //AB & ABo - Function to split long messages down into lines and output them to the conversation windows. Does not break mid word.
        private void lineSplitterBot(string input, string[] output, string name)
        {
            //AB & ABo - An integer to store the number of characters iterated through in the message string.
            int count = 0;

            //AB & ABo - Three flags to determine which line of the message is being manipulated.
            bool Line1 = true;
            bool Line2 = false;
            bool Line3 = false;

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
                        if (count > 60 && c == ' ')
                        {
                            Line1 = false;
                            Line2 = true;
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
                        if (count > 60 && c == ' ')
                        {
                            Line2 = false;
                            Line3 = true;
                            count = 0;
                        }
                }
                //AB & ABo - If the program is dealing with the second, line it adds the characters to the first line string.
                if (Line3 == true)
                {
                    output[3] = output[3] + c;
                }
            }

            botOutput(input, output, name);
        }

        //AB - Function which takes the bot output and decides to see if it will make a mistake before continuing.
        private void botOutput(string input, string[] output, string name)
        {
            //AB & ABo - Creates a blank space for the spare lines equal to the length of the users name.
            int nameLength = name.Length;
            string nameSpacing = "";
            for (int i = 0; i < nameLength; i++)
                nameSpacing = nameSpacing + "  ";


            //AB - Random number to be created to decide on the error shown.
            Random r = new Random();

            //AB - Random number generated to see if there will be an error in the line, and if so, which error.
            //AB - Errors only occur every so often to increase realism.
            int errorChoice = r.Next(1,40);


            //AB - If error 1 is chosen, marvin will accidently stop the line early and will then say 'oops' before continuing as normal.
            if(errorChoice == 1)
            {
                //AB - Two strings to store the halves of the original line.
                string lineHalf1 = "";
                string lineHalf2 = "";

                //AB - Random number to decide where the line will be split.
                int lineBreak = r.Next(0, output[1].Length);

                //AB - Counter to track through the progress towards the line split.
                int ctr = 0;

                //AB - Iterates through the line adding the characters to the first string until it reaches the break. Then it adds the characters to the second string.
                foreach(char c in output[1])
                {
                    if (ctr <= lineBreak)
                        lineHalf1 += c;

                    else
                        lineHalf2 += c;

                    ctr++;
                }

                //--- AB - Outputs all the strings in a disjointed manner. ---\\

                //AB - Types for the first half line, then outputs early.
                isTyping(lineHalf1);
                ConversationBox.Items.Add(name + ": " + lineHalf1);

                waitFunction(1000);

                //AB - Then continues to type the rest of the message as normal.
                input = lineHalf2 + output[2] + output[3];
                isTyping(input);
                string[] outputNew = new string[4];
                lineSplitter(input, outputNew, name);
            }


            //AB - If error 2 - 7 is chosen then Marvin will add accidently add a letter: q, w, or x.
            if (errorChoice == 2 | errorChoice == 3 | errorChoice == 4 | errorChoice == 5 | errorChoice == 6 | errorChoice == 7 | errorChoice == 8 | errorChoice == 9 | errorChoice == 10)
            {
                //AB - String to store the line with the added letter.
                string changedString = "";

                //AB - Random number to decide where a letter will be added.
                int swappedLetter = r.Next(0, output[1].Length);

                //AB - Counter to track through the progress towards the letter to be added.
                int ctr = 0;

                //AB - Iterates through the string, adding it to the changed string, when it finds the location for the letter to be added, it adds the letter.
                foreach(char c in output[1])
                {
                    changedString += c;

                    if (ctr == swappedLetter)
                    {
                        if (errorChoice == 2 | errorChoice == 5 | errorChoice == 8)
                            changedString += 'q';

                        if (errorChoice == 3 | errorChoice == 6 | errorChoice == 9)
                            changedString += 'w';

                        if (errorChoice == 4 | errorChoice == 7 | errorChoice == 10)
                            changedString += 'x';
                    }

                    //Iterate throuh the string
                    ctr++;
                }

                //--- AB - Outputs as normal but with the added letter. ---\\

                //LE & TB - Displays 'Marvin is tpying...' label animation while bot replies 
                isTyping(input);

                //AB & ABo - Outputs the first line, and if required the second and third lines.
                ConversationBox.Items.Add(name + ": " + changedString);

                //AB - Only outputs the second and third lines if they have something in them.
                if (output[2] != null)
                    ConversationBox.Items.Add(nameSpacing + output[2]);

                if (output[3] != null)
                    ConversationBox.Items.Add(nameSpacing + output[3]);

            }

            //AB - If no error is going to occur, the defeault output will happen.
            if (errorChoice > 10)
            {
                //LE & TB - Displays 'Marvin is tpying...' label animation while bot replies 
                isTyping(input);

                //AB & ABo - Outputs the first line, and if required the second and third lines.
                ConversationBox.Items.Add(name + ": " + output[1]);

                //AB - Only outputs the second and third lines if they have something in them.
                if (output[2] != null)
                    ConversationBox.Items.Add(nameSpacing + output[2]);

                if (output[3] != null)
                    ConversationBox.Items.Add(nameSpacing + output[3]);
            }

        }

        //AB - Function to make the program wait for given period of time, normally representing pauses before typing.
        private void waitFunction(int time)
        {
            var delay = Task.Delay(time); //1 second/1000 ms
            delay.Wait();
        }

        //AB - Function to aid in the flow of gossip.
        private void gossipGenerator()
        {
            //AB - String to store the bots output.
            string input = "";
            string input2 = "";

            string[] output = new string[4];
            string[] output2 = new string[4];

            //AB - Switch which uses different phrases depending how far through the conversation is.
            switch (conversationCount)
            {
                case 1:
                    input = "Hi";
                    isTyping(input);
                    lineSplitter(input, output, "Marvin");

                    waitFunction(1000);

                    input2 = "Alright i guess, feeling kinda annoyed though";
                    isTyping(input2);
                    lineSplitter(input2, output2, "Marvin");
                    break;

                case 2:
                    input = "Just a bit pissed off with my flatmate really. Shes just getting under my skin at the moment";
                    isTyping(input);
                    lineSplitter(input, output, "Marvin");
                    break;

                case 3:
                    input = "She just never does her washing up and just leaves all her stuff in the sink, then has a go at uss.";
                    isTyping(input);
                    lineSplitter(input, output, "Marvin");

                    waitFunction(1000);

                    input2 = "And she will not shut up, holy shit. She narrqates everything she does, no one even cares. URGH.";
                    isTyping(input2);
                    lineSplitter(input2, output2, "Marvin");
                    break;

                case 4:
                    input = "I wanted to, but I left it too late, now im stuck with the cow for another year";
                    isTyping(input);
                    lineSplitter(input, output, "Marvin");
                    break;

                case 5:
                    input = "No seriously, she's a bitch.";
                    isTyping(input);
                    lineSplitter(input, output, "Marvin");
                    break;

                case 6:
                    input = "Don't tell me my damn buiesness. You dont even know me.";
                    isTyping(input);
                    lineSplitter(input, output, "Marvin");
                    break;

                case 7:
                    input = "Yeah i'm sorry, she just gets me so wound up.";
                    isTyping(input);
                    lineSplitter(input, output, "Marvin");

                    waitFunction(1000);
                    ConversationBox.TopIndex = ConversationBox.Items.Count - 1;

                    input2 = "I don't want to talk about it anymore, lets talk about something else";
                    isTyping(input2);
                    lineSplitter(input2, output2, "Marvin");
                    break;

                //AB - Once all phrases are used it stops gossiping.
                default:
                    AIMode = true;
                    break;
            }

            //AB - Increases the count as the conversation has moved on one place.
            conversationCount++;
        }
    }
}
