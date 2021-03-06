﻿using System;
using System.Windows.Forms;
using AIMLbot;

namespace GossbitBot_Chatroom
{
    public class Program
    {
        //AB - A string to store the users inputted name.
        public static string UserName;

        //AB - An int to store the number of characters in the users message.
        public static int CharacterCount = 0;
        

        //AB - Creates objects used by in AIML.
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
