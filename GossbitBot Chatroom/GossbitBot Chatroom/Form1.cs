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
    public partial class Form1 : Form
    {
        public Form1()
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

                Form2 Chatroom = new Form2();
                Chatroom.ShowDialog();
            }




        }
    }
}
