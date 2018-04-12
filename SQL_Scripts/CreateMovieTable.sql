USE [dbProject4]
GO

/****** Object:  Table [dbo].[Movie]    Script Date: 4/11/2018 8:42:21 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Movie](
	[Title] [varchar](50) NOT NULL,
	[Producer] [varchar](50) NOT NULL,
	[ReleaseDate] [date] NOT NULL,
	[RunTime] [time](7) NOT NULL,
	[Budget] [int] NOT NULL,
	[Gross] [int] NOT NULL,
	[Rating] [int] NOT NULL,
	PRIMARY KEY(Title)
) ON [PRIMARY]
GO


