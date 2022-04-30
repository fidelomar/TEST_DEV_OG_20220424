-- User: root
-- Pass: Abril22#

INSERT INTO [dbo].[AspNetUsers]
           ([Id]
           ,[UserName]
           ,[NormalizedUserName]
           ,[Email]
           ,[NormalizedEmail]
           ,[EmailConfirmed]
           ,[PasswordHash]
           ,[SecurityStamp]
           ,[ConcurrencyStamp]
           ,[PhoneNumber]
           ,[PhoneNumberConfirmed]
           ,[TwoFactorEnabled]
           ,[LockoutEnd]
           ,[LockoutEnabled]
           ,[AccessFailedCount])
     VALUES
           (
           'b1accdab-fc0b-488b-9c9f-07a6f9e6b2b1',
           'ogarci4@gmail.com',
           'OGARCI4@GMAIL.COM',
           'ogarci4@gmail.com',
           'OGARCI4@GMAIL.COM',
           0,
           'AQAAAAEAACcQAAAAEOd6PXT525qkDINHz7A+leSZiZbdjDLNGIjrdaOqzbKZuWhicJFLcJyhPYzhUgWHXw==',
           'QJ3IQGQOAUOK4VO3ZNB63E3VJNXFL3GS',
           '665748d2-6871-435c-891b-fba72167f54e',
           '',
           '',
           0,
           '',
           1,
           0)
GO