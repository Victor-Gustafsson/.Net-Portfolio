using static The_Harbour.Data.FileManagement;
using static The_Harbour.Model.HarbourCalculations;
using The_Harbour.Model;
using System.IO;
using System.Windows;
using The_Harbour.Controllers;
using System.Linq;
using System.Collections.Generic;
using System.Windows.Controls;
using System;


namespace The_Harbour
{
    /// <summary>
    // Jag har försökt att få koden så självkommenterande som möjligt 
    // Förbättringsmöjligheter
    //      • Lägga till en backgroundWorker så att simulera en vecka går dag för dag 
    //      • Under körning refektorierna kodens så den inte behöver läsa från filen varje gång
    /// </summary>
    public partial class MainWindow : Window
    {
        Controller controller = new Controller(new Harbour(32, 32));

        public MainWindow()
        {
            InitializeComponent();
            ShowHabour();
        }
        //Button click = kör en dag
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            bool[] Filter = new bool[] { (bool)RowBoatRadio.IsChecked, (bool)MotorBoatRadio.IsChecked, (bool)SailBoatRadio.IsChecked, (bool)CargoChipRadio.IsChecked, (bool)CatamaranRadio.IsChecked };
            controller.Run(int.Parse(MySlider.Value.ToString()), Filter);
            MyTreeViewFirst.Items.Clear();
            MyTreeViewSecond.Items.Clear();
            KörDagLabel.Content = DateTime.Parse(DateTime.Now.AddDays(controller.Harbor.HarborTotalDays).ToString("M/d/yyyy"));

