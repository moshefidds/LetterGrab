using gnuciDictionary;
using System.Numerics;
using System.Linq;
using System.Diagnostics;
using System.Text;
using System.Windows.Forms;
using System.Collections.Generic;

namespace LetterGrabApp
{
    public partial class frmLetterGrab : Form
    {
        List<Word> lstword = gnuciDictionary.EnglishDictionary.GetAllWords().ToList();

        List<TextBox> lstalltextboxes;

        List<TextBox> lstrow0;
        List<TextBox> lstrow1;
        List<TextBox> lstrow2;
        List<TextBox> lstrow3;
        List<TextBox> lstrow4;
        List<TextBox> lstrow5;
        List<TextBox> lstrow6;
        List<TextBox> lstrow7;
        List<TextBox> lstrow8;
        List<TextBox> lstrow9;
        List<TextBox> lstcolumn0;
        List<TextBox> lstcolumn1;
        List<TextBox> lstcolumn2;
        List<TextBox> lstcolumn3;
        List<TextBox> lstcolumn4;
        List<TextBox> lstcolumn5;
        List<TextBox> lstcolumn6;
        List<TextBox> lstcolumn7;
        List<TextBox> lstcolumn8;
        List<TextBox> lstcolumn9;
        List<TextBox> lstdiag00;
        List<TextBox> lstdiag01;
        List<TextBox> lstdiag02;
        List<TextBox> lstdiag03;
        List<TextBox> lstdiag04;
        List<TextBox> lstdiag05;
        List<TextBox> lstdiag06;
        List<TextBox> lstdiag07;
        List<TextBox> lstdiag08;
        List<TextBox> lstdiag09;
        List<TextBox> lstdiag10;
        List<TextBox> lstdiag11;
        List<TextBox> lstdiag12;
        List<TextBox> lstdiag13;
        List<TextBox> lstdiag14;
        List<TextBox> lstdiag15;
        List<TextBox> lstdiag16;
        List<List<TextBox>> lstallsets;

        List<TextBox> lstredacquired;
        List<TextBox> lstblueacquired;
        List<TextBox> lstanyacquired;

        List<string> lsttakenwords;

        List<Button> lstControls;
        List<TableLayoutPanel> lsttblGameScore;
        List<TextBox> lsttxtboxRedScore;
        List<TextBox> lsttxtboxBlueScore;

        enum players { Blue, Red }
        players currentplayer = players.Red;
        Color currentcolor = Color.Red;

        enum gamestatus { LetsStartGame, Playing, Winner, Tie }
        gamestatus currentgamestatus = gamestatus.LetsStartGame;

        enum errors { NoError, InputtedMoreThenOneSet, NoInput, WordNoExist, WordAlreadyUsed }
        errors errorstatus = errors.NoError;

        enum sessionstatus { InSession, SessionComplete }
        sessionstatus currentsessionstatus = sessionstatus.InSession;

        int gamenumber = 0;

