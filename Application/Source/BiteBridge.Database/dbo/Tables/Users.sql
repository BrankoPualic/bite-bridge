CREATE TABLE [dbo].[Users] (
    [Id]           UNIQUEIDENTIFIER NOT NULL,
    [FirstName]    NVARCHAR (20)    NOT NULL,
    [MiddleName]   NVARCHAR (20)    NULL,
    [LastName]     NVARCHAR (30)    NOT NULL,
    [Email]        NVARCHAR (60)    NOT NULL,
    [Password]     NVARCHAR (MAX)   NOT NULL,
    [DateOfBirth]  DATETIME2 (7)    NOT NULL,
    [HomeNumber]   NVARCHAR (15)    NOT NULL,
    [OfficeNumber] NVARCHAR (15)    NULL,
    [DetailsJson]  NVARCHAR (MAX)   NOT NULL,
    [IsActive]     BIT              DEFAULT (CONVERT([bit],(1))) NOT NULL,
    [CreatedOn]    DATETIME2 (7)    NOT NULL,
    [ModifiedOn]   DATETIME2 (7)    NULL,
    [ModifiedBy]   UNIQUEIDENTIFIER NULL,
    CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
CREATE NONCLUSTERED INDEX [IX_Users_FirstName_MiddleName_LastName]
    ON [dbo].[Users]([FirstName] ASC, [MiddleName] ASC, [LastName] ASC)
    INCLUDE([DateOfBirth]);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_Users_Email]
    ON [dbo].[Users]([Email] ASC);

