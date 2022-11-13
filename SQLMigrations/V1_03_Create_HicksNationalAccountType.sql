/*
*************************************
Hicks National Account Type
Description: Stores Account Type metadata
Created On: 11/10/2022
Created By: Connor Hicks
*************************************
*/
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[ref].[HicksNationalAccountType]') AND type = N'U')
BEGIN
CREATE TABLE [ref].[HicksNationalAccountType](
	[Id] [int] NOT NULL,
	[IsInvestment] [bit] NOT NULL,
	[AccountType] [nvarchar](100) NOT NULL,
	[WithdrawalLimit] [int] NULL,
 CONSTRAINT [PK_HicksNationalAccountType] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

END

BEGIN 
DELETE FROM [ref].[HicksNationalAccountType]
INSERT INTO [ref].[HicksNationalAccountType] VALUES (1,0,'Checking', NULL)
INSERT INTO [ref].[HicksNationalAccountType] VALUES (2,1,'Individual', 500)
INSERT INTO [ref].[HicksNationalAccountType] VALUES (3,1,'Corporate', NULL)
END