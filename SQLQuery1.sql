DROP PROCEDURE searchADD
GO
CREATE PROCEDURE [dbo].[searchADD]
@Number int,
@Date datetime,
@Message nvarchar(MAX),
@Id int
AS
INSERT INTO Numbers (Number, Date, Message) VALUES (@Number, @Date, @Message)
SET @Id = @@IDENTITY