        public frmLetterGrab()
        {
            InitializeComponent();

            lstword.ForEach(lw => lw.Value.ToLower());

            lstalltextboxes = new()
            {
                txtboxR0C0D08, txtboxR0C1D09, txtboxR0C2D10, txtboxR0C3D11, txtboxR0C4D12, txtboxR0C5D13, txtboxR0C6D14, txtboxR0C7D15, txtboxR0C8D16, txtboxR0C9Dn,
                txtboxR1C0D07, txtboxR1C1D08, txtboxR1C2D09, txtboxR1C3D10, txtboxR1C4D11, txtboxR1C5D12, txtboxR1C6D13, txtboxR1C7D14, txtboxR1C8D15, txtboxR1C9D16,
                txtboxR2C0D06, txtboxR2C1D07, txtboxR2C2D08, txtboxR2C3D09, txtboxR2C4D10, txtboxR2C5D11, txtboxR2C6D12, txtboxR2C7D13, txtboxR2C8D14, txtboxR2C9D15,
                txtboxR3C0D05, txtboxR3C1D06, txtboxR3C2D07, txtboxR3C3D08, txtboxR3C4D09, txtboxR3C5D10, txtboxR3C6D11, txtboxR3C7D12, txtboxR3C8D13, txtboxR3C9D14,
                txtboxR4C0D04, txtboxR4C1D05, txtboxR4C2D06, txtboxR4C3D07, txtboxR4C4D08, txtboxR4C5D09, txtboxR4C6D10, txtboxR4C7D11, txtboxR4C8D12, txtboxR4C9D13,
                txtboxR5C0D03, txtboxR5C1D04, txtboxR5C2D05, txtboxR5C3D06, txtboxR5C4D07, txtboxR5C5D08, txtboxR5C6D09, txtboxR5C7D10, txtboxR5C8D11, txtboxR5C9D12,
                txtboxR6C0D02, txtboxR6C1D03, txtboxR6C2D04, txtboxR6C3D05, txtboxR6C4D06, txtboxR6C5D07, txtboxR6C6D08, txtboxR6C7D09, txtboxR6C8D10, txtboxR6C9D11,
                txtboxR7C0D01, txtboxR7C1D02, txtboxR7C2D03, txtboxR7C3D04, txtboxR7C4D05, txtboxR7C5D06, txtboxR7C6D07, txtboxR7C7D08, txtboxR7C8D09, txtboxR7C9D10,
                txtboxR8C0D00, txtboxR8C1D01, txtboxR8C2D02, txtboxR8C3D03, txtboxR8C4D04, txtboxR8C5D05, txtboxR8C6D06, txtboxR8C7D07, txtboxR8C8D08, txtboxR8C9D09,
                txtboxR9C0Dn,  txtboxR9C1D00, txtboxR9C2D01, txtboxR9C3D02, txtboxR9C4D03, txtboxR9C5D04, txtboxR9C6D05, txtboxR9C7D06, txtboxR9C8D07, txtboxR9C9D08
            };
            //MF - would have liked to use the below foreach instead of above, however the list wasn't being created sequentially?
            //foreach (TextBox tb in tblLetters.Controls)
            //{
            //    lstalltextboxes.Add(tb);
            //}

            lstrow0 = new();
            lstrow0.AddRange(CreateSetList("R0").ToList());
            lstrow1 = new();
            lstrow1.AddRange(CreateSetList("R1").ToList());
            lstrow2 = new();
            lstrow2.AddRange(CreateSetList("R2").ToList());
            lstrow3 = new();
            lstrow3.AddRange(CreateSetList("R3").ToList());
            lstrow4 = new();
            lstrow4.AddRange(CreateSetList("R4").ToList());
            lstrow5 = new();
            lstrow5.AddRange(CreateSetList("R5").ToList());
            lstrow6 = new();
            lstrow6.AddRange(CreateSetList("R6").ToList());
            lstrow7 = new();
            lstrow7.AddRange(CreateSetList("R7").ToList());
            lstrow8 = new();
            lstrow8.AddRange(CreateSetList("R8").ToList());
            lstrow9 = new();
            lstrow9.AddRange(CreateSetList("R9").ToList());
            lstcolumn0 = new();
            lstcolumn0.AddRange(CreateSetList("C0").ToList());
            lstcolumn1 = new();
            lstcolumn1.AddRange(CreateSetList("C1").ToList());
            lstcolumn2 = new();
            lstcolumn2.AddRange(CreateSetList("C2").ToList());
            lstcolumn3 = new();
            lstcolumn3.AddRange(CreateSetList("C3").ToList());
            lstcolumn4 = new();
            lstcolumn4.AddRange(CreateSetList("C4").ToList());
            lstcolumn5 = new();
            lstcolumn5.AddRange(CreateSetList("C5").ToList());
            lstcolumn6 = new();
            lstcolumn6.AddRange(CreateSetList("C6").ToList());
            lstcolumn7 = new();
            lstcolumn7.AddRange(CreateSetList("C7").ToList());
            lstcolumn8 = new();
            lstcolumn8.AddRange(CreateSetList("C8").ToList());
            lstcolumn9 = new();
            lstcolumn9.AddRange(CreateSetList("C9").ToList());
            lstdiag00 = new();
            lstdiag00.AddRange(CreateSetList("D00").ToList());
            lstdiag01 = new();
            lstdiag01.AddRange(CreateSetList("D01").ToList());
            lstdiag02 = new();
            lstdiag02.AddRange(CreateSetList("D02").ToList());
            lstdiag03 = new();
            lstdiag03.AddRange(CreateSetList("D03").ToList());
            lstdiag04 = new();
            lstdiag04.AddRange(CreateSetList("D04").ToList());
            lstdiag05 = new();
            lstdiag05.AddRange(CreateSetList("D05").ToList());
            lstdiag06 = new();
            lstdiag06.AddRange(CreateSetList("D06").ToList());
            lstdiag07 = new();
            lstdiag07.AddRange(CreateSetList("D07").ToList());
            lstdiag08 = new();
            lstdiag08.AddRange(CreateSetList("D08").ToList());
            lstdiag09 = new();
            lstdiag09.AddRange(CreateSetList("D09").ToList());
            lstdiag10 = new();
            lstdiag10.AddRange(CreateSetList("D10").ToList());
            lstdiag11 = new();
            lstdiag11.AddRange(CreateSetList("D11").ToList());
            lstdiag12 = new();
            lstdiag12.AddRange(CreateSetList("D12").ToList());
            lstdiag13 = new();
            lstdiag13.AddRange(CreateSetList("D13").ToList());
            lstdiag14 = new();
            lstdiag14.AddRange(CreateSetList("D14").ToList());
            lstdiag15 = new();
            lstdiag15.AddRange(CreateSetList("D15").ToList());
            lstdiag16 = new();
            lstdiag16.AddRange(CreateSetList("D16").ToList());

            lstallsets = new()
                {
                    lstrow0, lstrow1, lstrow2, lstrow3, lstrow4, lstrow5, lstrow6, lstrow7, lstrow8, lstrow9,
                    lstcolumn0, lstcolumn1, lstcolumn2, lstcolumn3, lstcolumn4, lstcolumn5, lstcolumn6, lstcolumn7, lstcolumn8, lstcolumn9,
                    lstdiag00, lstdiag01, lstdiag02, lstdiag03, lstdiag04, lstdiag05, lstdiag06, lstdiag07, lstdiag08, lstdiag09, lstdiag10, lstdiag11, lstdiag12, lstdiag13, lstdiag14, lstdiag15, lstdiag16
                };

            lstredacquired = new();
            lstblueacquired = new();
            lstanyacquired = new();

            lsttakenwords = new();

            lstControls = new() { btnForGoTurn, btnRefreshInput, btnSubmit };
            lsttblGameScore = new() { tblGame1Score, tblGame2Score, tblGame3Score, tblGame4Score, tblGame5Score, tblGame6Score, tblGame7Score, tblGame8Score, tblGame9Score, tblGame10Score, tblTotalScore };
            lsttxtboxRedScore = new() { txtboxGame1RedScore, txtboxGame2RedScore, txtboxGame3RedScore, txtboxGame4RedScore, txtboxGame5RedScore, txtboxGame6RedScore, txtboxGame7RedScore, txtboxGame8RedScore, txtboxGame9RedScore, txtboxGame10RedScore };
            lsttxtboxBlueScore = new() { txtboxGame1BlueScore, txtboxGame2BlueScore, txtboxGame3BlueScore, txtboxGame4BlueScore, txtboxGame5BlueScore, txtboxGame6BlueScore, txtboxGame7BlueScore, txtboxGame8BlueScore, txtboxGame9BlueScore, txtboxGame10BlueScore, };

            btnSubmit.Click += BtnSubmit_Click;
            btnForGoTurn.Click += BtnForGoTurn_Click;
            btnRefreshInput.Click += BtnRefreshInput_Click;
            btnNewGame.Click += BtnNewGame_Click;
            btnNewSession.Click += BtnNewSession_Click;
            btnRules.Click += BtnRules_Click;

            lstalltextboxes.ForEach(latb => latb.KeyPress += ListAllTextBoxes_KeyPress);
            lstalltextboxes.ForEach(latb => latb.Click += ListAllTextBoxes_Click);
            lstalltextboxes.ForEach(latb => latb.TextChanged += ListAllTextBoxes_TextChanged);

            tooltipNewGame.SetToolTip(btnNewGame, "Click to End/Start Game");
            tooltipNewSession.SetToolTip(btnNewSession, "Click to End/Start Session");
            tooltipForgoTurn.SetToolTip(btnForGoTurn, "Click to Forgo Your Turn");
            tooltipRefreshInput.SetToolTip(btnRefreshInput, "Click to Restart Your Input");
            tooltipSubmit.SetToolTip(btnSubmit, "Click to Submit Your Word");

            this.KeyDown += ActiveForm_KeyDown;

            DisplayMessage();
            ResetFields();
            lstalltextboxes.ForEach(latb => latb.Enabled = false);
            lstControls.ForEach(lc => lc.Enabled = false);
            lsttblGameScore.ForEach(ltgs => ltgs.Hide());
        }

