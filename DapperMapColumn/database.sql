USE [master]

CREATE DATABASE [LojaDB]

USE [LojaDB]

CREATE TABLE [dbo].[Clientes](
	[Id] [int] IDENTITY(1,1) NOT NULL PRIMARY KEY ,
	[Nome] [nvarchar](max) NULL
)