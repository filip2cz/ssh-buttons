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
using ssh_buttons_console;

namespace ssh_buttons_desktop
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Config configLoader = new Config();
            string[] config = configLoader.LoadConfig();

            if (config[0] == "error")
            {
                Debug.WriteLine("Error loading config file:");
                Debug.WriteLine(config[2]);
            }

            Ssh ssh = new Ssh();

            Debug.WriteLine("Loaded config:");
            foreach (string prvek in config)
            {
                Debug.WriteLine(prvek);
            }


        }
        public void Button_Click1(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine("Button1 clicked");
        }
        public void Button_Click2(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine("Button2 clicked");
        }
        public void Button_Click3(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine("Button3 clicked");
        }
        public void Button_Click4(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine("Button4 clicked");
        }
        public void Button_Click5(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine("Button5 clicked");
        }
        public void Button_Click6(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine("Button6 clicked");
        }
        public void Button_Click7(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine("Button7 clicked");
        }
        public void Button_Click8(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine("Button8 clicked");
        }
    }
}
