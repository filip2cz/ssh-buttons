<!-- 

Pokud nemáte program na otevření tohoto souboru v čitelném formátu, použijte následující odkaz:
https://github.com/filip2cz/ssh-buttons/blob/2vystup/2vystup.md

-->

# SSH-Buttons - Druhý výstup
Filip Komárek, 4.C  
7. ledna 2024

Repozitář s kódem relevantnímu k tomuto výstupu: [https://github.com/filip2cz/ssh-buttons/tree/2vystup](https://github.com/filip2cz/ssh-buttons/tree/2vystup)

Spustitelný soubor releventní k tomuto výstupu: [https://github.com/filip2cz/ssh-buttons/releases/tag/v0.2](https://github.com/filip2cz/ssh-buttons/releases/tag/v0.2) (soubor [ssh-buttons.zip](https://github.com/filip2cz/ssh-buttons/releases/download/v0.2/ssh-buttons.zip))

Pro tento výstup byli provedeny následující úpravy kódu:

## 1. Úprava struktury konfiguračních souborů
V předchozí verzi byl konfigurační soubor ve formátu JSON, ale program se k němu nechovat jako k JSONu, pracovat spíše s pořadím prvků než s jejich jmény.
Bylo třeba zvážit, jakým způsobem bude program s konfiguračním souborem pracovat. Na zvážení byli dvě možnosti:

1. Jeden konfigurační soubor ve formátu JSON, ze kterého bude program číst jak informace o serveru, tak i příkazy.

2. Jeden konfigurační soubor ve formátu JSON s informacemi o serveru a druhý ve formátu TXT, který bude fungovat podobně jako funguje config.json do teď, ovšem bez json části.

Nakonec byl zvolen druhý způsob struktury konfiguračních souborů, protože je pro uživatele jednodušší oddělovat příkazy prostě dalším řádkem, nežli pracovat s dynamickým pojmenováním prvků v JSON konfiguračním souboru.

Příklad souboru config.json:
```json
{
  "hostname": "example.com",
  "username": "user"
}
```

Nyní existují teda dva konfigurační soubory. První config.json funguje stejně jako do teď s tím rozdílem, že se do něj již nepíšou příkazy, ale pouze informace o serveru. Druhý soubor commands.txt funguje tak, že jsou v něm tzv. na střídačku odděleny název příkazu a příkaz.

Příklad souboru commands.txt:
```
Spuštění webového serveru
sudo systemctl start apache2
Vypnutí webového serveru
sudo systemctl stop apache2
Vytvoření souboru test.txt
touch test.txt
Odstranění souboru test.txt
rm test.txt
```

## 2. Přizpůsobení projektu pro různé budoucí verze

Rozhodl jsem se v budoucnu udržovat jak konzolovou verzi programu, tak i verzi s grafickým rozhraním. Na stole je také potenciální verze pro Android. Upravil jsem proto projekt Visual Studia tak, aby v budoucnu obsahoval všechny tyto verze a tím se usnadnilo případné sdílení kódu, protože všechny verze budou v jazyce C# a jen konkrétní části budou specifické pro danou platformu / verzi.

## 3. Práce na asynchroním SSH spojení

V aktuální verzi funguje SSH spojení se serverem tak, že se připojuje při každém příkazu zvlášť a po vykonání příkazu se odpojí. Tento stav není přiliš ideální, pracuji tedy na kódu, kdy se program připojí k serveru po spuštění a po té bude připojen až do ukončení programu.