        // CreateSetList - Creates the set lists sequentially
        private List<TextBox> CreateSetList(String name)
        {
            List<TextBox> lstset = new();
            lstset.AddRange(lstalltextboxes.Where(latb => latb.Name.Contains(name)).ToList());
            return lstset;
        }

        // DisplayMessage
        private void DisplayMessage()
        {
            string gameoverendmessage = Environment.NewLine + "Click New Game to Begin a New Game";
            string playingendmessage = Environment.NewLine + "Player " + currentplayer + ": You can Go Ahead and Try Again";
            string specificmessage = "";
            Color forcolor = Color.Black;
            Color backcolor = Color.Ivory;
            if (currentsessionstatus == sessionstatus.InSession)
            {
                switch (currentgamestatus)
                {
                    case gamestatus.LetsStartGame:
                        specificmessage = "Click New Game To Begin Playing";
                        break;
                    case gamestatus.Playing:
                        if (errorstatus == errors.NoError)
                        {
                            forcolor = currentcolor;
                            backcolor = Color.Ivory;
                            specificmessage = "Current Turn: " + currentplayer;
                        }
                        else
                        {
                            forcolor = Color.Ivory;
                            backcolor = Color.DarkGray;
                            switch (errorstatus)
                            {
                                case errors.InputtedMoreThenOneSet:
                                    specificmessage = "Inputs Exceed More Then One Set" + playingendmessage;
                                    break;
                                case errors.NoInput:
                                    specificmessage = "No Inputs Have Been Entered" + playingendmessage;
                                    break;
                                case errors.WordNoExist:
                                    specificmessage = "Inputted Word Doesn't Exist" + playingendmessage;
                                    break;
                                case errors.WordAlreadyUsed:
                                    specificmessage = "Inputted Word Already Used" + playingendmessage;
                                    break;
                            }
                        }
                        break;
                    case gamestatus.Winner:
                        DeterminePlayerColor();
                        forcolor = currentcolor;
                        backcolor = Color.Ivory;
                        specificmessage = "Game Winner is " + currentplayer + "!!!" + gameoverendmessage;
                        break;
                    case gamestatus.Tie:
                        forcolor = Color.Black;
                        backcolor = Color.Ivory;
                        specificmessage = "It's a Tie " + gameoverendmessage;
                        break;
                }
            }
            else if (currentsessionstatus == sessionstatus.SessionComplete)
            {
                switch (currentgamestatus)
                {
                    case gamestatus.Tie:
                        specificmessage = "Session Complete!! It's a Tie" + Environment.NewLine + "Click New Session to Play Again";
                        break;
                    case gamestatus.LetsStartGame:
                        specificmessage = "Session Complete!! Let's Actually Play ;)" + Environment.NewLine + "Click New Session to Begin Paying";
                        break;
                    default:
                        specificmessage = "Session Complete!! Master Winner is: " + currentplayer + Environment.NewLine + "Click New Session to Play Again";
                        break;
                }
            }
            lblMessage.ForeColor = forcolor;
            lblMessage.BackColor = backcolor;
            lblMessage.Text = specificmessage;
        }

