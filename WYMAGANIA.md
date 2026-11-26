# Wymagania i plan odbioru

**Cel.** Ułatwić nowym studentom znalezienie recepcji, biblioteki i laboratoriów. Projekt obejmuje mapę przykładowego kampusu i opisy budynków w wersji na Windows.

**Zadanie.** Dodać wybór budynku z mapy i z listy. Kryterium odbioru jest spełnione, gdy każdy z trzech budynków ma własną nazwę, lokalizację i opis, a po zmianie wyboru mapa i lista wskazują ten sam budynek. Sprawdzić scenę po imporcie i powtórzyć próbę w buildzie.

**Role.** Koordynacja i integracja obejmują ustalenie wersji Unity oraz scalenie zmian. Implementacja obejmuje scenę i interfejs. Niezależny odbiór obejmuje odtworzenie projektu z repozytorium i sprawdzenie zadania według README.

**Decyzja o migracji.** Do wydania zostały trzy dni, więc koordynator utrzymuje Unity 2022.3.5f1. Po wydaniu właściciel integracji sprawdzi nowszy Edytor na gałęzi `test/editor-upgrade` w osobnej kopii. Warunki przyjęcia zmiany to import pakietów, działanie trzech punktów, udany build Windows i przegląd zmian. Jeśli próba się nie powiedzie, zespół otworzy osobną kopię z `main` w 2022.3.5f1.
