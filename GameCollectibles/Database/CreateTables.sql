use GameCollectibles;

DROP TABLE [User];
DROP TABLE Game;
DROP TABLE CollectibleList;
DROP TABLE Collectible;
DROP TABLE User_Collectible;


CREATE TABLE [User] (
	ID int PRIMARY KEY IDENTITY(1,1),
	UserName nvarchar(255) UNIQUE NOT NULL
);

CREATE TABLE Game (
	ID int PRIMARY KEY IDENTITY(1,1),
	Title nvarchar(255) NOT NULL,
	[Description] text,
);

CREATE TABLE Collectible (
	ID int PRIMARY KEY IDENTITY(1,1),
	[Name] nvarchar(255) NOT NULL,
	[Description] text,
);

CREATE TABLE CollectibleList (
	CollectibleID int NOT NULL,
	GameID int NOT NULL,
	[Name] nvarchar(255) NOT NULL,
	[Description] text,
	FOREIGN KEY (CollectibleID) REFERENCES Collectible(ID),
	FOREIGN KEY (GameID) REFERENCES Game(ID)
);



CREATE TABLE User_Collectibles (
	UserID int,
	CollectibleID int,
	Collected bit DEFAULT 0 NOT NULL,
	FOREIGN KEY (UserID) REFERENCES [User](ID),
	FOREIGN KEY (CollectibleID) REFERENCES Collectible(ID)
);

