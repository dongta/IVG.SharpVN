

/****** Object:  Table [dbo].[tbl_CancelReason]    Script Date: 7/30/2021 11:57:53 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[tbl_CancelReason](
	[Id] [uniqueidentifier] NOT NULL,
	[Reason] [nvarchar](500) NULL,
 CONSTRAINT [PK_tbl_CancelReason] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[tbl_CancelReason] ADD  CONSTRAINT [DF_tbl_CancelReason_Id]  DEFAULT (newid()) FOR [Id]
GO

