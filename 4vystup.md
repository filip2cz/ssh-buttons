<!-- 

Pokud nemáte program na otevření tohoto souboru v čitelném formátu, použijte následující odkaz:
https://github.com/filip2cz/ssh-buttons/blob/4vystup/4vystup.md

-->

# SSH-Buttons - Třetí výstup
Filip Komárek, 4.C  
11. února 2024

Repozitář s kódem relevantnímu k tomuto výstupu: [https://github.com/filip2cz/ssh-buttons/tree/4vystup](https://github.com/filip2cz/ssh-buttons/tree/4vystup)

Spustitelné soubory releventní k tomuto výstupu: [https://github.com/filip2cz/ssh-buttons/releases/tag/v0.5](https://github.com/filip2cz/ssh-buttons/releases/tag/v0.5) (soubory ssh-buttons-console.zip a ssh-buttons-desktop.zip)

Tato verze je převážně úprava grafického rozhraní, provedl jsem spoustu větších i menších změn.

## Dynamická tlačítka
Počet tlačítek se odvíjí podle toho, kolik je nastaveno tlačítek v souboru `commands.txt``. Pokud je tedy nastaveno 8 příkazů (16 řádků), bude zde přesně 8 tlačítek + jedno tlačítko pro zadání vlastního příkazu. Kvůli dynamickému generování tlačítek bylo tlačítko pro vlastní příkaz přesunuto vedle výstupu z konzole.

## Lepší konzole
Konzole má nyní font Consolas, který je používán v konzolích v systému Windows. Je tímto dosažena větší designová jednota se systémem a uživatel lépe pochopí, o co se jedná. Dále bylo umožněno uživateli kopírovat text z výstupu konzole. Z výstupu také zmizel text `Output:`, jenž mohl být uživatelem zaměněn s opravdovým výstupem příkazu.

## Responzivita tlačítek
Grid s tlačítky je plně responzivní a přizpůsobuje se velikosti okna. Na základě velikosti okna se mění rozměry tlačítek a také, kolik tlačítek je na jednom řádku. Pro případ, že by bylo větší množství řádků, než je možné zobrazit, přibyla také možnost skrolovat v této části okna.

## Velikost nadpisů v konfigurační části programu
Poslední grafickou změnou je velikost nadpisů v konfigurační části programu, které jsou menší, díky čemuž vypadají lépe a jsou kompaktnější.

## Další problémy k řešení
Pracuji dále na asynchroním Ssh.cs, aby se nemusel program kvůli každému příkazu připojovat zvlášť.

Dále také pracuji tom, že některé příkazy (například sudo) mohou vyžadovat další input od uživatele, takže by bylo vhodné, aby ho uživatel mohl dodat v průběhu příkazu.