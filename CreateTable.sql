USE ProjectsAccounting

--DROP TABLE ProjectRates
--DROP TABLE Projects
--DROP TABLE Users

CREATE TABLE Users (
    UserId int identity(1, 1) primary key,
    UserName varchar(255),
    FullName varchar(255),
    PMCID varchar(255),
    InternalRate float 
);

CREATE TABLE Projects (
    ProjectId int identity(1, 1) primary key,
    ProjectName varchar(255),
    PMCID varchar(255)
);

CREATE TABLE ProjectRates (
    ProjectRateId int identity(1, 1) primary key,
    ProjectId int,
    UserId int,
	ExternalRate float,
	FOREIGN KEY (UserId) REFERENCES Users(UserId),
	FOREIGN KEY (ProjectId) REFERENCES Projects(ProjectId)
);