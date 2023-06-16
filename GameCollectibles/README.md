<script src="https://cdn.jsdelivr.net/npm/mermaid@8.14.0/dist/mermaid.min.js"></script>

# Description
De Collectible Tracker App is een webgebaseerde toepassing ontworpen om gamers te helpen bijhouden van hun verzamelobjecten in verschillende spellen. Of het nu gaat om insecten in Animal Crossing, Pokemon in Pokemon, of prestaties in Stardew Valley, deze app stelt gebruikers in staat om hun voortgang gemakkelijk bij te houden en te monitoren.

# Analyse

## Requirements
De volgorde van de requirements is gelijk de prioriteit van de requirements.
![Requirements](https://git.fhict.nl/I510031/s2db-jonathan-kat-individueel/-/raw/main/GameCollectibles/Documentatie/Requirements.png)

## UseCases
Usecases helpen bij het begrijpen van de interactie tussen de gebruikers en het systeem, het helpt ook bij de verschillende stappen en scenario's die zich kunnen voordoen.

### UC-01
![UC-01](https://git.fhict.nl/I510031/s2db-jonathan-kat-individueel/-/raw/main/GameCollectibles/Documentatie/UC01.png)

### UC-02
![UC-02](https://git.fhict.nl/I510031/s2db-jonathan-kat-individueel/-/raw/main/GameCollectibles/Documentatie/UC02.png)

### UC-03
![UC-03](https://git.fhict.nl/I510031/s2db-jonathan-kat-individueel/-/raw/main/GameCollectibles/Documentatie/UC-03.png)

### UC-04
![UC-04](https://git.fhict.nl/I510031/s2db-jonathan-kat-individueel/-/raw/main/GameCollectibles/Documentatie/UC-04.png)


## Testplan & Testmatrix
Een Testplan kan je helpen om testen te plannen. Door test cases te relateren aan use cases worden enerzijds voorbeelden gegeven van waar het systeem precies mee moet kunnen werken. Anderzijds beschrijft dit ook hoe het systeem reageert wanneer de gegevens onjuist zijn (de uitzonderingen). Aangezien het gebruik van het systeem al gemodelleerd is in de use cases, zullen test cases altijd aan use cases gekoppeld worden.

![TestPlan](https://git.fhict.nl/I510031/s2db-jonathan-kat-individueel/-/raw/main/GameCollectibles/Documentatie/Testplan.png)

De Testmatrix wordt gebruikt om aan te tonen welke requirements de testcases testen

![TestMatrix](https://git.fhict.nl/I510031/s2db-jonathan-kat-individueel/-/raw/main/GameCollectibles/Documentatie/TestMatrix.png)

## Context Diagram
Een context diagram wordt gebruikt om aantegeven met weke externe entiteiten je programma mee interacteerd

![Context Diagram](https://git.fhict.nl/I510031/s2db-jonathan-kat-individueel/-/raw/main/GameCollectibles/Documentatie/ContextDiagram.png)

## Conceptueel model
Een conceptueel model wordt gebruikt om een duidelijk plaatje te brengen voor de klant hoe de database eruit kan gaan zien.

![Conceptueel model](https://git.fhict.nl/I510031/s2db-jonathan-kat-individueel/-/raw/main/GameCollectibles/Documentatie/ConceptueelModel.png)

# Ontwerp

## Architecture
Ik gebruik een drie laagse architecture. Dit splitst het project op in 3 lagen. 
- Presentatie laag
    - Dit is de laag waar de data wordt laten zien.
- Business / Logic laag
    - Deze laag zorgt er voor dat de opgehaalde data verwerkt
- Data Access laag
    - Deze laag wordt gebruikt als een connectie tussen de database.

Een van de voordelen van deze architectuur is dat de code wordt georganiseerd, dus de code wordt overzichtelijker

Door middel van interfaces is het mogelijk om de Logic laag onafhankelijk te hebben van de andere 2 lagen.\
Dit is zodat je andere repositories kan gebruiken als om een of andere reden je degene die je nu gebruikt niet meer kan gebruiken (bijvoorbeeld bij het UnitTesten van het programma)

![Architecture](https://git.fhict.nl/I510031/s2db-jonathan-kat-individueel/-/raw/main/GameCollectibles/Documentatie/ArchitectureDiagram.png)

## Domain Model / Class Diagram
Dit is mijn Domeinmodel van de Business / Logic layer.
Voor iedere klasse wordt de naam evenals de attributen en methoden weergegeven.

![DomeinModel](https://git.fhict.nl/I510031/s2db-jonathan-kat-individueel/-/raw/main/GameCollectibles/Documentatie/DomainModel.png)

## ERD
Voor de Database heb ik 5 Tables.
Begint bij de User Table waarbij ik de userID en userName in opsla.\
Daarnaast heb ik ook een Games Table waarbij de verschillende games worden opgeslagen.\
Ik heb een Category Table om de verschillende categories op te slaan in de Database\
Ik heb ook een Collectibles Table om te laten zien welke collectibles er in welke list staan.\
Als laatst heb ik de USER_COLLECTIBLES table om te kunnen zien of de collectible daartwerkelijk is gecollect.

![ERD](https://git.fhict.nl/I510031/s2db-jonathan-kat-individueel/-/raw/main/GameCollectibles/Documentatie/ERDGameCollectibles.png)



