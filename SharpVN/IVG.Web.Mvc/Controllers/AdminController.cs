using IVG.Web.Mvc.EF;
using IVG.Web.Mvc.Models;
using System;
using System.Linq;
using System.Web.Mvc;

namespace IVG.Web.Mvc.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {

        AppDbContext db = new AppDbContext();
        public ActionResult Users()
        {
            return View();
        }
        public ActionResult AddUser(Guid? id)
        {
            CreateUserOutputDto model = new CreateUserOutputDto();
            if (id.HasValue)
            {
                model.AdminUserView = db.AdminUsersViews.FirstOrDefault(a => a.ID == id);
                var roleId = db.tbl_UserRoles.Where(a => a.UserID == id).Select(a=>a.RoleID).ToList();
                model.RoleNames = db.tbl_Roles.Where(a => roleId.Contains(a.ID)).Select(a => a.Role).ToList();
            }
            model.ASCCombobox = db.tbl_ServiceCenters.Where(a => a.Status == 1).OrderBy(a => a.Name)
                .Select(a => new DropdownItemDto
                {
                    Id = a.ServiceCenterID.ToString(),
                    DisplayName = a.Name
                }).ToList();
            return View(model);
        }
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

        // GET: Admin/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Admin/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Admin/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Admin/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
