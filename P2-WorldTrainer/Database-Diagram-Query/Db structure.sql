create table Users(
 Id int Primary Key not null Identity(1,1),
 FirstName Varchar(50) not null,
 LastName varchar(50) not null,
 Email varchar(70) not null,
 Password varchar(70) not null
)

create table Trainers(
 Id int Primary Key not null Identity(1,1),
 FirstName Varchar(50) not null,
 LastName varchar(50) not null,
 Email varchar(70) not null,
 Password varchar(70) not null
)

create table Skills(
 Id int Primary Key not null Identity(1,1),
	Name varchar(50) not null
)

create table TrainerDetails(
 Id int Primary Key not null Identity(1,1),
 Experience int not null,
 HighestQualification varchar(100) not null,
 Trainer_Id int foreign key references Trainers(Id) not null
)

create table TrainerSkill(
 Id int Primary Key not null Identity(1,1),
	 Trainer_Id int foreign key references Trainers(Id) not null,
 Skill_Id int foreign key references Skills(Id) not null
)


