using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Flappy_Bird_pratice
{
    public partial class birdGame : Form
    {

        int pipeSpeed = 8;
        int gravity = 5;
        int score = 0;

        public birdGame()
        {
            InitializeComponent();
        }

        private void gameTimerEvent(object sender, EventArgs e)
        {
            flappyBird.Top += gravity;
            pipeBottom.Left -= pipeSpeed;
            pipeTop.Left -= pipeSpeed;
            scoreTxt.Text = score.ToString();

            if (pipeBottom.Left < -250)
            {
                pipeBottom.Left = 600;
                score++;

            }
            if (pipeTop.Left < -180)
            {
                pipeTop.Left = 750;
                score++;
            }
            if (flappyBird.Bounds.IntersectsWith(pipeBottom.Bounds) ||
                flappyBird.Bounds.IntersectsWith(pipeTop.Bounds) ||
                flappyBird.Bounds.IntersectsWith(ground.Bounds)
                )
            {
                endGame();
            }

            if(score > 5)
            {
                pipeSpeed = 10;
            }
            if (score > 15)
            {
                pipeSpeed = 15;
            }
            if(flappyBird.Top < -25)
            {
                endGame();
            }
        }

        private void gameKeyIsDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Space)
            {
                gravity = -8;
            }
        }

 

        private void gameKeyIsUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                gravity = 8;
            }
        }

        private void endGame()
        {
            gameTimer.Stop();
            scoreTxt.Text += " Meters flown. Game over. " ;
        }
         

        private void ground_Click(object sender, EventArgs e)
        {

        }
    }

    
}
