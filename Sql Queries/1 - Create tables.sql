CREATE TABLE Team
(
	Id int PRIMARY KEY Identity(1, 1) not null,
	Name nvarchar(200),
	Colour nvarchar(100),
	Code nvarchar(10)
)

CREATE TABLE Game
(
	Id int PRIMARY KEY Identity(1, 1) not null,
	TeamAId FOREIGN KEY References Team(Id),
	TeamBId FOREIGN KEY References Team(Id),
	StartedAt DateTime,
	EndedAt DateTime
)

CREATE TABLE Set
(
	Id int PRIMARY KEY Identity(1, 1) not null,
	GameId int FOREIGN KEY References Game(Id),
	TeamAScore int,
	TeamBScore int,
	SetNumber int,
	StartedAt DateTime,
	EndedAt DateTime
)
