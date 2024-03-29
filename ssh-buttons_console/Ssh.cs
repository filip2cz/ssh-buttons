﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Renci.SshNet;
using SshNet;

namespace ssh_buttons_console
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
                    client.Connect();

                    var runCommand = client.RunCommand(command);
                    output = runCommand.Result;
                    Debug.WriteLine($"[Ssh.cs] Output: {output}");
                }
                catch (Exception ex)
                {
                    output = "[Ssh.cs] Error: " + ex.Message;
                    Debug.WriteLine(output);
                }
                finally
                {
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