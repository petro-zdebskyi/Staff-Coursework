using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace StaffCoursework
{
    /// <summary>
    /// Interaction logic for ProjectsInDepartment.xaml
    /// </summary>
    public partial class ProjectsInDepartment : Window
    {
        public ProjectsInDepartment()
        {
            InitializeComponent();
        }
        private void StartButton_Click(object sender, RoutedEventArgs e)
        {
            Tasks.ProjectsInDepartmentFunc(MainWindow.Workers, ProjectsInDepartmentTextBox);
        }
        private void ProjectsInDepartmentTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            var textBox = sender as TextBox;
            if (textBox == null)
                return;

            // робимо перевірку правильності вводу даних
            if (DataValidation.DepartmentProject(textBox.Text))
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
