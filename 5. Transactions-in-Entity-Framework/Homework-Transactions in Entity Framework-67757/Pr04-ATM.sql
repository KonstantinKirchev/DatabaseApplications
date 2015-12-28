USE [master]
GO
CREATE DATABASE [ATM]
GO
USE [ATM]
GO

CREATE TABLE [dbo].[CardAccounts](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CardNumber] [char](10) NOT NULL,
	[CardPIN] [char](4) NOT NULL,
	[CardCash] [money](18, 2) NOT NULL,
 CONSTRAINT [PK_dbo.CardAccounts] PRIMARY KEY CLUSTERED ([Id]) ON [PRIMARY])

GO

INSERT [dbo].[CardAccounts] ([CardNumber], [CardPIN], [CardCash]) VALUES ('1234567890', '1234', 2345.34 )
INSERT [dbo].[CardAccounts] ([CardNumber], [CardPIN], [CardCash]) VALUES ('0987654321', '2345', 847654.65)

GO