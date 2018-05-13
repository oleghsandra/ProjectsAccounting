USE ProjectsAccounting
GO

--
--DROP TABLE InvoicedTasks
--DROP TABLE Invoices
--DROP TABLE ProjectRates
--DROP TABLE Projects
--DROP TABLE Users
--DROP TABLE CompanyInfo

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
	CustomerName varchar(255),
	CustomerAddress varchar(255),
	CustomerEmail varchar(255),
	CustomerPhone varchar(255),
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

CREATE TABLE CompanyInfo (
	CompanyId int identity(1, 1) primary key,
    CompanyName varchar(255),
	MainAccpuntantName varchar(255),
	OwnerName varchar(255),
	LocationAddress varchar(255),
	Fax varchar(255),
	Phone varchar(255),
	TaxRate float,
    OfficeRate float
);

CREATE TABLE Invoices (
	InvoiceId int identity(1, 1) primary key,
	ProjectId int,
	InvoiceDate DateTime,
	Notes varchar(255),
	CompanyName varchar(255),
	MainAccpuntantName varchar(255),
	OwnerName varchar(255),
	LocationAddress varchar(255),
	Fax varchar(255),
	Phone varchar(255),
	TaxRate float,
    OfficeRate varchar(255),

	FOREIGN KEY (ProjectId) REFERENCES Projects(ProjectId)
);

CREATE TABLE InvoicedTasks (
	InvoicedTaskId int identity(1, 1) primary key,
	InvoiceId int,
	UserId int,
	ReportedHours float,
	TaskName varchar(255)

	FOREIGN KEY (InvoiceId) REFERENCES Invoices(InvoiceId),
	FOREIGN KEY (UserId) REFERENCES Users(UserId),
);