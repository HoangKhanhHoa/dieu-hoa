using idn.AnPhu.Biz.Extensions;
using idn.AnPhu.Biz.Models;
using idn.AnPhu.Biz.Services;
using idn.AnPhu.Utils;
using idn.AnPhu.Website.Controllers;
using idn.AnPhu.Website.Helpers;
using idn.AnPhu.Website.Models;
using idn.AnPhu.Website.State;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace idn.AnPhu.Website.Areas.Auth.Controllers
{
    public class LocationController : AdministratorController
    {
        // GET: Auth/Location
        private LocationManager LocationManager
        {
            get { return ServiceFactory.LocationManager; }
        }
        public ActionResult Index(int locationDiscountId)
        {
            LocationDiscount discount = ServiceFactory.LocationDiscountManager.Get(new LocationDiscount { LocationDiscountId = locationDiscountId });
            List<Location> listLocation = new List<Location>();
            listLocation = ServiceFactory.LocationManager.GetAllByParentId(locationDiscountId);
            discount.Location = listLocation;
            return View(discount);
        }

        [HttpGet]
        public ActionResult Create(int locationDiscountId)
        {
            Location data = new Location();
            data.LocationDiscountId = locationDiscountId;

            return View("Create", data);
        }

        [HttpPost, ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Location model)
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
                model.LocationValue = model.LocationName.ToUrlSegment(250).ToLower();
                model.Culture = Culture;

                ServiceFactory.LocationManager.Add(model);
                resultEntry.Success = true;
                resultEntry.AddMessage("Tạo mới quận/huyện thành công!");
                resultEntry.RedirectUrl = Url.Action("Create", "Location", new { area = "Auth", locationDiscountId = model.LocationDiscountId});
            }
            else
            {
                resultEntry.Detail = "dư lieu null";
            }
            return Json(resultEntry);
        }

        [HttpGet]
        public ActionResult Update(int locationId)
        {
            if (CUtils.IsNullOrEmpty(locationId))
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var newsCate = LocationManager.Get(new Location() { LocationId = locationId });

            if (newsCate != null)
            {
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
        public ActionResult Update(Location model)
        {
            var resultEntry = new JsonResultEntry() { Success = false };
            var exitsData = "";
            if (model != null && !CUtils.IsNullOrEmpty(model.LocationId))
            {
                var News = LocationManager.Get(new Location() { LocationId = model.LocationId });
                if (News != null)
                {
                    var updateBy = "";
                    if (UserState != null && !CUtils.IsNullOrEmpty(UserState.UserName))
                    {
                        updateBy = CUtils.StrTrim(UserState.UserName);
                    }
                    model.LocationValue = model.LocationName.ToUrlSegment(250).ToLower();

                    LocationManager.Update(model, News);
                    resultEntry.Success = true;
                    resultEntry.AddMessage("Cập nhật quận/huyện thành công!");
                    resultEntry.RedirectUrl = Url.Action("Index", "Location", new { locationDiscountId = model.LocationDiscountId });
                }
                else
                {
                    resultEntry.Success = true;
                    exitsData = "Mã quận/huyện '" + model.LocationId + "' không có trong hệ thống!";
                }
            }
            else
            {
                resultEntry.Success = true;
                exitsData = "Mã quận/huyện trống!";
            }
            resultEntry.AddMessage(exitsData);
            return Json(resultEntry);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int locationId)
        {
            var resultEntry = new JsonResultEntry() { Success = false };
            var objNews = new Location() { LocationId = locationId };
            LocationManager.Remove(objNews);
            resultEntry.Success = true;
            resultEntry.AddMessage("Xóa quận/huyện thành công!");
            return Json(resultEntry);
        }
    }
}