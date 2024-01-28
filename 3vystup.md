<!-- 

Pokud nemáte program na otevření tohoto souboru v čitelném formátu, použijte následující odkaz:
https://github.com/filip2cz/ssh-buttons/blob/3vystup/3vystup.md

-->

# SSH-Buttons - Třetí výstup
Filip Komárek, 4.C  
28. ledna 2024

Repozitář s kódem relevantnímu k tomuto výstupu: [https://github.com/filip2cz/ssh-buttons/tree/3vystup](https://github.com/filip2cz/ssh-buttons/tree/3vystup)

Spustitelné soubory releventní k tomuto výstupu: [https://github.com/filip2cz/ssh-buttons/releases/tag/v0.3](https://github.com/filip2cz/ssh-buttons/releases/tag/v0.3) (soubory 
ssh-buttons-console.zip a  ssh-buttons-desktop.zip)

Pro třetí výstup jsem vytvořil první verzi s grafickým rozhraním. Jedná se ovšem o velmi ranou verzi, kde nebyl brán v potaz vzhled a taky dynamičnost, kdy tato verze má přesně 7 nastavitelných tlačítek. Tato verze je vytvořena pomocí WPF, kdy umístění prvků v grafickém rozhraní je definováno pomocí `xaml`, konkrétně je celé okno rozděleno do tzv. gridů, neboli mřížky. Tato verze také sdílí kód Ssh.cs a Config.cs s konzolovou verzí programu, která bude dále udržována funkční a obohacována o nové funkce.

Dále do obou verzí přibyla možnost spuštění vlastního příkazu.

### Popis grafického rozhraní

Rozhraní prvků v grafické verzi se aktuálně dá rozdělit do tří částí:

V první části se nachází aktuální nastavení hostitele, ke kterému se program připojuje, a také uživatelské jméno a heslo. Hostitel a uživatelské jméno mohou být přebrány z konfiguračního souboru `config.json`.

Ve druhé části se nachází tlačítka pro spouštění příkazů. Aktuálně se zde nachází 7 nastavitelných tlačítek a jedno tlačítko pro spuštění vlastního příkazu. Tyto tlačítka si z konfiguračního souboru `commands.txt` načítají svůj text a také příkaz, který spustí po kliknutí.

Ve třetí části se nachází výstup programu, například výstup příkazu nebo chybové hlášky programu.

### Budoucí změny ve grafickém rozhraní

Aktuálně je přesný počet tlačítek, v budoucnu budou tlačítka přesně podle toho, kolik příkazů bude nastaveno v souboru commands.txt + jedno tlačítko pro vlastní příkaz. Dále také bude grafické rozhraní asynchroní, kdy aktuálně celý program zamrzne až do vykonání příkazu.