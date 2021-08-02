alter table tbl_cases add  CancelReasonId uniqueidentifier
alter table tbl_CasesRequest add  CancelReasonId uniqueidentifier
alter table tbl_cases add CaseRequestId uniqueidentifier
alter table tbl_casesrequest add RequestCode nvarchar(100)
alter table tbl_cases add RequestCode nvarchar(100)

create view AdminUsersView
as
select
ID, u.UserName, u.DisplayName, u.Password, 
u.Address, u.Email, u.Phone, u.MobilePhone, 
u.Description, 
u.Active, 
case when u.Active=0 then N'Không hoạt động' else N'Hoạt động' end as ActiveName,
u.LastLogOn, u.CreatedBy, 
u.CreatedOn, u.ModifiedBy, u.ModifiedOn, u.Owner, 
u.ServicecenterID,
svc.Name as AscName,
u.IsAdmin, u.IsASC, u.Lang, 
u.SessionID, u.LoginError, u.FailedNumber, 
u.EmailCredential, u.EmailPassWord, u.HostMail, 
u.SendMail, u.LastLock, u.LoginCount, u.Token, 
u.EWarrantyRoleId

from tbl_Users u
left join tbl_ServiceCenters svc on u.ServicecenterID = svc.ServiceCenterID