        // ResetFields
        private void ResetFields(bool reseterrorstatus = true)
        {
            lstalltextboxes.ForEach(latb => latb.ForeColor = Color.Black);
            if (reseterrorstatus == true)
            {
                errorstatus = errors.NoError;
            }
        }

        // DeterminePlayerColor
        private void DeterminePlayerColor()
        {
            currentcolor = currentplayer == players.Red ? Color.Red : Color.Blue;
        }

        // SwitchPlayer
        private void SwitchPlayer()
        {
            if (errorstatus == errors.NoError)
            {
                currentplayer = currentplayer == players.Red ? players.Blue : players.Red;
                DeterminePlayerColor();
            }
        }

        // DetermineInitialError
        private void DetermineInitialError(List<List<TextBox>> lstcheckword)
        {
            // if more then one set inputted
            if (lstcheckword.Count() > 1)
            {
                errorstatus = errors.InputtedMoreThenOneSet;
                UndoInput(false);
            }
            // if no input 
            else if (lstcheckword.Count() < 1)
            {
                errorstatus = errors.NoInput;
                UndoInput(false);
            }
        }

        // DetermineWordError
        private void DetermineWordError(string word, List<List<TextBox>> lstcheckword)
        {
            List<TextBox> lstfullset = new();
            List<TextBox> lstinputtedrange = new();
            lstcheckword.ForEach(lcw => lcw.ForEach(lfs => lstfullset.Add(lfs)));
            int firstinput = lstfullset.IndexOf(lstfullset.First(lfs => lfs.ForeColor == currentcolor));
            int lastinput = lstfullset.IndexOf(lstfullset.Last(lfs => lfs.ForeColor == currentcolor));
            for (int n = firstinput; n <= lastinput; n++)
            {
                lstinputtedrange.Add(lstfullset[n]);
            }

            // if word not sequential
            if ((lstfullset.Count() - lstinputtedrange.Count) != (lstfullset.Count() - word.Count()))
            {
                errorstatus = errors.NoInput;
                UndoInput(false);
            }
            // if word doesn't exist
            else if (!lstword.Exists(lw => lw.Value.Contains(word)))
            {
                errorstatus = errors.WordNoExist;
                UndoInput(false);
            }
            // if word already inputted
            else if (lsttakenwords.Exists(lw => lw.Contains(word)))
            {
                errorstatus = errors.WordAlreadyUsed;
                UndoInput(false);
            }
        }

