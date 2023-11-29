Popis webové aplikace - BookLibraryAPI
======================================

## Popis
BookLibraryAPI je webová aplikace, která slouží k evidenci knih v knihovnì. Aplikace umožòuje pøidávat, upravovat a mazat knihy. 
Dále umožòuje vyhledávat knihy podle Id nebo vrátit všechny knihy. Aplikace je napojena na databázi, která obsahuje tabulku knih.

## Použité technologie
* ASP.NET8
* Entity Framework
* PostgreSql
* Swagger
* Docker
* Docker-compose
* MediatR
* AutoMapper
* FluentValidation
* Unit testy - xUnit - Jsou vytvoøeny testy pro všechny metody v BookControlleru. Je použita in-memory databáze, vèetnì seedování dat.

## Struktura projektu
Projekt je rozdìlen do nìkolika vrstev.
* BookLibraryAPI - Obsahuje kontrolery, které zpracovávají požadavky a volají metody z vrstvy Application. Mapuje DTO objekty na MediaTR objekty a naopak.
* BookLibraryAPI.AppLayer - Obsahuje metody, které zpracovávají požadavky a volají metody z vrstvy Domain, pro validaci bussiness logiky. Implementuje MediatR.
* BookLibraryAPI.Domain - Obsahuje základní entitu Book a rozhraní pro repository.
* BookLibraryAPI.Infrastructure - Obsahuje implementaci repository a DbContextu.
* BookLibraryAPI.Tests - Obsahuje unit testy pro BookController.
* BookLibrary.Contracts - Obsahuje DTO objekty, které se používají pro komunikaci ven a dovnitø aplikace.

## Spuštìní aplikace
Aplikace je možné spustit pomocí docker-compose. V rootu projektu je soubor docker-compose.yml, který obsahuje nastavení pro spuštìní aplikace.
Pro spuštìní aplikace je potøeba mít nainstalovaný docker a docker-compose. Po spuštìní pøíkazu `docker-compose up --build` se sestaví a spustí aplikace na portu 8080.
Aplikace je dostupná na adrese http://localhost:8080/swagger/index.html

## Co mohlo být vylepšeno
* Logování - Pro logování by bylo vhodné použít nìjaký logging framework, napø. Serilog.
* Autentizace - Pro autentizaci by bylo vhodné použít nìjaký framework.