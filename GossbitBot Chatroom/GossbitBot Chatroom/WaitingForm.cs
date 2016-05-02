using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GossbitBot_Chatroom
{
    public partial class WaitingForm : Form
    {
        bool waitDone = false;

        public WaitingForm()
        {
            InitializeComponent();

            //AB - Calls the shown method when the form is first initialised.
            this.Shown += new System.EventHandler(this.Form1_Shown);
        }

        //AB - Method used upon creation and first run of the form.
        private void Form1_Shown(object sender, EventArgs e)
        {
            pleaseWait();

            //AB - Once the pleaseWait function has finished, the label text is changed.
            label3.Text = "Complete.";
            label3.Refresh();

            //AB - Slight pause before the form closes.
            var delay = Task.Delay(1000); //1 second/1000 ms
            delay.Wait();

            this.Close(); 
        }

        //AB - An adapted version of LE & TB's isTyping function to show
        //     the program searching for someone for the user to chat with.
        private void pleaseWait()
        {
            int waitDelay = 250;

            var delay = Task.Delay(10000).ContinueWith(_ =>
            {
                waitDone = true;
            });

            while (waitDone == false)
            {
                Task.Delay(waitDelay).Wait();
                label3.Text = "Searching";
                label3.Refresh();
                Task.Delay(waitDelay).Wait();
                label3.Text = "Searching.";
                label3.Refresh();
                Task.Delay(waitDelay).Wait();
                label3.Text = "Searching..";
                label3.Refresh();
                Task.Delay(waitDelay).Wait();
                label3.Text = "Searching...";
                label3.Refresh();
                Task.Delay(waitDelay).Wait();
            }

            waitDone = false;
        }
    }
}
