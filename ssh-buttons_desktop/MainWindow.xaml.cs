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
        Config configLoader = new Config();
        string[] commands;

        Ssh ssh = new Ssh();

        public MainWindow()
        {
            InitializeComponent();
            int i;

            output.Text = "SSH-Buttons\r\nCreated by Filip Komárek\r\nVersion: v0.3\r\nWaiting for command...";

            string[] config = configLoader.LoadConfig();

            if (config[0] == "error")
            {
                Debug.WriteLine("Error loading config file:");
                Debug.WriteLine(config[2]);
            }
            else
            {
                Debug.WriteLine("Loaded config:");
                foreach (string thing in config)
                {
                    Debug.WriteLine(thing);
                }
            }

            if (config[1] != "askUser")
            {
                hostname.Text = config[1];
            }

            if (config[2] != "askUser")
            {
                username.Text = config[2];
            }

            commands = configLoader.LoadCommands();

            bool commandsLoaded = true;
            if (commands[1] == "error")
            {
                commandsLoaded = false;
            }

            Debug.WriteLine("Loaded commands:");

            Debug.WriteLine("Loaded config:");
            foreach (string thing in commands)
            {
                Debug.WriteLine(thing);
            }

            if (commandsLoaded == true)
            {
                Button1.Content = commands[0];
                Button2.Content = commands[2];
                Button3.Content = commands[4];
                Button4.Content = commands[6];
                Button5.Content = commands[8];
                Button6.Content = commands[10];
                Button7.Content = commands[12];
            }
            else
            {
                output.Text = $"{commands[0]}\r\n{commands[2]}";
            }
        }
        public void Button_Click1(object sender, RoutedEventArgs e)
        {
            if (hostname.Text == string.Empty)
            {
                output.Text = "Error: empty hostname";
            }
            else
            {
                output.Text = $"Executing command {commands[1]}";
                output.Text = ssh.Command(hostname.Text, username.Text, password.Password, commands[1]);
            }
        }
        public void Button_Click2(object sender, RoutedEventArgs e)
        {
            if (hostname.Text == string.Empty)
            {
                output.Text = "Error: empty hostname";
            }
            else
            {
                output.Text = $"Executing command {commands[3]}";
                output.Text = ssh.Command(hostname.Text, username.Text, password.Password, commands[3]);
            }
        }
        public void Button_Click3(object sender, RoutedEventArgs e)
        {
            if (hostname.Text == string.Empty)
            {
                output.Text = "Error: empty hostname";
            }
            else
            {
                output.Text = $"Executing command {commands[5]}";
                output.Text = ssh.Command(hostname.Text, username.Text, password.Password, commands[5]);
            }
        }
        public void Button_Click4(object sender, RoutedEventArgs e)
        {
            if (hostname.Text == string.Empty)
            {
                output.Text = "Error: empty hostname";
            }
            else
            {
                output.Text = $"Executing command {commands[7]}";
                output.Text = ssh.Command(hostname.Text, username.Text, password.Password, commands[7]);
            }
        }
        public void Button_Click5(object sender, RoutedEventArgs e)
        {
            if (hostname.Text == string.Empty)
            {
                output.Text = "Error: empty hostname";
            }
            else
            {
                output.Text = $"Executing command {commands[9]}";
                output.Text = ssh.Command(hostname.Text, username.Text, password.Password, commands[9]);
            }
        }
        public void Button_Click6(object sender, RoutedEventArgs e)
        {
            if (hostname.Text == string.Empty)
            {
                output.Text = "Error: empty hostname";
            }
            else
            {
                output.Text = $"Executing command {commands[11]}";
                output.Text = ssh.Command(hostname.Text, username.Text, password.Password, commands[11]);
            }
        }
        public void Button_Click7(object sender, RoutedEventArgs e)
        {
            if (hostname.Text == string.Empty)
            {
                output.Text = "Error: empty hostname";
            }
            else
            {
                output.Text = $"Executing command {commands[13]}";
                output.Text = ssh.Command(hostname.Text, username.Text, password.Password, commands[13]);
            }
        }
        public void Button_Click_Custom(object sender, RoutedEventArgs e)
        {
            if (hostname.Text == string.Empty)
            {
                output.Text = "Error: empty hostname";
            }
            else
            {
                output.Text = $"Executing command {customCommand.Text}";
                output.Text = ssh.Command(hostname.Text, username.Text, password.Password, customCommand.Text);
            }
        }
    }
}
