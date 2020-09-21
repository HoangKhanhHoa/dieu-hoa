using Client.Core.Data.Entities.Paging;
using idn.AnPhu.Biz.Extensions;
using idn.AnPhu.Biz.Models;
using idn.AnPhu.Biz.Services;
using idn.AnPhu.Utils;
using idn.AnPhu.Website.Controllers;
using idn.AnPhu.Website.Helpers;
using idn.AnPhu.Website.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace idn.AnPhu.Website.Areas.Auth.Controllers
{
    public class LocationDiscountController : AdministratorController
    {
        private LocationDiscountManager LocationDiscountManager
        {
            get { return ServiceFactory.LocationDiscountManager; }
        }
        // GET: Auth/LocationDiscount
        public ActionResult Index()
        {

            var list = ServiceFactory.LocationDiscountManager.GetAll(Culture);

            return View(list);
        }

        [HttpGet]
        public ActionResult Create()
        {
            LocationDiscount data = new LocationDiscount();
            var categories = ServiceFactory.LocationDiscountManager.GetAll(Culture);
            ViewBag.Categories = categories;
            return View("Create", data);
        }
        [HttpPost, ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Create(LocationDiscount model)
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
                model.LocationDiscountValue = model.LocationDiscountName.ToUrlSegment(250).ToLower();
                model.Culture = Culture;

                ServiceFactory.LocationDiscountManager.Add(model);
                resultEntry.Success = true;
                resultEntry.AddMessage("Tạo mới danh mục thành công!");
                resultEntry.RedirectUrl = Url.Action("Create", "LocationDiscount", new { area = "Auth" });
            }
            else
            {
                resultEntry.Detail = "dư lieu null";
            }
            return Json(resultEntry);
        }

        [HttpGet]
        public ActionResult Update(int locationDiscountId)
        {
            if (CUtils.IsNullOrEmpty(locationDiscountId))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var newsCate = LocationDiscountManager.Get(new LocationDiscount() { LocationDiscountId = locationDiscountId });

            if (newsCate != null)
            {
                var categories = ServiceFactory.LocationDiscountManager.GetAll(Culture);
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
        public ActionResult Update(LocationDiscount model)
        {
            var resultEntry = new JsonResultEntry() { Success = false };
            var exitsData = "";
            if (model != null && !CUtils.IsNullOrEmpty(model.LocationDiscountId))
            {
                var News = LocationDiscountManager.Get(new LocationDiscount() { LocationDiscountId = model.LocationDiscountId });
                if (News != null)
                {
                   
                    model.LocationDiscountValue = model.LocationDiscountName.ToUrlSegment(250).ToLower();

                    LocationDiscountManager.Update(model, News);
                    resultEntry.Success = true;
                    resultEntry.AddMessage("Cập nhật thông tin thành công!");
                    resultEntry.RedirectUrl = Url.Action("Index", "LocationDiscount", new { area = "Auth" });
                }
                else
                {
                    resultEntry.Success = true;
                    exitsData = "Mã tỉnh '" + model.LocationDiscountId + "' không có trong hệ thống!";
                }
            }
            else
            {
                resultEntry.Success = true;
                exitsData = "Mã tỉnh trống!";
            }
            resultEntry.AddMessage(exitsData);
            return Json(resultEntry);
        }
    }
}