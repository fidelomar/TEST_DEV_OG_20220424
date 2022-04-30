-- User: root
-- Pass: abril

INSERT INTO dbo.AspNetUsers( 
    Id ,
    Email ,
    EmailConfirmed ,
    PasswordHash ,
    SecurityStamp ,
    PhoneNumber ,
    PhoneNumberConfirmed ,
    TwoFactorEnabled ,    
    LockoutEnabled ,
    AccessFailedCount ,
    UserName    
)
    VALUES  ( 
    '36040EE4-2475-4BD2-BABC-653D4E683C02' , -- Id - nvarchar(128)
    'fidelomar@outlook.com' , -- Email
    0 , -- EmailConfirmed - bit   
    N'cI6mrrzRQEYhGgLktZ36wa6B60CFNqHPRVUqgdOrGoc=', --PasswordHash
    N'd5b34c61-2928-434a-a97f-e936501397b1' , -- SecurityStamp - nvarchar(max)
    null,   -- PhoneNumber - nvarchar(max)
    0 ,     -- PhoneNumberConfirmed - bit
    0,      -- TwoFactorEnabled - bit    
    0,          -- LockoutEnabled - bit
    0 ,         -- AccessFailedCount - int
    N'Root'   -- UserName - nvarchar(256)
    ) 
