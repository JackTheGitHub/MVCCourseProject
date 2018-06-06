﻿CREATE TABLE [dbo].[Category] (
    [ID]   INT            IDENTITY (1, 1) NOT NULL,
    [Name] NVARCHAR (200) NOT NULL,
    CONSTRAINT [PK_Categories] PRIMARY KEY CLUSTERED ([ID] ASC)
);
