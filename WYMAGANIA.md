# Wymagania i plan odbioru

## Problem i zakres

Nowi studenci potrzebują jednego widoku, na którym szybko znajdą recepcję, bibliotekę i laboratoria. Demonstrator przedstawia fikcyjny układ kampusu na komputerze z systemem Windows. Dane są przykładowe i działają offline.

## Zadanie i kryteria odbioru

Zadanie „Wybór budynku na mapie” obejmuje trzy oznaczone punkty i panel informacyjny. Po uruchomieniu scena zachęca do wyboru punktu. Każdy punkt można wybrać na mapie lub z listy. Po wyborze panel pokazuje nazwę, opis i lokalizację tego punktu, a poprzedni wybór przestaje być zaznaczony. Odbiór obejmuje otwarcie sceny po ponownym imporcie, przejście przez trzy punkty i uruchomienie buildu Windows.

## Proponowany podział ról

- Koordynacja i integracja – ustalenie wersji Edytora, zakresu oraz przegląd i scalenie zmian.
- Implementacja – scena, mapa, panel informacyjny i powiązane pliki .meta.
- Odbiór – niezależne odtworzenie projektu z repozytorium i sprawdzenie kryteriów w buildzie.

## Decyzja o migracji

W sytuacji z ćwiczenia 3 do wydania zostały trzy dni. Koordynator utrzymuje Unity 2022.3.5f1 na main do wydania. Po wydaniu właściciel integracji zakłada gałąź test/editor-upgrade i otwiera osobną kopię źródeł w wymaganej wersji. Akceptacja wymaga pomyślnego importu pakietów, przejścia testu wszystkich trzech punktów, udanego buildu Windows i przeglądu zmian plików projektu. W razie niepowodzenia zespół wraca do osobnej kopii z niezmienionego commitu main i otwiera ją w 2022.3.5f1.
