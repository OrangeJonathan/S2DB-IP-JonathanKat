# S2DB - Jonathan Kat - Individueel
Ik ben Jonathan Kat en dit is zijn alle projecten waar ik individueel aan heb gewerkt tijdens mijn 2e Semester.\
Ik ben 17 jaar oud en ik ben geboren in Groningen, toen ik 1 jaar oud was verhuisde ik naar een dorpje genaamd Haaften.

## Semester 2 Portfolio
Dit is mijn portfolio met alles wat ik heb gedaan in het 2e Semester van de HBO-ICT opleiding op Fontys.
Uitleg van deze verschilende projecten kunt u verder lezen in op deze links

- [GameCollectibles](./GameCollectibles)
- [Circustrein](./Circusopdracht)
- [Visitor Placement Tool](./VisitorPlacementTool)
- [Demo's](./Demo's)

## Iteratie 3
### LU3

- [ERD](/GameCollectibles/Documentatie/ERDGameCollectibles.png)
- [Conceptueel Model](/GameCollectibles/Documentatie/ConceptueelModel.png)
- [Context Diagram](/GameCollectibles/Documentatie/ContextDiagram.png)

### LU4

In deze iteratie heb ik gewerkt aan het ombouwen naar het 3 lagen structuur
Ik heb eerst een Oefening / Demo gemaakt om te oefenen hoe het moet
- [De Demo](./Demo's/MultilayerArchitecture)

Daarna heb ik het toegepast aan mijn eigen project.
- [Presentatie](./GameCollectibles/GameCollectibleApp/Controllers/GamesController.cs)
- [Core](./GameCollectibles/GameCollectiblesCore/Games/GameService.cs)
    - [interface](/GameCollectibles/GameCollectiblesCore/IGameRepository.cs)
- [Data](./GameCollectibles/GameCollectiblesData/Games/GameRepository.cs)

### LU5
Ik heb een begin gemaakt aan de visitor placement tool. Hierin is (nog) niet zo veel gebeurd

- [Visitor Placement Tool](./VisitorPlacementTool)

### LU6
In deze iteratie heb ik alle CRUD onderdelen afgemaakt.
Ik heb:
- Create
- Read
- Update
- Delete

Deze kan je vinden in:
- [Repository](/GameCollectibles/GameCollectiblesData/Games/GameRepository.cs)

### LU7

Voor LU7 kan ik aantonen dat ik, ten eerste git gebruik, zoals je kan zien, maar ik ook UnitTests hebt gebruikt:

- [UnitTests Circustrein](./Circusopdracht/CircustreinUnitTest)

## Iteratie 4

### LU3

- [Testplan](https://git.fhict.nl/I510031/s2db-jonathan-kat-individueel/-/blob/main/GameCollectibles/Documentatie/Testplan.png)
- [UI Schets](https://git.fhict.nl/I510031/s2db-jonathan-kat-individueel/-/blob/main/GameCollectibles/Documentatie/UISchets.png)

### LU4

- De UserSwitch:
    - In plaats van een Login systeem heb ik een 'UserSwitch' waardoor je makkelijk van user kan veranderen.
    - (ik weet niet 100% zeker bij welke LU dit hoort maar ik denk 4)

### LU7

- [Validatie voor Delete Game en Edit Game](https://git.fhict.nl/I510031/s2db-jonathan-kat-individueel/-/blob/main/GameCollectibles/GameCollectiblesCore/Games/GameService.cs)

## Iteratie 5

### LU3

- [UseCases](https://git.fhict.nl/I510031/s2db-jonathan-kat-individueel/-/blob/main/GameCollectibles/Documentatie/UseCases.png)
- [Testplan](https://git.fhict.nl/I510031/s2db-jonathan-kat-individueel/-/blob/main/GameCollectibles/Documentatie/Testplan.png)
- [Architecture Diagram](https://git.fhict.nl/I510031/s2db-jonathan-kat-individueel/-/blob/main/GameCollectibles/Documentatie/ArchitectureDiagram.png)
- [Domain Model / Class Diagram](https://git.fhict.nl/I510031/s2db-jonathan-kat-individueel/-/blob/main/GameCollectibles/Documentatie/DomainModel.png)
- [Deze documentatie vind je allemaal in 1 document](https://git.fhict.nl/I510031/s2db-jonathan-kat-individueel/-/blob/main/GameCollectibles/README.md)


### LU6

- [INNER JOIN](https://git.fhict.nl/I510031/s2db-jonathan-kat-individueel/-/blob/main/GameCollectibles/GameCollectiblesData/Categories/CategoryRepository.cs) (line 87)


### LU7 

- [UnitTests voor de gameService](https://git.fhict.nl/I510031/s2db-jonathan-kat-individueel/-/tree/main/GameCollectibles/xUnitTestGameCollectibles)
- [Validatie GameService](https://git.fhict.nl/I510031/s2db-jonathan-kat-individueel/-/blob/main/GameCollectibles/GameCollectiblesCore/Games/GameService.cs)
- [User_Collectibles are Added and Deleted from database](https://git.fhict.nl/I510031/s2db-jonathan-kat-individueel/-/blob/main/GameCollectibles/GameCollectiblesCore/Collectibles/CollectibleService.cs) (line 36)
- [Exception Handling in de Controller](https://git.fhict.nl/I510031/s2db-jonathan-kat-individueel/-/blob/main/GameCollectibles/GameCollectibleApp/Controllers/GamesController.cs)

## Finale Sprint

### LU4

- Encapsulation van Models
    - [Game](https://git.fhict.nl/I510031/s2db-jonathan-kat-individueel/-/blob/main/GameCollectibles/GameCollectiblesCore/Games/Game.cs)
    - [Category](https://git.fhict.nl/I510031/s2db-jonathan-kat-individueel/-/blob/main/GameCollectibles/GameCollectiblesCore/Categories/Category.cs)
    - [Collectible](https://git.fhict.nl/I510031/s2db-jonathan-kat-individueel/-/blob/main/GameCollectibles/GameCollectiblesCore/Collectibles/Collectible.cs)

### LU5

- [Verder gegaan met VisitorPlacementTool](./VisitorPlacementTool)
