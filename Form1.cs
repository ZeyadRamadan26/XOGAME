using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace game_xOXO
{
    public partial class Form1 : Form
    {
        System.Media.SoundPlayer playermus = new System.Media.SoundPlayer();
        public enum player
        {
            X, O
        }
        player CURRENTPLAYER;
        Random random = new Random();
        int playerWincount = 0;
        int cpuwincount = 0;
        List<Button> buttons;

        public Form1()
        {
            InitializeComponent();
            resetgame();
            playermus.SoundLocation = "Jingle Bells Christmas Song.wav";
        }

        private void Playerclickbutton(object sender, EventArgs e)
        {
            var button = (Button)sender;
            CURRENTPLAYER = player.X;
            button.Text = CURRENTPLAYER.ToString();
            button.Enabled = false;
            button.BackColor = Color.Cyan;
            buttons.Remove(button);
            checkgame();
            Gametimer.Start();
        }

        private void resetgame(object sender, EventArgs e)
        {
            resetgame();
        }

        private void cpumove(object sender, EventArgs e)
        {
            if (buttons.Count > 0)
            {
                int index = random.Next(0, buttons.Count);
                buttons[index].Enabled = false;
                CURRENTPLAYER = player.O;
                buttons[index].Text = CURRENTPLAYER.ToString();
                buttons[index].BackColor = Color.Pink;
                buttons.RemoveAt(index);
                checkgame();
                Gametimer.Stop();
            }

        }
        private void checkgame()
        {
            if (button1.Text == "X" && button5.Text == "X" && button3.Text == "X" ||
                button4.Text == "X" && button2.Text == "X" && button10.Text == "X" ||
                button9.Text == "X" && button8.Text == "X" && button7.Text == "X" ||
                button1.Text == "X" && button4.Text == "X" && button9.Text == "X" ||
                button5.Text == "X" && button2.Text == "X" && button8.Text == "X" ||
                button3.Text == "X" && button10.Text == "X" && button7.Text == "X" ||
                button1.Text == "X" && button2.Text == "X" && button7.Text == "X" ||
                button3.Text == "X" && button2.Text == "X" && button9.Text == "X")
            {
                Gametimer.Stop();
                MessageBox.Show("Player one wins", "Dark Warrior say");
                playerWincount++;
                label1.Text = "Player Wins:" + playerWincount;
                resetgame();
            }
            else if (button1.Text == "O" && button5.Text == "O" && button3.Text == "O" ||
                button4.Text == "O" && button2.Text == "O" && button10.Text == "O" ||
                button9.Text == "O" && button8.Text == "O" && button7.Text == "O" ||
                button1.Text == "O" && button4.Text == "O" && button9.Text == "O" ||
                button5.Text == "O" && button2.Text == "O" && button8.Text == "O" ||
                button3.Text == "O" && button10.Text == "O" && button7.Text == "O" ||
                button1.Text == "O" && button2.Text == "O" && button7.Text == "O" ||
                button3.Text == "O" && button2.Text == "O" && button9.Text == "O")
            {
                Gametimer.Stop();
                MessageBox.Show("cpu wins", "Dark Warrior say");
                cpuwincount++;
                label3.Text = "CPU Player Wins:" + cpuwincount;
                resetgame();
            }
        }
        private void resetgame() 
        {
            buttons = new List<Button>
            { button1, button2, button3 , button4, button5,
                button10, button7, button8, button9 };
            foreach (Button b in buttons) 
            {
                b.Enabled = true;
                b.Text = "X/O";
                b.BackColor = DefaultBackColor;
            
            }
        }

        private void party(object sender, EventArgs e)
        {
            playermus.Play();
        }

        private void NAV3(object sender, EventArgs e)
        {
            this.Hide();
            Form3 f3 = new Form3();
            f3.Show();
        }

       
    }
}
