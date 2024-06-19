CREATE TABLE [dbo].[ErrorLogs] (
    [Id]             UNIQUEIDENTIFIER NOT NULL,
    [Message]        NVARCHAR (MAX)   NOT NULL,
    [StackTrace]     NVARCHAR (MAX)   NULL,
    [InnerException] NVARCHAR (MAX)   NULL,
    [CreatedOn]      DATETIME2 (7)    NOT NULL,
    CONSTRAINT [PK_ErrorLogs] PRIMARY KEY CLUSTERED ([Id] ASC)
);

