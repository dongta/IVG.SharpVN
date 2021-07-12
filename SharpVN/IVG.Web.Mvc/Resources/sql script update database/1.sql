alter table [tbl_CasesRequest]
add 
	[CRMID] [uniqueidentifier] NULL,
	[Code] [nvarchar](20) NULL,
	[ReferenceCode] [nvarchar](50) NULL,
	[ServiceCenterID] [uniqueidentifier] NULL,
	[TechnicalStaffID] [uniqueidentifier] NULL,
	--[CustomerID] [uniqueidentifier] NULL,
	--[ModelID] [uniqueidentifier] NULL,
	[ModelUsedID] [uniqueidentifier] NULL,
	[SupplierID] [uniqueidentifier] NULL,
	--[SerialNo] [nvarchar](50) NULL,
	[BoughtDate] [datetime] NULL,
	[PlaceOfBuy] [nvarchar](250) NULL,
	[WCardNo] [nvarchar](50) NULL,
	[MadeDate] [datetime] NULL,
	[EndDate] [datetime] NULL,
	[WarrantyTime] [int] NULL,
	[WarrantyStatus] [int] NULL,
	[WarrantyType] [int] NULL,
	[ConditionID] [uniqueidentifier] NULL,
	[DefectID] [uniqueidentifier] NULL,
	[Description] [nvarchar](max) NULL,
	[SVNDescript] [nvarchar](max) NULL,
	--[Status] [int] NULL,
	[RepairType] [int] NULL,
	[ReceivedBy] [nvarchar](250) NULL,
	[ReceivedDate] [datetime] NULL,
	--[CreatedBy] [uniqueidentifier] NULL,
	--[CreatedOn] [datetime] NULL,
	--[ModifiedOn] [datetime] NULL,
	--[ModifiedBy] [uniqueidentifier] NULL,
	[SyncStatus] [int] NULL,
	[Repeat] [int] NULL,
	[TechnicalCheckedOn] [datetime] NULL,
	[ConvertBy] [uniqueidentifier] NULL,
	[ConvertOn] [datetime] NULL