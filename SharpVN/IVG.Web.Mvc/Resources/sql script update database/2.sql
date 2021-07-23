create view DanhSachCaseRequest
as
select 
	ca.CaseID as RequestId,
	ca.Code as MaPhieu, 
	ca.ReferenceCode as MaThamChieu,
	cus.Name as TenKhachHang,
	cus.Address as DiaChi,
	cus.Mainphone as SoDienThoai,
	cus.MobilePhone as SoDienThoaiKhac,
	svc.Name as TenTrungTam,
	tech.Name as TenKTV,
	m.Code as MaSanPham,
	ca.SerialNo as SoSerial,
	def.Code as MaLoi,
	ca.Description as DienGiaiLoi,
	ca.WarrantyStatus as TrangThaiSuaChua,
	ca.RepairType as LoaiSuaChuaId,
	'' as CachSuaChua,
	'' as NgayDangKySuaChua,
	ca.ReceivedBy as NguoiTiepNhan,
	ca.ReceivedDate as NgayTiepNhan,
	'' as CallCenterGhiChu,
	'' as ASCGhiChu,
	'' as ThangTT,
	'' as NgayKTVKiemTra,
	'' as ASCHoanThanhOn,
	'' as ASCHoanThanhBoi
from tbl_CasesRequest ca
left join tbl_Customers cus on ca.CustomerID =cus.CustomerID
left join tbl_ServiceCenters svc on ca.ServiceCenterID = svc.ServiceCenterID
left join tbl_TechnicalStaffs tech on ca.TechnicalStaffID=tech.TechnicalStaffID
left join tbl_Model m on ca.ModelID = m.ModelID
left join tbl_DefectCodes def on ca.DefectID = def.DefectCodeID