        // CalculateScore
        private void CalculateScore(string word, List<TextBox> lstinputtedword)
        {
            if (errorstatus == errors.NoError)
            {
                lsttakenwords.Add(word);

                List<TextBox> lstacquiredtxtboxes = new();
                lstinputtedword.Where(liw => !lstanyacquired.Contains(liw)).ToList().ForEach(laaq => lstacquiredtxtboxes.Add(laaq));

                switch (currentplayer)
                {
                    case players.Red:
                        lstacquiredtxtboxes.ForEach(latb => lstredacquired.Add(latb));
                        break;
                    case players.Blue:
                        lstacquiredtxtboxes.ForEach(latb => lstblueacquired.Add(latb));
                        break;
                }
                txtboxCurrentScoreRed.Text = lstredacquired.Count().ToString();
                txtboxCurrentScoreBlue.Text = lstblueacquired.Count().ToString();

                lstacquiredtxtboxes.ForEach(latb => lstanyacquired.Add(latb));
            }
        }

        // BuildWordAndScore
        private void BuildWordAndScore()
        {
            string word = "";
            List<List<TextBox>> lstcheckword = new();
            lstcheckword.AddRange(lstallsets.Where(las => las.Count(set => set.ForeColor == currentcolor) >= 2));

            DetermineInitialError(lstcheckword);
            List<TextBox> lstinputtedword = new();
            if (errorstatus == errors.NoError)
            {
                StringBuilder inputtedword = new();

                lstcheckword.ForEach(lcw => lcw.Where(txtbox => txtbox.ForeColor == currentcolor).ToList().ForEach(txtboxfill => lstinputtedword.Add(txtboxfill)));
                lstinputtedword.ForEach(liw => inputtedword.Append(liw.Text));

                word = inputtedword.ToString();
                DetermineWordError(word, lstcheckword);
            }
            CalculateScore(word, lstinputtedword);
        }

        // DetermineWinner
        private void DetermineWinner()
        {
            int redtotal = lstredacquired.Count();
            int bluetotal = lstblueacquired.Count();
            if (currentsessionstatus == sessionstatus.SessionComplete)
            {
                bool br = int.TryParse(txtboxTotalRedScore.Text, out redtotal);
                bool bb = int.TryParse(txtboxTotalBlueScore.Text, out bluetotal);
            }

            if (bluetotal.Equals(0) || redtotal.Equals(0))
            {
                currentgamestatus = gamestatus.LetsStartGame;
            }
            else if (redtotal > bluetotal)
            {
                currentgamestatus = gamestatus.Winner;
                currentplayer = players.Red;
            }
            else if (bluetotal > redtotal)
            {
                currentgamestatus = gamestatus.Winner;
                currentplayer = players.Blue;
            }
            else
            {
                currentgamestatus = gamestatus.Tie;
            }
        }

