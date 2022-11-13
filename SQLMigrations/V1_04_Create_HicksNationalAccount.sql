/*
*************************************
Create Hicks National Account Table
Description: Holds Account Metadata and totals
Created On: 11/9/2022
Created By: Connor Hicks
*************************************
*/
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[account].[HicksNationalAccount]') AND type = N'U')
BEGIN
CREATE TABLE [account].[HicksNationalAccount]  (
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[AccountNumber] [bigint] NULL,
	[AccountTypeId] [int] NULL,
	[Balance] [int] NOT NULL,
	[CreatedOn] [datetime2](2) NOT NULL, 
	[ModifiedOn] [datetime2](2) NULL,
	CONSTRAINT [PK_HicksNationalAccount] PRIMARY KEY CLUSTERED 
	(
		[Id] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
	) ON [PRIMARY]

	ALTER TABLE [account].[HicksNationalAccount] WITH NOCHECK ADD  CONSTRAINT [FK_Account_AccountType] FOREIGN KEY([AccountTypeId])
REFERENCES [ref].[HicksNationalAccountType] ([Id])

	END