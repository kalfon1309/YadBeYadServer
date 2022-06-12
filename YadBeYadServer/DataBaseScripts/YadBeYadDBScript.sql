Use Master

CREATE DATABASE YadBeYadDB

GO

Use YadBeYadDB

GO

CREATE TABLE Attraction(
    AttractionID INT PRIMARY KEY IDENTITY(10000,1) NOT NULL,
    AttName NVARCHAR(255) NOT NULL,
    AttDescription NVARCHAR(255) NOT NULL,
    AttLocation NVARCHAR(255) NOT NULL,
    GeographyLoc NVARCHAR(255) NOT NULL,
    IsPrice BIT NOT NULL

);
--ALTER TABLE
--    Attraction ADD CONSTRAINT attraction_attractionid_primary PRIMARY KEY(AttractionID);

CREATE TABLE Rate(
    RateID INT PRIMARY KEY IDENTITY(10000,1) NOT NULL,
    Rates INT NOT NULL,
    AttractionID INT NOT NULL,
    UserID INT NOT NULL
);
--ALTER TABLE
--    Rate ADD CONSTRAINT rate_id_primary PRIMARY KEY(ID);


CREATE TABLE Review(
    ReviewID INT PRIMARY KEY IDENTITY(10000,1) NOT NULL,
    Comment NVARCHAR(255) NOT NULL,
    AttractionID INT NOT NULL,
    IsActive BIT NOT NULL,
    ReviewDate DATE NOT NULL,
    UserID INT NOT NULL
);
--ALTER TABLE
--    Review ADD CONSTRAINT review_id_primary PRIMARY KEY(ID);


CREATE TABLE Users(
    UserID INT PRIMARY KEY IDENTITY(10000,1) NOT NULL,
    Email NVARCHAR(255) UNIQUE NOT NULL,
    FirstName NVARCHAR(255) NOT NULL,
    LastName NVARCHAR(255) NOT NULL,
    Age INT NOT NULL,
    UserName NVARCHAR(255) UNIQUE NOT NULL,
    Pass NVARCHAR(255) NOT NULL
);
--ALTER TABLE
--    Users ADD CONSTRAINT user_id_primary PRIMARY KEY(ID);


CREATE TABLE Favorites(
    FavoriteID INT PRIMARY KEY IDENTITY(10000,1) NOT NULL,
    AttractionID INT NOT NULL,
    UserID INT NOT NULL,
    IsActive BIT NOT NULL
);
--ALTER TABLE
--    RecentAtt ADD CONSTRAINT recentatt_attracionid_primary PRIMARY KEY(AttracionID);



CREATE TABLE AttStatus(
    AttractionID INT NOT NULL,
    IsOpen BIT NOT NULL,
    OpeningHours NVARCHAR(255) NOT NULL,
    ClosingHours NVARCHAR(255) NOT NULL,
    IsWeekend BIT NOT NULL
);



--ALTER TABLE
--    AttStatus ADD CONSTRAINT attstatus_attractionid_primary PRIMARY KEY(AttractionID);
ALTER TABLE
    Rate ADD CONSTRAINT rate_attractionid_foreign FOREIGN KEY(AttractionID) REFERENCES Attraction(AttractionID);

ALTER TABLE
    Review ADD CONSTRAINT review_attractionid_foreign FOREIGN KEY(AttractionID) REFERENCES Attraction(AttractionID);
ALTER TABLE
    Rate ADD CONSTRAINT rate_userid_foreign FOREIGN KEY(UserID) REFERENCES Users(UserID);
ALTER TABLE
    Review ADD CONSTRAINT review_userid_foreign FOREIGN KEY(UserID) REFERENCES Users(UserID);
ALTER TABLE
    Favorites ADD CONSTRAINT favorites_attractionid_foreign FOREIGN KEY(AttractionID) REFERENCES Attraction(AttractionID);
ALTER TABLE
    Favorites ADD CONSTRAINT favorites_userid_foreign FOREIGN KEY(UserID) REFERENCES Users(UserID);
ALTER TABLE
    AttStatus ADD CONSTRAINT attstatus_attractionid_foreign FOREIGN KEY(AttractionID) REFERENCES Attraction(AttractionID);











    USE [YadBeYadDB]
GO

INSERT INTO [dbo].[Attraction]
           ([AttName]
           ,[AttDescription]
           ,[AttLocation]
           ,[GeographyLoc]
           ,[IsPrice])
     VALUES
           ('Hermon'
           ,'this is the highest place in all of Israel.'
           ,'Ramat Hagolan'
           ,'North'
           ,1)
