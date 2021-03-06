USE [master]
GO
/****** Object:  Database [Task13]    Script Date: 9/1/2020 5:56:33 PM ******/
CREATE DATABASE [Task13]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Task13', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\Task13.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Task13_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\Task13_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [Task13] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Task13].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Task13] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Task13] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Task13] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Task13] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Task13] SET ARITHABORT OFF 
GO
ALTER DATABASE [Task13] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Task13] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Task13] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Task13] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Task13] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Task13] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Task13] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Task13] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Task13] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Task13] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Task13] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Task13] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Task13] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Task13] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Task13] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Task13] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Task13] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Task13] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Task13] SET  MULTI_USER 
GO
ALTER DATABASE [Task13] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Task13] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Task13] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Task13] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Task13] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Task13] SET QUERY_STORE = OFF
GO
USE [Task13]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 9/1/2020 5:56:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Actors]    Script Date: 9/1/2020 5:56:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Actors](
	[Id] [uniqueidentifier] NOT NULL,
	[FirstName] [nvarchar](50) NULL,
	[MiddleName] [nvarchar](50) NULL,
	[LastName] [nvarchar](50) NULL,
	[Gender] [int] NOT NULL,
	[DateOfBirth] [datetime2](7) NOT NULL,
	[BirthPlace] [nvarchar](50) NULL,
	[Biography] [nvarchar](200) NULL,
	[ImageURL] [nvarchar](2048) NULL,
 CONSTRAINT [PK_Actors] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Characters]    Script Date: 9/1/2020 5:56:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Characters](
	[Id] [uniqueidentifier] NOT NULL,
	[FullName] [nvarchar](50) NULL,
	[Alias] [nvarchar](50) NULL,
	[Gender] [int] NOT NULL,
	[ImageURL] [nvarchar](2048) NULL,
 CONSTRAINT [PK_Characters] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Directors]    Script Date: 9/1/2020 5:56:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Directors](
	[Id] [uniqueidentifier] NOT NULL,
	[FirstName] [nvarchar](50) NULL,
	[MiddleName] [nvarchar](50) NULL,
	[LastName] [nvarchar](50) NULL,
	[Gender] [int] NOT NULL,
	[DateOfBirth] [datetime2](7) NOT NULL,
	[BirthPlace] [nvarchar](50) NULL,
	[Biography] [nvarchar](500) NULL,
	[ImageURL] [nvarchar](2048) NULL,
 CONSTRAINT [PK_Directors] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Franchises]    Script Date: 9/1/2020 5:56:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Franchises](
	[Id] [uniqueidentifier] NOT NULL,
	[Name] [nvarchar](50) NULL,
	[Description] [nvarchar](250) NULL,
 CONSTRAINT [PK_Franchises] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MovieCharacters]    Script Date: 9/1/2020 5:56:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MovieCharacters](
	[CharacterId] [uniqueidentifier] NOT NULL,
	[MovieId] [uniqueidentifier] NOT NULL,
	[ImageURL] [nvarchar](2048) NULL,
	[ActorId] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_MovieCharacters] PRIMARY KEY CLUSTERED 
(
	[CharacterId] ASC,
	[MovieId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MovieDirectors]    Script Date: 9/1/2020 5:56:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MovieDirectors](
	[DirectorId] [uniqueidentifier] NOT NULL,
	[MovieId] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_MovieDirectors] PRIMARY KEY CLUSTERED 
(
	[DirectorId] ASC,
	[MovieId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Movies]    Script Date: 9/1/2020 5:56:33 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Movies](
	[Id] [uniqueidentifier] NOT NULL,
	[Title] [nvarchar](50) NULL,
	[Genre] [int] NOT NULL,
	[ReleaseYear] [datetime2](7) NOT NULL,
	[PosterURL] [nvarchar](2048) NULL,
	[TrailerURL] [nvarchar](2048) NULL,
	[FranchiseId] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_Movies] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20200827131438_InitialCreate', N'3.1.7')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20200827191142_ActorManyToManyMovieCharacter', N'3.1.7')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20200827191619_ActorOneToManyMovieCharacter', N'3.1.7')
