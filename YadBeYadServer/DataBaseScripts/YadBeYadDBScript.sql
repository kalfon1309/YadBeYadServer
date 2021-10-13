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


CREATE TABLE RecentAtt(
    AttractionID INT NOT NULL,
    UserID INT NOT NULL,
    AttDate DATE NOT NULL
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
    RecentAtt ADD CONSTRAINT recentAtt_attractionid_foreign FOREIGN KEY(AttractionID) REFERENCES Attraction(AttractionID);
ALTER TABLE
    RecentAtt ADD CONSTRAINT recentAtt_userid_foreign FOREIGN KEY(UserID) REFERENCES Users(UserID);
ALTER TABLE
    AttStatus ADD CONSTRAINT attstatus_attractionid_foreign FOREIGN KEY(AttractionID) REFERENCES Attraction(AttractionID);
