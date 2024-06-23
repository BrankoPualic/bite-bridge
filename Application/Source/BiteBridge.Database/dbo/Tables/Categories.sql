CREATE TABLE [dbo].[Categories] (
    [Id]          INT            IDENTITY (1, 1) NOT NULL,
    [ParentId]    INT            NULL,
    [Name]        NVARCHAR (30)  NOT NULL,
    [Description] NVARCHAR (100) NOT NULL,
    CONSTRAINT [PK_Categories] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_Categories_Categories_ParentId] FOREIGN KEY ([ParentId]) REFERENCES [dbo].[Categories] ([Id])
);


GO
CREATE NONCLUSTERED INDEX [IX_Categories_ParentId]
    ON [dbo].[Categories]([ParentId] ASC);


GO
CREATE UNIQUE NONCLUSTERED INDEX [IX_Categories_Name]
    ON [dbo].[Categories]([Name] ASC);

