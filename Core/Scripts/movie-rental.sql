Use MovieRental


CREATE TABLE [dbo].[Genres] (
    [Id]   INT            IDENTITY (1, 1) NOT NULL,
    [name] NVARCHAR (100) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);


CREATE TABLE [dbo].[Directors] (
    [Id]          INT           NOT NULL,
    [firstName]   NVARCHAR (50) NOT NULL,
    [lastName]    NVARCHAR (50) NOT NULL,
    [Nationality] NVARCHAR (50) NULL,
    [Birth]       DATETIME      NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);


CREATE TABLE [dbo].[Movies] (
    [Id]          INT            IDENTITY (1, 1) NOT NULL,
    [DirectorId]  INT            NOT NULL,
	[Name]		  NVARCHAR(50)	NOT NULL,	
    [GenreId]     INT            NOT NULL,
    [Title]       NVARCHAR (500) NOT NULL,
    [ReleaseYear] NVARCHAR (50)  NOT NULL,
    [Rating]      FLOAT (53)     NOT NULL,
    [MovieLength] INT            NOT NULL,
	[DailyPrice] FLOAT(53)		NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    FOREIGN KEY ([GenreId]) REFERENCES [dbo].[Genres] ([Id]),
    FOREIGN KEY ([DirectorId]) REFERENCES [dbo].[Directors] ([Id])
);






CREATE TABLE [dbo].[Customers] (
    [Id]          INT            IDENTITY (1, 1) NOT NULL,
    [firstName]   NVARCHAR (50)  NOT NULL,
    [lastName]    NVARCHAR (50)  NOT NULL,
    [email]       NVARCHAR (100) NOT NULL,
    [phoneNumber] NVARCHAR (50)  NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

CREATE TABLE [dbo].[Rentals] (
    [Id]         INT      IDENTITY (1, 1) NOT NULL,
    [movieId]    INT      NOT NULL,
    [customerId] INT      NOT NULL,
    [rentDate]   DATETIME NOT NULL,
    [returnDate] DATETIME NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    FOREIGN KEY ([movieId]) REFERENCES [dbo].[Movies] ([Id]),
    FOREIGN KEY ([customerId]) REFERENCES [dbo].[Customers] ([Id])
);

