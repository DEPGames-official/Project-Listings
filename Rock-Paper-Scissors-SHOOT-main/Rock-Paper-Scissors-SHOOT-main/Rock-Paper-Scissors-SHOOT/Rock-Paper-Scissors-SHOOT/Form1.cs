using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Rock_Paper_Scissors_SHOOT
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public void button1_Click(object sender, EventArgs e)
        {
            RPCText.Visible = true;

            Results.Visible = false;

            RPCText.Text = "Select Rock, Paper, or Scissors";
            RPCText.Font = new Font("Segoe UI", 30);
            
            RockSelect.Visible = true;
            RockSelect.Enabled = true;

            PaperSelect.Visible = true;
            PaperSelect.Enabled = true;

            ScissorsSelect.Visible = true;
            ScissorsSelect.Enabled = true;
            
            StartGameButton.Visible = false;
        }

        Random randomRPC = new Random();
        int number;
        private void RPCTimer_Tick(object sender, EventArgs e)
        {
            if (RPCText.Text == "Rock")
            {
                RPCText.Text = "Paper";
            }
            else if (RPCText.Text == "Paper")
            {
                RPCText.Text = "Scissors!";
            }
            else if (RPCText.Text == "Scissors!")
            {
                RPCText.Text = "SHOOT!";
                
            }
            else
            {
                RPCTimer.Enabled = false;
                RPCText.Visible = false;

                Results.Visible = true;

                StartGameButton.Visible = true;
            }
            
        }

        
        private void RockSelect_Click(object sender, EventArgs e)
        {
            number = randomRPC.Next(3);
            if (number == 1)
            {
                Results.Text = "Rock: Tie";
            }
            else if (number == 3)
            {
                Results.Text = "Scissors: Congratulations You WON!";
            }
            else
            {
                Results.Text = "Paper: Lost, Try Again?";
            }
            EnableDisableRPCButtons(false);

            RPCText.Text = "Rock";
            RPCTimer.Interval = 2000;
            RPCTimer.Enabled = true;
        }

        private void PaperSelect_Click(object sender, EventArgs e)
        {
            number = randomRPC.Next(3);
            if (number == 2)
            {
                Results.Text = "Paper: Tie";
            }
            else if (number == 1)
            {
                Results.Text = "Rock: Congratulations You WON!";
            }
            else
            {
                Results.Text = "Scissors: Lost, Try Again?";
            }
            EnableDisableRPCButtons(false);

            RPCText.Text = "Rock";
            RPCTimer.Interval = 1500;
            RPCTimer.Enabled = true;
        }

        private void ScissorsSelect_Click(object sender, EventArgs e)
        {
            number = randomRPC.Next(3);
            if (number == 3)
            {
                Results.Text = "Scissors: Tie";
            }
            else if (number == 2)
            {
                Results.Text = "Paper: Congratulations You WON!";
            }
            else
            {
                Results.Text = "Rock: Lost, Try Again?";
            }

            EnableDisableRPCButtons(false);

            RPCText.Text = "Rock";
            RPCTimer.Interval = 2000;
            RPCTimer.Enabled = true;
        }

        private void EnableDisableRPCButtons(bool enabled)
        {
            RockSelect.Enabled = enabled;
            PaperSelect.Enabled = enabled;
            ScissorsSelect.Enabled = enabled;
        }
    }
}
