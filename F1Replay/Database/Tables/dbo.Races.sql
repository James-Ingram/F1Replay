CREATE TABLE [dbo].[races]
(
	[raceId]    INT DEFAULT (NULL) NOT NULL,
    [year]      INT  DEFAULT ('0') NOT NULL,
    [round]     INT  DEFAULT ('0') NOT NULL,
    [circuitId] INT  DEFAULT ('0') NOT NULL,
    [name]      VARCHAR (255) NOT NULL,
    [data]      VARCHAR (255) DEFAULT ('00/00/0000') NOT NULL,
    [time]      VARCHAR (255) DEFAULT (NULL) NULL,
    [url]       VARCHAR (255) DEFAULT (NULL) NULL,
    PRIMARY KEY ([raceId]),
)
