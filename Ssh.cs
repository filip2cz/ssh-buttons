using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Renci.SshNet;
using SshNet;

namespace ssh_buttons_console_demo
{
    public partial class Ssh
    {
        public string Command(string hostname, string username, string password, string command)
        {
            ConnectionInfo connectionInfo = new ConnectionInfo(hostname, username, new PasswordAuthenticationMethod(username, password));
            string output = string.Empty;

            using (var client = new SshClient(connectionInfo))
            {
                try
                {
                    // Připojení k SSH serveru
                    client.Connect();

                    Debug.WriteLine("připojeno (asi)");

                    // Zde můžete provádět operace na SSH serveru

                    // Příklad: Výpis aktuálního adresáře
                    var runCommand = client.RunCommand(command);
                    output = "Output: " + runCommand.Result;
                    Debug.WriteLine($"Output: {output}");
                }
                catch (Exception ex)
                {
                    output = "Error: " + ex.Message;
                    Debug.WriteLine(output);
                }
                finally
                {
                    // Uzavření připojení
                    if (client.IsConnected)
                    {
                        client.Disconnect();
                    }
                }
                return output;
            }
            
        }
    }
}