CREATE TABLE [dbo].[Anime] (
    [ID]       INT            IDENTITY (1, 1) NOT NULL,
    [Name]     NVARCHAR (200) NOT NULL,
    [Category] INT            NOT NULL,
    [Rating]   INT            NOT NULL,
    CONSTRAINT [PK_Anime] PRIMARY KEY CLUSTERED ([ID] ASC),
    CONSTRAINT [FK_Anime_Category] FOREIGN KEY ([Category]) REFERENCES [dbo].[Category] ([ID]) ON DELETE CASCADE
);





