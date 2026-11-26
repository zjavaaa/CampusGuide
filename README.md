# Przewodnik po kampusie

Projekt laboratoryjny WSB Merito. Lokalna kopia robocza znajduje się w katalogu Projekt-final.

Demonstrator na PC pomaga nowym studentom znaleźć podstawowe punkty kampusu. Użytkownik wybiera budynek na mapie lub z listy i odczytuje opis jego przeznaczenia. Lokalizacje są fikcyjne. [Wymagania, role i decyzja o migracji](WYMAGANIA.md).

## Środowisko

- Unity Editor 2022.3.5f1 LTS, szablon 3D (Built-In Render Pipeline).
- Cel: Windows x86-64, standardowe wsparcie kompilacji Windows z backendem Mono.
- Git śledzi Assets razem z plikami .meta, Packages (manifest i lock) oraz ProjectSettings. Library, Temp, Logs, UserSettings i Builds powstają lokalnie.
- Serializacja Force Text i widoczne pliki .meta zachowują czytelną historię scen i identyfikatory zasobów.

## Uruchomienie

1. Sklonuj repozytorium lub pobierz jego lokalną kopię. W Unity Hub wybierz **Projects → Add → Add project from disk** i wskaż katalog zawierający Assets, Packages i ProjectSettings.
2. Otwórz projekt w Unity 2022.3.5f1 i poczekaj na import. Otwórz **Assets/Scenes/CampusGuide.unity** i naciśnij **Play**.
3. Sprawdź widok początkowy, wybierz kolejno Recepcję, Bibliotekę i Laboratoria. Każdy punkt ma pokazać własny opis i lokalizację. Zmiana wyboru ma podświetlić ten sam budynek na mapie i liście.
4. W **File → Build Settings** wybierz **PC, Mac & Linux Standalone**, docelowy system Windows i architekturę x86-64. Scena CampusGuide jest już na liście. Zbuduj do katalogu **Builds/Windows**, następnie uruchom **CampusGuide.exe** i powtórz krok 3.

## Historia pracy

Wykonaj `git log --oneline --graph --all`, żeby zobaczyć gałąź wymagań, jej scalenie oraz commity projektu Unity.
