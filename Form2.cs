using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace game_xOXO
{
    public partial class Form2 : Form
    {

        public enum player
        {
            X, O
        }
        player CURRENTPLAYER;
        int playerone = 0;
        int playertwo = 0;
        List<Button> buttons;
        public Form2()
        {
            InitializeComponent();
            resetgame();
        }

        private void CheckGame()
        {
            if (check_game(player.X))
            {
                MessageBox.Show("Player_X_win", "Dark_Warrior");
                playerone++;
                label1.Text = "Playerone Wins: " + playerone;
                resetgame();
            }
            else if (check_game(player.O))
            {
                MessageBox.Show("Player_O_win", "Dark_Warrior");
                playertwo++;
                label2.Text = "Playertwo Wins: " +  playertwo;
                resetgame();
            }
            else if (buttons.Count == 0)
            {
                MessageBox.Show("It's a draw!", "Game Over");
                resetgame();
            }
        }


        private bool check_game(player CURRENTPLAYER)
        {
            if (button1.Text == "X" && button2.Text == "X" && button3.Text == "X" ||
                button4.Text == "X" && button5.Text == "X" && button6.Text == "X" ||
                button7.Text == "X" && button8.Text == "X" && button9.Text == "X" ||
                button1.Text == "X" && button4.Text == "X" && button7.Text == "X" ||
                button2.Text == "X" && button5.Text == "X" && button8.Text == "X" ||
                button3.Text == "X" && button6.Text == "X" && button9.Text == "X" ||
                button1.Text == "X" && button5.Text == "X" && button9.Text == "X" ||
                button3.Text == "X" && button5.Text == "X" && button7.Text == "X")
            {
              return CURRENTPLAYER == player.X;
            }
            else if (button1.Text == "O" && button2.Text == "O" && button3.Text == "O" ||
                button4.Text == "O" && button5.Text == "O" && button6.Text == "O" ||
                button7.Text == "O" && button8.Text == "O" && button9.Text == "O" ||
                button1.Text == "O" && button4.Text == "O" && button7.Text == "O" ||
                button2.Text == "O" && button5.Text == "O" && button8.Text == "O" ||
                button3.Text == "O" && button6.Text == "O" && button9.Text == "O" ||
                button1.Text == "O" && button5.Text == "O" && button9.Text == "O" ||
                button3.Text == "O" && button5.Text == "O" && button7.Text == "O")
            {
                return CURRENTPLAYER == player.O;
            }
            return false;
        }
        private void resetgame()
        {
            buttons = new List<Button>
            { button1, button2, button3 , button4, button5,
                button6, button7, button8, button9 };
            foreach (Button b in buttons)
            {
                b.Enabled = true;
                b.Text = "X/O";
                b.BackColor = DefaultBackColor;

            }
        }

     

        private void resetgame(object sender, EventArgs e)
        {
            resetgame();
        }

        private void chooseone(object sender, EventArgs e)
        {
            var button = (Button)sender;
            button.Enabled = false;

            if (CURRENTPLAYER == player.X)
            {
                button.Text = player.X.ToString();
                button.BackColor = Color.Cyan;
            }
            else
            {
                button.Text = player.O.ToString();
                button.BackColor = Color.Pink;
            }

            buttons.Remove(button);
            CheckGame();
            SwitchPlayer();
        }
        private void SwitchPlayer()
        {
            CURRENTPLAYER = (CURRENTPLAYER == player.X) ? player.O : player.X;
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void nav4(object sender, EventArgs e)
        {
            this.Hide();
            Form3 f3 = new Form3();
            f3.Show();
        }
    }
}