            ShowHabour();
        }
        private void KörVecka_Click(object sender, RoutedEventArgs e)
        {
            bool[] Filter = new bool[] { (bool)RowBoatRadio.IsChecked, (bool)MotorBoatRadio.IsChecked, (bool)SailBoatRadio.IsChecked, (bool)CargoChipRadio.IsChecked, (bool)CatamaranRadio.IsChecked };
            for (int i = 0; i < 7; i++)
            {
                controller.Run(int.Parse(MySlider.Value.ToString()), Filter);
                MyTreeViewFirst.Items.Clear();
                MyTreeViewSecond.Items.Clear();
                körVeckaLable.Content = DateTime.Parse(DateTime.Now.AddDays(controller.Harbor.HarborTotalDays).ToString("M/d/yyyy"));
                ShowHabour();
            }
        }
        private void MySlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (SlideNumber != null)
            {
                SlideNumber.Text = MySlider.Value.ToString();
            }
        }

        public void ShowHabour()
        {
            PrintBoats(MyTreeViewFirst, BerthOne);
            PrintBoats(MyTreeViewSecond, BerthTwo);
            PrintBoatsCheckOut();
            PrintBoatsCheckIn();
            PrintBoatsRejected();
            PrintHabourFacts();
        }

        public void PrintBoats(TreeView MyTreeView, string DataFile)
        {


            foreach (string line in File.ReadAllLines(DataFile))
            {
                try
                {
                    string[] file = line.Split(' ', '-');
                    int start = int.Parse(file[1]);
                    string id = $"{file[6]}-{file[7]}";
                    string type = file[4];
                    int weight = int.Parse(file[9]);
                    double maxSpeed = ConvertKnopToKMh(int.Parse(file[11]));
                    double berthSize = double.Parse(file[13]);
                    int berthTime = int.Parse(file[15]);
                    int uniqe = int.Parse(file[18]);
                    int end = 0;

                    TreeViewItem ParentItem = new TreeViewItem();
                    TreeViewItem Child1Item = new TreeViewItem();
                    TreeViewItem Child2Item = new TreeViewItem();
                    TreeViewItem Child3Item = new TreeViewItem();
                    TreeViewItem Child5Item = new TreeViewItem();
                    Child1Item.Header = $"Weight: {weight}";
                    Child2Item.Header = $"Max speed: {maxSpeed} Km/h";
                    Child5Item.Header = $"Days left in dock: {int.Parse(file[15])}";

                    if (type == "Sailboat" || type == "Cargo ship" || type == "Catamaran")
                    {
                        end = int.Parse(file[2]);
                        ParentItem.Header = $"{start}-{end} {type} \t({id}) ";
                    }
                    else
                        ParentItem.Header = $"{start} {type} \t({id}) ";



                    if (type == "Rowboat")
                        Child3Item.Header = $"Max Number of passenger {uniqe} st";
                    else if (type == "PowerBoat")
                        Child3Item.Header = $"Horsepower {uniqe} st";
                    else if (type == "Sailboat")
                        Child3Item.Header = $"Boat length {uniqe} m";
                    else if (type == "CargoShip")
                        Child3Item.Header = $"loaded Containers {uniqe} st";
                    else if (type == "Catamaran")
                        Child3Item.Header = $"Number of beds {uniqe} st";

                    MyTreeView.Items.Add(ParentItem);
                    ParentItem.Items.Add(Child1Item);
                    ParentItem.Items.Add(Child2Item);
                    ParentItem.Items.Add(Child3Item);
                    ParentItem.Items.Add(Child5Item);
                }
                catch
                {
                    TreeViewItem ParentItem = new TreeViewItem();
                    string[] file = line.Split(' ', '-');
                    ParentItem.Header = $"{file[1]} {file[2]}";
                    MyTreeView.Items.Add(ParentItem);
                }

            }
        }


        private void PrintBoatsCheckOut()
        {
            List<string> ut = new List<string>();
            var TodaysCheckOuts = controller.Harbor.TodaysCheckOuts
           .GroupBy(b => b.ToString())
           .Select(b => b.First());

            foreach (var boat in TodaysCheckOuts)
            {
                ut.Add(boat.Typ + " " + boat.Id);
            }
            ListBoxUt.ItemsSource = ut;
        }

        private void PrintBoatsCheckIn()
        {
            List<string> inCheck = new List<string>();
            var TodaysCheckIns = controller.Harbor.TodaysCheckIns
           .GroupBy(b => b.ToString())
           .Select(b => b.First());


            foreach (var boat in TodaysCheckIns)
            {
                inCheck.Add(boat.Typ + " " + boat.Id);
            }
            ListBoxIn.ItemsSource = inCheck;
        }

        private void PrintBoatsRejected()
        {
            List<string> avvisade = new List<string>();
            var TodaysRejected = controller.Harbor.TodaysRejected
           .GroupBy(b => b.ToString())
           .Select(b => b.First());

            foreach (var boat in TodaysRejected)
            {
                avvisade.Add(boat.Typ + " " + boat.Id);
            }

            ListBoxAv.ItemsSource = avvisade;
        }

        private void PrintHabourFacts()
        {
            Antal_Båtar.Header = $"Number of boats ({CountTotalNumberOfBoats(controller.Harbor.BerthsFirst, controller.Harbor.BerthsSecond)})";
            List<string> antal = new List<string>();
            antal.Add($"Rowing boats: {CountSpecificBoatType(controller.Harbor.BerthsFirst, controller.Harbor.BerthsSecond, "Rowboat")} st");
            antal.Add($"Powerboats: {CountSpecificBoatType(controller.Harbor.BerthsFirst, controller.Harbor.BerthsSecond, "PowerBoat")} st");
            antal.Add($"Sailboats: {CountSpecificBoatType(controller.Harbor.BerthsFirst, controller.Harbor.BerthsSecond, "Sailboat")} st");
            antal.Add($"Cargo ships: {CountSpecificBoatType(controller.Harbor.BerthsFirst, controller.Harbor.BerthsSecond, "CargoShip")} st");
            antal.Add($"Catamarans: {CountSpecificBoatType(controller.Harbor.BerthsFirst, controller.Harbor.BerthsSecond, "Catamaran")} st");
            ListBoxAntalBåtar.ItemsSource = antal;

            List<string> övrigt = new List<string>();
            övrigt.Add($"Number of rejected boats: {controller.Harbor.RejectedBoats} st");
            övrigt.Add($"Number of Harbour Days: {controller.Harbor.HarborTotalDays} st");
            övrigt.Add($"Number of available docks: {controller.Harbor.NumberOfAvailableBerths} st");
            övrigt.Add($"Total weight In the Harbour: {controller.Harbor.TotalBoatWeight} kg");
            övrigt.Add($"Average max speed: {controller.Harbor.AverageOfAllBoatsMaximumSpeed} Km/h");
            ListBoxÖvrigt.ItemsSource = övrigt;
        }


    }
}
