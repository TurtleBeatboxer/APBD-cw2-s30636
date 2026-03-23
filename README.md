# Uczelniana Wypożyczalnia Sprzętu (University Equipment Rental)

## Opis Projektu
Aplikacja konsolowa w języku C# symulująca system wypożyczalni sprzętu na uczelni. System pozwala na zarządzanie użytkownikami (Studenci, Pracownicy), sprzętem (Laptopy, Kamery, Projektory) oraz obsługuje pełen cykl wypożyczeń, w tym limity aktywnych wypożyczeń i kary za opóźnienia.

## Architektura i Decyzje Projektowe
Aplikacja została zaprojektowana z wykorzystaniem podziału na warstwy, aby oddzielić logikę biznesową od interfejsu użytkownika (konsoli) oraz od sposobu przechowywania danych. 

Zastosowany podział klas i katalogów:
* **Entities (Model Domenowy)**: Klasy takie jak `Device`, `User`, `Rental` oraz ich specjalizacje (np. `Student`, `Laptop`). Zawierają podstawowy stan i proste zachowania. Użyto dziedziczenia, aby wydzielić wspólne cechy sprzętu i użytkowników.
* **Repositories (Repozytoria)**: Klasy `DeviceRepository`, `RentalRepository`, `UserRepository` odpowiadają wyłącznie za przechowywanie danych (w tym przypadku w pamięci przy użyciu kolekcji) oraz dostęp do nich.
* **Services (Serwisy)**: Klasy `DeviceService`, `RentalService`, `UserService` centralizują logikę biznesową. To tutaj sprawdzane są limity wypożyczeń, naliczane kary za opóźnienia i generowane raporty. Dzięki temu `Program.cs` nie zawiera logiki, a jedynie wywołuje odpowiednie metody.
* **DTOs**: Służą do bezpiecznego przekazywania danych wejściowych z poziomu UI (konsoli) do serwisów, oddzielając wejście użytkownika od wewnętrznego modelu bazy danych.
