using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;
using System.Globalization;

namespace Digital_Clock
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
            
            //Set the date
            date.Text = DateTime.Now.ToString("D");
        }

        //Bool to determine 12 or 24 hour format
        public bool formatSwap = false;
        private void timer1_Tick(object sender, EventArgs e)
        {
            //Set the time once timer starts
            if (!formatSwap)
            {
                time.Text = DateTime.Now.ToString("T");
            }
            else
            {
                time.Text = DateTime.Now.ToString("h:mm:ss:tt");
            }
            
        }

        //Once form is loaded start the timer
        private void Form1_Load(object sender, EventArgs e)
        {
            System.Timers.Timer timer = new System.Timers.Timer();
            timer1.Start();
        }

        //Change bool every time button is clicked
        private void TimeFormat_Click(object sender, EventArgs e)
        {
            if (!formatSwap)
            {
                formatSwap = true;
            }
            else
            {
                formatSwap = false;
            }
        }
    }
}
