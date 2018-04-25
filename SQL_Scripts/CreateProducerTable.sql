USE [dbProject4]
GO

/****** Object:  Table [dbo].[Producer]    Script Date: 4/11/2018 8:42:53 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Producer](
	[Name] [varchar](50) NOT NULL
	[Gender] [varchar](50) NOT NULL,
	[Rating] [int] NOT NULL,
	PRIMARY KEY (Name)
) ON [PRIMARY]
GO


