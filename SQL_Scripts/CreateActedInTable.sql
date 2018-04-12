USE [dbProject4]
GO

/****** Object:  Table [dbo].[ActedIn]    Script Date: 4/11/2018 8:41:17 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[ActedIn](
	[Actor] [varchar](50) NOT NULL,
	[Movie] [varchar](50) NOT NULL,
	[CharName] [varchar](50) NOT NULL,
	[Pay] [int] NOT NULL, 
	PRIMARY KEY (Actor, Movie)
) ON [PRIMARY]
GO


