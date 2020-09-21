using idn.AnPhu.Biz.Extensions;
using idn.AnPhu.Biz.Models;
using idn.AnPhu.Biz.Persistance.SqlServer;
using idn.AnPhu.Biz.Services;
using idn.AnPhu.Utils;
using idn.AnPhu.Website.Controllers;
using idn.AnPhu.Website.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace idn.AnPhu.Website.Areas.Auth.Controllers
{
    public class ManufacterController : AdministratorController
    {
        // GET: Auth/Manufacter
        private ManufacterManager ManufacterManager
        {
            get { return ServiceFactory.ManufacterManager; }
        }
        public ActionResult Index()
        {
            var list = ServiceFactory.ManufacterManager.GetAll(Culture);
            return View(list);
        }

        [HttpGet]
        public ActionResult Create()
        {
            Manufacters data = new Manufacters();
            var categories = ServiceFactory.ManufacterManager.GetAll(Culture);
            ViewBag.Categories = categories;
            return View("Create", data);
        }

        [HttpPost, ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Manufacters model)
        {
            var resultEntry = new JsonResultEntry() { Success = false };
            if (model != null)
            {
                var createBy = "";
                if (UserState != null && !CUtils.IsNullOrEmpty(UserState.UserName))
                {
                    createBy = CUtils.StrTrim(UserState.UserName);
                }
                model.CreateBy = createBy;
                model.ManufactShortName = model.ManufactName.ToUrlSegment(250).ToLower();
                model.Culture = Culture;

                ServiceFactory.ManufacterManager.Add(model);
                resultEntry.Success = true;
                resultEntry.AddMessage("Tạo mới nhà sản xuất thành công!");
                resultEntry.RedirectUrl = Url.Action("Create", "Manufacter", new { area = "Auth" });
            }
            else
            {
                resultEntry.Detail = "dư lieu null";
            }
            return Json(resultEntry);
        }

        [HttpGet]
        public ActionResult Update(int manufactId)
        {
            if (CUtils.IsNullOrEmpty(manufactId))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var newsCate = ManufacterManager.Get(new Manufacters() { ManufactId = manufactId });

            if (newsCate != null)
            {
                var categories = ServiceFactory.ManufacterManager.GetAll(Culture);
                ViewBag.Categories = categories;
                ViewBag.IsEdit = true;
                return View(newsCate);
            }
            else
            {
                return HttpNotFound();
            }
        }

        [HttpPost, ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Update(Manufacters model)
        {
            var resultEntry = new JsonResultEntry() { Success = false };
            var exitsData = "";
            if (model != null && !CUtils.IsNullOrEmpty(model.ManufactId))
            {
                var News = ManufacterManager.Get(new Manufacters() { ManufactId = model.ManufactId });
                if (News != null)
                {

                    model.ManufactShortName = model.ManufactName.ToUrlSegment(250).ToLower();

                    ManufacterManager.Update(model, News);
                    resultEntry.Success = true;
                    resultEntry.AddMessage("Cập nhật thông tin thành công!");
                    resultEntry.RedirectUrl = Url.Action("Index", "Manufacter", new { area = "Auth" });
                }
                else
                {
                    resultEntry.Success = true;
                    exitsData = "Mã nhà sản xuất '" + model.ManufactId + "' không có trong hệ thống!";
                }
            }
            else
            {
                resultEntry.Success = true;
                exitsData = "Mã nhà sản xuất trống!";
            }
            resultEntry.AddMessage(exitsData);
            return Json(resultEntry);
        }

        [HttpPost, ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int manufactId)
        {
            var resultEntry = new JsonResultEntry() { Success = false };
            var objNews = new Manufacters() { ManufactId = manufactId };
            ManufacterManager.Remove(objNews);
            resultEntry.Success = true;
            resultEntry.AddMessage("Xóa nhà sản xuất thành công!");
            return Json(resultEntry);
        }
    }
}