###CompetitionTracker

**CompetitionTracker** to aplikacja do zapisywania wyników zawodów wspinaczkowych. Jej głównym zadaniem jest tworzenie rankingu opartego na wpisach dotyczących tras, jakie ukończył dany uczestnik w zawodach.
Wpisem w tym przypadku jest nazwisko zawodnika oraz nazwa ukończonej drogi. Na podstawie typu trasy system dolicza punkty danemu uczestnikowi oraz ustala jego pozycję w rankingu.

**Ranking** tworzą uczestnicy, którzy wzięli udział w zawodach przynajmniej raz i zdobyli w nich jakiekolwiek punkty. Tworzony jest na podstawie posortowanej malejąco łącznej sumy punktów zawodników. Możliwa jest także dyskwalifikacja zawodnika poprzez usunięcie jego wpisu z rankingu. 

**Dane** (lista dróg, lista uczestników, aktualny ranking) trzymane są w pamięci i działają tylko w obrębie jednego uruchomienia.

**CompetitionTracker umożliwia**: dodawanie, edycję, usuwanie i pobieranie listy uczestników i tras oraz dodawanie i usuwanie wpisów z rankingu. 

**Technologie** użyte przy implementacji aplikacji:
* Klient: Angular 5 (TypeScript),
* Serwer: C# (Web API).

Aktualnie aplikacja spełnia podstawowe funkcjonalności, zaś pozostałe są cały czas aktualizowane. 