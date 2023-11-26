<!-- 

Pokud nemáte program na otevření tohoto souboru v čitelném formátu, použijte následující odkaz:
https://github.com/filip2cz/ssh-buttons/blob/1vystup/1vystup.md

-->

# SSH-Buttons - První výstup
Filip Komárek, 4.C  
26. listopadu 2023

Repozitář s kódem relevantnímu k tomuto výstupu: [https://github.com/filip2cz/ssh-buttons/tree/1vystup](https://github.com/filip2cz/ssh-buttons/tree/1vystup)

Spustitelný soubor releventní k tomuto výstupu: [https://github.com/filip2cz/ssh-buttons/releases/tag/v0.1](https://github.com/filip2cz/ssh-buttons/releases/tag/v0.1) (soubor [ssh-buttons.zip](https://github.com/filip2cz/ssh-buttons/releases/download/v0.1/ssh-buttons.zip))

V rámci prvního výstupu jsem vypracoval konzolovou aplikaci, která je prototypem budoucí grafické aplikace ve WPF.
V rámci tohoto kódu jsou hlavní 3 soubory: Program.cs, Config.cs a Ssh.cs.

Program.cs obsahuje kód specifický pro tuto testovací verzi,
zatím co Config.cs a Ssh.cs jsou univerzální a budoucí grafická verze aplikace je zdědí.

Pomocí Config.cs si program načte nastavení z konfiguračního souboru config.json. Aktuálně jde ovšem o pořadí prvků v konfiguračním souboru,
a ne o jejich název, což jde proti filozofii JSON formátu a je třeba na tom ještě zapracovat.

Ukázka kódu načítajícího konfigurační soubor:
```
string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "config.json");
string json = File.ReadAllText(filePath);
JObject jsonObject = JObject.Parse(json);
string[] loadedCommands = jsonObject.Properties().Select(p => p.Value.ToString()).ToArray();
return loadedCommands;
```

Pomocí Ssh.cs se program připojí k SSH serveru na adrese, kterou mu hlavní část programu (Program.cs) předá a po té vykoná příkaz, jenž
mu tato hlavní část programu předá ve stejný moment. Po dokončení příkazu se odpojí. Zatím se mi bohužel nepodařilo zprostředkovat
vstup pro uživatele v případě, že bude příkaz vyžadovat heslo (např. pro sudo oprávnění). V rámci tohoto vznikla alternativní funkce
Ssh.cs, jenž prozatím není součástí hlavního kódu a je možné ji najít v branchi [ssh-async](https://github.com/filip2cz/ssh-buttons/blob/ssh-async/Ssh.cs) v repozitáři.

Část kódu zodpovědná za připojování se k SSH serveru a odesílání příkazu:
```
ConnectionInfo connectionInfo = new ConnectionInfo(hostname, username, new PasswordAuthenticationMethod(username, password));
string output = string.Empty;
using (var client = new SshClient(connectionInfo))
{
   client.Connect();
   var runCommand = client.RunCommand(command);
   output = "Output: " + runCommand.Result;
   Debug.WriteLine($"Output: {output}");
}
```

Program.cs obsahuje základní terminálové rozhraní pro ovládání této testovací verze, jejíž součástí je to že vypíše tolik možností,
kolik mu řekne výstup z funkce Config.cs, neboli teoreticky nekonečně mnoho, omezeno výkonem počítače.

Ukázka aktuálního ovládání programu:
```
SSH Buttons - test console version
Version v0.1
Created by Filip Komárek
https://github.com/filip2cz/ssh-buttons

Server hostname: example.com
Username: user
Password: ********
[1] Spuštění serveru
[2] Zastavení serveru
[3] Restart serveru
[4] Seznam nainstalovaných pluginů
[5] Seznam uživatelů online
[0] exit
Choose command:
```
