/*
*************************************
Create Hicks National Account Owner Table
Description: Reference table that stores client metadata
Created On: 11/10/2022
Created By: Connor Hicks
*************************************
*/
USE HicksNational
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[account].[HicksNationalAccountOwner]') AND type = N'U')
BEGIN
CREATE TABLE [account].[HicksNationalAccountOwner]  (
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar] (30),
	[LastName] [nvarchar] (30),
	CONSTRAINT [PK_HicksNationalAccountOwner] PRIMARY KEY CLUSTERED 
	(
		[Id] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
	) ON [PRIMARY]
	END