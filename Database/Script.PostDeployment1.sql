/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/

DELETE FROM Games;

INSERT INTO Games([Name], [Date], Venue, courtFees, AmountSpent, whoPaid) VALUES
('Dragan Djordjevic', '2018-11-27 12:30:00:000', 'Swinburne Campus Hawthorn', '100$', '100$', 'Dragan');