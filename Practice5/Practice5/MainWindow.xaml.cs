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

namespace Practice5
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            aWorker.WorkerSupportsCancellation = true;
            aWorker.DoWork += aWorker_DoWork;
            aWorker.RunWorkerCompleted += aWorker_RunWorkerCompleted;
        }
        System.ComponentModel.BackgroundWorker aWorker = new System.ComponentModel.BackgroundWorker();
        private void aWorker_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            for (int i = 0; i <= 50; i++)
            {
                for (int j = 1; j <= 10000000; j++)
                {
                }
                if (aWorker.CancellationPending)
                {
                    e.Cancel = true;
                    return;
                }
                UpdateDelegate update = new UpdateDelegate(UpdateLabel);
                label1.Dispatcher.BeginInvoke(
                System.Windows.Threading.DispatcherPriority.Normal, update, i);
            }
        }
        private void aWorker_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            if (!(e.Cancelled))
              label2.Content = "Run Completed";
            else
              label2.Content = "Run Cancelled";
        }
        private delegate void UpdateDelegate(int i);
        private void UpdateLabel(int i)
        {
            label1.Content = "Cycles: " + i.ToString();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            aWorker.RunWorkerAsync();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            aWorker.CancelAsync();
        }
    }
}