GO

INSERT INTO [dbo].[Attraction]
           ([AttName]
           ,[AttDescription]
           ,[AttLocation]
           ,[GeographyLoc]
           ,[IsPrice])
     VALUES
           ('Kineret'
           ,'this is the sweetest place in all of Israel.'
           ,'tveria'
           ,'North'
           ,0)
GO

INSERT INTO [dbo].[Attraction]
           ([AttName]
           ,[AttDescription]
           ,[AttLocation]
           ,[GeographyLoc]
           ,[IsPrice])
     VALUES
           ('MagicKass'
           ,'this is the Amits horror place in all of Israel.'
           ,'Maale Edumim'
           ,'East'
           ,1)
GO

INSERT INTO [dbo].[Attraction]
           ([AttName]
           ,[AttDescription]
           ,[AttLocation]
           ,[GeographyLoc]
           ,[IsPrice])
     VALUES
           ('Dead Sea'
           ,'this is the lowest place in all of Israel.'
           ,'Yerijo'
           ,'East'
           ,1)
GO

INSERT INTO [dbo].[Attraction]
           ([AttName]
           ,[AttDescription]
           ,[AttLocation]
           ,[GeographyLoc]
           ,[IsPrice])
     VALUES
           ('Jordan River'
           ,'one of the largest rivers in israel.'
           ,'Yerijo'
           ,'East'
           ,1)
GO

INSERT INTO [dbo].[Attraction]
           ([AttName]
           ,[AttDescription]
           ,[AttLocation]
           ,[GeographyLoc]
           ,[IsPrice])
     VALUES
           ('Ramat Gan Zoo'
           ,'this is the largest zoo in israel.'
           ,'Ramat Gan'
           ,'West'
           ,1)
GO

INSERT INTO [dbo].[Attraction]
           ([AttName]
           ,[AttDescription]
           ,[AttLocation]
           ,[GeographyLoc]
           ,[IsPrice])
     VALUES
           ('Mitzpe Tat Yami'
           ,'the best place to see amazing fish.'
           ,'Eilat'
           ,'South'
           ,1)
GO

INSERT INTO [dbo].[Attraction]
           ([AttName]
           ,[AttDescription]
           ,[AttLocation]
           ,[GeographyLoc]
           ,[IsPrice])
     VALUES
           ('Mitzpe Ramon'
           ,'this is the lowest place in all of Israel.'
           ,'Yerijo'
           ,'East'
           ,0)
GO


INSERT INTO [dbo].[Users]
           ([Email]
           ,[FirstName]
           ,[LastName]
           ,[Age]
           ,[UserName]
           ,[Pass])
     VALUES
           ('a@gmail.com'
           ,'Ahiya'
           ,'Calfon'
           ,17
           ,'achi'
           ,'123')


          INSERT INTO [dbo].[Review]
           ([Comment]
           ,[AttractionID]
           ,[IsActive]
           ,[ReviewDate]
           ,[UserID])
     VALUES
           ('the hermon is the besttttttt'
           ,10000
           ,1
           ,'20220523 02:00:00 PM'
           ,10000)


		   INSERT INTO [dbo].[Review]
           ([Comment]
           ,[AttractionID]
           ,[IsActive]
           ,[ReviewDate]
           ,[UserID])
     VALUES
           ('the hermon is the worsttt'
           ,10000
           ,1
           ,'20220321 07:22:00 PM'
           ,10000)



		   INSERT INTO [dbo].[Review]
           ([Comment]
           ,[AttractionID]
           ,[IsActive]
           ,[ReviewDate]
           ,[UserID])
     VALUES
           ('I realy love the Hermon'
           ,10000
           ,1
           ,'20210112 02:03:00 PM'
           ,10000)


		   INSERT INTO [dbo].[Review]
           ([Comment]
           ,[AttractionID]
           ,[IsActive]
           ,[ReviewDate]
           ,[UserID])
     VALUES
           ('amazing place'
           ,10000
           ,1
           ,'20200526 09:13:04 AM'
           ,10000)

		   INSERT INTO [dbo].[Review]
           ([Comment]
           ,[AttractionID]
           ,[IsActive]
           ,[ReviewDate]
           ,[UserID])
     VALUES
           ('nice place'
           ,10000
           ,1
           ,'20220523 02:00:00 PM'
           ,10000)
           
            INSERT INTO [dbo].[Rate]
           ([Rates]
           ,[AttractionID]
           ,[UserID])
     VALUES
           ('8'
           ,10000
           ,10000)


GO
