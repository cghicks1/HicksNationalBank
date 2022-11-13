/*
*************************************
Create Hicks National Account Owner Linkage
Description: Foreign keys into owner and 
account tables to keep track of owners with multiple accounts
Created On: 11/11/2022
Created By: Connor Hicks
*************************************
*/
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[account].[HicksNationalAccountOwnerLinkage]') AND type = N'U')
BEGIN
CREATE TABLE [account].[HicksNationalAccountOwnerLinkage]  (
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[OwnerId] [int] ,
	[AccountId] [int],
	CONSTRAINT [PK_HicksNationalAccountOwnerLinkage] PRIMARY KEY CLUSTERED 
	(
		[Id] ASC
	)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
	) ON [PRIMARY]

		ALTER TABLE [account].[HicksNationalAccountOwnerLinkage] WITH NOCHECK ADD  CONSTRAINT [FK_Account_Linkage] FOREIGN KEY([AccountId])
REFERENCES [account].[HicksNationalAccount] ([Id])
	ALTER TABLE [account].[HicksNationalAccountOwnerLinkage] WITH NOCHECK ADD  CONSTRAINT [FK_Owner_Linkage] FOREIGN KEY([OwnerId])
REFERENCES [account].[HicksNationalAccountOwner] ([Id])


	END

