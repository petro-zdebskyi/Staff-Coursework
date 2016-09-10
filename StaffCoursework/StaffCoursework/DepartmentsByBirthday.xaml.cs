using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace StaffCoursework
{
    /// <summary>
    /// Interaction logic for DepartmentsByBirthday.xaml
    /// </summary>
    public partial class DepartmentsByBirthday : Window
    {
        public DepartmentsByBirthday()
        {
            InitializeComponent();
        }
        private void StartButton_Click(object sender, RoutedEventArgs e)
        {
            Tasks.DepartmentsByBirthdayFunc(MainWindow.Workers, DepartmentsByBirthdayTextBox);
        }
        private void DepartmentsByBirthdayTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            var textBox = sender as TextBox;
            if (textBox == null)
                return;

            // робимо перевірку правильності вводу даних
            if (DataValidation.Date(textBox.Text))
            {
                textBox.Background = Brushes.Aqua;
                StartButton.IsEnabled = true;
            }
            else
            {
                textBox.Background = Brushes.White;
                StartButton.IsEnabled = false;
            }
        }
    }
}
