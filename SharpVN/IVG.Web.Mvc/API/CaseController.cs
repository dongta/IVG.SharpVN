using AutoMapper;
using IVG.Web.Mvc.API.Models;
using IVG.Web.Mvc.Common;
using IVG.Web.Mvc.EF;
using IVG.Web.Mvc.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace IVG.Web.Mvc.API
{
    public class CaseController : ApiController
    {
        AppDbContext db = new AppDbContext();


        [HttpPost]
        public object GetAll(GetRequestDto input)
        {
            try
            {
                //var userId = (HttpContext.Current.Session["user"] as tbl_Users)?.ID;

                var query = db.AllJobAndRequests.AsQueryable();
                var totalCount = query.Count();
                if (!string.IsNullOrEmpty(input?.FilterText))
                {
                    query = query.Where(a => a.CaseCode.Contains(input.FilterText)
                                          || a.SerialNo.Contains(input.FilterText)
                                          || a.ReferenceCode.Contains(input.FilterText)
                                          || a.CustomerName.Contains(input.FilterText)
                                          || a.CustomerPhone.Contains(input.FilterText)
                                          || a.CustomerOtherPhone.Contains(input.FilterText)
                                       );
                }
                if (!string.IsNullOrEmpty(input?.Ma))
                {
                    query = query.Where(a => a.CaseCode.Contains(input.Ma));
                }
                if (!string.IsNullOrEmpty(input?.MaThamChieu))
                {
                    query = query.Where(a => a.ReferenceCode.Contains(input.MaThamChieu));
                }
                if (!string.IsNullOrEmpty(input?.SanPham))
                {
                    query = query.Where(a => a.MaSanPham.Contains(input.SanPham));
                }
                if (!string.IsNullOrEmpty(input?.SoDienThoai))
                {
                    query = query.Where(a => a.CustomerPhone.Contains(input.SoDienThoai) || a.CustomerOtherPhone.Contains(input.SoDienThoai));
                }
                if (!string.IsNullOrEmpty(input?.SoSerial))
                {
                    query = query.Where(a => a.SerialNo.Contains(input.SoSerial));
                }
                if (!string.IsNullOrEmpty(input?.TenKhachHang))
                {
                    query = query.Where(a => a.CustomerName.Contains(input.TenKhachHang));
                }
                if (input.TrangThaiSuachua.HasValue)
                {
                    query = query.Where(a => a.RepairStatus == input.TrangThaiSuachua);
                }
                if (input.NgayTaoTu.HasValue)
                {
                    query = query.Where(a => a.CreatedOn.Value >= input.NgayTaoTu);
                }
                if (input.NgayTaoToi.HasValue)
                {
                    query = query.Where(a => a.CreatedOn.Value <= input.NgayTaoToi);
                }
                if (input.NgayTiepNhanTu.HasValue)
                {
                    query = query.Where(a => a.ModifiedOn.Value >= input.NgayTiepNhanTu);
                }
                if (input.NgayTiepNhanToi.HasValue)
                {
                    query = query.Where(a => a.ModifiedOn.Value <= input.NgayTiepNhanToi);
                }

                var filterCount = query.Count();
                query = query.OrderByDescending(a => a.CreatedOn);
                query = query.Skip(input.Start).Take(input.Length);
                var data = query.ToList();
                return new PagedResultDto(draw: input.Draw, totalRecords: totalCount, filteredRecords: filterCount, data: data);
            }
            catch (Exception ex)
            {
                NLogManager.Logger.Error(ex);
                throw;
            }
        }

        [HttpPost]
        public object AssignJob(AssignJobDto input)
        {
            var userId = (HttpContext.Current.Session["user"] as tbl_Users)?.ID;
            //var ServiceCenterCode = db.tbl_ServiceCenters.FirstOrDefault(a => a.ServiceCenterID == input.ServiceCenterId)?.Code;
            var auto = GetCaseCode(input.ServiceCenterId);
            var code = string.Format("JB{0}{1:yyMM}{2:00000}", auto[0], DateTime.Now, int.Parse(auto[1]));
            var job = db.tbl_Cases.FirstOrDefault(a => a.CaseID == input.Id);
            tbl_CasesRequest request = db.tbl_CasesRequest.FirstOrDefault(a => a.CaseID == input.Id);
            
            if (job != null)
            {
                job.ServiceCenterID = input.ServiceCenterId;
                job.CaseCode = code;
                job.RepairStatus = (int)AppEnum.RepairStatus.DaChuyenThanhJobOrChoASCXacNhan;
                job.CancelReasonId = null;
                job.TechnicalStaffID = null;
                db.SaveChanges();
            }
            else
            {
                //Tạo case từ request.
                job = new tbl_Cases
                {
                    CaseID = request.CaseID,
                    CaseRequestId = request.CaseID,
                    CaseCode = code,
                    ServiceCenterID = input.ServiceCenterId,
                    CustomerID = request.CustomerID,
                    ModelID = (Guid)request.ModelID,
                    SerialNo = request.SerialNo,
                    EndDate = request.EndDate,
                    MadeDate = request.MadeDate,
                    WarrantyTime = request.WarrantyTime,
                    WarrantyStatus = request.WarrantyStatus,
                    WarrantyType = request.WarrantyType,
                    DefectCodeID = request.DefectID,
                    RepairType = request.RepairType,
                    ReceivedDate = request.ReceivedDate,
                    ReceivedBy = request.ReceivedBy,
                    RepairStatus = (int)AppEnum.RepairStatus.DaChuyenThanhJobOrChoASCXacNhan,
                    Description = request.Description,
                    Description1 = request.SVNDescript,
                    CreatedBy = request.CreatedBy,
                    CreatedOn = DateTime.Now,
                    ModifiedBy = userId,
                    ModifiedOn = DateTime.Now,
                    

                };
                db.tbl_Cases.Add(job);
                db.SaveChanges();
            }
            //update request
            request.ServiceCenterID = input.ServiceCenterId;
            request.Status = (int)AppEnum.TrangThaiPhieuYeuCau.DaChuyenThanhJob;
            request.ConvertBy = userId;
            request.ConvertOn = DateTime.Now;
            request.Code = job.CaseCode;
            request.CancelReasonId = null;
            db.SaveChanges();
            return job;
        }

        [HttpPost]
        public object CancelJob(CancelJobDto input)
        {
            var userId = (HttpContext.Current.Session["user"] as tbl_Users)?.ID;
            var job = db.tbl_Cases.FirstOrDefault(a => a.CaseID == input.Id);
            if (job != null)
            {
                job.RepairStatus = (int)AppEnum.RepairStatus.DaHuy;
                job.CancelReasonId = input.CancelReasonId;
                job.ModifiedBy = userId;
                job.ModifiedOn = DateTime.Now;
                db.SaveChanges();
            }
            var request = db.tbl_CasesRequest.FirstOrDefault(a => a.CaseID == input.Id);
            if (request != null)
            {
                request.Status = (int)AppEnum.RepairStatus.DaHuy;
                request.CancelReasonId = input.CancelReasonId;
                request.ModifiedBy = userId;
                request.ModifiedOn = DateTime.Now;
                db.SaveChanges();
            }
            return true;
        }

        private string[] GetCaseCode(Guid ServiceCenterId)
        {
            var y = DateTime.Now.Year;
            var m = DateTime.Now.Month;
            List<SqlParameter> objParas = new List<SqlParameter>();
            objParas.Add(new SqlParameter("@ServiceCenterID", ServiceCenterId));
            objParas.Add(new SqlParameter("@ObjectCode", 4));
            objParas.Add(new SqlParameter("@Year", y));
            objParas.Add(new SqlParameter("@Month", m));
            var ServiceCenterCode = new SqlParameter("@ServiceCenterCode", "");
            ServiceCenterCode.Direction = ParameterDirection.Output;
            ServiceCenterCode.Size = 100;
            ServiceCenterCode.DbType = DbType.String;
            var Number = new SqlParameter("@Number", 0);
            Number.Direction = ParameterDirection.Output;
            ServiceCenterCode.DbType = DbType.Int32;
            objParas.Add(ServiceCenterCode);
            objParas.Add(Number);

            //var result = db.ExcuteStoreProcdureOrFunction<object>("p_AutoNumber_Generate @ServiceCenterID, @ObjectCode, @Year, @Month ", objParas.ToArray());
            var result = db.Database.ExecuteSqlCommand("exec p_AutoNumber_Generate @ServiceCenterID, @ObjectCode, @Year, @Month,@ServiceCenterCode =@ServiceCenterCode OUTPUT,@Number =@Number OUTPUT", objParas.ToArray());
            return  new string[] { ServiceCenterCode.Value.ToString(), Number.Value.ToString() };
        }
    }
}
