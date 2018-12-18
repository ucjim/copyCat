using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CopyCat
{
    public partial class Form1 : Form
    {
        Random random = new Random();
        Stats stats = new Stats();

        public Form1()
        {
            InitializeComponent();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            //Add a random key to the listBox

            letterBox.Items.Add((Keys)random.Next(65, 90));
            if (letterBox.Items.Count > 7)
            {
                letterBox.Items.Clear();
                letterBox.Items.Add("Game Over!");
                timer.Stop();
                MessageBox.Show("คุณแพ้แล้ว");
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            //If the user pressed a key that's in the letterBox, remove it
            //and then make the game move faster

            if (letterBox.Items.Contains(e.KeyCode))
            {
                
                    
                   
                letterBox.Items.Remove(e.KeyCode);
                letterBox.Refresh();
                if (timer.Interval > 400)
                    timer.Interval = timer.Interval - 10;
                if (timer.Interval > 250)
                    timer.Interval = timer.Interval - 7;
                if (timer.Interval > 100)
                    timer.Interval = timer.Interval - 2;
                progressBar.Value = 800 - timer.Interval;


                //User pressed a correct key, so update the stats object
                //by calling its update() method with argument true
                stats.Update(true);

            }
            else
            {
                //The user pressed incorrect key, so update the stats object
                //by calling its update() method with arguement false
                stats.Update(false);
                letterBox.Items.Clear();
                letterBox.Items.Add("Game Over!");
                timer.Stop();
                MessageBox.Show("คุณแพ้แล้วเรื่อวจากพิมพ์ผิด");


            }

            //Update status strip labels
            correctLabel.Text = "Correct: " + stats.Correct;
            missedLabel.Text = "Missed: " + stats.Missed;
            accuracyLabel.Text = "Accuracry: " + stats.Accurate + "%";
            
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            letterBox.Items.Clear();
            timer.Start();
        }
    }
}
