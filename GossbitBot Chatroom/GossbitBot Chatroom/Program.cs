using System;
using System.Windows.Forms;
using AIMLbot;

namespace GossbitBot_Chatroom
{
    public class Program
    {
        //AB - A string to store the users inputted name.
        public static string UserName;
        public static Bot myBot;
        public static User myUser;


        /// The main entry point for the application.
        [STAThread]
        static void Main()
        {
            //AB - Loads all of the AIML related files/settings.
            myBot = new Bot();
            myBot.loadSettings();
            myUser = new User("consoleUser", myBot);
            myBot.isAcceptingUserInput = false;
            myBot.loadAIMLFromFiles();
            myBot.isAcceptingUserInput = true;

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new StartUpForm());          
        }


    }
}
