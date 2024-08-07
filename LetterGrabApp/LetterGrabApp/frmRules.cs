using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace LetterGrabApp
{
    public partial class frmRules : Form
    {
        System.Windows.Forms.Timer tmrheader = new System.Windows.Forms.Timer();
        int position = 0;
        StringBuilder buildtxt = new();
        public frmRules()
        {
            InitializeComponent();
            tmrheader.Tick += Tmr_Tick;

            tmrheader.Enabled = true;
            tmrheader.Interval = 30;
        }

        private void Tmr_Tick(object? sender, EventArgs e)
        {
            CreateCoolString(GetRules(), lblRules);
        }

        private void CreateCoolString(String txt, Label lbl)
        {
            buildtxt.Append(txt[position]);
            position = position + 1;
            lbl.Text = buildtxt.ToString();
            if (position == txt.Count())
            {
                tmrheader.Enabled = false;
            }
        }

        private String GetRules()
        {
            StringBuilder txt = new();
            txt.Append("Hello and Welcome to LetterGrab!"
                + Environment.NewLine
                + "Please see a game description and rules below."
                + Environment.NewLine
                + "Game Description and Rules:"
                + Environment.NewLine
                + "• The game begins with an empty 10x10 grid. "
                + Environment.NewLine
                + "• Each player will use their turn to try and fill as many empty spots by filling them with one word per turn."
                + Environment.NewLine
                + "• Words can be inputted either horizontal, vertical or diagonal. Horizontal must  flow from left to right, vertical words must flow from top to bottom and diagonal words must flow left to right and top to bottom."
                + Environment.NewLine
                + "• Players can use the existing letters in the grid for their new inputted word. The additional filled spots will be acquired to the new player, and the original spots will remain with the original player."
                + Environment.NewLine
                + "• Use the arrow keys to move around."
                + Environment.NewLine
                + "• Once two inputs are detected, you can just continue typing the word."
                + Environment.NewLine
                + "• Use the Enter Key to submit."
                + Environment.NewLine
                + "• When using letters already inputted for your word, simply click the letter before you submit."
                + Environment.NewLine
                + "• At least two inputs are required for forming a word."
                + Environment.NewLine
                + "• Players have the choice to forgo their turn if they don’t see any word to add. When both players forgo their turn consecutively, it’s game over and the winner is calculated."
                + Environment.NewLine
                + "Points Calculation:"
                + Environment.NewLine
                + "• Points are simply calculated – one point is earned per filled spot."
                + Environment.NewLine
                + "The Winner:"
                + Environment.NewLine
                + "• The player who fills the most spots is the winner of this game."
                + Environment.NewLine
                + "Score Calculation:"
                + Environment.NewLine
                + "• There are two score calculations for LetterGrab –"
                + Environment.NewLine
                + "    o Game Score – calculates the score of the current games."
                + Environment.NewLine
                + "    o Session Score – calculates the total score of all games."
                + Environment.NewLine
                + "Enjoy!!!"
                );
            String rulestext = txt.ToString();
            return rulestext;
        }
    }
}
