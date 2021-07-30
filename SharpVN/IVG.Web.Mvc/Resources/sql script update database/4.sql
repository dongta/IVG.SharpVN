ALTER view [dbo].[AllJobAndRequest]
as
select 
a.CaseID, a.CRMID, a.CaseCode, a.ReferenceCode, a.ServiceCenterID, a.TechnicalStaffID, a.
CustomerID, a.DealerID, a.ReimburseID, a.ModelID, a.ModelUsedID, a.SupplierID, a.SerialNo,
BoughtDate, a.EndDate, a.PlaceOfBuy, a.WCardNo, a.MadeDate, a.WarrantyTime, a.WarrantyStatus, a.WarrantyType,
ConditionID, a.DefectCodeID, a.PositionCodeID, a.RepairCodeID, a.RepairType, a.ReceivedDate, a.ScheduleStart,
ScheduleEnd, a.StartDate, a.CompleteDate, a.ApprovalDate, a.Repeat, a.ReceivedBy, a.RepairStatus, a.MaplocationID, a.
TripCost, a.LabourCost, a.ExtPartCost, a.TransCost, a.ReturnCost, a.PartPrice, a.ExchangeModelCost, a.CustomerSign, a.
TicketID, a.Description, a.Description1, a.CreatedBy, a.CreatedOn, a.ModifiedBy, a.ModifiedOn, a.SyncStatus, a.RMonth, a.
RYear, a.Km, a.CompletedSVNOn, a.CompletedSVNBy, a.TechnicalCheckedOn, a.
CompletedASCOn, a.CompletedASCBy, a.CreatedCustomerOn, a.CreatedCustomerBy, a.IsJob, a.CancelReasonId,

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


