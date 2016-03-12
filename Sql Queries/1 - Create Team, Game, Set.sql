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
	TeamAId int FOREIGN KEY References Team(Id),
	TeamBId int FOREIGN KEY References Team(Id),
	StartedAt DateTime,
	EndedAt DateTime
)

CREATE TABLE GameSet
(
	Id int PRIMARY KEY Identity(1, 1) not null,
	GameId int FOREIGN KEY References Game(Id),
	TeamAScore int,
	TeamBScore int,
	SetNumber int,
	StartedAt DateTime,
	EndedAt DateTime
)

CREATE TABLE Player
(
	Id int PRIMARY KEY Identity(1, 1) not null,
	FirstName nvarchar(100),
	LastName nvarchar(100),
	RegistrationNumber int
)

CREATE TABLE TeamPlayer
(
	Id int PRIMARY KEY Identity(1, 1) not null,
	TeamId int FOREIGN KEY References Team(Id),
	PlayerId int FOREIGN KEY References Player(Id),
	ActiveFrom datetime,
	ActiveTo datetime
)

CREATE TABLE GamePlayer
(
	Id int PRIMARY KEY Identity(1, 1) not null,
	GameId int FOREIGN KEY References Game(Id),
	PlayerId int FOREIGN KEY References Player(Id),
	ShirtNumber int
)