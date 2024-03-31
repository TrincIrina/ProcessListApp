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
using System.Windows.Shapes;

namespace ProcessListApp
{
    /// <summary>
    /// Логика взаимодействия для InformationProcess.xaml
    /// </summary>
    public partial class InformationProcess : Window
    {
        private Process process;
        public InformationProcess(int id)
        {
            InitializeComponent();

            TextProcess(id);
        }

        private void TextProcess(int id)
        {
            process = Process.GetProcessById(id);
            infListBox.Items.Add($"Handle: {process.Handle}");
            infListBox.Items.Add($"PID: {process.Id}");
            infListBox.Items.Add($"Name: {process.ProcessName}");
            infListBox.Items.Add($"Priority: {process.BasePriority}");
            infListBox.Items.Add($"StartTime: {process.StartTime}");
        }

        private void exitButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
