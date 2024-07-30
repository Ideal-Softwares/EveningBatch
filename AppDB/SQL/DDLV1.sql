CREATE TABLE [dbo].[Students] (
    [Id]     INT          IDENTITY (1, 1) NOT NULL,
    [FName]  VARCHAR (15) NOT NULL,
    [LName]  VARCHAR (15) NOT NULL,
    [Gender] VARCHAR (10) NOT NULL,
    [Mob]    BIGINT          NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

select * from [dbo].[Students]
Select * from Students