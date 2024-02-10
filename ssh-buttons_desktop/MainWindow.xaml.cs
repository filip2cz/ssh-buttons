using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
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
            this.MinWidth = 760;
            this.MaxWidth = 850;
            this.MinHeight = 360;

            int i;

            output.Text = "SSH-Buttons\r\nCreated by Filip Komárek\r\nVersion: v0.4\r\nWaiting for command...";

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

            /*
            if (commandsLoaded == true)
            {
                try
                {
                    Button1.Content = commands[0];
                }
                catch (Exception) { }
                try
                {
                    Button2.Content = commands[2];
                }
                catch (Exception) { }
                try
                {
                    Button3.Content = commands[4];
                }
                catch (Exception) { }
                try
                {
                    Button4.Content = commands[6];
                }
                catch (Exception) { }
                try
                {
                    Button5.Content = commands[8];
                }
                catch (Exception) { }
                try
                {
                    Button6.Content = commands[10];
                }
                catch (Exception) { }
                try
                {
                    Button7.Content = commands[12];
                }
                catch (Exception) { }
            }
            else
            {
                output.Text = $"{commands[0]}\r\n{commands[2]}";
            }
            */

            if (commandsLoaded == true)
            {
                int howManyButtons = commands.Length/2;
                int columns = 4;
                int buttonContent = 0;

                i = 0;

                while (i < howManyButtons)
                {
                    try
                    {
                        int index = i;

                        Button button = new Button();
                        button.Content = commands[buttonContent];
                        buttonContent += 2;
                        button.Width = 180;
                        button.Height = 85;
                        button.Margin = new Thickness(0, 0, 0, 10);

                        button.Click += (sender, e) => Button_Click(index);

                        gridButtons.Children.Add(button);
                        Grid.SetColumn(button, i % columns);
                        Grid.SetRow(button, i / columns);
                    }
                    catch (Exception)
                    {
                        throw;
                    }
                    i++;
                }

                for (int tmp = 0; tmp < (int)Math.Ceiling((double)howManyButtons / columns); tmp++)
                {
                    RowDefinition rowDefinition = new RowDefinition();
                    rowDefinition.Height = GridLength.Auto;
                    gridButtons.RowDefinitions.Add(rowDefinition);
                    gridButtons.SetValue(Grid.RowSpanProperty, tmp+1);
                }
            }
            else
            {
                MessageBox.Show($"{commands[0]}\r\n{commands[2]} \r\n\r\nDoes commands.txt exists?");
                output.Text = $"{commands[0]}\r\n{commands[2]}";
            }
        }
        public void Button_Click(int index)
        {
            if (hostname.Text == string.Empty)
            {
                output.Text = "Error: empty hostname";
            }
            else
            {
                Debug.WriteLine($"Executing command {commands[(index+1)*2-1]}");
                output.Text = ssh.Command(hostname.Text, username.Text, password.Password, commands[(index + 1) * 2 - 1]);
            }
        }
        /*
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
        */
    }
}
