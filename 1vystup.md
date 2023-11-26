# SSH-Buttons - První výstup
Filip Komárek, 4.C  
26. listopadu 2023

Repozitáø s kódem relevantnímu k tomuto výstupu: [https://github.com/filip2cz/ssh-buttons/tree/1vystup](https://github.com/filip2cz/ssh-buttons/tree/1vystup)

Spustitelný soubor releventní k tomuto výstupu: [https://github.com/filip2cz/ssh-buttons/releases/tag/v0.1](https://github.com/filip2cz/ssh-buttons/releases/tag/v0.1) (soubor [ssh-buttons.zip](https://github.com/filip2cz/ssh-buttons/releases/download/v0.1/ssh-buttons.zip))

V rámci prvního výstupu jsem vypracoval konzolovou aplikaci, která je prototypem budoucí grafické aplikace ve WPF.
V rámci tohoto kódu jsou hlavní 3 soubory: Program.cs, Config.cs a Ssh.cs.

Program.cs obsahuje kód specifický pro tuto testovací verzi,
zatím co Config.cs a Ssh.cs jsou univerzální a budoucí grafická verze aplikace je zdìní.

Pomocí Config.cs si program naète nastavení z konfiguraèního souboru config.json. Aktuálnì jde ovšem o poøadí prvkù v konfiguraèním souboru,
a ne o jejich název, což jde proti filozofii JSON formátu a je tøeba na tom ještì zapracovat.

Pomocí Ssh.cs se program pøipojí k SSH serveru na adrese, kterou mu hlavní èást programu (Program.cs) pøedá a po té vykoná pøíkaz, jenž
mu tato hlavní èást programu pøedá ve stejný moment. Po dokonèení pøíkazu se odpojí. Zatím se mi bohužel nepodaøilo zprostøedkovat
vstup pro uživatele v pøípadì, že bude pøíkaz vyžadovat heslo (napø. pro sudo oprávnìní). V rámci tohoto vznikla alternativní funkce
Ssh.cs, jenž prozatím není souèástí hlavního kódu a je možné ji najít v branchi [ssh-async](https://github.com/filip2cz/ssh-buttons/blob/ssh-async/Ssh.cs) v repozitáøi.

Program.cs obsahuje základní terminálové rozhraní pro ovládání této testovací verze, jejíž souèástí je to že vypíše tolik možností,
kolik mu øekne výstup z funkce Config.cs, neboli teoreticky nekoneènì mnoho, omezeno výkonem poèítaèe.