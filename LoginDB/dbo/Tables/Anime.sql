CREATE TABLE [dbo].[Anime] (
    [ID]   INT            IDENTITY (1, 1) NOT NULL,
    [Name] NVARCHAR (200) NOT NULL,
    CONSTRAINT [PK_Anime] PRIMARY KEY CLUSTERED ([ID] ASC)
);

