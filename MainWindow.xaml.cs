using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using System.Windows.Threading;

namespace ProcessListApp
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Process[] processes;        
        public MainWindow()
        {
            InitializeComponent();

            ProcessList();           
        }

        private void exitButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void informationButton_Click(object sender, RoutedEventArgs e)
        {
            string proc = processListBox.SelectedItem.ToString();
            int ind = proc.IndexOf("-");
            proc = proc.Remove(ind - 1);
            if (proc != null)
            {
                InformationProcess information = new InformationProcess(Convert.ToInt32(proc));
                information.Show();
            }
            else
            {
                MessageBox.Show(
                    "The process is not selected",
                    "Error",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error);
            }
        }

        private void updateButton_Click(object sender, RoutedEventArgs e)
        {
            processListBox.Items.Clear();
            ProcessList();            
        }

        private void ProcessList()
        {            
            processes = Process.GetProcesses();
            processListBox.Items.Add("PID - Process name");
            foreach (Process process in processes)
            {
                processListBox.Items.Add($"{process.Id} - {process.ProcessName}");
            }
        }
    }
}
