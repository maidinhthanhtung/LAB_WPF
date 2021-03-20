using System;
using System.IO;
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

namespace WpfHello
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            button.IsEnabled = false;
            button1.IsEnabled = false;
        }
        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            button.IsEnabled = true;
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                StreamWriter sw = new StreamWriter("username.txt");
                sw.WriteLine(textBox.Text);
                sw.Close();
                button1.IsEnabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                StreamReader sr = new
                StreamReader("username.txt");
                label.Content = "Приветствую Вас, уважаемый " + sr.ReadToEnd();
                sr.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void button3_Click(object sender, RoutedEventArgs e)
        {
            myTextBox.Text = DateTime.Now.ToString();
        }
    }
}
