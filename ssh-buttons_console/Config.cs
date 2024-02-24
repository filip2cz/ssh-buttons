using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace ssh_buttons_console
{
    public partial class Config
    {
        public string[] LoadConfig()
        {
            
            try
            {
                string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "config.json");

                string json = File.ReadAllText(filePath);

                JObject jsonObject = JsonConvert.DeserializeObject<JObject>(json);

                string hostname;
                try
                {
                    hostname = jsonObject["hostname"].Value<string>();
                }
                catch (Exception)
                {
                    hostname = "";
                }

                string username;
                try
                {
                    username = jsonObject["username"].Value<string>();
                }
                catch (Exception)
                {
                    username = "";
                }

                string[] loadedConfig = { "success" , hostname , username };

                Debug.WriteLine("[Congig.cs] success");
                Debug.WriteLine($"[Congig.cs] hostname = {hostname}");
                Debug.WriteLine($"[Congig.cs] username = {username}");

                return loadedConfig;
            }
            catch (FileNotFoundException ex)
            {
                string[] loadedConfig = new string[] { "error", "Error: Configuration file was not loaded", ex.Message };

                Debug.WriteLine("[Congig.cs] error");
                Debug.WriteLine($"[Congig.cs] {ex}");

                return loadedConfig;
            }
            catch (JsonException ex)
            {
                string[] loadedConfig = new string[] { "error", "Error: Configuration file was not loaded", ex.Message };

                Debug.WriteLine("[Congig.cs] error");
                Debug.WriteLine($"[Congig.cs] {ex}");

                return loadedConfig;
            }
            catch (Exception ex)
            {
                string[] loadedConfig = new string[] { "error", "Error: Configuration file was not loaded", ex.Message };

                Debug.WriteLine("[Congig.cs] error");
                Debug.WriteLine($"[Congig.cs] {ex}");

                return loadedConfig;
            }
        }
        public string[] LoadCommands()
        {

            try
            {
                string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "commands.txt");

                string fileContent = File.ReadAllText(filePath);

                string[] loadedCommands = fileContent.Split(Environment.NewLine, StringSplitOptions.RemoveEmptyEntries);

                return loadedCommands;
            }
            catch (FileNotFoundException ex)
            {
                string[] loadedCommands = new string[] {"Error: Configuration file was not loaded", "error", ex.Message, "error" };

                return loadedCommands;
            }
            catch (JsonException ex)
            {
                string[] loadedCommands = new string[] { "Error: Configuration file was not loaded", "error", ex.Message, "error" };

                return loadedCommands;
            }
            catch (Exception ex)
            {
                string[] loadedCommands = new string[] { "Error: Configuration file was not loaded", "error", ex.Message, "error" };

                return loadedCommands;
            }
        }
    }
}
