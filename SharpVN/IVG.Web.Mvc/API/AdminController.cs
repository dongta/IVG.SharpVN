using IVG.Web.Mvc.API.Models;
using IVG.Web.Mvc.EF;
using System;
using System.Linq;
using System.Web;
using System.Web.Http;
using static IVG.Web.Mvc.Common.Helper;

namespace IVG.Web.Mvc.API
{
    public class AdminController : ApiController
    {
        AppDbContext db = new AppDbContext();


        [HttpPost]
        public object GetAll(BasicFilter input)
        {
            var query = db.AdminUsersViews.AsQueryable();
            var totalCount = query.Count();
            if (!string.IsNullOrEmpty(input.FilterText))
            {
                query = query.Where(a => a.UserName.Contains(input.FilterText)
                            || a.DisplayName.Contains(input.FilterText)
                            || a.Email.Contains(input.FilterText)
                            || a.Phone.Contains(input.FilterText)
                            || a.MobilePhone.Contains(input.FilterText)
                            || a.Description.Contains(input.FilterText)
                            || a.Address.Contains(input.FilterText)
                            || a.AscName.Contains(input.FilterText)
                            || a.ActiveName.Contains(input.FilterText)
                            );
            }

            var filterCount = query.Count();
            query = query.OrderByDescending(a => a.CreatedOn);
            query = query.Skip(input.Start).Take(input.Length);
            var data = query.ToList();
            return new PagedResultDto(draw: input.Draw, totalRecords: totalCount, filteredRecords: filterCount, data: data);
        }

        [HttpPost]
        public object CreateUser(CreateOrEditUserInput input)
        {
            var userId = (HttpContext.Current.Session["user"] as tbl_Users)?.ID;

            if (db.tbl_Users.Any(a=>a.UserName==input.UserName && a.ID != input.ID))
            {
                return new
                {
                    Status = false,
                    Message = $"Tên đăng nhập {input.UserName} đã tồn tại."
                };
            }
            tbl_Users u = new tbl_Users();

            if (input.ID == Guid.Empty)
            {
                var password = VerifyMD5.GetMd5Hash("123456");
                u = new tbl_Users
                {
                    UserName = input.UserName,
                    Password = password,
                    DisplayName = input.DisplayName,
                    Address = input.Address,
                    Email = input.Email,
                    Phone = input.Phone,
                    MobilePhone = input.MobilePhone,
                    Description = input.Description,
                    ServicecenterID = input.ServicecenterID,
                    Active = input.Active,
                    ID = Guid.NewGuid(),
                    CreatedBy = userId,
                    ModifiedBy = userId,
                    CreatedOn = DateTime.Now,
                    ModifiedOn = DateTime.Now
                };
                db.tbl_Users.Add(u);
                db.SaveChanges();
            }
            else
            {
                u = db.tbl_Users.FirstOrDefault(a => a.ID == input.ID);
                u.UserName = input.UserName;
                u.DisplayName = input.DisplayName;
                u.Address = input.Address;
                u.Email = input.Email;
                u.Phone = input.Phone;
                u.MobilePhone = input.MobilePhone;
                u.Description = input.Description;
                u.ServicecenterID = input.ServicecenterID;
                u.Active = input.Active;
                u.ModifiedBy = userId;
                u.ModifiedOn = DateTime.Now;
                db.SaveChanges();
            }
            db.tbl_UserRoles.RemoveRange(db.tbl_UserRoles.Where(a => a.UserID == input.ID));
            db.SaveChanges();
            if (input.ListRole?.Any()==true)
            {
                foreach (var roleName in input.ListRole)
                {
                    tbl_UserRoles ur = new tbl_UserRoles();
                    ur.UserID = u.ID;
                    ur.RoleID = db.tbl_Roles.FirstOrDefault(a => a.Role == roleName).ID;
                    ur.CreatedBy = userId;
                    ur.CreatedOn = DateTime.Now;
                    ur.ModifiedBy = userId;
                    ur.ModifiedOn = DateTime.Now;
                    db.tbl_UserRoles.Add(ur);
                    db.SaveChanges();
                }
            }
            input.ID = u.ID;
            return input;
        }
    }
}
