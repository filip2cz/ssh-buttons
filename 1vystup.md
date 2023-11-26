# SSH-Buttons - Prvn� v�stup
Filip Kom�rek, 4.C  
26. listopadu 2023

Repozit�� s k�dem relevantn�mu k tomuto v�stupu: [https://github.com/filip2cz/ssh-buttons/tree/1vystup](https://github.com/filip2cz/ssh-buttons/tree/1vystup)

Spustiteln� soubor releventn� k tomuto v�stupu: [https://github.com/filip2cz/ssh-buttons/releases/tag/v0.1](https://github.com/filip2cz/ssh-buttons/releases/tag/v0.1) (soubor [ssh-buttons.zip](https://github.com/filip2cz/ssh-buttons/releases/download/v0.1/ssh-buttons.zip))

V r�mci prvn�ho v�stupu jsem vypracoval konzolovou aplikaci, kter� je prototypem budouc� grafick� aplikace ve WPF.
V r�mci tohoto k�du jsou hlavn� 3 soubory: Program.cs, Config.cs a Ssh.cs.

Program.cs obsahuje k�d specifick� pro tuto testovac� verzi,
zat�m co Config.cs a Ssh.cs jsou univerz�ln� a budouc� grafick� verze aplikace je zd�n�.

Pomoc� Config.cs si program na�te nastaven� z konfigura�n�ho souboru config.json. Aktu�ln� jde ov�em o po�ad� prvk� v konfigura�n�m souboru,
a ne o jejich n�zev, co� jde proti filozofii JSON form�tu a je t�eba na tom je�t� zapracovat.

Pomoc� Ssh.cs se program p�ipoj� k SSH serveru na adrese, kterou mu hlavn� ��st programu (Program.cs) p�ed� a po t� vykon� p��kaz, jen�
mu tato hlavn� ��st programu p�ed� ve stejn� moment. Po dokon�en� p��kazu se odpoj�. Zat�m se mi bohu�el nepoda�ilo zprost�edkovat
vstup pro u�ivatele v p��pad�, �e bude p��kaz vy�adovat heslo (nap�. pro sudo opr�vn�n�). V r�mci tohoto vznikla alternativn� funkce
Ssh.cs, jen� prozat�m nen� sou��st� hlavn�ho k�du a je mo�n� ji naj�t v branchi [ssh-async](https://github.com/filip2cz/ssh-buttons/blob/ssh-async/Ssh.cs) v repozit��i.

Program.cs obsahuje z�kladn� termin�lov� rozhran� pro ovl�d�n� t�to testovac� verze, jej� sou��st� je to �e vyp�e tolik mo�nost�,
kolik mu �ekne v�stup z funkce Config.cs, neboli teoreticky nekone�n� mnoho, omezeno v�konem po��ta�e.