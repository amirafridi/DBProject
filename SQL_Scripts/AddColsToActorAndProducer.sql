USE [dbProject4]
GO

ALTER TABLE dbo.Actor ADD Gender VARCHAR(10);
ALTER TABLE dbo.Producer ADD Gender VARCHAR(10);
ALTER TABLE dbo.Actor ADD Rating int;
ALTER TABLE dbo.Producer ADD Rating int;