        // CalculateSessionScore
        private void CalculateSessionScore()
        {
            int sumred = 0;
            int sumblue = 0;
            lsttxtboxRedScore.ForEach(ltbrs => sumred = sumred + int.Parse(ltbrs.Text));
            lsttxtboxBlueScore.ForEach(ltbbs => sumblue = sumblue + int.Parse(ltbbs.Text));
            txtboxTotalRedScore.Text = sumred.ToString();
            txtboxTotalBlueScore.Text = sumblue.ToString();
        }

        // DisplayGameScore
        private void DisplayGameScore()
        {
            lsttblGameScore[gamenumber].Show();
            lsttxtboxRedScore[gamenumber].Text = lstredacquired.Count().ToString();
            lsttxtboxBlueScore[gamenumber].Text = lstblueacquired.Count().ToString();
            tblTotalScore.Show();

            CalculateSessionScore();

            gamenumber = gamenumber + 1;
        }

        // DetermineSessionStatus
        private void DetermineSessionStatus()
        {
            if (gamenumber == 10)
            {
                btnNewGame.Enabled = false;
                btnNewSession.Text = "New Session";
                currentsessionstatus = sessionstatus.SessionComplete;
                DetermineWinner();
            }
        }

        // ClearAllForNewGame
        private void ClearAllForNewGame()
        {
            lstredacquired.Clear();
            lstblueacquired.Clear();
            lstanyacquired.Clear();
            lsttakenwords.Clear();
            txtboxCurrentScoreRed.Text = lstredacquired.Count().ToString();
            txtboxCurrentScoreBlue.Text = lstblueacquired.Count().ToString();
            lstalltextboxes.ForEach(latb => latb.ResetText());
        }

        // ClearAllForNewSession
        private void ClearAllForNewSession()
        {
            ClearAllForNewGame();
            lsttxtboxRedScore.ForEach(ltbrs => ltbrs.Text = "0");
            lsttxtboxBlueScore.ForEach(ltbbs => ltbbs.Text = "0");
            CalculateSessionScore();

            gamenumber = 0;

            lsttblGameScore.ForEach(ltgs => ltgs.Hide());
        }

        // SetAllForPlaying
        private void SetAllForPlaying()
        {
            currentgamestatus = gamestatus.Playing;
            currentsessionstatus = sessionstatus.InSession;
            btnNewGame.Enabled = true;
            lstalltextboxes.ForEach(latb => latb.Enabled = true);
            lstControls.ForEach(lc => lc.Enabled = true);
            currentplayer = players.Red;
            currentcolor = Color.Red;
            btnNewGame.Text = "End Game";
        }

        // EndOrStartNewGame
        private void EndOrStartGame()
        {
            if (currentgamestatus == gamestatus.Playing)
            {
                DetermineWinner();
                DisplayGameScore();
                DetermineSessionStatus();
                DisplayMessage();
                lstalltextboxes.ForEach(latb => latb.Enabled = false);
                lstControls.ForEach(lc => lc.Enabled = false);
                btnNewGame.Text = "New Game";
            }
            else
            {
                ClearAllForNewGame();
                SetAllForPlaying();
                DeterminePlayerColor();
                DisplayMessage();

                txtboxR0C0D08.Focus();
            }
        }

        // BeginNewSession
        private void EndOrBeginNewSession()
        {
            if (currentsessionstatus == sessionstatus.InSession)
            {
                EndOrStartGame();
                currentsessionstatus = sessionstatus.SessionComplete;
                DetermineWinner();
                DisplayMessage();
                btnNewSession.Text = "New Session";
            }
            else
            {
                ClearAllForNewSession();
                SetAllForPlaying();
                DisplayMessage();
                btnNewSession.Text = "End Session";
            }
        }

        // DetermineForgoTurn
        private void DetermineForgoTurn()
        {
            if (btnForGoTurn.BackColor == Color.LightPink)
            {
                EndOrStartGame();
                btnForGoTurn.BackColor = Color.DarkViolet;
            }
            else
            {
                UndoInput();
                SwitchPlayer();
                DisplayMessage();
                btnForGoTurn.BackColor = Color.LightPink;
            }
        }

        // DetermineIfAllTaken
        private void DetermineIfAllTaken()
        {
            if (lstalltextboxes.Count() == lstanyacquired.Count())
            {
                EndOrStartGame();
            }
        }

        // UndoInput
        private void UndoInput(bool reseterrorstatus = true)
        {
            lstalltextboxes.Where(lat => !lstanyacquired.Contains(lat)).ToList().ForEach(newinput => newinput.ResetText());
            ResetFields(reseterrorstatus);
        }