GO
INSERT [dbo].[Actors] ([Id], [FirstName], [MiddleName], [LastName], [Gender], [DateOfBirth], [BirthPlace], [Biography], [ImageURL]) VALUES (N'78d3d632-9beb-4bf4-bbc5-328d503b44ea', N'John', N'Joseph', N'Travolta', 0, CAST(N'1968-02-18T14:21:47.6010000' AS DateTime2), N'Englewood, New Jersey', N'John Joseph Travolta was born in Englewood, New Jersey, one of six children of Helen Travolta (née Helen Cecilia Burke) and Salvatore/Samuel J. Travolta', N'https://m.media-amazon.com/images/M/MV5BMTUwNjQ0ODkxN15BMl5BanBnXkFtZTcwMDc5NjQwNw@@._V1_UY317_CR11,0,214,317_AL_.jpg')
INSERT [dbo].[Actors] ([Id], [FirstName], [MiddleName], [LastName], [Gender], [DateOfBirth], [BirthPlace], [Biography], [ImageURL]) VALUES (N'b49403bf-4070-41de-80d2-aea32ca3df8e', N'Uma', NULL, N'Thurman', 1, CAST(N'1970-04-29T14:00:00.6010000' AS DateTime2), N'Boston, Massachusetts, USA', N'Uma Karuna Thurman was born in Boston, Massachusetts, into a highly unorthodox and internationally-minded family', N'https://m.media-amazon.com/images/M/MV5BMjMxNzk1MTQyMl5BMl5BanBnXkFtZTgwMDIzMDEyMTE@._V1_UX214_CR0,0,214,317_AL_.jpg')
INSERT [dbo].[Actors] ([Id], [FirstName], [MiddleName], [LastName], [Gender], [DateOfBirth], [BirthPlace], [Biography], [ImageURL]) VALUES (N'52da45b2-1833-4bb4-be3a-cb2e143988d6', N'Samuel', N'Leroy', N'Jackson', 0, CAST(N'1948-12-21T14:00:00.6010000' AS DateTime2), N'Washington, District of Columbia, USA', N'Samuel L. Jackson is an American producer and highly prolific actor', N'https://m.media-amazon.com/images/M/MV5BMTQ1NTQwMTYxNl5BMl5BanBnXkFtZTYwMjA1MzY1._V1_UX214_CR0,0,214,317_AL_.jpg')
GO
INSERT [dbo].[Characters] ([Id], [FullName], [Alias], [Gender], [ImageURL]) VALUES (N'f0b9ad0f-9def-45ca-89c2-103aa847fb17', N'Vincent Vega', NULL, 0, N'https://m.media-amazon.com/images/M/MV5BMzFhN2UyNDMtMGM1ZS00Y2VmLWFlYWYtZWYxYjcyN2QyNWZlXkEyXkFqcGdeQXVyNDIyNjA2MTk@._V1_.jpg')
INSERT [dbo].[Characters] ([Id], [FullName], [Alias], [Gender], [ImageURL]) VALUES (N'e00de279-8130-4c63-b343-da772a7c463d', N'Mia Wallace', NULL, 1, N'https://m.media-amazon.com/images/M/MV5BNzg1MTgwMTUzM15BMl5BanBnXkFtZTcwNjA0MzU5Ng@@._V1_SY200_CR46,0,200,200_AL_.jpg')
INSERT [dbo].[Characters] ([Id], [FullName], [Alias], [Gender], [ImageURL]) VALUES (N'b0171e0f-b606-4c98-a6ba-e5e1a351f0e1', N'Jules Winnfield', NULL, 0, N'https://m.media-amazon.com/images/M/MV5BMjIwNTg0Mjc4Nl5BMl5BanBnXkFtZTcwODAzNDY3Mw@@._V1_SY200_CR70,0,200,200_AL_.jpg')
GO
INSERT [dbo].[Directors] ([Id], [FirstName], [MiddleName], [LastName], [Gender], [DateOfBirth], [BirthPlace], [Biography], [ImageURL]) VALUES (N'632fa20a-1c0d-4e71-ab07-aab66299964e', N'Quentin', N'Jerome', N'Tarantino', 0, CAST(N'1963-03-27T14:00:00.6010000' AS DateTime2), N'Knoxville, Tennessee, USA', N'Quentin Jerome Tarantino was born in Knoxville, Tennessee. His father, Tony Tarantino, is an Italian-American actor and musician from New York, and his mother, Connie (McHugh), is a nurse from Tennessee', N'https://m.media-amazon.com/images/M/MV5BMTgyMjI3ODA3Nl5BMl5BanBnXkFtZTcwNzY2MDYxOQ@@._V1_UX214_CR0,0,214,317_AL_.jpg')
GO
INSERT [dbo].[Franchises] ([Id], [Name], [Description]) VALUES (N'c3934230-a4c7-4af7-b160-8b4afe930537', N'Quentin Tarantino Movie', N'A Tarantino film can be distinguished in many ways. Violence, wit, humor, incredible dialogue, non-linear plots, profanity, references to pop culture, and homage to genres are all parts of the pastiche that make up a Tarantino movie.')
GO
INSERT [dbo].[MovieCharacters] ([CharacterId], [MovieId], [ImageURL], [ActorId]) VALUES (N'f0b9ad0f-9def-45ca-89c2-103aa847fb17', N'80d7d9f6-f465-4d85-bea8-cdadffa4abc3', N'https://www.imdb.com/title/tt0110912/mediaviewer/rm689864704?ft0=name&fv0=nm0000237&ft1=image_type&fv1=still_frame', N'78d3d632-9beb-4bf4-bbc5-328d503b44ea')
INSERT [dbo].[MovieCharacters] ([CharacterId], [MovieId], [ImageURL], [ActorId]) VALUES (N'e00de279-8130-4c63-b343-da772a7c463d', N'80d7d9f6-f465-4d85-bea8-cdadffa4abc3', N'https://m.media-amazon.com/images/M/MV5BNmU1ODYxMTgtNjJiMS00NWFhLWIzMjMtNTkyODExNzMwZTFhXkEyXkFqcGdeQXVyNzQwMzAwNTI@._V1_.jpg', N'b49403bf-4070-41de-80d2-aea32ca3df8e')
INSERT [dbo].[MovieCharacters] ([CharacterId], [MovieId], [ImageURL], [ActorId]) VALUES (N'b0171e0f-b606-4c98-a6ba-e5e1a351f0e1', N'80d7d9f6-f465-4d85-bea8-cdadffa4abc3', N'https://m.media-amazon.com/images/M/MV5BOTBmMjg1MGEtNmM3NS00NTM4LWE4OTItYWEyZTI2MmY1NTkzXkEyXkFqcGdeQXVyNDIyNjA2MTk@._V1_SX1492_CR0,0,1492,999_AL_.jpg', N'52da45b2-1833-4bb4-be3a-cb2e143988d6')
GO
INSERT [dbo].[MovieDirectors] ([DirectorId], [MovieId]) VALUES (N'632fa20a-1c0d-4e71-ab07-aab66299964e', N'80d7d9f6-f465-4d85-bea8-cdadffa4abc3')
GO
INSERT [dbo].[Movies] ([Id], [Title], [Genre], [ReleaseYear], [PosterURL], [TrailerURL], [FranchiseId]) VALUES (N'80d7d9f6-f465-4d85-bea8-cdadffa4abc3', N'Pulp Fiction', 18, CAST(N'1994-10-21T15:21:47.6010000' AS DateTime2), N'https://m.media-amazon.com/images/M/MV5BNGNhMDIzZTUtNTBlZi00MTRlLWFjM2ItYzViMjE3YzI5MjljXkEyXkFqcGdeQXVyNzkwMjQ5NzM@._V1_UY268_CR1,0,182,268_AL_.jpg', N'https://www.youtube.com/watch?v=s7EdQ4FqbhY', N'c3934230-a4c7-4af7-b160-8b4afe930537')
GO
/****** Object:  Index [IX_MovieCharacters_ActorId]    Script Date: 9/1/2020 5:56:33 PM ******/
CREATE NONCLUSTERED INDEX [IX_MovieCharacters_ActorId] ON [dbo].[MovieCharacters]
(
	[ActorId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_MovieCharacters_MovieId]    Script Date: 9/1/2020 5:56:33 PM ******/
CREATE NONCLUSTERED INDEX [IX_MovieCharacters_MovieId] ON [dbo].[MovieCharacters]
(
	[MovieId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_MovieDirectors_MovieId]    Script Date: 9/1/2020 5:56:33 PM ******/
CREATE NONCLUSTERED INDEX [IX_MovieDirectors_MovieId] ON [dbo].[MovieDirectors]
(
	[MovieId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Movies_FranchiseId]    Script Date: 9/1/2020 5:56:33 PM ******/
CREATE NONCLUSTERED INDEX [IX_Movies_FranchiseId] ON [dbo].[Movies]
(
	[FranchiseId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[MovieCharacters]  WITH CHECK ADD  CONSTRAINT [FK_MovieCharacters_Actors_ActorId] FOREIGN KEY([ActorId])
REFERENCES [dbo].[Actors] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[MovieCharacters] CHECK CONSTRAINT [FK_MovieCharacters_Actors_ActorId]
GO
ALTER TABLE [dbo].[MovieCharacters]  WITH CHECK ADD  CONSTRAINT [FK_MovieCharacters_Characters_CharacterId] FOREIGN KEY([CharacterId])
REFERENCES [dbo].[Characters] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[MovieCharacters] CHECK CONSTRAINT [FK_MovieCharacters_Characters_CharacterId]
GO
ALTER TABLE [dbo].[MovieCharacters]  WITH CHECK ADD  CONSTRAINT [FK_MovieCharacters_Movies_MovieId] FOREIGN KEY([MovieId])
REFERENCES [dbo].[Movies] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[MovieCharacters] CHECK CONSTRAINT [FK_MovieCharacters_Movies_MovieId]
GO
ALTER TABLE [dbo].[MovieDirectors]  WITH CHECK ADD  CONSTRAINT [FK_MovieDirectors_Directors_DirectorId] FOREIGN KEY([DirectorId])
REFERENCES [dbo].[Directors] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[MovieDirectors] CHECK CONSTRAINT [FK_MovieDirectors_Directors_DirectorId]
GO
ALTER TABLE [dbo].[MovieDirectors]  WITH CHECK ADD  CONSTRAINT [FK_MovieDirectors_Movies_MovieId] FOREIGN KEY([MovieId])
REFERENCES [dbo].[Movies] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[MovieDirectors] CHECK CONSTRAINT [FK_MovieDirectors_Movies_MovieId]
GO
ALTER TABLE [dbo].[Movies]  WITH CHECK ADD  CONSTRAINT [FK_Movies_Franchises_FranchiseId] FOREIGN KEY([FranchiseId])
REFERENCES [dbo].[Franchises] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Movies] CHECK CONSTRAINT [FK_Movies_Franchises_FranchiseId]
GO
USE [master]
GO
ALTER DATABASE [Task13] SET  READ_WRITE 
GO
