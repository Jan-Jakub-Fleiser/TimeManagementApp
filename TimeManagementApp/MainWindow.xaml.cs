using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace TimeManagementApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<ModuleDetails> details = new List<ModuleDetails>();
        Calculation c;
        int weeks = 1;
        
        public MainWindow()
        {
            InitializeComponent();
            CenterWindowOnScreen();
        }
        
        private void CenterWindowOnScreen()
        {
            double screenWidth = System.Windows.SystemParameters.PrimaryScreenWidth;
            double screenHeight = System.Windows.SystemParameters.PrimaryScreenHeight;
            double windowWidth = this.Width;
            double windowHeight = this.Height;
            this.Left = (screenWidth / 2) - (windowWidth / 2);
            this.Top = (screenHeight / 2) - (windowHeight / 2);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string value1 = NumberOfCreditsTextBox.Text;
            string value2 = ClassHoursPerWeekTextBox.Text;
            int Credits;
            int HoursPerWeek;

            if (int.TryParse(value1, out Credits) && int.TryParse(value2, out HoursPerWeek))
            {
                details.Add(new ModuleDetails() { Code = CodeTextBox.Text, Name = NameTextBox.Text, NumberOfCredits = Credits, ClassHoursPerWeek = HoursPerWeek, StartDate = StartDate.Text});
            }
            else
            {
                MessageBox.Show("Amount is only numbers");
            }
            printDetails();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < details.Count; i++)
            {
                if (details[i].Name == NameTextBox.Text)
                {
                    details.RemoveAt(i);
                }
            }
            printDetails();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            string value = NumberOfWeeksTextBox.Text;

            if (int.TryParse(value, out weeks) && weeks > 0)
            {
                printDetails();
            }
            else if (!(weeks > 0))
            {
                MessageBox.Show("Week has to be more than 1");
                NumberOfWeeksTextBox.Text = "1";
            }
            else
            {
                MessageBox.Show("Numbers Only");
            }
        }

        private void printDetails()
        {
            ModuleDetailTextBlock.Text = "Study time for \t\t is \n";

            var subset = from c in details select c;

            foreach (ModuleDetails module in details)
            {
                c = new Calculation(module.NumberOfCredits, module.ClassHoursPerWeek, weeks);
                ModuleDetailTextBlock.Text += $"{module.Name}\t\t\t\t{c.SelfStudy()}\n";
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < ModulesRecordListBox.Items.Count; i++)
            {
                ModulesRecordListBox.Items.RemoveAt(i);
            }

            foreach (ModuleDetails course in details)
            {
                ModulesRecordListBox.Items.Add(course.Name);

            }
        }

        private void ModulesRecordListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(int.TryParse(HoursTextBox.Text, out int hoursRemaining))
            {
                foreach (ModuleDetails course in details)
                {
                    if (ModulesRecordListBox.SelectedItem.ToString() == course.Name)
                    {
                        c = new Calculation(course.NumberOfCredits, course.ClassHoursPerWeek, course.NumberOfCredits);
                        HoursTextBlock.Text = $"{ c.SelfStudy() - int.Parse(HoursTextBox.Text)}";
                    }
                }
            }
            else
            {
                HoursTextBox.Text = "0";
                MessageBox.Show("Number of hours cannot be left open");
            }
            
        }

        private void TextBox_TextChanged_1(object sender, TextChangedEventArgs e)
        {
            if (int.TryParse(HoursTextBox.Text, out int hoursRemaining))
            {
                foreach (ModuleDetails course in details)
                {
                    if (ModulesRecordListBox.SelectedItem.ToString() == course.Name)
                    {
                        c = new Calculation(course.NumberOfCredits, course.ClassHoursPerWeek, course.NumberOfCredits);
                        HoursTextBlock.Text = $"{ c.SelfStudy() - int.Parse(HoursTextBox.Text)}";
                    }
                }
            }
            else
            {
                HoursTextBox.Text = "0";
                MessageBox.Show("Number of hours cannot be left open");
            }
        }
        
    }
}