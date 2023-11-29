Popis webov� aplikace - BookLibraryAPI
======================================

## Popis
BookLibraryAPI je webov� aplikace, kter� slou�� k evidenci knih v knihovn�. Aplikace umo��uje p�id�vat, upravovat a mazat knihy. 
D�le umo��uje vyhled�vat knihy podle Id nebo vr�tit v�echny knihy. Aplikace je napojena na datab�zi, kter� obsahuje tabulku knih.

## Pou�it� technologie
* ASP.NET8
* Entity Framework
* PostgreSql
* Swagger
* Docker
* Docker-compose
* MediatR
* AutoMapper
* FluentValidation
* Unit testy - xUnit - Jsou vytvo�eny testy pro v�echny metody v BookControlleru. Je pou�ita in-memory datab�ze, v�etn� seedov�n� dat.

## Struktura projektu
Projekt je rozd�len do n�kolika vrstev.
* BookLibraryAPI - Obsahuje kontrolery, kter� zpracov�vaj� po�adavky a volaj� metody z vrstvy Application. Mapuje DTO objekty na MediaTR objekty a naopak.
* BookLibraryAPI.AppLayer - Obsahuje metody, kter� zpracov�vaj� po�adavky a volaj� metody z vrstvy Domain, pro validaci bussiness logiky. Implementuje MediatR.
* BookLibraryAPI.Domain - Obsahuje z�kladn� entitu Book a rozhran� pro repository.
* BookLibraryAPI.Infrastructure - Obsahuje implementaci repository a DbContextu.
* BookLibraryAPI.Tests - Obsahuje unit testy pro BookController.
* BookLibrary.Contracts - Obsahuje DTO objekty, kter� se pou��vaj� pro komunikaci ven a dovnit� aplikace.

## Spu�t�n� aplikace
Aplikace je mo�n� spustit pomoc� docker-compose. V rootu projektu je soubor docker-compose.yml, kter� obsahuje nastaven� pro spu�t�n� aplikace.
Pro spu�t�n� aplikace je pot�eba m�t nainstalovan� docker a docker-compose. Po spu�t�n� p��kazu `docker-compose up --build` se sestav� a spust� aplikace na portu 8080.
Aplikace je dostupn� na adrese http://localhost:8080/swagger/index.html

## Co mohlo b�t vylep�eno
* Logov�n� - Pro logov�n� by bylo vhodn� pou��t n�jak� logging framework, nap�. Serilog.
* Autentizace - Pro autentizaci by bylo vhodn� pou��t n�jak� framework.