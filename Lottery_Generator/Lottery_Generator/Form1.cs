using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Lottery_Generator._1
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();

        }

        //Fields
        Random random = new Random();
        //Array holds the played lottery row
        List<int> lotteryRow = new List<int>();
        //Array holds the current generated lottery row
        int[] generatedLotteryNumbers = new int[7];
        string[] errorMessage = new string[7];

        // Number correct rows 
        int OneCorrectNumbers = 0;
        int TwoCorrectNumbers = 0;
        int ThreeCorrectNumbers = 0;
        int FourCorrectNumbers = 0;
        int FiveCorrectNumbers = 0;
        int SixCorrectNumbers = 0;
        int SevenCorrectNumbers = 0;

        private void MainForm_Load(object sender, EventArgs e)
        {
            //Starting error message to the ErrorTextBox
            errorMessage[0] = "You have 7 numbers left to choose";
            errorMessage[1] = "Select the number of game rounds";
            ErrorMessagesListBox.Items.Insert(0, errorMessage[0]);
            ErrorMessagesListBox.Items.Insert(1, errorMessage[1]);

        }

        /*
         A method....
         */
        private void removeNumberToRow(int numberToRemove)
        {
            this.lotteryRow.Remove(numberToRemove);
            howManyNumbersAreLeftToChoose();
        }

        /*
         A method....
         */
        private void addNumberToRow(int numberToAdd)
        {
            if (lotteryRow.Count != 7)
            {
                // add the selected number to the row
                this.lotteryRow.Add(numberToAdd);
                howManyNumbersAreLeftToChoose();

            }

        }

        /*
         A method....
         */
        private void howManyNumbersAreLeftToChoose()
        {
            ErrorMessagesListBox.Items.Remove(errorMessage[0]);
            ErrorMessagesListBox.Items.Insert(0, errorMessage[0] = $"You have {7 - lotteryRow.Count} numbers left to choose");
            if (lotteryRow.Count == 7)
            {
                ErrorMessagesListBox.Items.Remove(errorMessage[0]);
            }
            // change the lable that displays the lottery row
            this.LottoradLabel.Text = $"Lottery line: {string.Join(", ", lotteryRow)}";
        }


        /*
         A method who checks the checkboxes if they are checked or not
         */
        private void checkBox_CheckedChanged(object sender, EventArgs e)
        {
            //Create a Checkbox
            CheckBox clickedCheckBox = (CheckBox)sender;

            // Check if the selected checkBox is checked and if the max number is already taken
            if (clickedCheckBox.Checked && lotteryRow.Count != 7)
            {
                clickedCheckBox.ForeColor = Color.DarkGreen;
                addNumberToRow(int.Parse(clickedCheckBox.Text));
            }
            // Otherwise deny the choice
            else
            {
                clickedCheckBox.Checked = false;
            }
            // Check if the checkBox should not be selected
            if (!clickedCheckBox.Checked)
            {
                clickedCheckBox.Checked = false;
                clickedCheckBox.ForeColor = Color.Red;
                removeNumberToRow(int.Parse(clickedCheckBox.Text));
            }
        }

        private void ValjAntalSpelomgangarNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            if (ValjAntalSpelomgangarNumericUpDown.Value > 0)
            {
                ErrorMessagesListBox.Items.Remove(errorMessage[1]);
            }
            else
            {
                ErrorMessagesListBox.Items.Add(errorMessage[1]);
            }
        }

        private void DeleteRowsButton_Click(object sender, EventArgs e)
        {
            foreach (var CheckBox in NumbersFlowLayoutPanel.Controls)
            {
                CheckBox cb = (CheckBox)CheckBox;
                cb.Checked = false;
            }
        }

        private void RandomRowsButton_Click(object sender, EventArgs e)
        {
            //First clear old row 
            DeleteRowsButton_Click(sender, e);


            int[] randomRow = new int[7];
            // Generate random numbers 
            for (int i = 0; i < randomRow.Length; i++)
            {
                int randomNumber = 0;
                do
                {
                    randomNumber = random.Next(1, 37 + 1);
                }
                while (randomRow.Contains(randomNumber));
                randomRow[i] = randomNumber;
            }

            foreach (var chekcbox in NumbersFlowLayoutPanel.Controls)
            {
                CheckBox cb = (CheckBox)chekcbox;
                for (int i = 0; i < randomRow.Length; i++)
                {
                    if (cb.Text == randomRow[i].ToString())
                    {
                        cb.Checked = true;
                    }
                }

            }
        }

        private void SlumpaUtdelningButton_Click(object sender, EventArgs e)
        {
            // Max 5 000 000
            ValjUtdelningSjuRattNumericUpDown.Value = random.Next(1000000, 5000000 + 1);
            // Max 1 000 000
            ValjUtdelningSexRattNumericUpDown.Value = random.Next(100000, 1000000 + 1);
            // Max 100000
            ValjUtdelningFemRattNumericUpDown.Value = random.Next(1, 100000 + 1);
        }

        private void SlumpaSpelomgangarButton_Click(object sender, EventArgs e)
        {
            // Max 10 000 000
            ValjAntalSpelomgangarNumericUpDown.Value = random.Next(1, 10000000 + 1);
        }

        private void SlumpaKostnadLottButton_Click(object sender, EventArgs e)
        {

            int randomNumb = random.Next(0, 3 + 1);
            var radioButtons = InstallningKostnadGroupBox.Controls.OfType<RadioButton>();
            
            foreach (RadioButton rb in radioButtons)
            {
                rb.Checked = false;
            }
            int count = 0;
            foreach (RadioButton rb in radioButtons)
            {
                if (randomNumb == count)
                {
                    rb.Checked = true;
                    break;
                }
                count++;
            }
        }

        private int radioButtonValue()
        {
            var radioButtons = InstallningKostnadGroupBox.Controls.OfType<RadioButton>();
            string value = "";
            foreach (RadioButton rb in radioButtons)
            {
                if (rb.Checked)
                {
                    value = rb.Text.Replace('k', ' ').Replace('r', ' ').Trim();
                }
            }
            return int.Parse(value);
        }


        private void StartGameButton_Click(object sender, EventArgs e)
        {

            AntalRaderFemRättLabel.Text = "Rows with 5 correct:";
            AntalRaderSexRättLabel.Text = "Rows with 6 correct:";
            AntalRaderSjuRättLabel.Text = "Rows with 7 correct:";
            TotalVinstLabel.Text = $"Total profit:";
            TotalKostnadLabel.Text = $"Total cost:";

            if (ErrorMessagesListBox.Items.Count == 0)
            {
                PlayGame();
            }
        }

        private void PlayGame()
        {
            for (int i = 0; i < ValjAntalSpelomgangarNumericUpDown.Value; i++)
            {
                CreateRandomRow();
                CheckCorrectNumbers();
            }
            Console.WriteLine($"1 rätt: {OneCorrectNumbers}");
            Console.WriteLine($"2 rätt: {TwoCorrectNumbers}");
            Console.WriteLine($"3 rätt: {ThreeCorrectNumbers}");
            Console.WriteLine($"4 rätt: {FourCorrectNumbers}");
            AntalRaderFemRättLabel.Text = $"Rows with 5 correct: {FiveCorrectNumbers}";
            AntalRaderSexRättLabel.Text = $"Rows with 6 correct: {SixCorrectNumbers}"; 
            AntalRaderSjuRättLabel.Text = $"Rows with 7 correct: {SevenCorrectNumbers}";
            decimal totalPayout = (FiveCorrectNumbers * ValjUtdelningFemRattNumericUpDown.Value) + (SixCorrectNumbers * ValjUtdelningSexRattNumericUpDown.Value) + (SevenCorrectNumbers * ValjUtdelningSjuRattNumericUpDown.Value);
            decimal totalCost = ValjAntalSpelomgangarNumericUpDown.Value * radioButtonValue();
            TotalVinstLabel.Text = $"Total profit: {totalPayout} kr";
            TotalKostnadLabel.Text = $"Total cost: {totalCost} kr";

            ClearCorrectNumbers();
        }

        private void CheckCorrectNumbers()
        {
            int correctNumbers = 0;

            for (int i = 0; i < lotteryRow.Count; i++)
            {
                if (lotteryRow.Contains(generatedLotteryNumbers[i]))
                {
                    correctNumbers++;
                }
            }
            switch (correctNumbers)
            {
                case 1:
                    OneCorrectNumbers++;
                    break;
                case 2:
                    TwoCorrectNumbers++;
                    break;
                case 3:
                    ThreeCorrectNumbers++;
                    break;
                case 4:
                    FourCorrectNumbers++;
                    break;
                case 5:
                    FiveCorrectNumbers++;
                    break;
                case 6:
                    SixCorrectNumbers++;
                    break;
                case 7:
                    SevenCorrectNumbers++;
                    break;
            }
        }

        private void ClearCorrectNumbers()
        {
            OneCorrectNumbers = 0;
            TwoCorrectNumbers = 0;
            ThreeCorrectNumbers = 0;
            FourCorrectNumbers = 0;
            FiveCorrectNumbers = 0;
            SixCorrectNumbers = 0;
            SevenCorrectNumbers = 0;
        }

        private void CreateRandomRow()
        {
            Array.Clear(generatedLotteryNumbers, 0, generatedLotteryNumbers.Length);
            for (int i = 0; i < generatedLotteryNumbers.Length; i++)
            {
                int drawNumber = random.Next(1, 37);
                // Ensures that there are no duplicates of the numbers
                while (generatedLotteryNumbers.Contains(drawNumber))
                {
                    drawNumber = random.Next(1, 37);
                }
                //Puts the random number in i position of the array generatedLotteryNumbers
                generatedLotteryNumbers[i] = drawNumber;
            }
        }

        private void SlumpaInstallningarButton_Click(object sender, EventArgs e)
        {
            SlumpaUtdelningButton_Click(sender,e);
            RandomRowsButton_Click(sender, e);
            SlumpaKostnadLottButton_Click(sender, e);
            SlumpaSpelomgangarButton_Click(sender,e);
        }
    }

}

