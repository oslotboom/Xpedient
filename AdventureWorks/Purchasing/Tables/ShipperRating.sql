-- =============================================
-- Create table definition for ShipperRating 
--Contains a rating of a shipper by
--a customer, on a particular date.
--Ratings are from 1-100.
-- =============================================
CREATE TABLE [Purchasing].[ShipperRating]
(
[ShipperID] [int] NOT NULL,
[CustomerID] [nchar] (5) COLLATE SQL_Latin1_General_CP1_CS_AS NOT NULL,
[RatingDate] [datetime] NULL,
[Rating] [int] NOT NULL, 
    CONSTRAINT [FK_ShipperRating_Shippers] FOREIGN KEY ([ShipperID]) REFERENCES [Purchasing].[ShipMethod] ([ShipMethodID])
) ON [PRIMARY]
GO

CREATE INDEX [ShipperRatingDate] ON [Purchasing].[ShipperRating] (RatingDate)
