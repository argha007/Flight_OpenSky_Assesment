USE [DAF_Assesment]
GO
SET IDENTITY_INSERT [dbo].[Airports] ON 

INSERT [dbo].[Airports] ([Id], [Name], [Icao], [Latitude], [Longitude]) VALUES (1, N'Ronald Reagan Washington National Airport', N'KDCA', NULL, NULL)
INSERT [dbo].[Airports] ([Id], [Name], [Icao], [Latitude], [Longitude]) VALUES (2, N'Amsterdam Airport Schiphol', N'EHAM', NULL, NULL)
INSERT [dbo].[Airports] ([Id], [Name], [Icao], [Latitude], [Longitude]) VALUES (3, N'Indira Gandhi International Airport', N'VIDP', NULL, NULL)
SET IDENTITY_INSERT [dbo].[Airports] OFF
GO