        // BtnSubmit_Click
        private void BtnSubmit_Click(object? sender, EventArgs e)
        {
            BuildWordAndScore();
            SwitchPlayer();
            DisplayMessage();
            ResetFields();
            DetermineIfAllTaken();
        }

        // ShowRules
        private void ShowRules()
        {
            frmRules newfrmrules = new();
            newfrmrules.Show();
        }

        // DoTextChanged
        private void DoTextChanged(TextBox textbox)
        {
            textbox.ForeColor = currentcolor;
            List<TextBox> lstinputted = new();
            if (lstalltextboxes.Where(tb => tb.ForeColor == currentcolor).Count() >= 2)
            {
                lstinputted.AddRange(lstallsets.First(las => las.Count(set => set.ForeColor == currentcolor) >= 2));
                int nextbox = lstinputted.IndexOf(textbox) + 1;
                if (nextbox <= lstinputted.Count() - 1)
                {
                    lstinputted[nextbox].Focus();
                }
            }
        }

        private void BtnNewSession_Click(object? sender, EventArgs e)
        {
            EndOrBeginNewSession();
        }

        private void BtnNewGame_Click(object? sender, EventArgs e)
        {
            EndOrStartGame();
        }

        private void BtnRefreshInput_Click(object? sender, EventArgs e)
        {
            UndoInput();
        }

        private void BtnForGoTurn_Click(object? sender, EventArgs e)
        {
            DetermineForgoTurn();
        }

        private void BtnRules_Click(object? sender, EventArgs e)
        {
            ShowRules();
        }

        // ListAllTextBoxes_KeyPress - only 1)Letters, 2)Lower case, 3)one character - (Since "Iscontrol" not enabled, can't backspace)
        private void ListAllTextBoxes_KeyPress(object? sender, KeyPressEventArgs e)
        {
            if (sender is TextBox)
            {
                TextBox textbox = (TextBox)sender;
                if (char.IsDigit(e.KeyChar) || !char.IsLower(e.KeyChar) || textbox.Text.Length >= 1)
                {
                    e.Handled = true;
                }
            }
        }

        // ListAllTextBoxes_Click - click will change to Color of current turn.
        private void ListAllTextBoxes_Click(object? sender, EventArgs e)
        {
            if (sender is TextBox)
            {
                TextBox textbox = (TextBox)sender;
                textbox.ForeColor = currentcolor;
            }
        }

        // ListAllTextBoxes_TextChanged
        private void ListAllTextBoxes_TextChanged(object? sender, EventArgs e)
        {
            if (sender is TextBox)
            {
                TextBox textbox = (TextBox)sender;
                DoTextChanged(textbox);
            }
        }

        // ActiveForm_KeyDown
        private void ActiveForm_KeyDown(object? sender, KeyEventArgs e)
        {
            var currentfocus = this.ActiveControl;
            if (currentfocus is TextBox currenttextbox)
            {
                List<TextBox> lstcurrentrow = new();
                List<TextBox> lstcurrentcolumn = new();
                lstcurrentrow.AddRange(lstallsets.GetRange(0, 10).ToList().First(las => las.Contains(currentfocus)));
                lstcurrentcolumn.AddRange(lstallsets.GetRange(10, 10).ToList().First(las => las.Contains(currentfocus)));

                int rowbox = lstcurrentrow.IndexOf(currenttextbox);
                int columnbox = lstcurrentcolumn.IndexOf(currenttextbox);

                switch (e.KeyCode)
                {
                    case Keys.Left:
                        if (rowbox - 1 > -1)
                        {
                            lstcurrentrow[rowbox - 1].Focus();
                        }
                        break;
                    case Keys.Right:
                        if (rowbox + 1 < 10)
                        {
                            lstcurrentrow[rowbox + 1].Focus();
                        }
                        break;
                    case Keys.Up:
                        if (columnbox - 1 > -1)
                        {
                            lstcurrentcolumn[columnbox - 1].Focus();
                        }
                        break;
                    case Keys.Down:
                        if (columnbox + 1 < 10)
                        {
                            lstcurrentcolumn[columnbox + 1].Focus();
                        }
                        break;
                    case Keys.Enter:
                        BtnSubmit_Click(sender, e);
                        break;
                }
            }
        }
    }
}