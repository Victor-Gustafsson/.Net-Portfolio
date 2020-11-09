using System;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace Simple_Text_Editor
{
    public partial class MyMainForm : Form
    {
        SaveFileDialog saveFileDialog = new SaveFileDialog();
        OpenFileDialog openFileDialog = new OpenFileDialog();
        string Filter = "Text documents (*.txt)|*.txt|All files (*.*)|*.*";
        string InitialDirectory = Directory.GetCurrentDirectory() + "\\Example_Files";
        string LatestSavedFilePath;
        bool FileIsChanged;
        public MyMainForm()
        {
            InitializeComponent();
            CreateNewFile();
        }

        /*******************************************Events_Methods***********************************************/
        // A Method that open a file dialog
        private void OppenButton_Click(object sender, EventArgs e)
        {
            if (FileIsChanged)
                SaveBefore(OppenFile);
            else
                OppenFile();
        }

        // A method that clear the text from the document
        private void ClearButton_Click(object sender, EventArgs e)
        {
            MyTextBox.Clear();
        }

        //  A method that save the file in a new file if it dont exist else save in allready existing file 
        private void SaveButton_Click(object sender, EventArgs e)
        {
            Save();
        }

        //  A method that save the file in a new file
        private void SaveAsButton_Click(object sender, EventArgs e)
        {
            SaveAs();
        }

        // A method that resets the document to default. Calling CreateNewFile() method
        private void NewButton_Click(object sender, EventArgs e)
        {
            if (FileIsChanged)
                SaveBefore(CreateNewFile);
            else
                CreateNewFile();
        }

        // A method that check if there is new changes need to be saved
        private void MyTextBox_TextChanged(object sender, EventArgs e)
        {
            if (FileIsChanged)
            {
                //If The file is saved, don't do anything
            }
            else
            {
                if (File.Exists(LatestSavedFilePath))
                {
                    this.Text = Path.GetFileName(InitialDirectory + $"\\{this.Text}") + "*";
                }
                else
                {
                    this.Text = "unnamed.txt*";
                }
                FileIsChanged = true;
            }
            AnalyzeTheText();
        }

        // A method that quits the application, if the file is not saved, the user can choose if to save first
        private void ExitProgram_Click(object sender, EventArgs e)
        {
            if (FileIsChanged)
                SaveBefore(Application.Exit);
            else
                Application.Exit();
        }

        // A method that check if the user press the x button and wants to quit. If File has changes the user ask to save befor quit
        private void MyMainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (FileIsChanged)
            {
                DialogResult dialogResult = MessageBoxWantToSave();
                if (dialogResult == DialogResult.Yes)
                {
                    Save();
                }
                if (dialogResult == DialogResult.No)
                {

                }
                else
                    e.Cancel = true;
            }
        }

        /**********************************************Help_Methods*************************************************/

        //A method that clear the settings and point the program to save and open files from the application source folder (Example_Files) again
        private void CreateNewFile()
        {
            openFileDialog.Filter = Filter;
            openFileDialog.InitialDirectory = InitialDirectory;
            saveFileDialog.Filter = Filter;
            saveFileDialog.InitialDirectory = InitialDirectory;
            LatestSavedFilePath = null;
            MyTextBox.Clear();
            FileIsChanged = false;
            this.Text = "unnamed.txt";
        }

        //  A method that opens a FileDialog
        private void OppenFile()
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                MyTextBox.Text = File.ReadAllText(openFileDialog.FileName);
                ChangeOpenAndSaveInitialDirectory(openFileDialog.FileName);
            }
        }


        //  A method that save the file if it exists else calling SaveAs method
        private void Save()
        {
            if (File.Exists(LatestSavedFilePath))
            {
                if (this.Text.Last() == '*')
                    this.Text = this.Text.Remove(this.Text.Length - 1);

                File.WriteAllText(LatestSavedFilePath, MyTextBox.Text);
                FileIsChanged = false;
            }
            else
            {
                SaveAs();
            }
        }

        //  A method that save the file in a new file 
        private void SaveAs()
        {
            if (this.Text.Last() == '*')
                saveFileDialog.FileName = this.Text.Remove(this.Text.Length - 1);
            else
                saveFileDialog.FileName = this.Text;

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllText(Path.GetFullPath(saveFileDialog.FileName), MyTextBox.Text);
                ChangeOpenAndSaveInitialDirectory(saveFileDialog.FileName);
            }
        }

        // A method that change the open and save dialog when it´s time to save or oppen a file again
        private void ChangeOpenAndSaveInitialDirectory(string path)
        {
            FileIsChanged = false;
            this.Text = Path.GetFileName(path);
            LatestSavedFilePath = Path.GetFullPath(path);
            openFileDialog.InitialDirectory = Path.GetDirectoryName(path);
            openFileDialog.FileName = null;
            saveFileDialog.InitialDirectory = Path.GetDirectoryName(path);
        }

        // A method that asks the user if they want to save their changes before the next action
        private void SaveBefore(Action action)
        {
            DialogResult dialogResult = MessageBoxWantToSave();
            if (dialogResult == DialogResult.Yes)
            {
                Save();
                action();
            }
            else if (dialogResult == DialogResult.No)
            {
                action();
            }
        }

        // The MessageBox dialog that ask what the user wants to do
        private DialogResult MessageBoxWantToSave()
        {
            return MessageBox
                 .Show($"Vill du spara ändringar för {this.Text}"
                    , "Varning"
                    , MessageBoxButtons.YesNoCancel
                    , MessageBoxIcon.Warning);
        }


        // A method that analyzes the text and calculates different values presented to the user
        private void AnalyzeTheText()
        {
            //Linq querry to find characters with witespaces
            var q1 = MyTextBox.Text
                .ToCharArray()
                .Where(c => c.Equals('\r') == false && c.Equals('\n') == false)
                .Count();
            textBoxMed.Text = q1.ToString();

            //Linq querry to find characters without witespaces
            var q2 = MyTextBox.Text
                .ToCharArray()
                .Where(c => c.Equals('\r') == false && c.Equals('\n') == false && c.Equals(' ') == false)
                .Count();
            textBoxUtan.Text = q2.ToString();

            //Linq querry to count words
            var q3 = MyTextBox.Text
                .Split(' ', '\r', '\n')
                .Where(c => c != "")
                .Count();
            textBoxOrd.Text = q3.ToString();

            //Linq querry to count number of rows in the text
            var q4 = MyTextBox.Text
                .Split('\n')
                .Count();
            textBoxRader.Text = q4.ToString();
        }


        // A drag Drop method
        private void MyTextBox_DragDrop(object sender, DragEventArgs e)
        {
            var data = e.Data.GetData(DataFormats.FileDrop);
            if (data != null)
            {
                var fileNames = data as string[];

                if (FileIsChanged)
                {
                    DialogResult dialogResult = MessageBoxWantToSave();
                    if (dialogResult == DialogResult.Yes)
                    {
                        if (File.Exists(LatestSavedFilePath))
                        {
                            if (this.Text.Last() == '*')
                                this.Text = this.Text.Remove(this.Text.Length - 1);

                            File.WriteAllText(LatestSavedFilePath, MyTextBox.Text);
                            FileIsChanged = false;
                            MyTextBox.Text = File.ReadAllText(fileNames[0]);
                            ChangeOpenAndSaveInitialDirectory(fileNames[0]);
                        }
                        else
                        {
                            saveFileDialog.ShowDialog();
                            File.WriteAllText(Path.GetFullPath(saveFileDialog.FileName), MyTextBox.Text);
                            ChangeOpenAndSaveInitialDirectory(saveFileDialog.FileName);
                            MyTextBox.Text = File.ReadAllText(fileNames[0]);
                            ChangeOpenAndSaveInitialDirectory(fileNames[0]);
                        }
                    }
                    else if (dialogResult == DialogResult.No)
                    {
                        MyTextBox.Text = File.ReadAllText(fileNames[0]);
                        ChangeOpenAndSaveInitialDirectory(fileNames[0]);
                    }
                }
                else
                {
                    if (e.KeyState == 4) // SHIFT
                    {
                        Console.WriteLine(e.KeyState == 4);
                        File.AppendAllText(LatestSavedFilePath, File.ReadAllText(fileNames[0]));
                        MyTextBox.Text = File.ReadAllText(LatestSavedFilePath);
                    }
                    else if (e.KeyState == 8) // CTRL
                    {
                        Console.WriteLine(e.KeyState == 8);

                        int curPos = MyTextBox.SelectionStart;
                        MyTextBox.Text = MyTextBox.Text.Insert(curPos, File.ReadAllText(fileNames[0]));
                    }
                    else
                    {
                        MyTextBox.Text = File.ReadAllText(fileNames[0]);
                        ChangeOpenAndSaveInitialDirectory(fileNames[0]);
                    }
                }
            }
        }

        // A Drag Enter method
        private void MyTextBox_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Link;
            else
                e.Effect = DragDropEffects.None;
        }
    }
}


