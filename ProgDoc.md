## Winforms

Hra se skládá ze dvou Winforms formulářů - z Menu, ve kterém si uživatel navolí, jakou hru chce hrát, a z Game Form, hlavního herního formuláře.

## Menu

V hlavním menu má uživatel možnost vybrat si herní plán (na výběr jsou 3 typy), proti komu chce hrát, celkový počet jehňátek a počet sebraných jehňátek nutný k vítězství tygrů. Navíc je ošetřeno, aby se nedalo navolit více jehňátek, než se vejde na herní plochu, a aby tygři nemuseli sebrat víc jehňátek, než je celkový počet.

## Načtení herního plánu

Herní plán se načítá ze souboru. Důvodem pro to bylo, že je možné hru rozšířit tak, aby si hráč mohl případně vytvořit vlastní herní plochu a následně si ji i uložit.

Formát vstupu je následující:

1.řádek: počet vrcholů = n
2.řádek: indexy tří vrcholů, na kterých jsou na začátku hry umístěni tygři
3.- (n+3). řádek: pozice jednotlivých vrcholů (dvě čísla v intervalu od 0 do 100)
ostatní řádky: indexy vrcholů ležících na jedné přímce (co řádek to přímka)

Pozn.: Validita vstupu není v kódu (až na triviality jako správný počet tygrů apod.) ošetřována. (Například jestli pozice vrcholů na jedné přímce opravdu odpovídají jedné přímce.) Uživatel momentálně nemá možnost přidávat si vlastní herní plochy, a kdyby tato funkcionalita byla později přidána, ukládaly by se herní plochy do souboru přímo z programu samotného.

## Formát herního plánu

Herní plán je uložený jako instance třídy Graph. Ta si kromě pozic vrcholů a seznamu hran ukládá pro každý vrchol ještě informaci jestli je momentálně vybraný (v situaci, kdy hráč vybírá, kterou postavou pohnout) a seznamy sousedů a sousedů "ob jedno" (aby tygr věděl, kam může přeskakovat). Navíc je ve třídě Graph ještě dvojitý slovník držící si pro dvojice vrcholů "ob jedno", který vrchol je mezi nimi. 

## Hra

Abstraktní třída Game má 3 abstraktní metody: `CheckForWin()`, `HandleButtonClick(int i)` a `GetStatus()`. Poslední zmíněná metoda se využívá k vypisování stavu hry ve formuláři, aniž by musel zasahovat do vnitřních proměnných hry.

Podle toho, jestli chce uživatel hrát proti člověku, nebo počítači, je zvolena buď HumanGame, nebo AIGame. HumanGame rozlišuje hráče podle toho, jestli hrají za Jehňátka, nebo za Tygry, kdežto pro AIGame je výhodnější rozlišovat podle toho, jestli je hráč člověk, nebo počítač. 

## ILamb a ITiger

eee

## AI Player

Umělý hráč je implementovaný pomocí MinMax algoritmu, který se ve hrách dvou hráčů běžně používá. (Jehňátka se snaží skóre maximalizovat, tygři minimalizovat.) Při dosažení maximální hloubky MinMaxu používá umělý hráč heuristické ohodnocení hrací plochy, které závisí pouze na počtu zajatých jehňátek.

Umělý hráč implementuje zároveň rozhraní Jehňátka i Tygra, protože v MinMaxu potřebuje umět hrát jako oba tito hráči. 

Zajímavostí je, že umělý hráč je "líný" - pokud má víc ekvivalentních možností, jak zajmout jehňátko, počká si, až zbyde jen jedna z nich, a až pak tah provede.