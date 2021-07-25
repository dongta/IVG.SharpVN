USE [SharpWarranty]
GO

/****** Object:  View [dbo].[AllJobAndRequest]    Script Date: 7/25/2021 8:47:41 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



CREATE view [dbo].[AllJobAndRequest]
as
select 
	a.*,

	cus.Name as CustomerName      	   ,
	m.Code as MaSanPham,
	cus.Mainphone as CustomerPhone     	   ,
	cus.MobilePhone as CustomerOtherPhone	   ,
	cus.Email as CustomerEmail     	   ,
	cus.Address as CustomerAddress  ,
	svc.Name as ASCName,
	tech.Name as TechnicianName, 
	def.Code as DefectCode,
	o.Text as RepairStatusName
	
from StaffViewJob a
left join tbl_Customers cus on a.customerid = cus.CustomerID
left join tbl_Model m on a.ModelID = m.ModelID
left join tbl_TechnicalStaffs tech on a.TechnicalStaffID= tech.TechnicalStaffID
left join tbl_ServiceCenters svc on a.ServiceCenterID = svc.ServiceCenterID
left join tbl_DefectCodes def on a.DefectCodeID =def.DefectCodeID
left join (select Value,Text from tbl_OptionSetValues where OptionSetID=10) o on a.RepairStatus = o.Value
--select * from AllJobAndRequest
GO

