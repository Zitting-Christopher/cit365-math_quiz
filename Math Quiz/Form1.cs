using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Math_Quiz
{
    public partial class Form1 : Form
    {
        // Create a Random object called randomizer 
        // to generate random numbers.
        Random randomizer = new Random();

        //Time Left
        int timeLeft;

        //Addition integers
        int addend1;
        int addend2;

        //Subtraction Integers
        int subend1;
        int subend2;

        //Multiplication Integers
        int timesend1;
        int timesend2;

        //Division Integers
        int divend1;
        int divend2;

        //Start Quiz
        public void StartTheQuiz()
        {
            //Addition problem - generate two randos, store values
            addend1 = randomizer.Next(51);
            addend2 = randomizer.Next(51);

            //Convert randos to strings
            plusLeftLabel.Text = addend1.ToString();
            plusRightLabel.Text = addend2.ToString();

            //sum is name of NumericUpDown control, value set to 0
            sum.Value = 0;

            //subtraction problem - generate two randos, store values
            subend1 = randomizer.Next(1,101);
            subend2 = randomizer.Next(1,subend1);

            //Convert randos to strings
            minusLeftLabel.Text = subend1.ToString();
            minusRightLabel.Text = subend2.ToString();

            //difference is name of NumericUpDown control, value set to 0
            difference.Value = 0;

            //Multiplication problem - generate two randos, store values
            timesend1 = randomizer.Next(2,11);
            timesend2 = randomizer.Next(2,11);

            //Convert randos to strings
            timesLeftLabel.Text = timesend1.ToString();
            timesRightLabel.Text = timesend2.ToString();

            //product is name of NumericUpDown control, value set to 0
            product.Value = 0;

            //division problem - generate two randos, store values
            divend1 = randomizer.Next(2,11);
            int tempQuotient = randomizer.Next(2, 11);
            divend2 = divend1 * tempQuotient;

            //Convert randos to strings
            dividedLeftLabel.Text = divend2.ToString();
            dividedRightLabel.Text = divend1.ToString();

            //quotient is name of NumericUpDown control, value set to 0
            quotient.Value = 0;

            //Start timer
            timeLeft = 30;
            timeLabel.Text = "30 seconds";
            timer1.Start();
        }

        //Check the answer
        private bool CheckTheAnswer()
        {
            if ((addend1 + addend2 == sum.Value)
                &&(subend1 - subend2 == difference.Value)
                &&(timesend1 * timesend2 == product.Value)
                &&(divend2 / divend1 == quotient.Value))
                return true;
            else
                return false;
        }

        public Form1()
        {
            InitializeComponent();
            DateTime dt = DateTime.Today;
            dateLabel1.Text = dt.ToString("dd MMMM yyyy");
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click_1(object sender, EventArgs e)
        {

        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void product_ValueChanged(object sender, EventArgs e)
        {

        }

        private void startButton_Click(object sender, EventArgs e)
        {
            StartTheQuiz();
            startButton.Enabled = false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (CheckTheAnswer())
            {
                timer1.Stop();
                MessageBox.Show("You got all the answers right!", "Congratulations");
                startButton.Enabled = true;
                startButton.Text = "Start over";
            }

            if (timeLeft > 0)
            {
                timeLeft = timeLeft - 1;
                timeLabel.Text = timeLeft + " seconds";
            }

            else
            {
                timer1.Stop();
                timeLabel.Text = "Time's up!";
                MessageBox.Show("You didn't finish in time.", "Sorry!");
                sum.Value = addend1 + addend2;
                difference.Value = subend1 - subend2;
                product.Value = timesend1 * timesend2;
                quotient.Value = divend1 / divend2;
                startButton.Enabled = true;
                startButton.Text = "Try again";
            }
        }

        private void answer_Enter(object sender, EventArgs e)
        {
            NumericUpDown answerBox = sender as NumericUpDown;

            if (answerBox != null)
            {
                int lengthOfAnswer = answerBox.Value.ToString().Length;
                answerBox.Select(0, lengthOfAnswer);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void dateLabel1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void aboutToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            string msg = "Created from the Create a timed math quiz tutorial."
                + Environment.NewLine + "Put together by Chris Zitting";
            MessageBox.Show(msg, "About Math Quiz");
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string link = "https://www.hostyour.space/";
            System.Diagnostics.Process.Start(link);
        }
    }
}
