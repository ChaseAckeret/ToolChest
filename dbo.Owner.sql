CREATE TABLE [dbo].[Owner] (
    [OwnerId]     INT NOT NULL IDENTITY,
    [UserId]      NVARCHAR (128)     NOT NULL,
    [CreatedUtc]  DATETIMEOFFSET (7) NOT NULL,
    [ModifiedUtc] DATETIMEOFFSET (7) NOT NULL,
    CONSTRAINT [PK_dbo.Owner] PRIMARY KEY CLUSTERED ([UserId] ASC),
    CONSTRAINT [FK_dbo.Owner_dbo.ApplicationUser_UserId] FOREIGN KEY ([UserId]) REFERENCES [dbo].[ApplicationUser] ([Id])
);


GO
CREATE NONCLUSTERED INDEX [IX_UserId]
    ON [dbo].[Owner]([UserId] ASC);

