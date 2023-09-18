## Spuštění hry

Hru spustíte otevřením programu `AaduPuliAattam.exe` ve složce `AaduPuliAattam/bin/Debug/net6.0-windows/`. 

## Menu

V hlavním menu si můžete zvolit tři herní plány:

- Simple - 10 políček
- Intermediate - 23 políček
- Advanced - 29 políček

Dále je možné si zvolit hru proti jinému proti hráči nebo proti počítači (lze si vybrat, jestli bude počítač hrát za jehňátka, nebo za tygry).

V menu se taky dá navolit, kolik jehňátek bude ve hře, a kolik jich musí tygři zajmout, aby vyhráli. Výchozí možnost počtu jehňátek je doporučená, ale hráč si může navolit libovolnou kombinaci, kterou logika hry dovoluje (například nemůže být víc jehňátek + tygrů, než je velikost herní plochy).

## Pravidla

Aadu Puli Aatam, neboli Jehňátka a tygři, je indická strategická hra pro dva hráče. Jeden z hráčů hraje za jehňátka (symbolizována bílými čtverečky), druhý za tygry (symbolizováni oranžovými čtverečky). Cílem hráče ovládajícího jehňátka je zablokovat tygrům pohyb na herní ploše. Cílem hráče ovládajícího tygry je zajmout dostatečný počet jehňátek.

Před začátkem hry jsou na vrchní tři vrcholy herní plochy umístěni tři tygři. Poté se hráči střídají ve hře, začíná hráč s jehňátky. Ve svém tahu hráč s jehňátky umístí jedno jehňátko na prázdné políčko na herní ploše (kliknutím na příslušné políčko). Pokud už hráč umístil všechna svá jehňátka, místo umisťování nových může hýbat s těmi, která už na herní ploše jsou (kliknutím na jedno z jehňátek a poté na jedno z jeho sousedních prázdných políček). (Toto není možné, dokud nejsou všechna jehňátka na herní ploše.)

Hráč ovládající tygry musí v každém tahu pohnout jedním ze tří tygrů na herní ploše (kliknutím na příslušného tygra a poté na políčko, kam se má tygr pohnout). Tygři se mohou hýbat buď na sousední volné políčko, nebo přeskočit sousední políčko s jehňátkem (čímž toto jehňátko zajmou), a skončit na sousedním políčku "ob jedna".

Který hráč je zrovna na tahu, je naznačeno žlutým podbarvením obrázku jehňátka nebo tygra v záhlaví hry.

Jehňátka vyhrávají, pokud tygři nemají žádné políčko, kam by se mohli pohnout, tygři vítězí v případě, že zajmou dost jehňátek, nebo jehňátka nemají žádné políčko, kam se pohnout.