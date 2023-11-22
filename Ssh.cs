using Renci.SshNet;
using System;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Threading.Tasks;

public class Ssh
{
    private SshClient _client;

    public Ssh(string host, string username, string password)
    {
        _client = new SshClient(host, username, password);
    }

    public async Task<string> ExecuteCommand(string command, string password)
    {
        _client.Connect();

        using (var shell = _client.CreateShellStream("xterm", 80, 24, 800, 600, 1024))
        using (var reader = new StreamReader(shell, Encoding.UTF8))
        {
            shell.WriteLine(command);

            await Task.Delay(1000);

            shell.WriteLine(password);

            string output = await reader.ReadToEndAsync();
            Debug.WriteLine(output);

            if (output.Contains("password:", StringComparison.OrdinalIgnoreCase))
            {
                Debug.WriteLine("output indicates that we need send password");
                shell.WriteLine(password);
                await Task.Delay(1000);
                output = await reader.ReadToEndAsync();
            }

            _client.Disconnect();

            return output;
        }
    }
}
