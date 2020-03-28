USE [BookDB]
GO

/****** Object:  Table [dbo].[Orders]    Script Date: 3/28/2020 1:51:47 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Orders](
	[ID] [int] NOT NULL,
	[CustomerName] [nvarchar](50) NULL,
	[UserID] [int] Not Null,
	[AddressLine1] [nvarchar](50) NULL,
	[AddressLine2] [nvarchar](50) NULL,
	[AddressLine3] [nvarchar](50) NULL,
	[AddressType] [nvarchar](50) NULL,
	[City] [nvarchar](50) NULL,
	[Region] [nvarchar](20) NULL,
	[PostalCode] [nvarchar](15) NULL,
	[County] [nvarchar](50) NULL,
	[Country] [nvarchar](2) NULL,
	[BookID] [int] NOT NULL,
	[OrderDate] [datetime] NULL,
	[Quantity] [int] NULL,
	[BookCost] [money] NULL,
	[SalesTax] [money] NULL
	Primary key (ID)
) ON [PRIMARY]
GO


