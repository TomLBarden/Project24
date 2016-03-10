using System;
using System.Windows.Forms;
using AIMLbot;

namespace GossbitBot_Chatroom
{
    static class Program
    {
        //A string to store the users inputted name.
        public static string UserName;


        /// The main entry point for the application.
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new StartUpForm());
        }


    }
}
