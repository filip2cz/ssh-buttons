# SSH-Buttons - První výstup
Filip Komárek  
26. listopadu 2023

V rámci prvního výstupu jsem zpracoval konzolovou aplikaci, která je prototypem budoucí grafické aplikace ve WPF.
V rámci tohoto kódu jsou hlavní 3 soubory: Program.cs, Config.cs a Ssh.cs.

Program.cs obsahuje kód specifický pro tuto testovací verzi,
zatím co Config.cs a Ssh.cs jsou univerzální a budoucí grafická verze aplikace je zdìní.

Pomocí Config.cs si program naète nastavení z konfiguraèního souboru config.json. Aktuálnì jde ovšem o poøadí prvkù v konfiguraèním souboru,
a ne o jejich název, což jde proti filozofii JSON formátu a je tøeba na tom ještì zapracovat.

Pomocí Ssh.cs se program pøipojí k SSH serveru na adrese, kterou mu hlavní èást programu (Program.cs) pøedá a po té vykoná pøíkaz, jenž
mu tato hlavní èást programu pøedá ve stejný moment. Po dokonèení pøíkazu se odpojí. Zatím se mi bohužel nepodaøilo zprostøedkovat
vstup pro uživatele v pøípadì, že bude pøíkaz vyžadovat heslo (napø. pro sudo oprávnìní). V rámci tohoto vznikla alternativní funkce
Ssh.cs, jenž prozatím není souèástí hlavního kódu a je možné ji najít v branchi
[ssh-async](https://github.com/filip2cz/ssh-buttons/blob/ssh-async/Ssh.cs) v repozitáøi.

Program.cs obsahuje základní terminálové rozhraní pro ovládání této testovací verze, jejíž souèástí je to že vypíše tolik možností,
kolik mu øekne výstup z funkce Config.cs, neboli teoreticky nekoneènì mnoho, omezeno výkonem poèítaèe.