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

namespace NCommand
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            CommandBinding abinding = new CommandBinding();
            abinding.Command = CustomCommands.Launch;
            abinding.Executed += new ExecutedRoutedEventHandler(Launch_Handler);
            abinding.CanExecute += new CanExecuteRoutedEventHandler(LaunchEnabled_Handler);
            this.CommandBindings.Add(abinding);
        }
        private void Launch_Handler(object sender, ExecutedRoutedEventArgs e)
        {
            richTextBox.AppendText(textBox.Text);
            using (System.IO.StreamWriter writer = new
            System.IO.StreamWriter("log.txt", true))
            {
                writer.WriteLine("Внесено {0}: {1} ", textBox.Text,
                DateTime.Now.ToShortDateString() + ", время: " +
                DateTime.Now.ToLongTimeString());
                writer.Flush();
            }
        }
        private void LaunchEnabled_Handler(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = (bool)checkBox.IsChecked;
        }

    }
}
