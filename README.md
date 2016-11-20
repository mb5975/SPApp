# Knjižnica #


### Aplikacija omogoča:
* **Neregistriranemu uporabniku:**
  * Registracijo
  * Iskanje po bazi izdelkov
  * Vpogled v posamezne izdelke
* **Registriranemu uporabniku:**
  * Vpis
  * Iskanje po bazi izdelkov
  * Vpogled v posamezne izdelke
  * Izposojo izdelkov
  * Vpogled v statistiko izdelkov
  * Vpogled v svojo zgodovino izposoj
  * Predlaganje izdelka za izposojo
* **Administratorju**
  * Upravljanje z izdelki
  * Upravljanje z uporabniki

Glavni namen spletne aplikacije je **iskanje**, **rezervacija** in **izposoja** izdelkov (knjig, cdjev, ...). 
Poleg tega aplikacija omogoča vpogled v **statistiko** (največkrat izposojeni izdelki v zadnjem mesecu/letu, število izposoj ne mesec za tekoče leto, ...) 
ter **predlaganje novih izdelkov** za izposojo, ki jih trenutno še ni v knjižnici.

## CILJNA PUBLIKA IN NAPRAVE
Aplikacija je namenjena ljudem **vseh starosti**, ki si želijo izposoditi izdelke, ki jih nudimo v naši knjižnici. 
Ker je dizajn **prilagodljiv**, se aplikacija lepo obnaša na ekranih vseh naprav. Starejši lahko aplikacijo uporabljajo na računalnikih, mlajši pa kar na telefonu. 
Za dobro uporabniško izkušnjo sem uporabil tople barve in preprostost, poleg tega pa še dobro mero *javascripta*. 

## TEŽAVE V RAZLIČNIH BRSKALNIKIH
Prva opazna težava, na katero sem naletel je bila ta, da ko sem hotel imeti gumbe in vnosna polja na mobilnih napravah čez celo širino, je v *firefoxu* delalo vse pravilno, 
na *chromu* pa širina gumbov in vnosnih polj ni bila čisto čez vse *piksle*. To sem popravil s css atributom *box-sizing*, ki sem ga nastavil na *border-box*. 
To pomeni, da celotna širina elementa vsebuje tudi *padding* in *border*. Drug bolj opazen problem je bil ta, da ima vsak brskalnik svojo privzeto pisavo za 
vnosna polja. Ker sem hotel, da ima moja aplikacija na različnih brskalnikih enako pisavo na vnosnih poljih, sem moral posebej določiti pisavo, 
ki je povozila privzete nastavitve posameznih brskalnikov. Ostali manjši problemi so nastajali predvsem pri pisanju css datotek.

## ZMOGLJIVOSTI S POSEBNIM TRUDOM
Prva karakteristika se nahaja na naslovni strani in sicer zato, ker je naslovna stran prva stran, ki jo potencialni uporabniki vidijo in sem hotel, 
da bi pritegnila čim več uporabnikov. To je slika v ozadju. Veliko časa sem namenil temu, da slika ob premiku navzdol začne **bledeti** 
(na začetku počasi, potem pa vedno hitreje) in na koncu izgine iz ekrana. Poleg tega sem veliko dela vložil v **animacijo** elementov, ki se *zapeljejo* 
v ekran ob spremembi pozicije na strani. Druga karakteristika pa je **prilagodljiv dizajn**, kar povzroči dober izgled na ekranih vseh naprav.


## KOMENTAR:
V svojo aplikacijo bi, poleg fizičnih kopij knjig in cdjev, rad dodal še **e-knjige**, ki bi si jih uporabnik lahko tudi izposodil, za določeno obdobje 
in bi dobil dostop do njih na strežniku, tako da mu jih ne bi bilo treba fizično dvigniti v knjižnici. Poleg tega bi rad dodal še **opomnik** za bližanje
roka za vračanje izdelkov.
