USE [DAF_Assesment]
GO
/****** Object:  UserDefinedTableType [dbo].[FlightType]    Script Date: 24-02-2024 21:59:34 ******/
CREATE TYPE [dbo].[FlightType] AS TABLE(
	[AirportId] [int] NULL,
	[FlightName] [nvarchar](255) NULL,
	[FirstSeenUnixTimeStamp] [bigint] NULL,
	[EstDepartureAirport] [nvarchar](255) NULL,
	[LastSeenUnixTimeStamp] [bigint] NULL,
	[EstArrivalAirport] [nvarchar](255) NULL,
	[Callsign] [nvarchar](255) NULL,
	[EstDepartureAirportHorizDistance] [int] NULL,
	[EstDepartureAirportVertDistance] [int] NULL,
	[EstArrivalAirportHorizDistance] [int] NULL,
	[EstArrivalAirportVertDistance] [int] NULL,
	[DepartureAirportCandidatesCount] [int] NULL,
	[ArrivalAirportCandidatesCount] [int] NULL,
	[FirstSeen] [datetime] NULL,
	[LastSeen] [datetime] NULL
)
GO
/****** Object:  Table [dbo].[Airports]    Script Date: 24-02-2024 21:59:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Airports](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](128) NOT NULL,
	[Icao] [nvarchar](4) NOT NULL,
	[Latitude] [float] NULL,
	[Longitude] [float] NULL,
 CONSTRAINT [PK_Airport] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Flights]    Script Date: 24-02-2024 21:59:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Flights](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[AirportId] [int] NOT NULL,
	[FlightName] [nvarchar](255) NULL,
	[FirstSeenUnixTimeStamp] [bigint] NULL,
	[EstDepartureAirport] [nvarchar](255) NULL,
	[LastSeenUnixTimeStamp] [bigint] NULL,
	[EstArrivalAirport] [nvarchar](255) NULL,
	[Callsign] [nvarchar](255) NULL,
	[EstDepartureAirportHorizDistance] [int] NULL,
	[EstDepartureAirportVertDistance] [int] NULL,
	[EstArrivalAirportHorizDistance] [int] NULL,
	[EstArrivalAirportVertDistance] [int] NULL,
	[DepartureAirportCandidatesCount] [int] NULL,
	[ArrivalAirportCandidatesCount] [int] NULL,
	[FirstSeen] [datetime] NULL,
	[LastSeen] [datetime] NULL,
	[AirportName] [nvarchar](128) NULL,
 CONSTRAINT [PK__Flights__3214EC0799406765] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserEmails]    Script Date: 24-02-2024 21:59:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserEmails](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserEmail] [nvarchar](128) NOT NULL,
	[FlightId] [int] NOT NULL,
	[HasNotified] [bit] NULL,
	[NotificationTime] [smalldatetime] NULL,
 CONSTRAINT [PK_UserEmails] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[UserEmails] ADD  CONSTRAINT [DF_UserEmails_HasNotified]  DEFAULT ((0)) FOR [HasNotified]
GO
/****** Object:  StoredProcedure [dbo].[sp_BulkInsertFlights]    Script Date: 24-02-2024 21:59:34 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_BulkInsertFlights]
    @Flights FlightType READONLY
AS
BEGIN
    SET NOCOUNT ON;

    INSERT INTO [dbo].[Flights] (AirportId, FlightName, FirstSeenUnixTimeStamp, EstDepartureAirport, LastSeenUnixTimeStamp, EstArrivalAirport, Callsign, EstDepartureAirportHorizDistance, EstDepartureAirportVertDistance, EstArrivalAirportHorizDistance, EstArrivalAirportVertDistance, DepartureAirportCandidatesCount, ArrivalAirportCandidatesCount, FirstSeen, LastSeen)
    SELECT AirportId, FlightName, FirstSeenUnixTimeStamp, EstDepartureAirport, LastSeenUnixTimeStamp, EstArrivalAirport, Callsign, EstDepartureAirportHorizDistance, EstDepartureAirportVertDistance, EstArrivalAirportHorizDistance, EstArrivalAirportVertDistance, DepartureAirportCandidatesCount, ArrivalAirportCandidatesCount, FirstSeen, LastSeen
    FROM @Flights;
END
GO
