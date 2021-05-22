USE [MovieRental]
GO

/****** Object: Table [dbo].[Customers] Script Date: 5/22/2021 3:29:00 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Customers] (
    [Id]          INT            IDENTITY (1, 1) NOT NULL,
    [firstName]   NVARCHAR (50)  NOT NULL,
    [lastName]    NVARCHAR (50)  NOT NULL,
    [email]       NVARCHAR (100) NOT NULL,
    [phoneNumber] NVARCHAR (50)  NOT NULL
);


GO

/****** Object: Table [dbo].[Directors] Script Date: 5/22/2021 3:29:49 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Directors] (
    [Id]          INT           IDENTITY (1, 1) NOT NULL,
    [firstName]   NVARCHAR (50) NOT NULL,
    [lastName]    NVARCHAR (50) NOT NULL,
    [Nationality] NVARCHAR (50) NULL,
    [Birth]       DATE          NULL
);
GO

/****** Object: Table [dbo].[Genres] Script Date: 5/22/2021 3:30:38 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Genres] (
    [Id]   INT            IDENTITY (1, 1) NOT NULL,
    [name] NVARCHAR (100) NOT NULL
);

GO

/****** Object: Table [dbo].[Movies] Script Date: 5/22/2021 3:31:07 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Movies] (
    [Id]          INT            IDENTITY (1, 1) NOT NULL,
    [DirectorId]  INT            NOT NULL,
    [Name]        NVARCHAR (50)  NOT NULL,
    [GenreId]     INT            NOT NULL,
    [Title]       NVARCHAR (500) NOT NULL,
    [ReleaseYear] NVARCHAR (50)  NOT NULL,
    [Rating]      FLOAT (53)     NOT NULL,
    [MovieLength] INT            NOT NULL,
    [DailyPrice]  FLOAT (53)     NOT NULL
);

GO

/****** Object: Table [dbo].[Rentals] Script Date: 5/22/2021 3:31:49 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Rentals] (
    [Id]         INT      IDENTITY (1, 1) NOT NULL,
    [movieId]    INT      NOT NULL,
    [customerId] INT      NOT NULL,
    [rentDate]   DATETIME NOT NULL,
    [returnDate] DATETIME NULL
);


